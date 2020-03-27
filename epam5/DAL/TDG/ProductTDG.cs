using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Models;
using System.Data.SqlClient;
using System.Data;

namespace DAL.TDG
{
    class ProductTDG:IProductTDG
    {
        private SqlConnection _connection;

        public ProductTDG(SqlConnection connection)
        {
            this._connection = connection;
        }

        public void Add(Product product)
        {
            SqlCommand command = new SqlCommand($"insert into Products values ('{product.ProductName}', {product.CategoryID},{product.SupplierID},{product.Price})",_connection);

            var result = command.ExecuteNonQuery();
        }

        public void Update(Product product)
        {
            SqlCommand command = new SqlCommand($"update Products set ProductName = '{product.ProductName}', CategoryID = {product.CategoryID}, SupplierID = {product.SupplierID}, Price = {product.Price} where ProductID = {product.ProductID}",_connection);

            var result = command.ExecuteNonQuery();
        }

        public void Delete(Product product)
        {
            SqlCommand command = new SqlCommand($"delete from Products where ProductID = {product.ProductID}",_connection);

            var result = command.ExecuteNonQuery();
        }

        public IEnumerable<Product> GetAll()
        {
            //_connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter($"select * from Products join Categories on Categories.CategoryID = Products.CategoryID join Suppliers on Suppliers.SupplierID = Products.SupplierID",_connection);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);

            List<Product> productList = new List<Product>();
            foreach(DataTable dataTable in dataSet.Tables)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    Product product = new Product();
                    Supplier supplier = new Supplier();
                    Category category = new Category();

                    var cells = dataRow.ItemArray;

                    product.ProductID = (int)cells[0];
                    product.ProductName = (string)cells[1];
                    product.Price = (int)cells[4];
                    category.CategoryID = (int)cells[3];
                    category.CategoryName = (string)cells[6];
                    category.CategoryCharacteristic = (string)cells[7];
                    supplier.SupplierID = (int)cells[4];
                    supplier.CompanyName = (string)cells[9];

                    product.Supplier = supplier;
                    product.Category = category;

                    productList.Add(product);
                }
            }
            return productList;
        }
        
        public Product GetById(int id)
        {
            _connection.Open();
            SqlCommand command = new SqlCommand($"select top(1) * from Products p join Categories c on c.CategoryID = p.CategoryID join Suppliers s on s.SupplierID = p.ProductID where ProductID = {id} ",_connection);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                Product product = new Product();
                Supplier supplier = null;
                Category category = null;

                reader.Read();

                product.ProductID = (int)reader.GetValue(0);
                product.ProductName = (string)reader.GetValue(1);
                product.Price = (int)reader.GetValue(2);

                if (!reader.GetValue(3).GetType().Equals(typeof(DBNull)))
                {
                    category = new Category();
                    category.CategoryID = (int)reader.GetValue(4);
                    category.CategoryName = (string)reader.GetValue(5);
                    category.CategoryCharacteristic = (string)reader.GetValue(6);
                }

                if (!reader.GetValue(7).GetType().Equals(typeof(DBNull)))
                {
                    supplier = new Supplier();
                    supplier.SupplierID = (int)reader.GetValue(8);
                    supplier.CompanyName = (string)reader.GetValue(9);
                }
                product.Supplier = supplier;
                product.Category = category;

                reader.Close();
                return product;
            }

            else
            {
                reader.Close();
                return null;
            }
        }
    }
}
