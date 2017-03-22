using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using MonoGame.Extended;
using MonoGame.Extended.Shapes;

namespace Player
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Main : Game
    {
        // TODO Add this to references: http://opengameart.org/content/space-background
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Map map;
        Player player;
        KeyboardState previousState;
        Audio audio;
        Song song;
        Texture2D menu;

        GameState gameState = GameState.StartMenu;
        MenuItem menuItem = MenuItem.NewGame;

        private SpriteFont font;

        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = Screen.Width;// GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            graphics.PreferredBackBufferHeight = Screen.Height;// GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            //graphics.IsFullScreen = true;
            graphics.ApplyChanges();

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
            map = new Map(Content, Window);
            player = new Player(Content);
            audio = new Audio(Content);
            song = Content.Load<Song>("I3-Epic-Brave Heart");
            menu = Content.Load<Texture2D>("menubg");
            MediaPlayer.Play(song);
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
            if (KeyboardHelper.AltPress(previousState, Keys.Enter))
            {
                graphics.IsFullScreen = !graphics.IsFullScreen;
                graphics.ApplyChanges();
            }

            switch (gameState)
            {
                case GameState.StartMenu:
                    if (KeyboardHelper.Down(Keys.Up))
                    {
                        menuItem--;
                        if (menuItem < MenuItem.NewGame)
                            menuItem = MenuItem.Exit;
                    }
                    if (KeyboardHelper.Down(Keys.Down))
                    {
                        menuItem++;
                        if (menuItem > MenuItem.Exit)
                            menuItem = MenuItem.NewGame;
                    }
                    if (KeyboardHelper.Down(Keys.Enter))
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

                    spriteBatch.Draw(menu, new Rectangle(0, 0, Screen.Width, Screen.Height), new Rectangle(0, 0, Screen.Width, Screen.Height), Color.White);
                    spriteBatch.DrawString(font, "New Game", new Vector2(180, 220), Color.White);
                    spriteBatch.DrawString(font, "Load Game", new Vector2(180, 240), Color.White);
                    spriteBatch.DrawString(font, "Exit", new Vector2(180, 260), Color.White);
                    break;

                case GameState.World:

                    map.Draw(spriteBatch, (int) player.x, (int) player.y);
                    player.Draw(spriteBatch);
                    spriteBatch.DrawString(font, "FPS: " + (int) (1/deltaTime) + " X: " + player.x/32 + " Y: " + player.y/32, new Vector2(10, 10), Color.White);
                    break;

            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
