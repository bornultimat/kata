using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

// "Data Source = myServer\\myDB; Initial Catalog = Books; Integrated Security = True;";
// Checks, if a book is on stock.
// Refactor this poor piece of code.
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length <= 0)
            {
                Console.WriteLine("You need to enter booknames in the arguments! Try again", Console.ForegroundColor = ConsoleColor.Red);
                Console.ReadKey();
                Environment.Exit(0);
            }

            Libary lib = new Libary(@"(localdb)\BooksDB", "Libary");

            foreach (var bookname in args)
            {
                Console.WriteLine(bookname, Console.ForegroundColor = ConsoleColor.Cyan);
                Console.WriteLine($"{lib.GetAvailableBooks(bookname)}", Console.ForegroundColor = ConsoleColor.Gray);
            }

            
            Console.ReadKey();
        }
    }

    internal class Libary
    {
        private string dataSource;
        private string dataBase;
        private string connectionString;

        public Libary(string dataSource, string dataBase)
        {
            this.dataBase = dataBase;
            this.dataSource = dataSource;
            this.ConnectionString = @"Data Source =" + dataSource + "; Initial Catalog = " + dataBase + "; Integrated Security = True;";
        }

        public string ConnectionString
        {
            get { return connectionString; }
            private set { connectionString = value; }
        }
        public string DataBase
        {
            get { return dataBase; }
            private set { dataBase = value; }
        }
        public string DataSource
        {
            get { return dataSource; }
            private set { dataSource = value; }
        }

        /// <summary>
        /// Gets available Amount of Books as integer from SQL-Libary.
        /// </summary>
        /// <param name="bookname">Bookname which is requested.</param>
        /// <returns>The Amount of books.</returns>
        public int GetAvailableBooks(string bookname)
        {
            if (bookname == string.Empty)
            {
                return 0;
            }

            int qty = 0;
            bookname = bookname.Replace("'", "''");
            string searchString = "select quantity FROM BookDetails where bookname like '" + bookname + "'";

            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            using (SqlCommand cmd1 = new SqlCommand(searchString, cn))
            {
                try
                {
                    cn.Open();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Could not open Data from SQL database!", Console.ForegroundColor = ConsoleColor.Red);
                    Console.WriteLine(e.Message, Console.ForegroundColor = ConsoleColor.Cyan);
                    Console.ReadKey();
                    Environment.Exit(0);
                }

                using (SqlDataReader dr1 = cmd1.ExecuteReader())
                {
                    while (dr1.Read())
                    {
                        int.TryParse(dr1.GetValue(0).ToString(), out qty);
                    }

                    if (qty == 0)
                    {
                        Console.WriteLine("Book is not in stock, please select another book!", Console.ForegroundColor = ConsoleColor.Red);
                    }
                    else
                    {
                        Console.WriteLine("You are luck! Book is in stock!", Console.ForegroundColor = ConsoleColor.Green);
                    }

                    dr1.Close();
                }

                cn.Close();
            }

            return qty;
        }
    }
}
