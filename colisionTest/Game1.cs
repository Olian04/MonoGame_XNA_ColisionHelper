using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace colisionTest
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        CollisionBox targetRect, mouseRect;
        Rectangle rect;

        Texture2D circleTexture, squareTexture;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = 720;
            graphics.PreferredBackBufferWidth = 1080;
            Window.Position = new Point(100);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            targetRect = new AIDBC(new Vector2(400), 150f);
            mouseRect = new AIDBC(new Vector2(), 50f);

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

            circleTexture = Content.Load<Texture2D>("Bird.png");
            squareTexture = Content.Load<Texture2D>("pixel.png");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            bool isOnSide = false;

            mouseRect.setPosition(Mouse.GetState().Position.ToVector2());

            if (targetRect.Intersects(mouseRect))
                rect = Rectangle.Intersect(targetRect.getBoundingBox(), mouseRect.getBoundingBox());

            #region ConsoleMessages
            if (targetRect.Intersects(mouseRect))
                Console.WriteLine(targetRect.degreeTo(mouseRect));

            if (targetRect.isLeft(mouseRect))
            {
                Console.WriteLine("LEFT");
                isOnSide = true;
            }
            if (targetRect.isRight(mouseRect))
            {
                Console.WriteLine("RIGHT");
                isOnSide = true;
            }
            if (targetRect.isAbove(mouseRect))
            {
                Console.WriteLine("TOP");
                isOnSide = true;
            }
            if (targetRect.isBelow(mouseRect))
            {
                Console.WriteLine("BOTTOM");
                isOnSide = true;
            }
            if (!isOnSide)
            {
                Console.WriteLine("INSIDE");
            }
            #endregion

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.Draw(circleTexture, targetRect.getBoundingBox(), Color.Black);
            spriteBatch.Draw(circleTexture, mouseRect.getBoundingBox(), Color.White);
            spriteBatch.Draw(circleTexture, rect, Color.Red);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
