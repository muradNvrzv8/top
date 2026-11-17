namespace top
{
    public partial class Form1 : Form
    {
        private int ballXSpeed = 4;
        private int ballYSpeed = 4;

        
        private int paddleSpeed = 20;

        
        private bool goLeft, goRight;
        public Form1()
        {
            InitializeComponent();

            this.KeyPreview = true; 
            pictureBox1.Left = (this.ClientSize.Width - pictureBox1.Width) / 2;
            pictureBox1.Top = 30; 
        }
        
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (goLeft && panel1.Left > 0)
            {
                panel1.Left -= paddleSpeed;
            }
            if (goRight && panel1.Left + panel1.Width < this.ClientSize.Width)
            {
                panel1.Left += paddleSpeed;
            }

            
            pictureBox1.Left += ballXSpeed;
            pictureBox1.Top += ballYSpeed;

           
            if (pictureBox1.Left <= 0 || pictureBox1.Left + pictureBox1.Width >= this.ClientSize.Width)
            {
                ballXSpeed = -ballXSpeed; 
            }

            
            if (pictureBox1.Top <= 0)
            {
                ballYSpeed = -ballYSpeed;
            }

            
            if (pictureBox1.Bounds.IntersectsWith(panel1.Bounds))
            {
                ballYSpeed = -ballYSpeed; 

                
                Random rnd = new Random();
                ballXSpeed = rnd.Next(-5, 6); 
                if (ballXSpeed == 0) ballXSpeed = 3; 
            }

            
            if (pictureBox1.Top + pictureBox1.Height >= this.ClientSize.Height)
            {
                timer1.Stop();
                MessageBox.Show("Oyun Bitdi! Topu qaçırdınız.", "Məğlubiyyət", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                
                this.Close();
            }
        }
    }
}
