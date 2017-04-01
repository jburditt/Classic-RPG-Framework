using DataStore;
using Player.Graphics;
using Player.Inputs;
using Player.Manager;
using System.Collections.Generic;

namespace Player
{
    public class GameEngine
    {
        private IInputManager _inputManager;
        private IDialogManager _dialogManager;
        private IGraphics _graphics;
        private ISongManager _songManager;

        private NPCManager _npcManager;
        Battle battle;
        GamePlayer player;
        Map map;
        private List<IEffect> _effects { get; set; } = new List<IEffect>();

        public Party Party { get; private set; }
        public EnemyParty EnemyParty { get; private set; }
        public GameState GameState { get; private set; } = GameState.StartMenu;

        MenuItem menuItem = MenuItem.NewGame;

        public GameEngine(
            IDataStore dataStore, ISongManager songManager, IGraphics graphics, IBattleManager battleManager, IActorManager actorManager, IEnemyManager enemyManager,
            IIconManager iconManager, IInputManager inputManager, ITilesetManager tilesetManager, IDialogManager dialogManager)
        {
            _inputManager = inputManager;
            _dialogManager = dialogManager;
            _graphics = graphics;
            _songManager = songManager;

            _npcManager = new NPCManager(actorManager, _dialogManager, _graphics);
            _npcManager.NPC = dataStore.Load<List<NPC>>("world2.NPC");

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

            battle = new Battle(graphics, battleManager, actorManager, enemyManager, iconManager, inputManager, songManager, EnemyParty, Party, dialogManager);
            player = new GamePlayer(Party.Actors[0].CharSet, inputManager, actorManager);
            map = new Map(dataStore, tilesetManager, "Content/world2.tmx", true);

            //songManager.Play("01 - Namazu");
            songManager.Play("Sadness Everlasting");
        }

        public void Update(float deltaTime)
        {
            if (_inputManager.IsPressedInput((int)Input.Back) || _inputManager.IsPressedKey((int)Keys.Escape))
                GameState = GameState.Exit;

            switch (GameState)
            {
                case GameState.StartMenu:
                    if (_inputManager.JustPressedKey((int)Keys.Up))
                    {
                        menuItem--;
                        if (menuItem < MenuItem.NewGame)
                            menuItem = MenuItem.Exit;
                    }
                    if (_inputManager.JustPressedKey((int)Keys.Down))
                    {
                        menuItem++;
                        if (menuItem > MenuItem.Exit)
                            menuItem = MenuItem.NewGame;
                    }
                    if (_inputManager.IsPressedKey((int)Keys.Enter))
                    {
                        LoadWorld();
                    }
                    break;

                case GameState.Battle:
                    if (battle.Update())
                    {
                        LoadWorld();
                    }
                    break;

                case GameState.World:
                    _npcManager.Update(map);

                    if (_inputManager.IsPressedInput((int)Input.FaceButtonDown))
                        _effects.AddRange(_npcManager.CheckTalk(map, player.Pos));

                    player.Update(map, deltaTime);
                    if (player.step >= 3)
                    {
                        player.step = 0;
                        //GameState = GameState.Battle;
                        //battle.Load();
                    }
                    break;
            }
        }

        public void Draw()
        {
            switch (GameState)
            {
                case GameState.StartMenu:

                    _graphics.DrawSprite("menubg", new Rect(0, 0, Screen.Width, Screen.Height), new Rect(200, 200, Screen.Width + 200, Screen.Height + 200));               
                    _dialogManager.Draw(new Rect(160, 200, 130, 120));
                    _graphics.DrawString("New Game", 180, 220);
                    _graphics.DrawString("Load Game", 180, 240);
                    _graphics.DrawString("Exit", 180, 260);
                    _graphics.DrawSprite("cursor", 160, 223 + (int)menuItem * 20);
                    break;

                case GameState.World:

                    map.Draw(player.Pos.ToVector());
                    _npcManager.Draw(map);
                    player.Draw(map);
                    //_graphics.DrawString($"Step: {player.step} FPS: " + /*(int) (1/deltaTime) +*/ " X: " + player.x/32 + " Y: " + player.y/32, 10, 10);
                    break;

                case GameState.Battle:

                    battle.Draw();
                    break;

            }

            foreach (var effect in _effects)
            {
                effect.Draw();
            }
        }

        public void LoadWorld()
        {
            GameState = GameState.World;
            _songManager.Play("Losing Your Way");
        }
    }
}