using System.Threading.Tasks;

namespace _10_Several_tasks_WF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.ReadOnly = true; // ������ textBox1 ���� ��� �������
            textBox1.Multiline = true; // ���������� �������������� ��� � textBox1
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            Task<int> taskLen = Task.Run(() => richTextBox1.Text.Length);// �������� ��� ������ ������� �����
            Task<int> taskWordCount = Task.Run(() => CountWords(richTextBox1.Text)); // �������� ��� ��������� ���
            Task<int> taskLines = Task.Run(() => richTextBox1.Lines.Length); // �������� ��� ���������  ����� �����
            
            await Task.WhenAll(taskLen, taskWordCount, taskLines); // ������� ���������� ��� �������
            
            textBox1.Text = $"Length: {taskLen.Result}\r\nWord count: {taskWordCount.Result}";
            textBox1.AppendText($"\r\nLines: {taskLines.Result}\r\n"); 
        }
       

        private int CountWords(string text)
        {
            return text.Split(", !?-:;.\t\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
}
