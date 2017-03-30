using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Manager;
using Player;
using System.Collections.Generic;

namespace MonoGame
{
    public class Main : Game
    {
        // TODO Add this to references: http://opengameart.org/content/space-background
        GraphicsDeviceManager graphicsDeviceManager;
        Graphics graphics;
        SpriteBatch spriteBatch;
        Texture2D menu;

        SongManager songManager;
        SoundManager soundManager;
        BattleManager battleManager;
        ActorManager actorManager;
        EnemyManager enemyManager;
        IconManager iconManager;
        InputManager inputManager;

        GameEngine gameEngine;
        Map map;
        Player player;
        Dialog dialog;
        KeyboardState previousState;
        Battle battle;

        GameState gameState = GameState.Battle;
        MenuItem menuItem = MenuItem.NewGame;

        private SpriteFont font;

        public Main()
        {
            graphicsDeviceManager = new GraphicsDeviceManager(this);
            graphicsDeviceManager.PreferredBackBufferWidth = Screen.Width;// GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            graphicsDeviceManager.PreferredBackBufferHeight = Screen.Height;// GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            //graphics.IsFullScreen = true;
            graphicsDeviceManager.ApplyChanges();

            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            inputManager = new InputManager(this);
            
            this.Components.Add(inputManager);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("Menu");

            graphics = new Graphics(spriteBatch, font);
            map = new Map(new TilesetManager(Content, spriteBatch, "Content/world2.tmx"));
            player = new Player(Content, inputManager);
            dialog = new Dialog(Content, spriteBatch);
            songManager = new SongManager(Content);
            soundManager = new SoundManager(Content);
            actorManager = new ActorManager(Content, spriteBatch);
            enemyManager = new EnemyManager(Content, spriteBatch);
            iconManager = new IconManager(Content, spriteBatch);

            menu = Content.Load<Texture2D>("menubg");

            gameEngine = new GameEngine(songManager, enemyManager);

            battleManager = new BattleManager(Content, spriteBatch);
            battle = new Battle(graphics, battleManager, actorManager, enemyManager, iconManager, inputManager, gameEngine.EnemyParty, gameEngine.Party, dialog);

            //var darktroll = new Enemy { Name = "Dark Troll", Hp = 10, MaxHp = 10, SpriteName = "DarkTroll", Dexterity = 5 };
            //Common.Serializer.XmlSerialize<Enemy>(darktroll, "DarkTroll.xml");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            Content.Unload();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            var deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            // Exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Alt-Enter
            if (inputManager.IsPressedKey((int)Keys.F5))
            {
                graphicsDeviceManager.IsFullScreen = !graphicsDeviceManager.IsFullScreen;
                graphicsDeviceManager.ApplyChanges();
            }

            switch (gameState)
            {
                case GameState.StartMenu:
                    if (inputManager.IsPressedKey((int)Keys.Up))
                    {
                        menuItem--;
                        if (menuItem < MenuItem.NewGame)
                            menuItem = MenuItem.Exit;
                    }
                    if (inputManager.IsPressedKey((int)Keys.Down))
                    {
                        menuItem++;
                        if (menuItem > MenuItem.Exit)
                            menuItem = MenuItem.NewGame;
                    }
                    if (inputManager.IsPressedKey((int)Keys.Enter))
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

            base.Update(gameTime);

            previousState = Keyboard.GetState();
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            var deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            spriteBatch.Begin();

            GraphicsDevice.Clear(Color.Black);

            switch (gameState)
            {
                case GameState.StartMenu:

                    spriteBatch.Draw(menu, new Rectangle(0, 0, Screen.Width, Screen.Height), new Rectangle(200, 200, Screen.Width + 200, Screen.Height + 200), Color.White);
                    dialog.Draw(new Rect(160, 200, 130, 130));
                    spriteBatch.DrawString(font, "New Game", new Vector2(180, 220), Color.White);
                    spriteBatch.DrawString(font, "Load Game", new Vector2(180, 240), Color.White);
                    spriteBatch.DrawString(font, "Exit", new Vector2(180, 260), Color.White);
                    break;

                case GameState.World:

                    map.Draw((int) player.x, (int) player.y);
                    player.Draw(map, spriteBatch);
                    //spriteBatch.DrawString(font, "FPS: " + (int) (1/deltaTime) + " X: " + player.x/32 + " Y: " + player.y/32, new Vector2(10, 10), Color.White);
                    break;

                case GameState.Battle:

                    battle.Draw();
                    break;

            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
