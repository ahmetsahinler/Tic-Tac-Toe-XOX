using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace XOX
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        bool open = true;
        int open_count = 0;
        SoundPlayer select = new SoundPlayer(@"C:\Users\Ahmet\Desktop\Odevler\Odev10\XOX\bin\Debug\select.wav");
        SoundPlayer win = new SoundPlayer(@"C:\Users\Ahmet\Desktop\Odevler\Odev10\XOX\bin\Debug\win.wav");
        private void Button_Click(object sender, EventArgs e)
        {
            select.Play();
            Button btn = (Button)sender;
            if (open)
            {
                btn.Text="X";
                btn.BackColor = Color.Maroon;
            }
            else
            {
                btn.Text="O";
                btn.BackColor = Color.DarkTurquoise;
            }
            open = !open;
            btn.Enabled= false;
            open_count++;
            playerwin();
        }
        private void playerwin()
        {
            bool winner = false;

            if ((A1.Text == A2.Text)&&(A2.Text==A3.Text)&&(!A1.Enabled) || (B1.Text == B2.Text)&&(B2.Text == B3.Text)&&(!B1.Enabled)
              ||(C1.Text == C2.Text)&&(C2.Text==C3.Text)&&(!C1.Enabled) || (A1.Text == B1.Text)&&(B1.Text == C1.Text)&&(!A1.Enabled)
              ||(A2.Text == B2.Text)&&(B2.Text==C2.Text)&&(!A2.Enabled) || (A3.Text == B3.Text)&&(B3.Text == C3.Text)&&(!A3.Enabled)
              ||(A1.Text == B2.Text)&&(B2.Text==C3.Text)&&(!A1.Enabled) || (A3.Text == B2.Text)&&(B2.Text == C1.Text)&&(!A3.Enabled))
            {winner = true;}

            if (winner)
            {
                win.Play();
                disableButtons();
                string player_winner = "";
                if (open)
                {player_winner = "O";}
                else{player_winner = "X";}
                DialogResult result = MessageBox.Show(player_winner + " Oyuncusu Kazandı...\nTekrar Başlamak İster Misiniz?", "Tebrikler",MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    Restart();
                }
                else if (result == DialogResult.No)
                {
                    Application.Exit();
                }
            }
            else if (open_count==9)
            {
                win.Play();
                DialogResult result = MessageBox.Show("Berabere...\nTekrar Başlamak İster Misiniz?", "Berabere", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    Restart();
                }
                else if (result == DialogResult.No)
                {
                    Application.Exit();
                }
            }
        }
        private void disableButtons()
        {
            foreach (Control item in Controls)
            {
                Button btn = (Button)item;
                item.Enabled = false;
            }
        }
        private void Restart()
        {
            open= true;
            open_count= 0;
            foreach (Control item in Controls) 
            {
                Button btn = (Button)item;
                item.Enabled = true;
                item.Text = "";
                item.BackColor= Color.Black;
            }
        }
        private void Lane()
        {
            Graphics graphics = this.CreateGraphics();
            Pen pen = new Pen(Color.Gray,5);

            graphics.DrawLine(pen,142,10,142,400);
            graphics.DrawLine(pen,274,10,274,400);
            graphics.DrawLine(pen,11,141,405,141);
            graphics.DrawLine(pen,11,273,405,273);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Lane();
        }
    }
}

