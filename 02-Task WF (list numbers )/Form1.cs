using System.Threading.Tasks;

namespace _02_Task_WF__list_numbers__
{
    public partial class Form1 : Form
    {
        List<int> numbers = new List<int>();
        Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private async void  button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            button1.Enabled = false;

            var task = LongCalculationAsync(); // Запуск тривалої операції, не блокує UI, бо використовується await (запускається асинхронно)
            for (int i = 0; i < 100; i++)
            {
                listBox1.Items.Add(rnd.Next(1, 1000)); // Додавання випадкових чисел до ListBox
                await Task.Delay(50); // Імітація тривалої операції, не блокує UI, бо використовується await
            }
            int result = await task; // Очікування завершення тривалої операції
            MessageBox.Show($"Операція завершена! Результат: {result}");
            button1.Enabled = true; 
        }
        private async Task<int> LongCalculationAsync()
        {
            await Task.Delay(3000); // симуляція довгої операції
            return 12345; // 12345 - результат тривалої операції (int)
        }
    }
}
/*
 [Користувач натискає Start]
       │
       ▼
buttonStart_Click() запускає LongCalculationAsync()
       │
       ▼
LongCalculationAsync() -> await Task.Delay(3000) 
       │
       ├─ UI може оновлювати ListBox, можуть працювати кнопки
       │
       ▼
Через 3 сек Task завершився
       │
       ▼
await task -> отримує результат 12345
       │
       ▼
MessageBox.Show("Результат: 12345")

 
 */