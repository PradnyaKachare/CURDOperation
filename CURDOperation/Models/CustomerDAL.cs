using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CURDOperation.Models
{
    public class CustomerDAL
    {
        private readonly IConfiguration configuration;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public CustomerDAL(IConfiguration configuration)
        {
            this.configuration = configuration;
            string str = this.configuration.GetConnectionString("defaultConnection");
            con = new SqlConnection(str);
        }
        public int CustomerResister(Customers cust)
        {           
            string qry = "insert into Customers values(@name,@email,@contact,@pass)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", cust.Name);
            cmd.Parameters.AddWithValue("@email", cust.Email);
            cmd.Parameters.AddWithValue("@contact", cust.Contact);
            cmd.Parameters.AddWithValue("@pass", cust.Password);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public Customers CustomerLogin(Customers cust)
        {
            Customers c = new Customers();
            string qry = "select * from Customers where email=@email and password=@pass";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@email", cust.Email);
            cmd.Parameters.AddWithValue("@pass", cust.Password);
            con.Open();
            dr = cmd.ExecuteReader();          
            if (dr.HasRows)
            {
                if (dr.Read())
                {
                    c.Id = Convert.ToInt32(dr["id"]);
                    c.Name = dr["name"].ToString();
                    c.Email = dr["email"].ToString();
                }
                return c;
            }
            else
            {
                return null;
            }
            
        }
        
    }    
}
