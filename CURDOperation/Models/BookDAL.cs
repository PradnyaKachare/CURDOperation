using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CURDOperation.Models
{
    public class BookDAL
    {
        private readonly IConfiguration configuration;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public BookDAL(IConfiguration configuration)
        {

            this.configuration = configuration;
            string str = this.configuration.GetConnectionString("defaultConnection");
            con = new SqlConnection(str);
        }
       /* public List<Book> GetAllBook()
        {

            List<Book> employees = new List<Book>();
            cmd = new SqlCommand("select * from Book", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Book b = new Book();
                    b.Id = Convert.ToInt32(dr["id"]);
                    b.Name = dr["name"].ToString();
                    b.Price = Convert.ToDecimal(dr["salary"]);
                    employees.Add(emp);
                }

            }
            con.Close();
            return Book;
        }*/
    }
}
