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
            MessageBox.Show("������� ������� ��������...");
            Thread.Sleep(5000); // ������� ������� ��������
            MessageBox.Show("�������� ���������!");
        }
        //private async void button1_Click(object sender, EventArgs e)
        //{
        //    MessageBox.Show("������� ��������...");
        //    await Task.Delay(5000); // ������� ������� ��������
        //    MessageBox.Show("�������� ���������!");
        //}
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Text = $"X: {e.X}, Y: {e.Y}"; // ������ ���������� ���� � ��������� �����
        }
    }
}
