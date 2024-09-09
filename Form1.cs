using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics.Eventing.Reader;

namespace EditorTexto
{
    public partial class Form1 : Form
    {
        string archivo; 
        public Form1()
        {
            InitializeComponent();
        }

        private void abrilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();

            openFile.Filter = "Texto  | *.txt ";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                archivo = openFile.FileName;

                using (StreamReader sr = new StreamReader(archivo))
                {
                    richTextBox1.Text = sr.ReadToEnd();

                }
            }


        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();

            saveFile.Filter = "Texto |*.txt ";
            
            if (archivo != null)
            {
                using (StreamWriter sw = new StreamWriter(archivo)) 
                {
                    sw.Write(richTextBox1.Text);
                }
                
            }
            else
            {
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    archivo= saveFile.FileName;
                    using (StreamWriter sw = new StreamWriter(saveFile.FileName))

                    {
                        sw.Write(richTextBox1.Text); 
                    }
                }
            
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            archivo = null;


        }
    }
}
