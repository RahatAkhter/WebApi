using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1.Controllers
{
    public class SaveDataController : ApiController
    {
        [HttpGet]
        public string Save(string name)
        {
            string con1 = System.Configuration.ConfigurationManager.ConnectionStrings["DBMS"].ConnectionString;
            SqlConnection con = new SqlConnection(con1);
            SqlCommand cmd = new SqlCommand(@"insert into abc values(@name)", con);
            cmd.Parameters.AddWithValue("@name",name);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
            return "Save Successfully";


        }
        [HttpGet]
        public string Save1(string edit)
        {
            string con1 = System.Configuration.ConfigurationManager.ConnectionStrings["DBMS"].ConnectionString;
            SqlConnection con = new SqlConnection(con1);
            SqlCommand cmd = new SqlCommand(@"insert into abc values(@name)", con);
            cmd.Parameters.AddWithValue("@name", edit);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
            return "Edit Successfully";


        }

        [HttpGet]
        public string GetAllData()
        {
            string mycon = System.Configuration.ConfigurationManager.ConnectionStrings["DBMS"].ConnectionString;

            String myquery = "Select * from abc";
            SqlConnection con = new SqlConnection(mycon);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = myquery;
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            //DataTable firstTable = ds.Tables[0];
            return ds.GetXml();



        }

        private static DataTable getprint()
        {

            string con1 = System.Configuration.ConfigurationManager.ConnectionStrings["DBMS"].ConnectionString;
            SqlConnection conn = new SqlConnection(con1);
            SqlCommand cmd = new SqlCommand(@"Select * from abc", conn);
            // cmd.Parameters.AddWithValue("@date", SqlDbType.Date).Value = date;
            
            conn.Open();
            DataTable dt = new DataTable();
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            dr.Close();
            conn.Close();

            return dt;

        }


    }
}

public class abc
{
    public string name { get; set; }
}