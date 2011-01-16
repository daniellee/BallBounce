using BallBounceMVC.Controllers;
using BallBounceMVC.Models;
using BallBounceMVC.Views;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BallBounceMVC
{
	/// <summary>
	/// This is the main type for your game
	/// </summary>
	public class BallBounceGame : Game
	{
		readonly GraphicsDeviceManager _graphics;
		SpriteBatch _spriteBatch;
		private World _world;
		private BallController _ballController;
		private BallsViewer _ballsViewer;
		private WorldViewer _worldViewer;
		private Texture2D _ballTexture;
		private Texture2D _frameTexture;
		private FrameViewer _frameViewer;
		private PlayerController _playerController;
		private Texture2D _playerTexture;
		private PlayerViewer _playerViewer;


		public BallBounceGame()
		{
			_graphics = new GraphicsDeviceManager(this) {PreferredBackBufferWidth = 800, PreferredBackBufferHeight = 600};
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
			// TODO: Add your initialization logic here

			base.Initialize();
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			_spriteBatch = new SpriteBatch(GraphicsDevice);

			_world = new World(_graphics.GraphicsDevice.Viewport.Width, _graphics.GraphicsDevice.Viewport.Height);

			BallsModel ballsModel = _world.GetBallsModel();
			_ballController = new BallController(ballsModel);
			_ballTexture = Content.Load<Texture2D>("Sprites\\SilverBall");
			_ballsViewer = new BallsViewer(ballsModel.GetAllBalls(), _ballTexture);

			_frameTexture = Content.Load<Texture2D>("Frame\\titanium");
			_frameViewer = new FrameViewer(_world.GetFrameModel(), _frameTexture);
			_worldViewer = new WorldViewer();

			_playerTexture = Content.Load<Texture2D>("Sprites\\PlayerShip");
			PlayerModel playerModel = _world.GetPlayerModel();
			_playerController = new PlayerController(playerModel);
			_playerViewer = new PlayerViewer(playerModel, _playerTexture);
		}

		/// <summary>
		/// UnloadContent will be called once per game and is the place to unload
		/// all content.
		/// </summary>
		protected override void UnloadContent()
		{
			_ballTexture.Dispose();
			_frameTexture.Dispose();
			_playerTexture.Dispose();
			base.UnloadContent();
		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update(GameTime gameTime)
		{
			// Allows the game to exit
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
				Exit();

			_ballController.Control((float)gameTime.ElapsedGameTime.TotalSeconds);

			base.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			_spriteBatch.Begin();
			_worldViewer.Draw(_spriteBatch);
			_frameViewer.Draw(_spriteBatch);
			_ballsViewer.Draw(_spriteBatch);
			_playerViewer.Draw(_spriteBatch);
			_spriteBatch.End();

			base.Draw(gameTime);
		}
	}
}
