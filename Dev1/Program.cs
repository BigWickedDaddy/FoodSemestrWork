using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestrBD
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Userdb;Integrated Security=True";
            //string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString; ;
            Console.WriteLine(connectionString);

            AddNewReceipt("Name","Some about","Products",connectionString);

            PrintAllTeams(connectionString);

            Console.Read();

        }


        static void AddNewReceipt(string FoodName,string About,string Receipt, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Подключение открыто");
                string sqlExpression = "INSERT INTO FoodReceipts (FoodName,About,Receipt) VALUES (@foodname,@about,@receipt)";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                // создаем параметр для имени
                SqlParameter nameParam = new SqlParameter("@foodname", FoodName);
                // создаем параметр для описания
                SqlParameter aboutParam = new SqlParameter("@about", About);
                // создаем параметр для рецепта
                SqlParameter receiptParam = new SqlParameter("@receipt", Receipt);
                // добавляем параметр к команде
                command.Parameters.Add(nameParam);
                // добавляем параметр к команде
                command.Parameters.Add(aboutParam);
                // добавляем параметр к команде
                command.Parameters.Add(receiptParam);

                int number = command.ExecuteNonQuery();
                Console.WriteLine("Добавлено объектов: {0}", number);

            }
            Console.WriteLine("Подключение закрыто");
        }

        static void PrintAllTeams(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Подключение открыто");
                string sqlExpression = "SELECT * FROM FoodReceipts";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows) // если есть данные
                {
                    // выводим названия столбцов
                    Console.WriteLine("{0}\t{1}\t{2}", reader.GetName(0), reader.GetName(1),reader.GetName(2));
                    while (reader.Read()) // построчно считываем данные
                    {
                        string FoodName = reader.GetString(0);
                        string About = reader.GetString(1);
                        string Receipt = reader.GetString(2);
                        Console.WriteLine("{0} \t{1} \t{2}", FoodName,About,Receipt);
                    }
                }
                reader.Close();
            }
            Console.WriteLine("Подключение закрыто");
        }
        //string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=userdb;Integrated Security=True";

        //string sqlExpression = "SELECT * FROM Users";

        //string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        //Console.WriteLine(connectionString);

        //Console.WriteLine("Введите Id:");
        //int id = Int32.Parse(Console.ReadLine());

        //Console.WriteLine("Введите имя:");
        //string name = Console.ReadLine();

        //Console.WriteLine("Введите возраст:");
        //int age = Int32.Parse(Console.ReadLine());

        //string sqlExpression = String.Format("INSERT INTO Users (Id ,Name, Age) VALUES ({0}, '{1}',{2})",id, name, age);
        //using (SqlConnection connection = new SqlConnection(connectionString))
        //{
        //    connection.Open();
        //    // добавление
        //    SqlCommand command = new SqlCommand(sqlExpression, connection);
        //    int number = command.ExecuteNonQuery();
        //    Console.WriteLine("Добавлено объектов: {0}", number);

        //    // обновление ранее добавленного объекта
        //    Console.WriteLine("Введите новое имя:");
        //    name = Console.ReadLine();
        //    sqlExpression = String.Format("UPDATE Users SET Name='{0}' WHERE Age={1}", name, age);
        //    command.CommandText = sqlExpression;
        //    number = command.ExecuteNonQuery();
        //    Console.WriteLine("Обновлено объектов: {0}", number);
        //}

        //using (SqlConnection connection = new SqlConnection(connectionString))
        //{
        //    connection.Open();
        //    SqlCommand command = new SqlCommand(sqlExpression, connection);
        //    SqlDataReader reader = command.ExecuteReader();

        //    if (reader.HasRows) // если есть данные
        //    {
        //        // выводим названия столбцов
        //        Console.WriteLine("{0}\t{1}\t{2}", reader.GetName(0), reader.GetName(1), reader.GetName(2));

        //        while (reader.Read()) // построчно считываем данные
        //        {
        //            object id = reader.GetValue(0);
        //            object name = reader.GetValue(1);
        //            object age = reader.GetValue(2);

        //            Console.WriteLine("{0} \t{1} \t{2}", id, name, age);
        //        }
        //    }

        //    reader.Close();
        //}


        //string sqlExpression = "INSERT INTO Users (id,Name, Age) VALUES (1,'Tom', 18)";

        //using (SqlConnection connection = new SqlConnection(connectionString))
        //{
        //    connection.Open();
        //    SqlCommand command = new SqlCommand(sqlExpression, connection);
        //    int number = command.ExecuteNonQuery();
        //    Console.WriteLine("Добавлено объектов: {0}", number);
        //}

        // Создание подключения
        //SqlConnection connection = new SqlConnection(connectionString);
        //try
        //{
        //    // Открываем подключение
        //    connection.Open();
        //    Console.WriteLine("Подключение открыто");
        //    // Вывод информации о подключении
        //    Console.WriteLine("Свойства подключения:");
        //    Console.WriteLine("\tСтрока подключения: {0}", connection.ConnectionString);
        //    Console.WriteLine("\tБаза данных: {0}", connection.Database);
        //    Console.WriteLine("\tСервер: {0}", connection.DataSource);
        //    Console.WriteLine("\tВерсия сервера: {0}", connection.ServerVersion);
        //    Console.WriteLine("\tСостояние: {0}", connection.State);
        //    Console.WriteLine("\tWorkstationld: {0}", connection.WorkstationId);
        //}
        //catch (SqlException ex)
        //{
        //    Console.WriteLine(ex.Message);
        //}
        //finally
        //{
        //    // закрываем подключение
        //    connection.Close();
        //    Console.WriteLine("Подключение закрыто...");
        //}

    }
}
