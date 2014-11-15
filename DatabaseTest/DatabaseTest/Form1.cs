using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Configuration;
using System.Data.Common;
using DatabaseTestConnectedLayer;

namespace DatabaseTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        enum DataProvider
        {
            SqlServer, OleDb, Odbc, Oracle, None
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //Connection1();
            //Connection2();
            //Connection3();
            Connection4();

        }

        private void Connection4()
        {
            DataSet usersDS = new DataSet("Uzytkonicy");
            DataColumn usr_id = new DataColumn("usr_id", typeof(int));
            usr_id.ReadOnly = true;
            usr_id.AllowDBNull = false;
            usr_id.Unique = true;
            usr_id.Caption = "User ID";
            usr_id.AutoIncrement = true;
            usr_id.AutoIncrementSeed = 5;
            usr_id.AutoIncrementStep = 1;
            DataColumn usr_name = new DataColumn("usr_name", typeof(string));
            DataColumn usr_date = new DataColumn("usr_date", typeof(DateTime));
            DataColumn usr_email = new DataColumn("usr_email", typeof(string));
            DataColumn usr_pass = new DataColumn("usr_pass", typeof(string));
            DataColumn usr_logins = new DataColumn("usr_logins", typeof(int));
            DataTable usersTable = new DataTable("Users");
            usersTable.Columns.AddRange(new DataColumn[] {usr_id, usr_name, usr_date, usr_email, usr_pass, usr_logins });
            DataRow uRow = usersTable.NewRow();
            uRow[1] = "pawe";
            uRow[2] = DateTime.Now;
            uRow[3] = "jaisemial@asda";
            uRow[4] = "haselko";
            uRow[5] = 5;
            usersTable.Rows.Add(uRow);
            usersTable.PrimaryKey = new DataColumn[] { usersTable.Columns[0] };
            usersDS.Tables.Add(usersTable);

            PrintDataSets(usersDS);
        }

        private void PrintDataSets(DataSet ds)
        {
            foreach (DataTable dt in ds.Tables)
            {
                PrintTable(dt);
            }

        }

        private void Connection3()
        {
            string connString = ConfigurationManager.ConnectionStrings["testdb"].ConnectionString;
            DatabaseConnDAL db = new DatabaseConnDAL();
            db.OpenConnection(connString);
            /*Insert(db);
            Show(db);
            Update(db);
            Show(db);
            Delete(db);
            Show(db);*/


        }

        private void Update(DatabaseConnDAL db)
        {
            db.UpdateUser(2, "wojciech");
        }

        private void Delete(DatabaseConnDAL db)
        {
            try
            {
                db.DeleteUser(2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Show(DatabaseConnDAL db)
        {
            DataTable dt = db.GetAllUsers();
            PrintTable(dt);
        }

        private void PrintTable(DataTable dt)
        {
            DataTableReader dr = dt.CreateDataReader();
            string dane = "";
            while (dr.Read())
            {
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    dane += dr.GetValue(i).ToString().Trim() + " ";
                }
                dane += "\n\r";
            }
            MessageBox.Show(dane);
        }

        private void Display(DataTable dt)
        {
            String dane = "";
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                dane += dt.Columns[i].ColumnName.Trim() + "\t";
            }
            dane += "\n\r";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for(int j=0;j<dt.Columns.Count;j++)
                {
                    dane += dt.Rows[i][j].ToString().Trim() + "\t";
                }
                dane += "\n\r";
            }
            MessageBox.Show(dane);
        }

        private void Insert(DatabaseConnDAL db)
        {
            db.InsertUser(4, "adam4", "2012.12.12", "eamil@gmail.com", "tajne", 10);
        }
        void Connection2()
        {
            string connString = ConfigurationManager.ConnectionStrings["testdb"].ConnectionString;
            SqlConnection cn = new SqlConnection(connString);
            cn.Open();
            string query = "Select * from Users";
            SqlCommand cmd = new SqlCommand(query, cn);
            SqlDataReader myDataReader;
            myDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            String dane = "";
            while (myDataReader.Read())
            {
                //dane+=dR[0].ToString() + " " + dR[1] +" " + dR.
                for (int i = 0; i < myDataReader.FieldCount; i++)
                {
                    dane += myDataReader[i].ToString().Trim() + " ";

                }
                dane += "\n\r";

            }
            myDataReader.Close();
            MessageBox.Show(dane);
        }
        void Connection1()
        {
            string provider = ConfigurationManager.AppSettings["provider"];
            string connString = ConfigurationManager.ConnectionStrings["testdb"].ConnectionString;
            DbProviderFactory dbF = DbProviderFactories.GetFactory(provider);
            DbConnection cn = dbF.CreateConnection();
            cn.ConnectionString = connString;
            cn.Open();

            DbCommand cmd = dbF.CreateCommand();
            cmd.Connection = cn;
            cmd.CommandText = "Select * from Users";

            DbDataReader dR = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            String dane = "";
            while (dR.Read())
            {
                //dane+=dR[0].ToString() + " " + dR[1] +" " + dR.
                for (int i = 0; i < dR.FieldCount; i++)
                {
                    dane += dR[i].ToString().Trim() + " ";

                }
                dane += "\n\r";

            }
            MessageBox.Show(dane);

        }

    }

}
