using System.Threading.Tasks;

namespace _10_Several_tasks_WF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.ReadOnly = true; // Робимо textBox1 лише для читання
            textBox1.Multiline = true; // Дозволяємо багаторядковий ввід у textBox1
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            Task<int> taskLen = Task.Run(() => richTextBox1.Text.Length);// Завдання для показу довжини рядка
            Task<int> taskWordCount = Task.Run(() => CountWords(richTextBox1.Text)); // Завдання для підрахунку слів
            Task<int> taskLines = Task.Run(() => richTextBox1.Lines.Length); // Завдання для підрахунку  числа рядків
            
            await Task.WhenAll(taskLen, taskWordCount, taskLines); // Очікуємо завершення усіх завдань
            
            textBox1.Text = $"Length: {taskLen.Result}\r\nWord count: {taskWordCount.Result}";
            textBox1.AppendText($"\r\nLines: {taskLines.Result}\r\n"); 
        }
       

        private int CountWords(string text)
        {
            return text.Split(", !?-:;.\t\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
}
