using System.Windows.Forms;
namespace Threads_in_WinForms
{
    // ��� ������� ����� ����������� �������� UI-����,
    // ���� ������ �� ������ ��������� � ���������� ����� �������, �� �� ���� ���������� ������� 
    public partial class Form1 : Form
    {
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer(); // ������ ��� ��������� ���������� (��������� ��������)
        int counter = 0;
        public Form1()
        {
            InitializeComponent();

            listBox1.MultiColumn = true;
            listBox1.HorizontalScrollbar = true;
            timer.Interval = 100; // �������� � ����������
            timer.Tick += Timer_Tick; // ������� �� ���� Tick
            
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            if (counter >= 30)
                timer.Stop();
            else
            {
                counter++;
                listBox1.Items.Add(counter);
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            timer.Start(); // ������ �������
            Thread thread = new Thread(PrintLetters);
            thread.Start();
        }
        void PrintLetters()
        {
            for (char c = 'A'; c <= 'Z'; c++)
            {
                listBox1.Items.Add(c); // ���� ��������� �������, ���� �� ������ �� �������� ����
                                       // ���������� ����� � ��������������� Invoke() ��� BeginInvoke(), 
                                       // ��� ��� ����������� � ��������� UI-������

                //this.Invoke(new Action(() =>
                //{
                //    listBox1.Items.Add(c);
                //}));
                Thread.Sleep(100); // �������� ��� ��������
            }
        }
    }
}
