using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.DAL
{
    public class DAL
    {
        string _connectionString;
        public DAL(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<Todo> GetTodos()
        {
            var todoList = new List<Todo>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                // Create a SqlCommand, and identify it as a stored procedure.
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = "GetTodos";
                    //text -- query interna
                    //sqlCommand.CommandText = "select * from Todolist";
                    sqlCommand.Connection = connection;
                    // Add input parameter for the stored procedure and specify what to use as its value.
                    //sqlCommand.Parameters.Add(new SqlParameter("@CustomerName", SqlDbType.NVarChar, 40));
                    //sqlCommand.Parameters["@CustomerName"].Value = txtCustomerName.Text;
                    //sqlCommand.Parameters.AddWithValue("id", 1);

                    connection.Open();

                    // Run the stored procedure.
                    var reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {

                        while (reader.Read())
                        {
                            var todo = new Todo();
                            todo.Id = (int)reader["Id"];
                            todo.Name = reader["Name"].ToString();
                            todo.LastName = reader["Lastname"].ToString();
                            todo.InsertedOn = (DateTime)reader["InsertedOn"];
                            todo.UpdatedOn = Convert.ToDateTime(reader["UpdatedOn"]);
                            todo.DueDate = DateTime.Parse(reader["DueDate"].ToString());
                            todo.Task = reader["Task"].ToString();
                            todoList.Add(todo);
                        }
                    }

                    reader.Close();
                    // Customer ID is an IDENTITY value from the database.
                    //this.parsedCustomerID = (int)sqlCommand.Parameters["@CustomerID"].Value;

                    // Put the Customer ID value into the read-only text box.
                    //this.txtCustomerID.Text = Convert.ToString(parsedCustomerID);
                    connection.Close();
                }
            }

            return todoList;
        }
        

        public static void DropDB()
        {

        }
    }
}
