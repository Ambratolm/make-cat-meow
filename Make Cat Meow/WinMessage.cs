using System.Drawing;
using System.Media;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MakeCatMeow.Properties;

namespace MakeCatMeow
{
    public class WinMessage
    {
        /// <summary>
        /// Display an instant message that disapears after a delay.
        /// </summary>
        /// <param name="msg">Message to display</param>
        /// <param name="delay">Display time in secondes</param>
        /// <param name="parent">Parent control where to diplay message</param>
        public static void ShowInstantMessage(string msg, int delay, Control parent)
        {
            SoundPlayer soundPlayer = new SoundPlayer(Resources.bip);
            Label label = new Label();
            label.AutoSize = true;
            label.BackColor = Color.White;
            label.BorderStyle = BorderStyle.FixedSingle;
            label.Font = new Font(parent.Font.FontFamily, 20); 
            label.Text = msg;
            label.Location = new Point(32, 32);
            parent.Controls.Add(label);
            Task msgTask = new Task(() =>
                {
                    Thread.Sleep(delay);
                    label.Dispose();
                    soundPlayer.Play();
                });
            soundPlayer.Play();
            msgTask.Start();
        }
    }
}
