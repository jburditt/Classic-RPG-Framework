using Player.Graphics;
using Player.Inputs;
using Player.Manager;
using System.Collections.Generic;

namespace Player
{
    public class GameEngine
    {
        private IInputManager _inputManager;

        Battle battle;
        GamePlayer player;
        Map map;

        public Party Party { get; private set; }
        public EnemyParty EnemyParty { get; private set; }

        GameState gameState = GameState.Battle;
        MenuItem menuItem = MenuItem.NewGame;

        public GameEngine(
            ISongManager songManager, IGraphics graphics, IBattleManager battleManager, IActorManager actorManager, IEnemyManager enemyManager,
            IIconManager iconManager, IInputManager inputManager, ITilesetManager tilesetManager, IDialog dialog)
        {
            _inputManager = inputManager;

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

            battle = new Battle(graphics, battleManager, actorManager, enemyManager, iconManager, inputManager, EnemyParty, Party, dialog);
            player = new GamePlayer(Party.Actors[0].CharSet, inputManager, actorManager);
            map = new Map(tilesetManager);

            //songManager.Play("01 - Namazu");
            songManager.Play("Battle of the Mind");
        }

        public void Update(float deltaTime)
        {
            switch (gameState)
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
                        gameState = GameState.World;
                    break;

                case GameState.Battle:
                    if (battle.Update())
                        gameState = GameState.World;
                    break;

                case GameState.World:
                    player.Update(map, deltaTime);
                    break;
            }
        }

        public void Draw()
        {
            switch (gameState)
            {
                case GameState.StartMenu:

                    //spriteBatch.Draw(menu, new Rectangle(0, 0, Screen.Width, Screen.Height), new Rectangle(200, 200, Screen.Width + 200, Screen.Height + 200), Color.White);
                    //dialog.Draw(new Rect(160, 200, 130, 130));
                    //spriteBatch.DrawString(font, "New Game", new Vector2(180, 220), Color.White);
                    //spriteBatch.DrawString(font, "Load Game", new Vector2(180, 240), Color.White);
                    //spriteBatch.DrawString(font, "Exit", new Vector2(180, 260), Color.White);
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