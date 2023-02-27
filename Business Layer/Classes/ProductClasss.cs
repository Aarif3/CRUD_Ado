using Business_Layer.Interface;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Classes
{
    public class ProductClasss : IProducts
    {
        readonly DataContexts db;
        public ProductClasss()
        {
            db= new DataContexts();
        }
        public async Task<List<Product>> GetProduct(Product pro)
        {
            List<Product> products = new List<Product>();
            using (SqlConnection conn = new SqlConnection(db.cs))
            {
                SqlCommand cmd = new SqlCommand("spgetAllProduct", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();

                using (SqlDataReader dr = await cmd.ExecuteReaderAsync())
                {
                    while (dr.Read())
                    {
                        Product p = new Product();
                        p.ProductId = dr.GetFieldValue<int>(0);
                        p.ProductName = dr.GetFieldValue<string>(1);
                        p.ProductDescription = dr.GetFieldValue<string>(2);
                        p.Productprice = dr.GetFieldValue<int>(3);
                        products.Add(p);

                    }
                }
                return products;
            }
        }

        public async Task<bool> CreateProduct(Product pro)
        {
            using (SqlConnection conn = new SqlConnection(db.cs))
            {
                SqlCommand cmd = new SqlCommand("spCreateProduct", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", pro.ProductName);
                cmd.Parameters.AddWithValue("@Description", pro.ProductDescription);
                cmd.Parameters.AddWithValue("@Price", pro.Productprice);
                conn.Open();
                int i = await cmd.ExecuteNonQueryAsync();
                if (i > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public async Task<bool> DeleteProduct(int id)
        {
            using (SqlConnection conn = new SqlConnection(db.cs))
            {
                SqlCommand cmd = new SqlCommand("spDeletproduct", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                int i =await cmd.ExecuteNonQueryAsync();
                if (i > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public async Task<bool> EditProduct(Product pro)
        {
            using (SqlConnection conn = new SqlConnection(db.cs))
            {
                SqlCommand cmd = new SqlCommand("spEditproduct", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", pro.ProductId);
                cmd.Parameters.AddWithValue("@Name", pro.ProductName);
                cmd.Parameters.AddWithValue("@Description", pro.ProductDescription);
                cmd.Parameters.AddWithValue("@price", pro.Productprice);
                conn.Open();
                int i = await cmd.ExecuteNonQueryAsync();
                if (i > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }



        public async Task<Product> GetProductById(int id)
        {
            Product p = new Product();
            using (SqlConnection conn = new SqlConnection(db.cs))
            {
                SqlCommand cmd = new SqlCommand("spSearchProductbyId", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                using (SqlDataReader dr = await cmd.ExecuteReaderAsync())
                {
                    while (dr.Read())
                    {
                        p.ProductId = dr.GetFieldValue<int>(0);
                        p.ProductName = dr.GetFieldValue<string>(1);
                        p.ProductDescription = dr.GetFieldValue<string>(2);
                        p.Productprice = dr.GetFieldValue<int>(3);

                    }

                }
            }
            return p;
        }

        
    }
}
