using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using static System.Console;
using System.Data.SqlClient;


namespace COMP2614Assign04
{
	class Helper
	{
		public static void PrintCustomers(CustomerCollection customers)
		{
			string divider = new string('-', 67);
			WriteLine($"{"CompanyName",-33} {"City",-15} {"Prov", -4} {"Postal",-7} {"Hold",2}\n{divider}");

			foreach (var cusomer in customers)
			{
				PrintCustomer(cusomer);
			}
			Console.WriteLine(divider);
		}

		public static void PrintProvinceFilter(IList<string> provinces)
		{
			provinces.Add("ALL");
			for (int i = 0; i < provinces.Count(); i++)
			{
				WriteLine($"\t{i+1}: {provinces[i]}");
			}
		}

		private static void PrintCustomer(Customer customer)
		{
			WriteLine($"{customer.CompanyName,-33} {customer.City,-15} {customer.Province, -4} {customer.PostalCode, -7} {(customer.CreditHold ? "Y" : "N"),2}");
		}
	}
}
