using DataStore;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Manager;
using Player;
using Player.Core;
using Player.Events;
using Player.StateStack;

namespace MonoGame
{
    public class Main : Game
    {
        // TODO Add this to references: 
        // menubg.png   http://opengameart.org/content/space-background
        // cursor.png   http://opengameart.org/content/iron-plague-pointercursor
        // icons.png    https://www.scirra.com/forum/pixel-art-rpg-icons_t66386
        // dialog       http://opengameart.org/content/10-basic-message-boxes

        // MonoGame Framework
        private GraphicsDeviceManager graphicsDeviceManager;
        private SpriteBatch spriteBatch;
        private SpriteFont font;

        // MonoGame Managers
        private Graphics graphics;
        private InputManager inputManager;

        private IDataStore _dataStore;
        private IState _gameState;

        public Main()
        {
            graphicsDeviceManager = new GraphicsDeviceManager(this);
            graphicsDeviceManager.PreferredBackBufferWidth = Screen.Width;// GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            graphicsDeviceManager.PreferredBackBufferHeight = Screen.Height;// GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            //graphicsDeviceManager.IsFullScreen = true;
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

            var eventService = new EventService();
            graphics = new Graphics(Content, spriteBatch, font);
            var tilesetManager = new TilesetManager(Content, spriteBatch);
            var dialogManager = new DialogManager(Content, spriteBatch);
            var songManager = new SongManager(Content);
            var soundManager = new SoundManager(Content);
            var actorManager = new ActorManager(Content, spriteBatch);
            var enemyManager = new EnemyManager(Content, spriteBatch);
            var iconManager = new IconManager(Content, spriteBatch);
            var battleManager = new BattleManager(Content, spriteBatch);

            _dataStore = new BinaryDataStore();
            _gameState = new GameState(actorManager, battleManager, _dataStore, dialogManager, enemyManager, eventService, graphics, iconManager, inputManager, songManager, tilesetManager);
            _gameState.OnLoad();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            Content.Unload();
            _gameState.OnClose();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            var elapsedTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            
            if (!_gameState.Update(elapsedTime))
                Exit();

            // Alt-Enter
            if (inputManager.JustPressedKey((int)Keys.F5))
            {
                graphicsDeviceManager.IsFullScreen = !graphicsDeviceManager.IsFullScreen;
                graphicsDeviceManager.ApplyChanges();
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            GraphicsDevice.Clear(Color.Black);

            _gameState.Draw();

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}