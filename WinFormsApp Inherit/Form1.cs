using HelloWF;

namespace WinFormsApp_Inherit
{
    public partial class Form2 : Form1 // ������������� �� Form1 � ������ ������� HelloWF, ���������� ������� ��������� �� ������ HelloWF (Dependencies -Add Project Reference ...)
    {
        public Form2()
        {
            InitializeComponent();
            this.Text = "Form2";
            this.button1.Text = "Form2 Button1"; // �� ������ ����������� � Form1, ������� �� ���������� (����� �� ������)
            this.button2.BackColor = Color.Aqua; // �� ������ ��� ����������� � Form1, ������� �� ���������� (���� ������)
            this.Controls[0].BackColor = Color.LightCoral; // ������� ���� ������� �������� �� ���� (�� button1)
        }
    }
}
