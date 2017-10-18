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
using System.IO.Ports;

namespace WiF
{

    

    public partial class Form1 : Form
    {




        public Form1()
        {
            InitializeComponent();
            fileName();
            color(0);
            comboBox1.Items.AddRange(portnames);

            
        }

        public void color(int colorWin)
        {
            switch (colorWin)
            {
                case (0): this.BackColor = Color.Gray; toolStrip1.BackColor = Color.Gray; toolStrip2.BackColor = Color.Gray; toolStrip3.BackColor = Color.Gray; break;
                case (1): this.BackColor = Color.Red; toolStrip1.BackColor = Color.Red; toolStrip2.BackColor = Color.Red; toolStrip3.BackColor = Color.Red; break;
                case (2): this.BackColor = Color.Green; toolStrip1.BackColor = Color.Green; toolStrip2.BackColor = Color.Green; toolStrip3.BackColor = Color.Green; break;
                case (3): this.BackColor = Color.Blue; toolStrip1.BackColor = Color.Blue; toolStrip2.BackColor = Color.Blue; toolStrip3.BackColor = Color.Blue; break;
                case (4): this.BackColor = Color.White; toolStrip1.BackColor = Color.White; toolStrip2.BackColor = Color.White; toolStrip3.BackColor = Color.White; break;
            }
        }
        public string[] gameName = new string[4];
        public void fileName( )
        {
            toolStripTextBox1.Text = File.ReadAllText("namea.cfg") ;
            toolStripTextBox2.Text = File.ReadAllText("nameb.cfg") ;
            toolStripTextBox3.Text = File.ReadAllText("namec.cfg") ;
            toolStripTextBox4.Text = File.ReadAllText("named.cfg") ;
        }
        public void vinEcho(int i=0)
        {
            switch (i)
            {
                case (0): color(4); label1.Text = ""; label2.Text = ""; label3.Text = ""; break;
                case (1): color(1); label1.Text = "Победила команда:"; label2.Text = toolStripTextBox1.Text; label3.Text = "Поздравляем!"; progressBar1.Value = 100; break;
                case (2): color(2); label1.Text = "Победила команда:"; label2.Text = toolStripTextBox2.Text; label3.Text = "Поздравляем!"; progressBar1.Value = 100; break;
                case (3): color(3); label1.Text = "Победила команда:"; label2.Text = toolStripTextBox3.Text; label3.Text = "Поздравляем!"; progressBar1.Value = 100; break;
                case (4): color(4); label1.Text = "Победила команда:"; label2.Text = toolStripTextBox4.Text; label3.Text = "Поздравляем!"; progressBar1.Value = 100; break;
            }
        }
        public string[] portnames = SerialPort.GetPortNames();

        public string selectedState = " ";

        public void dataWiF()
        {
            SerialPort port = new SerialPort(selectedState, 9600, Parity.None, 8, StopBits.One);
            port.Open();
            toolStripLabel6.Text = "Подключено.";
            var lineS = port.ReadLine().Trim();
            port.Close();
                connected(lineS);
            //MessageBox.Show("Выбранный порт не отвечает...");
            
            //dataWiF();
        }

        public void connected(string line)
        {
            
            switch (line)
            {
                case "CMD0": vinEcho(0); color(0); dataWiF(); progressBar1.Value = 0; break;
                case "CMD1": vinEcho(1); color(1); progressBar1.Value = 100; break;
                case "CMD2": vinEcho(2); color(2); progressBar1.Value = 100; break;
                case "CMD3": vinEcho(3); color(3); progressBar1.Value = 100; break;
                case "CMD4": vinEcho(4); color(4); progressBar1.Value = 100; break;
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            vinEcho();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            toolStripLabel6.Text = "Подключение...";
            progressBar1.Value = 5;
            vinEcho();
            if (selectedState == " ")
            {
                MessageBox.Show("Порт не выбран... или драйвер не установлен.\n Пойми %USERNAME%, тебе нужно установить драйвер\n Если никто его не удалил");
            }
            else
            {
                color(0);
                dataWiF();
                
            }
            
        }

        private void toolStrip3_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripLabel6_Click(object sender, EventArgs e)
        {

        }
        
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            
            for(int i=0; i<=4; i++)
            {
                switch (i)
                {
                    
                    case (1): File.WriteAllText("namea.cfg", toolStripTextBox1.Text); break;
                    case (2): File.WriteAllText("nameb.cfg", toolStripTextBox2.Text); break;
                    case (3): File.WriteAllText("namec.cfg", toolStripTextBox3.Text); break;
                    case (4): File.WriteAllText("named.cfg", toolStripTextBox4.Text); break;
                }
                }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripTextBox2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox3_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            toolStripTextBox1.Text = "";
            toolStripTextBox2.Text = "";
            toolStripTextBox3.Text = "";
            toolStripTextBox4.Text = "";

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            fileName();
        }

        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            vinEcho();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
                selectedState = comboBox1.SelectedItem.ToString(); 

        }
    }
}

