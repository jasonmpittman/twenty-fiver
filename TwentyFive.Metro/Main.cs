using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroFramework.Forms;
using System.Media;

namespace TwentyFive.Metro
{
    public partial class Main : MetroForm
    {
        public Main()
        {
            InitializeComponent();
        }

        int timeLeft;
        string labelMinutes, labelSeconds;
        SoundPlayer sound = new SoundPlayer(@"sounds\alarm.wav");
        TwentyFiveLogger logger;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft = timeLeft - 1;
                updateTimerText(timeLeft);
            }
            else
            {
                timer1.Stop();
                lblTimer.Text = "00:00";
                sound.Play();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timeLeft = 1500;

            timer1.Start();
            logger = new TwentyFiveLogger(tbTask.Text, "start");
            logger.LogTwentyFiver();
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            logger = new TwentyFiveLogger(tbTask.Text, "stop");
            logger.LogTwentyFiver();
        }

        private void updateTimerText(int timeLeft)
        {
            int minutes = timeLeft / 60;
            int seconds = timeLeft % 60;


            //we need to add a zero when minutes are less than 10
            if (minutes < 10)
            {
                labelMinutes = "0" + minutes.ToString();
            }
            else
            {
                labelMinutes = minutes.ToString();
            }

            //we need to add a zero when seconds are less than 10
            if (seconds < 10)
            {
                labelSeconds = "0" + seconds.ToString();
            }
            else
            {
                labelSeconds = seconds.ToString();
            }

            lblTimer.Text = labelMinutes + ":" + labelSeconds;
        }
    }
}
