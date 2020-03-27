using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using DAL.Interfaces;
using System.Data.SqlClient;
using System.Data;

namespace DAL.TDG
{
    class SupplierTDG:ISupplierTDG
    {
        private SqlConnection _connection;

        public SupplierTDG(SqlConnection connection)
        {
            this._connection = connection;
        }

        public void Add(Supplier supplier)
        {
            SqlCommand command = new SqlCommand($"insert into Suppliers values({supplier.CompanyName})", _connection);

            var result = command.ExecuteNonQuery();
        }

        public void Update(Supplier supplier)
        {
            SqlCommand command = new SqlCommand($"update Suppliers set CompanyName={supplier.CompanyName}", _connection);

            var result = command.ExecuteNonQuery();
        }

        public void Delete(Supplier supplier)
        {
            SqlCommand command = new SqlCommand($"delete from Suppliers where SupplierID = {supplier.SupplierID}", _connection);

            var result = command.ExecuteNonQuery();
        }

        public IEnumerable<Supplier> GetAll()
        {
            SqlDataAdapter adapter = new SqlDataAdapter($"select * from Suppliers",_connection);

            DataSet dataSet = new DataSet();

            adapter.Fill(dataSet);

            List<Supplier> supplierList = new List<Supplier>();

            foreach(DataTable dataTable in dataSet.Tables)
            {
                foreach(DataRow dataRow in dataTable.Rows)
                {
                    Supplier supplier = new Supplier();

                    var cells = dataRow.ItemArray;

                    supplier.SupplierID = (int)cells[0];
                    supplier.CompanyName = (string)cells[2];

                    supplierList.Add(supplier);

                }
            }
            return supplierList;
        }

        public Supplier GetById(int id)
        {
            SqlCommand command = new SqlCommand($"select top(1) * from Suppliers", _connection);

            SqlDataReader reader = command.ExecuteReader();

            if(reader.HasRows)
            {
                reader.Read();
                Supplier supplier = new Supplier();
                supplier.SupplierID = (int)reader.GetValue(0);
                supplier.CompanyName = (string)reader.GetValue(1);

                reader.Close();
                return supplier;

            }
            else
            {
                reader.Close();
                return null;
            }

        }
    }
}
