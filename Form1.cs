using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.IO;

namespace CRUD_Operations
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_view_Click(object sender, EventArgs e)
        {
            string file = "D:\\Repository\\CRUD_Operations\\StudentsFile.txt";
            string readText =File.ReadAllText(file);
            if(readText != "")
            {
                MessageBox.Show("Student Found:\n " + readText, "Found");
            }
            else
            {
                MessageBox.Show("No Records Found:\n ", "Found");
            }
        }

        private void btn_Insert_Click(object sender, EventArgs e)
        {
            string file = "D:\\Repository\\CRUD_Operations\\StudentsFile.txt";
            string name = txt_Name.Text;
            string rollNo = txt_rollNo.Text;

            using(StreamWriter writer = new StreamWriter(file,true))
            {
                writer.WriteLine(name + "," + rollNo);//John,123
            }

            MessageBox.Show("Student Data\n Name: " + name + "\nRoll No: " + rollNo + "\nInserted Successfully...", "Student Data", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            string file = "D:\\Repository\\CRUD_Operations\\StudentsFile.txt";
            string name = txt_Name.Text;
            string rollNo = txt_rollNo.Text;

            if(File.Exists(file))
            {
                var lines = File.ReadAllLines(file);
                var LineToUpdate = lines.FirstOrDefault(Line => Line.StartsWith(Name + ","));

                if(LineToUpdate != null)
                {
                    var UpdatedLine = name + "," + rollNo;

                    lines[Array.IndexOf(lines, UpdatedLine)] = UpdatedLine;

                    File.WriteAllLines(file, lines);
                    MessageBox.Show("Student Record Updated Successfully...", "Update Record");
                }
                else
                {
                    MessageBox.Show("Student Not Found...", "Not Found");
                }
            }
            else
            {
                MessageBox.Show("File Not Exist...", "Error");
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            string file = "D:\\Repository\\CRUD_Operations\\StudentsFile.txt";

            if (File.Exists(file))
            {
                if(file != null)
                {
                    File.WriteAllText(file, string.Empty);
                    MessageBox.Show("File Contents Deleted Successfully...", "Deletion Succesfull");
                }
                else
                {
                    MessageBox.Show("File is Already Empty...", "Already Empty");
                }
            }
            else
            {
                MessageBox.Show("File Not Exist...", "Error");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
