using System;
using System.Data.SqlClient;
using static System.Console;

namespace COMP2614Assign04
{
	/// <summary>
	/// Driver class
	/// Repo: https://github.com/kriss3/BCIT_WinAppDev_2614_COMP2614Assign04.git
	/// </summary>
	class MyApp
	{
		static void Main(string[] args)
		{
			Run();
			ReadLine();
		}

		private static void Run()
		{
			Title = $"Hello, {Environment.UserName}. Welcome to Assignment 04.";

			try
			{
				var provinceFilter = CustomerRepository.GetProvinceFilter();
				WriteLine();
				WriteLine($"Select province filter:");
				Helper.PrintProvinceFilter(provinceFilter);
				var answer = ReadLine();
				var prov = provinceFilter[int.Parse(answer) - 1];   //this most could be TryParse with out parameter - ask if necessary as 
																	//user input is numeric based;

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
			catch (ArgumentOutOfRangeException indexEx)
			{
				ForegroundColor = ConsoleColor.Red;
				WriteLine($"Wrong filtering choice. Please enter correct numeric value.\n\n{indexEx.Message}\n\n{indexEx.StackTrace}");
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
