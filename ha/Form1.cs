using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ha
{
    
    public partial class Form1 : Form
    {
        //الطالب /حمزة عبد الرحمن محمد 
        //قسم /cs
        //الفرقة الثالثة سيكشن /1

        int count=0; Timer T = new Timer();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //OpenFileDialog f = new OpenFileDialog();
            ////f.Filter = "JPG|.jpg|JPEG|.jpeg|GIF|.gif|PNG|.png";

            //// f.Filter = "JPEG Files (.jpg)|.jpg|PNG Files (.png)|.png|BMP Files (.bmp)|.bmp|All files (.)|.";
            //f.Filter = "JPEG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|BMP Files (*.bmp)|*.bmp|All files (*.*)|*.*";
            //f.Multiselect = true;
            //if (f.ShowDialog() == DialogResult.OK)
            //{
            //    foreach (string filename in f.FileNames)
            //    {
            //        listBox1.Items.Add(filename);
            //    }
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Multiselect = true;
            of.Filter = "JPG|*.jpg|JPEG|*.jpeg|GIF|*.gif|PNG|*.png";
            if (of.ShowDialog() == DialogResult.OK)
            {
               
                foreach (string filename in of.FileNames)
                {
                    listBox1.Items.Add(filename);
                }

                
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //panel1.Controls.Clear();

            string t = listBox1.SelectedItems.ToString();
            PictureBox pic = new PictureBox();



            pic.Size = panel1.Size;
            pic.SizeMode = PictureBoxSizeMode.StretchImage;

            foreach (String f in  listBox1.SelectedItems)
            {
                panel1.Controls.Clear();
                pic.Image = Image.FromFile(f);
                this.panel1.Controls.Add(pic);
   
            }
            

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            /*string t = listBox1.SelectedItems.ToString();
            PictureBox pic = new PictureBox();



            pic.Size = panel1.Size;
            pic.SizeMode = PictureBoxSizeMode.StretchImage;

            foreach (String f in listBox1.SelectedItems)
            {
                panel1.Controls.Clear();
                pic.Image = Image.FromFile(f);
                this.panel1.Controls.Add(pic);

            }
            */
        }

        private void singleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            string t = listBox1.SelectedItems.ToString();
            PictureBox pic = new PictureBox();



            pic.Size = panel1.Size;
            pic.SizeMode = PictureBoxSizeMode.StretchImage;

            foreach (String f in listBox1.SelectedItems)
            {
                panel1.Controls.Clear();
                pic.Image = Image.FromFile(f);
                this.panel1.Controls.Add(pic);

            }

        }

        private void multiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            //f.Multiselect = true;
            int x = panel1.Location.X + 20;
            int y = panel1.Location.Y + 15;
            int MH = -1;
            foreach (string im in listBox1.SelectedItems)
            {
                PictureBox pic = new PictureBox();
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                pic.Image = Image.FromFile(im.ToString());

                pic.Location = new Point(x, y);
                x += pic.Width + 10;
                MH = Math.Max(pic.Height, MH);
                if (x > this.ClientSize.Width - 100)
                {
                    x = 20;
                    y = MH + 30;

                }
                panel1.Controls.Add(pic);


            }
        }

        private void slideShowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            //            picImg.Image = Image.FromFile(lstImgs.SelectedItem.ToString());


            T.Interval = 100;
            T.Tick += new EventHandler(WithTime);
            T.Start();
          
        }
        void WithTime(object sender, EventArgs e)
        {


            ListBox list = new ListBox();
           // hamza
            PictureBox picTT = new PictureBox();
           picTT.Image = Image.FromFile(listBox1.Items[count].ToString());
           picTT.Size = panel1.Size;
           picTT.SizeMode = PictureBoxSizeMode.StretchImage;

            if (count == listBox1.Items.Count - 1)
            {
                count = 0;
                T.Stop();
            }
             count++;
            panel1.Controls.Clear(); 
            panel1.Controls.Add(picTT);
           
            picTT.Image.Equals(null);
            string t = listBox1.Items[count].ToString();
            string fileName = System.IO.Path.GetFileName(t);
            textBox1.Text = fileName;


        }

        private void statusBar1_PanelClick(object sender, StatusBarPanelClickEventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
