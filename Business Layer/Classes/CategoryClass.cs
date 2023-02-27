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
    public class CategoryClass : ICategory
    {
        private readonly DataContexts db;
        public CategoryClass()
        {
            db = new DataContexts();
        }

        public async Task<bool> CreateCategory(Category cat)
        {
            using (SqlConnection conn = new SqlConnection(db.cs))
            {
                SqlCommand cmd = new SqlCommand("spCreateCategory", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", cat.CategoryName);
                cmd.Parameters.AddWithValue("@Active", cat.IsActive);
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

        public async Task<bool> DeleteCategory(int id)
        {
            using (SqlConnection conn = new SqlConnection(db.cs))
            {
                SqlCommand cmd = new SqlCommand("spdeletecategory", conn);
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

        public async Task<bool> EditCategory(Category cat)
        {
            using (SqlConnection conn = new SqlConnection(db.cs))
            {
                SqlCommand cmd = new SqlCommand("spEditcategory", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                cmd.Parameters.AddWithValue("@id", cat.Id);
                cmd.Parameters.AddWithValue("@name", cat.CategoryName);
                cmd.Parameters.AddWithValue("@Active", cat.IsActive);
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

        public async Task<List<Category>> GetAllCategory(Category cat)
        {
            List<Category> categories = new List<Category>();
            using (SqlConnection conn = new SqlConnection(db.cs))
            {
                SqlCommand cmd = new SqlCommand("spGetAllCategory", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                using (SqlDataReader dr = await cmd.ExecuteReaderAsync())
                {
                    while (dr.Read())
                    {
                        Category cata = new Category();
                        cata.Id = dr.GetFieldValue<int>(0);
                        cata.CategoryName = dr.GetFieldValue<String>(1);
                        cata.IsActive = dr.GetFieldValue<bool>(2);
                        categories.Add(cata);
                    }
                }
            }
            return categories;
        }

        public async Task<Category> GetCategoryByID(int id)
        {
            Category cat = new Category();
            using (SqlConnection conn = new SqlConnection(db.cs))
            {
                SqlCommand cmd = new SqlCommand("spGetCategoryById", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                using (SqlDataReader dr = await cmd.ExecuteReaderAsync())
                {
                    while (dr.Read())
                    {
                        cat.Id = dr.GetFieldValue<int>(0);
                        cat.CategoryName = dr.GetFieldValue<string>(1);
                        cat.IsActive = dr.GetFieldValue<bool>(2);


                    }
                }
            }
            return cat;
        }
    }
}
