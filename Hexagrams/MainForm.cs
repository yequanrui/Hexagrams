using System;
using System.Drawing;
using System.Windows.Forms;

namespace Hexagrams
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        string strSQL = "";
        Random rm = new Random();
        int[] intArr = new int[6];
        Button[] btnArr = new Button[6];
        string str = "";

        private void MainForm_Load(object sender, EventArgs e)
        {
            btnArr[0] = button1;
            btnArr[1] = button2;
            btnArr[2] = button3;
            btnArr[3] = button4;
            btnArr[4] = button5;
            btnArr[5] = button6;
            for (int i = 0; i < 6; i++)
            {
                btnArr[i].ForeColor = Color.Red;
                btnArr[i].Text = "?";
            }
        }

        private int GetGM()
        {
            int bh = rm.Next(2);
            return bh;
        }

        private void CalcBtn_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            str = "";
            for (int i = 0; i < 6; i++)
            {
                intArr[i] = GetGM();

                if (intArr[i] == 0)
                {
                    btnArr[i].Text = "阳";
                    btnArr[i].ForeColor = Color.Red;
                }
                else
                {
                    btnArr[i].Text = "阴";
                    btnArr[i].ForeColor = Color.Blue;
                }
                str += intArr[i];
            }
            // MessageBox.Show(str);
            strSQL = "select content from hexagrams where code='" + str + "'";
            string temp = oledbConn.GetSingle(strSQL).ToString();
            foreach (Char c in temp.ToCharArray())
            {
                if (c == ' ')
                {
                    richTextBox1.Text += "\n";
                }
                richTextBox1.Text += c;
            }
        }


        private void ResetBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 6; i++)
            {
                btnArr[i].Text = "?";
                btnArr[i].ForeColor = Color.Red;
            }
            richTextBox1.Text = "";
            str = "";
        }
    }
}
