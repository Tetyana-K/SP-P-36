namespace Stop_thread__WinForms_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Thread thread1;

        private CancellationTokenSource cts1;
        private ManualResetEventSlim pauseEvent = new ManualResetEventSlim(true); // ��� �����/�����������
        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.MultiColumn = true;
        }
        private void PrintLetters(object obj)
        {
            CancellationToken token = (CancellationToken)obj;
            for (char c = 'A'; c <= 'Z'; c++)
            {
                if (token.IsCancellationRequested) // ��������, �� ���� �������� ����������
                {
                    break; // ����� � �����, ���� ���������� ���������
                }
                pauseEvent.Wait(); // ���� "Pause", ��� ���� ������
                this.Invoke(new Action(() => // ������ ������ ����� � ListBox
                {
                    listBox1.Items.Add(c);
                }));
                Thread.Sleep(200); // �������� ��� ��������
            }
            
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (cts1 != null) // ���� ��� � ��������� ����, ��� ��������
            {
                cts1.Cancel();       // ��������� ��������� ����
                pauseEvent.Set();    // ��� ������ �� ����� � ����������
            }
            listBox1.Items.Clear();
            cts1 = new CancellationTokenSource();
            thread1 = new Thread(PrintLetters);
            thread1.Start(cts1.Token); // �������� ����� � ����
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            cts1.Cancel(); // ����� �� ����������
            pauseEvent.Set(); // �� �������, ���� ���� �� ����, ���������� ���� ���������� � �����������
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            pauseEvent.Reset(); // ������ ����� (�� ���������� ����), ���� ����������
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            pauseEvent.Set(); // ���������� (���������� ����), ���� ���������� ������
        }
    }
}
