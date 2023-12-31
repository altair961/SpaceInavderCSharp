﻿using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Shmup
{
    public class Player
    {
        private Sprite sprite;
        public const float PLAYER_SPEED = 4f;
        Vector2f position;
        private int delay = 0;
        public List<Bullet> bullets = new List<Bullet>();

        private void fire()
        {
            this.delay++;
            if (this.delay >= 15)
            {
                this.bullets.Add(new Bullet(this.position));
                var positionOfSecondBullet = new Vector2f(this.position.X + 25, this.position.Y);
                this.bullets.Add(new Bullet(positionOfSecondBullet));
                this.delay = 0;
            }
        }

        public Player()
        {
            sprite = new Sprite();
            sprite.Texture = TextureManager.PlayerTexture;
        }

        public void update()
        {
            this.keyHandler();
            this.sprite.Position = position;
            this.keyHandler();
            this.sprite.Position = position;

            for (int i = 0; i < this.bullets.Count; i++)
            {
                this.bullets[i].update();
                if (this.bullets[i].Position.Y < 0)
                {
                    this.bullets.Remove(this.bullets[i]);
                }
            }
        }

        public void draw(RenderTarget window)
        {
            window.Draw(this.sprite);
            foreach (var bullet in this.bullets)
            {
                window.Draw(bullet.RectangleBullet);
            }

        }

        public void keyHandler()
        {
            bool moveLeft = Keyboard.IsKeyPressed(Keyboard.Key.A);
            bool moveRight = Keyboard.IsKeyPressed(Keyboard.Key.D);
            bool moveUp = Keyboard.IsKeyPressed(Keyboard.Key.W);
            bool moveDown = Keyboard.IsKeyPressed(Keyboard.Key.S);

            bool isMove = moveLeft || moveRight || moveUp || moveDown;

            if (isMove)
            {
                if (moveLeft) position.X -= PLAYER_SPEED;
                if (moveRight) position.X += PLAYER_SPEED;
                if (moveUp) position.Y -= PLAYER_SPEED;
                if (moveDown) position.Y += PLAYER_SPEED;
            }

            bool isFire = Keyboard.IsKeyPressed(Keyboard.Key.Space);
            if (isFire) this.fire();
        }
    }
}