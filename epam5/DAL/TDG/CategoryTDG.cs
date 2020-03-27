using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DAL.Interfaces;
using System.Data.SqlClient;
using DAL.Models;
using System.Data;

namespace DAL.TDG
{
    class CategoryTDG : ICategoryTDG
    {
        private SqlConnection _connection;

        public CategoryTDG(SqlConnection connection)
        {
            this._connection = connection;
        }

        public void Add(Category category)
        {
            SqlCommand command = new SqlCommand($"insert into Categories values({category.CategoryName},{category.CategoryCharacteristic})", _connection);

            var result = command.ExecuteNonQuery();
        }
        
        public void Update(Category category)
        {
            SqlCommand command = new SqlCommand($"update Category set CategoryName = {category.CategoryName}, CategoryCharacteristic={category.CategoryCharacteristic} where CategoryID = {category.CategoryID}", _connection);

            var result = command.ExecuteNonQuery();
        }

        public void Delete(Category category)
        {
            SqlCommand command = new SqlCommand($"delete from Categories where CategoryID = {category.CategoryID}");

            var result = command.ExecuteNonQuery();
        }

        public IEnumerable<Category> GetAll()
        {
            SqlDataAdapter adapter = new SqlDataAdapter($"select * from Categories", _connection);

            DataSet dataSet = new DataSet();

            adapter.Fill(dataSet);

            List<Category> categoryList = new List<Category>();

            foreach(DataTable dataTable in dataSet.Tables)
            {
                foreach(DataRow dataRow in dataTable.Rows)
                {
                    Category category = new Category();

                    var cells = dataRow.ItemArray;

                    category.CategoryID = (int)cells[0];
                    category.CategoryName = (string)cells[1];
                    category.CategoryCharacteristic = (string)cells[2];

                    categoryList.Add(category);
                }

            }

            return categoryList;
        }

        public Category GetById(int id)
        {
            SqlCommand command = new SqlCommand($"select top(1) * from Categories", _connection);

            SqlDataReader reader = command.ExecuteReader();

            if(reader.HasRows)
            {
                Category category = new Category();

                reader.Read();

                category.CategoryID = (int)reader.GetValue(0);
                category.CategoryName = (string)reader.GetValue(1);
                category.CategoryCharacteristic = (string)reader.GetValue(2);

                reader.Close();
                return category;
            }
            else
            {
                reader.Close();
                return null;
            }
        }
    }
}