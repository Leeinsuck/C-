using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _0524메모장원본
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "텍스트 파일 (*.txt) | *.txt";

            if (sfd.ShowDialog() == DialogResult.OK)

            {


                FileStream fs = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write);

                StreamWriter sw = new StreamWriter(fs);

                sw.WriteLine(textBox1.Text); // 파일 저장
                sw.Close();




            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //파일오픈창 생성 및 설정
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "파일 오픈창";
            ofd.FileName = "";
            ofd.Filter = "텍스트 파일 (*.txt) | *.txt";

            //파일 오픈창 로드
            DialogResult dr = ofd.ShowDialog();

            //OK버튼 클릭시
            if (dr == DialogResult.OK)
            {

                //프로퍼티
                //File명만 뽑는다
                string fileNamel = ofd.SafeFileName.Substring(0, ofd.SafeFileName.Length - 4);
                StreamReader sr = new StreamReader(ofd.FileName, Encoding.UTF8);

                int position = ofd.FileName.LastIndexOf("\\");

                string textFileName = ofd.FileName.Substring(position + 1);

                this.Text = textFileName + " - Libo메모장";

                //출력 로직

                textBox1.Text = sr.ReadToEnd();
                sr.Close();


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            textBox1.Font = fontDialog1.Font;
            textBox1.ForeColor = fontDialog1.Color;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2(this);
            //FrmFind f = new FrmFind();

            f.Show();
        }
    }
}
