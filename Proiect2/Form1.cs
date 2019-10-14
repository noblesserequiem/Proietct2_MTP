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
using System.Diagnostics;

namespace Proiect2
{
    
    public partial class Form1 : Form
    {
        private TreeNode parentNode_1 = new TreeNode();
        private TreeNode parentNode_2 = new TreeNode();
        private TreeNode parentNode_3 = new TreeNode();
        private TreeNode parentNode_4 = new TreeNode();
        private int index = -1;
        List<Persoana> lista = new List<Persoana>();

        
        StreamWriter sw = new StreamWriter(Application.StartupPath.ToString() + "\\lista.txt", false);



        public Form1()
        {
            InitializeComponent();
            parentNode_1.Name = "node_prieteni";
            parentNode_1.Text = "Prieteni";
            
            parentNode_2.Name = "node_colegi";
            parentNode_2.Text = "Colegi";
            
            parentNode_3.Name = "node_rude";
            parentNode_3.Text = "Rude";
            
            parentNode_4.Name = "node_diversi";
            parentNode_4.Text = "Diversi";
            treeView1.Nodes.Add(parentNode_1);
            treeView1.Nodes.Add(parentNode_2);
            treeView1.Nodes.Add(parentNode_3);
            treeView1.Nodes.Add(parentNode_4);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            index++;
            Persoana obj = new Persoana(index, textBox1.Text, dateTimePicker1.Value, textBox2.Text, textBox3.Text, (Categorie)comboBox1.SelectedIndex);
            lista.Add(obj);
            propertyGrid1.SelectedObject = obj;
            TreeNode childNode = new TreeNode();
            childNode.Name = obj.Nume;
            childNode.Text = textBox1.Text;
            if (comboBox1.SelectedIndex == 0)
                parentNode_1.Nodes.Add(childNode);
            else if(comboBox1.SelectedIndex == 1)
                parentNode_2.Nodes.Add(childNode);
            else if(comboBox1.SelectedIndex == 2)
                parentNode_3.Nodes.Add(childNode);
            else
                parentNode_4.Nodes.Add(childNode);
            
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            foreach(Persoana p in lista)
            {
                if(String.Equals(p.Nume, treeView1.SelectedNode.Text))
                {
                    propertyGrid1.SelectedObject = p;
                    break;

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Persoana p in lista)
            {
                if (String.Equals(p.Nume, textBox4.Text))
                {
                    propertyGrid1.SelectedObject = p;
                    if (MessageBox.Show("Doriti sa stergeti persoana [" + p.Nume + "] ?", "Intrebare",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        lista.RemoveAt(p.Index);
                        TreeNode[] tns = treeView1.Nodes.Find(p.Nume, true);
                        treeView1.SelectedNode = tns[0];
                        treeView1.Nodes.Remove(treeView1.SelectedNode);
                        break;
                    }
                } 
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach(Persoana p in lista)
            {
                sw.WriteLine("\r\n----------------------------------\r\nNume: " + p.Nume + "\r\nCategorie: "
     + p.Categorie + "\r\nData Nasterii: " + p.Data + "\r\nTelefon: " + p.Telefon + "\r\nAdresa: " + p.Adresa);

            }
            sw.Close();
            Process.Start("notepad.exe", Application.StartupPath.ToString() + "\\lista.txt");
        }
    }
}
