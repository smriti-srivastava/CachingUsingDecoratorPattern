using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CachingUsingDecoratorPattern
{
    class SQLProductRepository : IRepository
    {
        private SqlConnection con;
        private void connection()
        {
            string constr = @"Data Source=TAVDESK149;Initial Catalog=ProductDatabase;User Id=sa;Password=test123!@#";
            con = new SqlConnection(constr);

        }
        public List<Product> GetAllProducts()
        {
            connection();
            List<Product> productList = new List<Product>();
            string query = "SELECT * FROM Product";
            SqlCommand command = new SqlCommand(query, con)
            {
                CommandType = CommandType.Text
            };
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                productList.Add(
                    new Product
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Name = Convert.ToString(dr["Name"]),
                        Price = (float)Convert.ToDouble(dr["Price"])
                    }
                );

            }
            return productList;
        }

        public Product GetProductById(int id)
        {
            connection();
            List<Product> productList = new List<Product>();
            string query = "SELECT * FROM Product where Id=" + id;
            SqlCommand command = new SqlCommand(query, con)
            {
                CommandType = CommandType.Text
            };
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                productList.Add(
                    new Product
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Name = Convert.ToString(dr["Name"]),
                        Price = (float)Convert.ToDouble(dr["Price"])
                    }
                );

            }
            return productList[0];
        }
    }
}
