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

namespace DrzewoDecyzyjne
{
    public partial class Form1 : Form
    {
        private bool fileOpened;
        private Dictionary<int,CDrzewo> drzewo;
        public Form1()
        {
            InitializeComponent();
        }

        private void otwórzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog myDialog = new OpenFileDialog();
            if (myDialog.ShowDialog() == DialogResult.OK)  
            {
                try
                {

                    Stream myStream = myDialog.OpenFile();
                    fileOpened = false;
                    if (myStream != null)
                    {
                        using (myStream)
                        {
                            byte[] tab = new byte[myStream.Length];
                            myStream.Read(tab,0,(int)myStream.Length);
                            String s = UTF8Encoding.UTF8.GetString(tab);
                            richTextBox1.Text = s;
                            toolStripStatusLabel1.Text = myDialog.FileName;
                            fileOpened = true;
                        }
                    }
                    myStream.Close();
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Error with reading a file");
                    MessageBox.Show(ex.Message);
                    //throw ex;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fileOpened = false;
            drzewo = new Dictionary<int, CDrzewo>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            drzewo.Clear();
            try
            {
                MakeTree(richTextBox1.Text);
                if (fileOpened == true)
                {
                    //if (TestTree(1) == -1) throw new Exception("Bład w drzewie");

                    TestTree(1);
                    ExecuteTree();
                }
                else
                {
                    MessageBox.Show("Najpierw otwórz plik");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
            

        }
        private int TestTree(int id)
        {
            if (id == 0) return 0;

            if (!drzewo.ContainsKey(id)) throw new Exception("Nie znaleziono klucza o id: " + id);
            TestTree(drzewo[id].odpTak);
            TestTree(drzewo[id].odpNie);
            //if (TestTree(drzewo[id].odpTak) == -1 || TestTree(drzewo[id].odpNie) == -1) return -1;
            return 0;


            
        }
        private void ExecuteTree()
        {
            int id=1;
            while(true)
            {
                DialogResult result = MessageBox.Show(drzewo[id].Tekst, drzewo[id].Tytul, MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    id = drzewo[id].odpTak;
                }
                else if (result == DialogResult.No)
                {
                    id = drzewo[id].odpNie;
                }
                if (drzewo[id].odpNie == 0 || drzewo[id].odpTak == 0)
                {
                    MessageBox.Show(drzewo[id].Tekst);
                    break;
                }
            }

        }
        private void MakeTree(String s)
        {
            if (s.Length > 0)
            {
                List<String> lista = new List<string>();
                using(StringReader reader = new StringReader(s))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if(line != "") lista.Add(line);
                    }
                }
                foreach (string item in lista)
                {
                    string[] items = item.Split('|');
                    if(items.Length<5)
                    {
                        //MessageBox.Show("Złe formatownaie pliku");
                        throw new Exception("Zle formatownaie pliku: " + item);
                    }
                    int id = Convert.ToInt32(items[0]);
                    int tak = Convert.ToInt32(items[1]);
                    int nie = Convert.ToInt32(items[2]);
                    if (drzewo.ContainsKey(id)) throw new Exception("Wezel o id: " + id + " juz istnieje!");
                    drzewo.Add(id, new CDrzewo(id,tak,nie,items[3],items[4])); 

                }

            }
        }
    }
}
