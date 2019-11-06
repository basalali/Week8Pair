using SSGeek.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SSGeek.Web.DAL
{
    public class ProductSqlDAO : IProductDAO
    {
        private readonly string connectionString;

        public ProductSqlDAO(string connectionString)
        {

            this.connectionString = connectionString;
        }

        public IList<Product> GetProducts()
        {
            IList<Product> products = new List<Product>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT * FROM products";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Product product = new Product();

                        product.Id = Convert.ToInt32(reader["product_id"]);
                        product.Name = Convert.ToString(reader["name"]);
                        product.Description = Convert.ToString(reader["description"]);
                        product.Price = Convert.ToDecimal(reader["price"]);
                        product.ImageName = Convert.ToString(reader["image_name"]);

                        products.Add(product);

                    }
                }
            }
            catch (SqlException)
            {
                products = new List<Product>();
            }

            return products;
        }
        public Product GetProduct(int id)
        {
            Product product = new Product();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT * FROM products WHERE product_id = @id;";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        product = MapRowToProduct(reader);
                    }

                    return product;

                }


            }

            catch (SqlException)
            {
                product = new Product();
            }

            return product;
        }

        private Product MapRowToProduct(SqlDataReader reader)
        {
            Product product = new Product();

            product.Id = Convert.ToInt32(reader["product_id"]);
            product.Name = Convert.ToString(reader["name"]);
            product.Description = Convert.ToString(reader["description"]);
            product.Price = Convert.ToDecimal(reader["price"]);
            product.ImageName = Convert.ToString(reader["image_name"]);

            return product;
        }
    }

}
