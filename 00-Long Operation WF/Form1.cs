namespace _00_Long_Operation_WF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // ������� �������� � ��������� ������ (UI ������), ��������� UI
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("������� ������� ��������...");
            //Thread.Sleep(5000); // ������� ������� ��������
            for (int i = 0; i <= 100; i++)
            {
                progressBar1.Value = i;
                Thread.Sleep(50); // ������� ������� ��������
            }
            MessageBox.Show("�������� ���������!");
        }

        // ������� �������� � ��������� ������ (UI ������) � async/await, �� ����� UI
        //    private async void button1_Click(object sender, EventArgs e) 
        //    {
        //        MessageBox.Show("������� ��������...");
        //        //await Task.Delay(5000); // ������� ������� ��������
        //        for (int i = 0; i <= 100; i++)
        //        {
        //            progressBar1.Value = i;
        //            await Task.Delay(50); // ������� ������� ��������, �� ����� UI, �� ��������������� await
        //}
        //MessageBox.Show("�������� ���������!");
        //    }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Text = $"X: {e.X}, Y: {e.Y}"; // ������ ���������� ���� � ��������� �����
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            progressBar1.Maximum = 100;
            progressBar1.Step = 1;
        }
    }
}
