using System.Windows.Forms;
namespace Threads_in_WinForms
{
    // при запуску форми створюється головний UI-потік,
    // інші потоки не повинні взаємодіяти з елементами форми напряму,
    // бо це може спричинити помилки або винятки (InvalidOperationException)
    public partial class Form1 : Form
    {
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer(); // таймер для оновлення інтерфейсу (програмно створили)
        int counter = 0;
        public Form1()
        {
            InitializeComponent();

            listBox1.MultiColumn = true;
            listBox1.HorizontalScrollbar = true;
            timer.Interval = 100; // інтервал у мілісекундах
            timer.Tick += Timer_Tick; // підписка на подію Tick, яка виникає при кожному спрацьовуванні таймера
            // таймер не запускається автоматично, його потрібно запускати вручну методом Start(), ми це робимо у buttonStart_Click
        }

        private void Timer_Tick(object? sender, EventArgs e) // для головного UI-потоку ымытували затримку  у виводі чисел
        {
            if (counter >= 30) // зупинка таймера після 30 оновлень
                timer.Stop();
            else
            {
                counter++;
                listBox1.Items.Add(counter); // додавання елемента у ListBox (1 2 3 ...)
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            timer.Start(); // запуск таймера
            Thread thread = new Thread(PrintLetters); // створення нового потоку, який виконує метод PrintLetters
            thread.Start(); // запуск потоку
        }
        void PrintLetters()
        {
            for (char c = 'A'; c <= 'Z'; c++)
            {
                // listBox1.Items.Add(c); // може викликати помилку, якщо це робить не головний потік
                // Правильний спосіб — використовувати Invoke() або BeginInvoke(), 
                // щоб код виконувався у головному UI-потоці

                this.Invoke(new Action(() => // Invoke - синхронний виклик, чекає поки завершиться дія
                {
                    listBox1.Items.Add(c);
                }));
                Thread.Sleep(100); // Затримка для наочності
            }
        }
    }
}
