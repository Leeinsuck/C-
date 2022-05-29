using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0524메모장원본
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private Form1 dnn = null;

        public Form2(Form1 objDotnetNote)
        {
            dnn = objDotnetNote;
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!FindText())
            {
                MessageBox.Show(
                    this.txt_Find.Text + "을(를) 찾을 수 없습니다."
                    , "메모장"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Information
                    );
            }
        }
        private bool FindText()
        {
            int nFind;
            int nLen;
            string strTempText;
            string strTempFind;

            if (checkBox1.Checked)
            {
                strTempText = dnn.textBox1.Text; //찾을 대상
                strTempFind = txt_Find.Text; //찾을 단어
            }
            else
            {
                strTempText = dnn.textBox1.Text.ToLower(); //소문자
                strTempFind = txt_Find.Text.ToLower(); //소문자
            }

            nLen = txt_Find.Text.Length; //텍스트 길이

            //위로 / 아래로 검색
            if (radioButton1.Checked)
            {
                if ((dnn.textBox1.SelectionStart - dnn.textBox1.SelectionLength) < 0)
                    nFind = -1;
                else
                    nFind = strTempText.LastIndexOf(
                        strTempFind
                        , dnn.textBox1.SelectionStart
                          - dnn.textBox1.SelectionLength
                          );
            }
            else // 아래로
            {
                nFind = strTempText.IndexOf(
                    strTempFind
                    , dnn.textBox1.SelectionStart
                      + dnn.textBox1.SelectionLength);

            }

            if (nFind == -1)
                return false;
            else
            {
                dnn.textBox1.SelectionStart = nFind;
                dnn.textBox1.SelectionLength = nLen;
                dnn.textBox1.Focus();
                return true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.button1.Enabled = true;
        }
    }
}
