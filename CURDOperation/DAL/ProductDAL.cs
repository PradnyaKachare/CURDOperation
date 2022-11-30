using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CURDOperation.DAL
{
    public class ProductDAL
    {
        private readonly IConfiguration configuration;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public ProductDAL(IConfiguration configuration)
        {
            this.configuration = configuration;
            string str = this.configuration.GetConnectionString("defaultConnection");
            con = new SqlConnection(str);
        }
        public List<Product> GetAllProduct()
        {

            List<Product> prod = new List<Product>();
            cmd = new SqlCommand("select * from Product", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Product p = new Product();
                 //   p.SetId(Convert.ToInt32(dr["id"]));
                  //  p.SetName(dr["name"].ToString());
                    p.Price = Convert.ToDecimal(dr["price"]);
                    prod.Add(p);
                }

            }
            con.Close();
            return prod;
        }

        public Product GetProductById(int id)
        {
            Product p = new Product();
            string qry = "select * from Product where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                   // p.SetId(Convert.ToInt32(dr["id"]));
                   // p.SetName(dr["name"].ToString());
                    p.Price = Convert.ToDecimal(dr["price"]);
                }

            }
            con.Close();
            return p;
        }

        public int AddProduct(Product prod)
        {
            string qry = "insert into Product values(@name,@price)";
            cmd = new SqlCommand(qry, con);
           // cmd.Parameters.AddWithValue("@name", prod.GetName());
            cmd.Parameters.AddWithValue("@price", prod.Price);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

        public int UpdateProduct(Product emp)
        {
            string qry = "update Product set name=@name,price=@price where id=@id";
            cmd = new SqlCommand(qry, con);
          //  cmd.Parameters.AddWithValue("@name", emp.GetName());
            cmd.Parameters.AddWithValue("@price", emp.Price);
           // cmd.Parameters.AddWithValue("@id", emp.GetId());
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

        public int DeleteProduct(int id)
        {
            string qry = "delete from Product where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }
}
