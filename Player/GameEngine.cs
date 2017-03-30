using Player.Graphics;
using Player.Inputs;
using Player.Manager;
using System.Collections.Generic;

namespace Player
{
    public class GameEngine
    {
        private IInputManager _inputManager;
        private IDialog _dialog;
        private IGraphics _graphics;

        Battle battle;
        GamePlayer player;
        Map map;
        
        public Party Party { get; private set; }
        public EnemyParty EnemyParty { get; private set; }
        public GameState GameState { get; private set; } = GameState.StartMenu;

        MenuItem menuItem = MenuItem.NewGame;

        public GameEngine(
            ISongManager songManager, IGraphics graphics, IBattleManager battleManager, IActorManager actorManager, IEnemyManager enemyManager,
            IIconManager iconManager, IInputManager inputManager, ITilesetManager tilesetManager, IDialog dialog)
        {
            _inputManager = inputManager;
            _dialog = dialog;
            _graphics = graphics;

            Party = new Party
            {
                Actors = new List<Actor> {
                    new Actor("gus", "gus") { Name = "Gus", Hp = 40, MaxHp = 58, Mp = 2, MaxMp = 8, Limit = 23 },
                    new Actor("fitz", "fitz") { Name = "Fitz", Hp = 32, MaxHp = 52, Mp = 5, MaxMp = 12, Limit = 17 },
                    new Actor("sorah", "sorah") { Name = "Sorah", Hp = 102, MaxHp = 252, Mp = 8, MaxMp = 12, Limit = 37 },
                    new Actor("sheba", "sheba") { Name = "Sheba", Hp = 44, MaxHp = 52, Mp = 8, MaxMp = 12, Limit = 5 }
                }
            };

            EnemyParty = new EnemyParty(new List<Enemy> { enemyManager.Enemies["DarkTroll"] });

            //var darktroll = new Enemy { Name = "Dark Troll", Hp = 10, MaxHp = 10, SpriteName = "DarkTroll", Dexterity = 5 };
            //Common.Serializer.XmlSerialize<Enemy>(darktroll, "DarkTroll.xml");

            battle = new Battle(graphics, battleManager, actorManager, enemyManager, iconManager, inputManager, songManager, EnemyParty, Party, dialog);
            player = new GamePlayer(Party.Actors[0].CharSet, inputManager, actorManager);
            map = new Map(tilesetManager);

            //songManager.Play("01 - Namazu");
            songManager.Play("Battle of the Mind");
        }

        public void Update(float deltaTime)
        {
            if (_inputManager.IsPressedInput((int)Input.Back) || _inputManager.IsPressedKey((int)Keys.Escape))
                GameState = GameState.Exit;

            switch (GameState)
            {
                case GameState.StartMenu:
                    if (_inputManager.IsPressedKey((int)Keys.Up))
                    {
                        menuItem--;
                        if (menuItem < MenuItem.NewGame)
                            menuItem = MenuItem.Exit;
                    }
                    if (_inputManager.IsPressedKey((int)Keys.Down))
                    {
                        menuItem++;
                        if (menuItem > MenuItem.Exit)
                            menuItem = MenuItem.NewGame;
                    }
                    if (_inputManager.IsPressedKey((int)Keys.Enter))
                        GameState = GameState.World;
                    break;

                case GameState.Battle:
                    if (battle.Update())
                        GameState = GameState.World;
                    break;

                case GameState.World:
                    player.Update(map, deltaTime);
                    break;
            }
        }

        public void Draw()
        {
            switch (GameState)
            {
                case GameState.StartMenu:

                    //spriteBatch.Draw(menu, new Rectangle(0, 0, Screen.Width, Screen.Height), new Rectangle(200, 200, Screen.Width + 200, Screen.Height + 200), Color.White);
                    _dialog.Draw(new Rect(160, 200, 130, 130));
                    _graphics.DrawString("New Game", 180, 220);
                    _graphics.DrawString("Load Game", 180, 240);
                    _graphics.DrawString("Exit", 180, 260);
                    break;

                case GameState.World:

                    map.Draw((int)player.x, (int)player.y);
                    player.Draw(map);
                    ////spriteBatch.DrawString(font, "FPS: " + (int) (1/deltaTime) + " X: " + player.x/32 + " Y: " + player.y/32, new Vector2(10, 10), Color.White);
                    break;

                case GameState.Battle:

                    battle.Draw();
                    break;

            }
        }
    }
}