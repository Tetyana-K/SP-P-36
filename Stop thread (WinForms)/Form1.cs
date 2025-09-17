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
        private ManualResetEventSlim pauseEvent = new ManualResetEventSlim(true); // для паузи/продовження
        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.MultiColumn = true;
        }
        private void PrintLetters(object obj)
        {
            CancellationToken token = (CancellationToken)obj;
            for (char c = 'A'; c <= 'Z'; c++)
            {
                if (token.IsCancellationRequested) // перевірка, чи було запитано скасування
                {
                    break; // вихід з циклу, якщо скасування запрошено
                }
                pauseEvent.Wait(); // якщо "Pause", тут потік зависає
                this.Invoke(new Action(() => // інакше додаємо букву у ListBox
                {
                    listBox1.Items.Add(c);
                }));
                Thread.Sleep(200); // Затримка для наочності
            }
            
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (cts1 != null) // якщо вже є запущений потік, для рестарту
            {
                cts1.Cancel();       // скасувати попередній потік
                pauseEvent.Set();    // щоб вийшов із паузи і завершився
            }
            listBox1.Items.Clear();
            cts1 = new CancellationTokenSource();
            thread1 = new Thread(PrintLetters);
            thread1.Start(cts1.Token); // передаємо токен у потік
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            cts1.Cancel(); // запит на скасування
            pauseEvent.Set(); // на випадок, якщо потік на паузі, дозволяємо йому продовжити і завершитись
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            pauseEvent.Reset(); // робимо паузу (не сигнальний стан), потік зупиниться
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            pauseEvent.Set(); // продовжуємо (сигнальний стан), потік продовжить роботу
        }
    }
}
