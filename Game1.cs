using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Main
{
    public class Game1 : Game
    {
        public static float gConst;

        public static float defaultDrag;

        public static Texture2D lineTexture;
        public static Texture2D ballTexture;
        public static Texture2D wallTexture;
        
        public static GraphicsDeviceManager _graphics;
        public static SpriteBatch _spriteBatch;

        public static Player _player;

        public static Vector2 hookPos;
        public static float hookSpeed;

        public static Wall upWall;
        public static Wall downWall;
        public static Wall leftWall;
        public static Wall rightWall;

        public static Wall tryWall;

        public static MouseState mState;
        public static MouseState omState;

        public static KeyboardState kState;
        public static KeyboardState okState;

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

            upWall = new Wall(0, 0, _graphics.PreferredBackBufferWidth, 0);
            downWall = new Wall(0, _graphics.PreferredBackBufferHeight, _graphics.PreferredBackBufferWidth, 0);
            leftWall = new Wall(0, 0, 0, _graphics.PreferredBackBufferHeight);
            rightWall = new Wall(_graphics.PreferredBackBufferWidth, 0, 0, _graphics.PreferredBackBufferHeight);



            hookSpeed = 300f;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here


            lineTexture = Content.Load<Texture2D>("Sprites/line");
            ballTexture = Content.Load<Texture2D>("Sprites/ball");
            wallTexture = Content.Load<Texture2D>("Sprites/wall");

            tryWall = new Wall(100, 200, wallTexture, 300, 200);
        }

        

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            kState = Keyboard.GetState();
            mState = Mouse.GetState();



            /*if (kState.IsKeyDown(Keys.Up))
                hookPos.Y -= hookSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kState.IsKeyDown(Keys.Down))
                hookPos.Y += hookSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kState.IsKeyDown(Keys.Left))
                hookPos.X -= hookSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kState.IsKeyDown(Keys.Right))
                hookPos.X += hookSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (hookPos.X > _graphics.PreferredBackBufferWidth - ballTexture.Width / 2)
                hookPos.X = _graphics.PreferredBackBufferWidth - ballTexture.Width / 2;
            else if (hookPos.X < ballTexture.Width / 2)
                hookPos.X = ballTexture.Width / 2;

            if (hookPos.Y > _graphics.PreferredBackBufferHeight - ballTexture.Height / 2)
                hookPos.Y = _graphics.PreferredBackBufferHeight - ballTexture.Height / 2;
            else if (hookPos.Y < ballTexture.Height / 2)
                hookPos.Y = ballTexture.Height / 2;*/

            if (mState.LeftButton == ButtonState.Pressed && omState.LeftButton == ButtonState.Released)
            {
                hookPos.X = mState.X;
                hookPos.Y = mState.Y;
                _player.SendHook(hookPos);
            }



            _player.Update(gameTime);


            okState = kState;
            omState = mState;
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Red);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            tryWall.Draw();
            _player.DrawHook();
            _spriteBatch.Draw(ballTexture, hookPos, null, Color.White, 0, new Vector2(ballTexture.Width / 2, ballTexture.Height / 2), 1, SpriteEffects.None, 0);
            _spriteBatch.End();



            base.Draw(gameTime);
        }
    }
} 
