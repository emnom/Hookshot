using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Main
{
    public class Game1 : Game
    {
        public static Texture2D lineTexture;
        public static Texture2D ballTexture;
        
        public static GraphicsDeviceManager _graphics;
        public static SpriteBatch _spriteBatch;

        public static Player _player;

        public static Vector2 hookPos;
        public static float hookSpeed;

        public Game1()
        {
             _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            _graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
            _graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height - 80;
            _graphics.ApplyChanges();

            _player = new Player(_graphics.PreferredBackBufferWidth/2, _graphics.PreferredBackBufferHeight/2);

            hookSpeed = 300f;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            lineTexture = Content.Load<Texture2D>("Sprites/line");
            ballTexture = Content.Load<Texture2D>("Sprites/ball");
        }

        

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            var ksate = Keyboard.GetState();

            if (ksate.IsKeyDown(Keys.Up))
                hookPos.Y -= hookSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (ksate.IsKeyDown(Keys.Down))
                hookPos.Y += hookSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (ksate.IsKeyDown(Keys.Left))
                hookPos.X -= hookSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (ksate.IsKeyDown(Keys.Right))
                hookPos.X += hookSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (hookPos.X > _graphics.PreferredBackBufferWidth - ballTexture.Width / 2)
                hookPos.X = _graphics.PreferredBackBufferWidth - ballTexture.Width / 2;
            else if (hookPos.X < ballTexture.Width / 2)
                hookPos.X = ballTexture.Width / 2;

            if (hookPos.Y > _graphics.PreferredBackBufferHeight - ballTexture.Height / 2)
                hookPos.Y = _graphics.PreferredBackBufferHeight - ballTexture.Height / 2;
            else if (hookPos.Y < ballTexture.Height / 2)
                hookPos.Y = ballTexture.Height / 2;




            _player.SendHook(hookPos);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Red);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            _spriteBatch.End();




            base.Draw(gameTime);
        }
    }
} 
