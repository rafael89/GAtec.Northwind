using System.Collections.Generic;
using GAtec.Northwind.Domain.Model;
using GAtec.Northwind.Domain.Repository;
using System.Data;
using System.Data.SqlClient;
using GAtec.Northwind.Util;

namespace GAtec.Northwind.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        public void Add(Category item)
        {
            using (var con = new SqlConnection(NorthwindSettings.ConnectionString))
            {
                con.Open();

                using (var cmd = new SqlCommand("insert into Categories (CategoryName, Description) values (@name, @description)", con))
                {
                    cmd.Parameters.Add("name", SqlDbType.NVarChar).Value = item.Name;
                    cmd.Parameters.Add("description", SqlDbType.NText).Value = item.Description;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(Category item)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(object id)
        {
            throw new System.NotImplementedException();
        }

        public Category Get(object id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Category> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}