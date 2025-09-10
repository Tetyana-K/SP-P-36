using HelloWF;

namespace WinFormsApp_Inherit
{
    public partial class Form2 : Form1 // успадкувалися від Form1 з іншого проекту HelloWF, попередньо додавши посилання на проект HelloWF (Dependencies -Add Project Reference ...)
    {
        public Form2()
        {
            InitializeComponent();
            this.Text = "Form2";
            this.button1.Text = "Form2 Button1"; // ця кнопка успадкована з Form1, змінюємо її властивості (напис на кнопці)
            this.button2.BackColor = Color.Aqua; // ця кнопка теж успадкована з Form1, змінюємо її властивості (колір кнопки)
            this.Controls[0].BackColor = Color.LightCoral; // змінюємо колір першого контролу на формі (це button1)
        }
    }
}
