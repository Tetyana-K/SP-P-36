namespace _00_Long_Operation_WF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Початок тривалої операції...");
            Thread.Sleep(5000); // Імітація тривалої операції
            MessageBox.Show("Операція завершена!");
        }
        //private async void button1_Click(object sender, EventArgs e)
        //{
        //    MessageBox.Show("Початок операції...");
        //    await Task.Delay(5000); // Імітація тривалої операції
        //    MessageBox.Show("Операція завершена!");
        //}
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Text = $"X: {e.X}, Y: {e.Y}"; // Показує координати миші в заголовку форми
        }
    }
}
