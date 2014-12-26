using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentEntryUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        public string MakeConnection()
        {
            string connection;
            connection = @"SERVER=BITM-401-PC08\SQLEXPRESS;Database = StudentDB;integrated security=true";
            return connection;
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Text;
            string email = emailTextBox.Text;
            string address = addressTextBox.Text;

            
            SqlConnection aConnection = new SqlConnection(MakeConnection());

            string queery = string.Format("INSERT INTO Student_table VALUES('{0}','{1}','{2}')", name, email, address);

            SqlCommand aCommand=new SqlCommand(queery,aConnection);

            aConnection.Open();

            int isDataAffected = aCommand.ExecuteNonQuery();

            aConnection.Close();


            if (isDataAffected>0)
            {
                MessageBox.Show("The data willbe inserted");
            }
            else
            {
                MessageBox.Show("The data will not be inserted");
            }


        }
    }
}
