namespace _00_Long_Operation_WF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // тривала операція в основному потоці (UI потоці), блокується UI
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Початок тривалої операції...");
            //Thread.Sleep(5000); // Імітація тривалої операції
            for (int i = 0; i <= 100; i++)
            {
                progressBar1.Value = i;
                Thread.Sleep(50); // Імітація тривалої операції
            }
            MessageBox.Show("Операція завершена!");
        }

        // тривала операція в основному потоці (UI потоці) з async/await, не блокує UI
        //    private async void button1_Click(object sender, EventArgs e) 
        //    {
        //        MessageBox.Show("Початок операції...");
        //        //await Task.Delay(5000); // Імітація тривалої операції
        //        for (int i = 0; i <= 100; i++)
        //        {
        //            progressBar1.Value = i;
        //            await Task.Delay(50); // Імітація тривалої операції, не блокує UI, бо використовується await
        //}
        //MessageBox.Show("Операція завершена!");
        //    }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Text = $"X: {e.X}, Y: {e.Y}"; // Показує координати миші в заголовку форми
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            progressBar1.Maximum = 100;
            progressBar1.Step = 1;
        }
    }
}
