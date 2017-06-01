using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;


namespace COMP2614Assign04
{
	/// <summary>
	/// Helper class to provide access to shared functionality accross applicaiton;
	/// Repo: https://github.com/kriss3/BCIT_WinAppDev_2614_COMP2614Assign04.git
	/// </summary>
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

		/// <summary>
		/// Helper mehod to print filter, incrementing index only for display purpose;
		/// Add a static value of 'ALL' for additional filtering;
		/// </summary>
		/// <param name="provinces">Generic collection of string types - collection to iterate over objects of the collection</param>
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
