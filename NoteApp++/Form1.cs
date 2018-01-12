using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteApp__
{
    public partial class frmMain : Form
    {
        string OurFilename = null;
        

        void Save(string filename)
        {
            OurFilename = filename;
            textBox.SaveFile(filename);
        }

        void SaveAs()
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Save(saveFileDialog1.FileName);
            }
        }

        

        public frmMain()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Undo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Cut();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Paste();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Clear();
        }

        bool CheckChanges()
        {
            return true;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CheckChanges())
            {
                //opens file dialog and waits for user to click OK button
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    //LoadFile loads the text in a .txt file into the ritch text box
                    textBox.LoadFile(openFileDialog1.FileName);
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(OurFilename))
            {
                SaveAs();
            }
            else
            {
                Save(OurFilename);
            }
           
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
             //open form for find and replace text function
        }

        private void sceneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string interior = "\n \t Int. 'LOCATION' ";
            foreach (var item in interior)
            {
                textBox.Text += item;
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            //finds all words in the richtextBox, selects first occurance
            textBox.Find(txtFindBox.Text);
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            //replaces all occurances of text in the txtFindBox and replaces them 
            //with the text in the txtReplaceBox
           textBox.Text = textBox.Text.Replace(txtFindBox.Text, txtReplaceBox.Text);
        }

        private void dialogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string interior = "\n \t 'Character': 'Dialog' ";
            foreach (var item in interior)
            {
                textBox.Text += item;
            }
        }
    }
}
