using DataStore;
using Player.Events;
using Player.Graphics;
using Player.Inputs;
using Player.Manager;
using Player.StateStack;
using System.Collections.Generic;

namespace Player
{
    public class WorldState : IState
    {
        private IInputManager _inputManager;
        private IDialogManager _dialogManager;
        private IEventService _eventService;
        private IGraphics _graphics;
        private ISongManager _songManager;

        private NPCManager _npcManager;
        private GamePlayer gamePlayer;
        private string mapName = "World";

        public MapEngine Map { get; set; }
        public Party Party { get; private set; }
        public EnemyParty EnemyParty { get; private set; }
        public List<IEffect> Effects { get; set; } = new List<IEffect>();

        public WorldState(
            IDataStore dataStore, IEventService eventService, ISongManager songManager, IGraphics graphics, IBattleManager battleManager, IActorManager actorManager,
            IEnemyManager enemyManager, IIconManager iconManager, IInputManager inputManager, ITilesetManager tilesetManager, 
            IDialogManager dialogManager)
        {
            _inputManager = inputManager;
            _dialogManager = dialogManager;
            _eventService = eventService;
            _graphics = graphics;
            _songManager = songManager;

            Party = new Party
            {
                Actors = new List<Actor> {
                    new Actor("gus", "gus") { Name = "Gus", Hp = 40, MaxHp = 58, Mp = 2, MaxMp = 8, Limit = 23 },
                    new Actor("fitz", "fitz") { Name = "Fitz", Hp = 32, MaxHp = 52, Mp = 5, MaxMp = 12, Limit = 17 },
                    new Actor("sorah", "sorah") { Name = "Sorah", Hp = 102, MaxHp = 252, Mp = 8, MaxMp = 12, Limit = 37 },
                    new Actor("sheba", "sheba") { Name = "Sheba", Hp = 44, MaxHp = 52, Mp = 8, MaxMp = 12, Limit = 5 }
                }
            };

            Map = new MapEngine(dataStore, _eventService, iconManager, tilesetManager, $"../../../../Data/Game/map/", mapName);
            gamePlayer = new GamePlayer(Party.Actors[0].CharSet, inputManager, actorManager, Map.Start);
            gamePlayer.WalkOnTile += new GamePlayer.MoveEventHandler(OnWalkOnTile);
            gamePlayer.Action += new GamePlayer.PlayerEventHandler(OnAction);

            _npcManager = new NPCManager(actorManager, _dialogManager, _graphics);
        }

        public void OnLoad()
        {
            //songManager.Play("01 - Namazu");
            _songManager.Play("Sadness Everlasting");
        }

        public void OnClose()
        {
            _songManager.Stop();
        }

        public bool Update(float elapsedTime)
        {
            if (_inputManager.IsPressedInput((int)Input.Back) || _inputManager.IsPressedKey((int)Keys.Escape))
                return false;
               
            _npcManager.Update(Map);

            gamePlayer.Update(Map, elapsedTime);
            if (gamePlayer.step >= 3)
            {
                gamePlayer.step = 0;
                //GameState = GameState.Battle;
                //battle.Load();
            }

            return true;
        }

        public void Draw()
        {
            Map.Draw(gamePlayer.Pos.ToVector());
            _npcManager.Draw(Map);
            gamePlayer.Draw(Map);
            //_graphics.DrawString($"Step: {player.step} FPS: " + /*(int) (1/deltaTime) +*/ " X: " + player.x/32 + " Y: " + player.y/32, 10, 10);

            foreach (var effect in Effects)
            {
                effect.Update();
                if (effect.Lifespan <= 0)
                {
                    Effects.Remove(effect);
                    break;
                }
                effect.Draw();
            }
        }

        public void OnWalkOnTile(MoveEventArgs e)
        {
            // activate triggers
            var ev = Map.MapMeta.GetEventId(new Vector(e.NewPos.X, e.NewPos.Y));
            if (ev == null)
                return;

            var eventId = ev.Id;
            var eventPage1 = _eventService.Get(eventId)?.Walk(true);
            var eventPage2 = _eventService.Get(eventId)?.Walk(false);

            // execute event
            if (eventPage1 != null)
                Script.Execute(eventPage1, gamePlayer, this, _graphics, _dialogManager);
            if (eventPage2 != null)
                Script.Execute(eventPage2, gamePlayer, this, _graphics, _dialogManager);
        }

        public void OnAction()
        {
            Effects.AddRange(_npcManager.CheckTalk(Map, gamePlayer.Pos));

            var p = (gamePlayer.Pos / new VectorF(Map.TileWidth, Map.TileHeight)).ToVector();

            for (var x = -1; x <= 1; x++)
                for (var y = -1; y <= 1; y++)
                {
                    if (Map.OutBounds(x, y))
                        continue;

                    // TODO check distance of tile from player
                    var e = Map.MapMeta.GetEventId(new Vector(p.X + x, p.Y + y));
                    if (e == null)
                        continue;

                    var eventId = e.Id;
                    var eventPage = _eventService.Get(eventId)?.Action();
                    if (eventPage != null)
                    {
                        Script.Execute(eventPage, gamePlayer, this, _graphics, _dialogManager);
                    }
                }
        }
    }
}