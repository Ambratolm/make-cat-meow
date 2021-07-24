using System.Drawing;
using System.Media;
using MakeCatMeow.Properties;

namespace MakeCatMeow
{
    public class Actor
    {
        public Graphics GX { get; private set; }
        public Image Sprite { get; set; }
        public Point Location { get; set; }
        public enum Direction { Right, Left, Up, Down }
        public Direction CurrentDirection { get; set; }

        public Actor(Graphics graphics, Image sprite, int x = 0, int y = 0)
        {
            this.GX = graphics;
            this.Sprite = sprite;
            this.Location = new Point(x, y);
            Draw();
        }

        public void Draw()
        {
            GX.DrawImage(this.Sprite, Location.X, Location.Y);
        }

        public void Move(Direction direction = Direction.Down, int step = 1)
        {
            PlayWalkSound();
            switch (direction)
            {
                case Direction.Right:
                    this.Location = new Point(this.Location.X + step, this.Location.Y);
                    break;
                case Direction.Left:
                    this.Location = new Point(this.Location.X - step, this.Location.Y);
                    break;
                case Direction.Up:
                    this.Location = new Point(this.Location.X, this.Location.Y - step);
                    break;
                case Direction.Down:
                    this.Location = new Point(this.Location.X, this.Location.Y + step);
                    break;
                default:
                    break;
            }
            CurrentDirection = direction;
            Draw();
        }

        public void PlayWalkSound()
        {
            (new SoundPlayer(Resources.walk)).Play();
        }

        public void PlayMeowSound()
        {
            new SoundPlayer(Resources.meow).Play();
        }

        public void PlayTouchSound()
        {
            new SoundPlayer(Resources.touch).Play();
        }
    }
}
