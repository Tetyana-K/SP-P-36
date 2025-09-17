using System.Windows.Forms;
namespace Threads_in_WinForms
{
    // ��� ������� ����� ����������� �������� UI-����,
    // ���� ������ �� ������ ��������� � ���������� ����� �������,
    // �� �� ���� ���������� ������� ��� ������� (InvalidOperationException)
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
            timer.Tick += Timer_Tick; // ������� �� ���� Tick, ��� ������ ��� ������� ������������� �������
            // ������ �� ����������� �����������, ���� ������� ��������� ������ ������� Start(), �� �� ������ � buttonStart_Click
        }

        private void Timer_Tick(object? sender, EventArgs e) // ��� ��������� UI-������ ��������� ��������  � ����� �����
        {
            if (counter >= 30) // ������� ������� ���� 30 ��������
                timer.Stop();
            else
            {
                counter++;
                listBox1.Items.Add(counter); // ��������� �������� � ListBox (1 2 3 ...)
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            timer.Start(); // ������ �������
            Thread thread = new Thread(PrintLetters); // ��������� ������ ������, ���� ������ ����� PrintLetters
            thread.Start(); // ������ ������
        }
        void PrintLetters()
        {
            for (char c = 'A'; c <= 'Z'; c++)
            {
                // listBox1.Items.Add(c); // ���� ��������� �������, ���� �� ������ �� �������� ����
                // ���������� ����� � ��������������� Invoke() ��� BeginInvoke(), 
                // ��� ��� ����������� � ��������� UI-������

                this.Invoke(new Action(() => // Invoke - ���������� ������, ���� ���� ����������� ��
                {
                    listBox1.Items.Add(c);
                }));
                Thread.Sleep(100); // �������� ��� ��������
            }
        }
    }
}
