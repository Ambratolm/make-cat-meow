using System;
using System.Drawing;
using System.Windows.Forms;
using MakeCatMeow.Properties;

namespace MakeCatMeow
{
    public partial class Form_Game : Form
    {
        private Actor mainActor;

        public Form_Game()
        {
            InitializeComponent();
            MaximumSize = Size;
            mainActor = new Actor(this.CreateGraphics(), Resources.cat.ToBitmap(), Size.Width/2, Size.Height/2);
            KeyDown += new KeyEventHandler(Controller);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            mainActor.Draw();
        }

        private void Controller(object sender, KeyEventArgs e)
        {
            int step = 32;
            switch (e.KeyCode)
            {
                case Keys.Right:
                    if (mainActor.Location.X <= Size.Width - 3*step) mainActor.Move(Actor.Direction.Right, step);
                    break;
                case Keys.Left:
                    if (mainActor.Location.X >= step/2) mainActor.Move(Actor.Direction.Left, step);
                    break;
                case Keys.Up:
                    if (mainActor.Location.Y >= step) mainActor.Move(Actor.Direction.Up, step);
                    break;
                case Keys.Down:
                    if (mainActor.Location.Y <= Size.Height - 3*step) mainActor.Move(Actor.Direction.Down, step);
                    break;
                default:
                    break;
            }
            Invalidate();
        }

        private void Form_Game_Load(object sender, EventArgs e)
        {
            WinMessage.ShowInstantMessage("Find a way to make cat meow.", 3000, this);
        }

        private void Form_Game_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mainActor.PlayTouchSound();
                Graphics gfx = CreateGraphics();
                Random rand = new Random();
                int len = rand.Next(8, 64);
                gfx.DrawImage(Resources.hole, e.X - (len / 2), e.Y - (len / 2), len, len);
                if ((e.X == e.Y) || (e.X == Size.Width && e.Y == Size.Height))
                {
                    mainActor.PlayMeowSound();
                }
            }
        }
    }
}
