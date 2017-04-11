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
        private IGraphics _graphics;
        private ISongManager _songManager;

        private EventService _eventService;
        private NPCManager _npcManager;

        private BattleState battle;
        private GamePlayer player;
        private MapEngine map;
        private List<IEffect> _effects { get; set; } = new List<IEffect>();

        public Party Party { get; private set; }
        public EnemyParty EnemyParty { get; private set; }

        private string mapName = "Untitled";

        public WorldState(
            IDataStore dataStore, ISongManager songManager, IGraphics graphics, IBattleManager battleManager, IActorManager actorManager,
            IEnemyManager enemyManager, IIconManager iconManager, IInputManager inputManager, ITilesetManager tilesetManager, IDialogManager dialogManager)
        {
            _inputManager = inputManager;
            _dialogManager = dialogManager;
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

            //var darktroll = new Enemy { Name = "Dark Troll", Hp = 10, MaxHp = 10, SpriteName = "DarkTroll", Dexterity = 5 };
            //Common.Serializer.XmlSerialize<Enemy>(darktroll, "DarkTroll.xml");

            map = new MapEngine(dataStore, _eventService, iconManager, tilesetManager, $"../../../../Data/map/", mapName);
            player = new GamePlayer(Party.Actors[0].CharSet, inputManager, actorManager, map.Start);

            _npcManager = new NPCManager(actorManager, _dialogManager, _graphics);
            _npcManager.NPC = map.MapMeta.Layers[0].NPCs;
            _eventService = new EventService();
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
               
            _npcManager.Update(map);

            if (_inputManager.IsPressedInput((int)Input.FaceButtonDown))
            {
                map.Action(player);

                _effects.AddRange(_npcManager.CheckTalk(map, player.Pos));
            }

            player.Update(map, elapsedTime);
            if (player.step >= 3)
            {
                player.step = 0;
                //GameState = GameState.Battle;
                //battle.Load();
            }

            return true;
        }

        public void Draw()
        {
            map.Draw(player.Pos.ToVector());
            _npcManager.Draw(map);
            player.Draw(map);
            //_graphics.DrawString($"Step: {player.step} FPS: " + /*(int) (1/deltaTime) +*/ " X: " + player.x/32 + " Y: " + player.y/32, 10, 10);

            foreach (var effect in _effects)
            {
                effect.Draw();
            }
        }
    }
}