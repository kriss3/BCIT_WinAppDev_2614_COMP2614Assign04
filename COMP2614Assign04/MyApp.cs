using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace COMP2614Assign04
{
	class MyApp
	{
		static void Main(string[] args)
		{
			Run();
		}

		private static void Run()
		{
			Title = $"Hello, {Environment.UserName}";

			try
			{
				var p = CustomerRepository.GetProvinceFilter();
				WriteLine();
				WriteLine($"Select province filter:");
				Helper.PrintProvinceFilter(p);
				var answer = ReadLine();
				var prov = p[int.Parse(answer) - 1];

				WriteLine($"Customer listing for {prov}");
				WriteLine();
				var customers = CustomerRepository.GetCustomersByProvince(prov);
				Helper.PrintCustomers(customers);
				SetCursorPosition(0, 0);
				Console.ReadLine();
				
			}
			catch (SqlException sqlEx)
			{
				ForegroundColor = ConsoleColor.Red;
				WriteLine($"Data Access Error\n\n{sqlEx.Message}\n\n{sqlEx.StackTrace}");
				ForegroundColor = ConsoleColor.Gray;
			}
			catch (Exception ex)
			{
				ForegroundColor = ConsoleColor.Red;
				WriteLine($"Processing Error\n\n{ex.Message}\n\n{ex.StackTrace}");
				ForegroundColor = ConsoleColor.Gray;
			}
		}
	}
}
