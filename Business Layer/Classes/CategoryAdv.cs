using Business_Layer.Interface;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Business_Layer.Classes
{
    public class CategoryAdv : ICategoryAdv
    {
        private readonly DataContexts db;
        public CategoryAdv()
        {
            db = new DataContexts();
        }
        public bool Active(int id)
        {
            using (SqlConnection conn = new SqlConnection(db.cs))
            {
                SqlCommand cmd = new SqlCommand("spActiveCategory", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                int i = cmd.ExecuteNonQuery();
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
        public bool DeActive(int id)
        {
            using (SqlConnection conn = new SqlConnection(db.cs))
            {
                SqlCommand cmd = new SqlCommand("spDeActiveCAtegory", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                int i = cmd.ExecuteNonQuery();
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
        public List<Product> ShowAddProducts()
        {
            List<Product> pro = new List<Product>();
            using (SqlConnection conn = new SqlConnection(db.cs))
            {
                SqlCommand cmd = new SqlCommand("spgetAllproduct", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Product p = new Product();
                        p.ProductId = dr.GetFieldValue<int>(0);
                        p.ProductName = dr.GetFieldValue<string>(1);
                        p.ProductDescription = dr.GetFieldValue<string>(2);
                        p.Productprice = dr.GetFieldValue<int>(3);
                        pro.Add(p);
                    }
                }
                return pro;
            }
        }

        public bool AddProduts(int Pid, int Cid)
        {
            using (SqlConnection conn = new SqlConnection(db.cs))
            {
                SqlCommand cmd = new SqlCommand("spAddProToCat", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Pid", Pid);
                cmd.Parameters.AddWithValue("@cid", Cid);
                conn.Open();
                int i = cmd.ExecuteNonQuery();
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

        public List<Product> ShowProductInCategory(int id)
        {
            List<Product> pro = new List<Product>();
            using (SqlConnection conn = new SqlConnection(db.cs))
            {
                SqlCommand cmd = new SqlCommand("spShowProInCat", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Product p = new Product();
                        p.ProductId = dr.GetFieldValue<int>(0);
                        p.ProductName = dr.GetFieldValue<string>(1);
                        p.ProductDescription = dr.GetFieldValue<string>(2);
                        p.Productprice = dr.GetFieldValue<int>(3);
                        pro.Add(p);

                    }

                }
                return pro;
            }

        }

        
    }
}
