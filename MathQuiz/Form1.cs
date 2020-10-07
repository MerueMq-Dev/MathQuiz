using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathQuiz
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }

        Random randomizer = new Random();

        int addend1;
        int addend2;
        int minuend;
        int subtrahend;
        int multiplicand;
        int multiplier;
        int dividend;
        int divisor;
        int timeLeft;

        private void startButton_Click(object sender, EventArgs e)
        {
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            minuend = randomizer.Next(1,101);
            subtrahend = randomizer.Next(1, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();

            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();

            divisor = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();

            quotient.Value = 0;
            product.Value = 0;
            difference.Value = 0;
            sum.Value = 0;

            timeLeft = 30;
            timeLabel.Text = "30 секунд";
            startButton.Enabled = false;

            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                timer1.Stop();
                MessageBox.Show("Ты ответил на все загадки! Поздравляю!");
                timeLabel.BackColor = Color.White;
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                timeLeft--;
                if(timeLeft == 5)
                {
                    timeLabel.BackColor = Color.Red;
                }
                timeLabel.Text = timeLeft + " секунд";
            }
            else
            {
                timer1.Stop();
                timeLabel.Text = "Время вышло!";
                MessageBox.Show("Вы не успели","Простите!");
                timeLabel.BackColor = Color.White;
                sum.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                startButton.Enabled = true;
              
            }
        }
        private bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == sum.Value)
            && (minuend - subtrahend == difference.Value)
            && (multiplicand * multiplier == product.Value)
            && (dividend / divisor == quotient.Value))
                return true;
            else
                return false;
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            NumericUpDown anserBox = sender as NumericUpDown;

            if(anserBox != null)
            {
                int lenghtOfAnswer = anserBox.Value.ToString().Length;
                anserBox.Select(0, lenghtOfAnswer);
            }
        }
    }
}
