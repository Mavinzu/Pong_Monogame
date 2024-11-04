using Entity;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pong;

namespace Scene;

public enum ScoreUI
{
    score1,
    score2
}

public static class MainScene
{
    public static Paddle paddle1;
    public static Paddle paddle2;

    static Ball ball;

    static int uiScore1 = 0;
    static int uiScore2 = 0;
    static Vector2 scorePos1 = new Vector2(
        Game1.RESOLUTION_WIDTH / 2 - 80,
        50
    );
    static Vector2 scorePos2 = new Vector2(
        Game1.RESOLUTION_WIDTH / 2 + 60,
        50
    );
    
    public static void Init()
    {
        SetupPaddle();
        SetupBall();
    }
    public static void Update(GameTime gameTime)
    {
        paddle1.Update(gameTime);
        paddle2.Update(gameTime);
        ball.Update(gameTime);
    }
    public static void Draw(SpriteBatch spriteBatch)
    {
        SetupScore(spriteBatch);
        paddle1.Draw(spriteBatch);
        paddle2.Draw(spriteBatch);
        ball.Draw(spriteBatch);
    }

    private static void SetupPaddle()
    {
        // paddle user no 1
        paddle1 = new Paddle(
            Game1.paddleBlueSprite,
            new Rectangle(50, 50, Game1.paddleBlueSprite.Height, Game1.paddleBlueSprite.Width)
        );
        paddle1.AddMovement(Keys.W, Keys.S);
        paddle1.Rotate(MathHelper.ToRadians(90));
        paddle1.MoveCollider(-20, 0);

        // paddle user no 2
        paddle2 = new Paddle(
            Game1.paddleRedSprite,
            new Rectangle(Game1.RESOLUTION_WIDTH - 50, 50, Game1.paddleRedSprite.Height, Game1.paddleRedSprite.Width)
        );
        paddle2.AddMovement(Keys.Up, Keys.Down);
        paddle2.Rotate(MathHelper.ToRadians(90));
        paddle2.MoveCollider(-30, 0);
    }

    private static void SetupBall()
    {
        ball = new Ball(
            Game1.ballSprite,
            new Rectangle(Game1.RESOLUTION_WIDTH / 2, Game1.RESOLUTION_HEIGHT / 2, Game1.ballSprite.Width, Game1.ballSprite.Height)
        );
    }

    private static void SetupScore(SpriteBatch spriteBatch)
    {
        spriteBatch.DrawString(Game1.font, uiScore1.ToString(), scorePos1, Color.White);
        spriteBatch.DrawString(Game1.font, uiScore2.ToString(), scorePos2, Color.White);
    }

    public static void UpdateScore(ScoreUI score)
    {
        if(score == ScoreUI.score1)
        {
            uiScore1 += 1;
        }
        if(score == ScoreUI.score2)
        {
            uiScore2 += 1;
        }
    }
}