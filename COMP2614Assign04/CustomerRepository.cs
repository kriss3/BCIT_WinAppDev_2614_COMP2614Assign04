﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace COMP2614Assign04
{
	/// <summary>
	/// Repository class to handle database operations;
	/// </summary>
	class CustomerRepository
	{
		#region Public Methods

		/// <summary>
		/// Methods to retrieve data required to build dynamic filter
		/// </summary>
		/// <returns>Generic collection of String</returns>
		public static IList<String> GetProvinceFilter()
		{
			var provinces = new List<String>();
			using (SqlConnection conn = new SqlConnection(GetConnectionString()))
			{
				var provinceQry = @"SELECT distinct Province FROM Customer";
				using (SqlCommand cmd = new SqlCommand())
				{
					cmd.CommandType = CommandType.Text;
					cmd.CommandText = provinceQry;
					cmd.Connection = conn;

					conn.Open();

					using (var r = cmd.ExecuteReader())
					{
						while (r.Read())
						{
							provinces.Add(r["Province"] as string);
						}
					}
				}
			}
			return provinces;
		}

		/// <summary>
		/// Method to search Customers by province;
		/// </summary>
		/// <param name="province">Two character string indicating Canadian province</param>
		/// <returns>collection of Customer objects</returns>
		public static CustomerCollection GetCustomersByProvince(string province)
		{
			CustomerCollection customersByProvince;

			using (var conn = new SqlConnection(GetConnectionString()))
			{
				var q = @"SELECT CompanyName, City, Province, PostalCode, CreditHold FROM Customer";

				var wherePart = @" where Province = @province";
				var orderPart = @" Order by CompanyName";

				var query = String.Empty;
				if (province == "ALL")
				{
					query = q + orderPart;
				}
				else
				{
					query = q + wherePart + orderPart;
				}

				using (var cmd = new SqlCommand())
				{
					cmd.CommandType = CommandType.Text;
					cmd.CommandText = query;
					cmd.Connection = conn;
					cmd.Parameters.AddWithValue("@province", province);
					conn.Open();

					customersByProvince = new CustomerCollection();
					using (var r = cmd.ExecuteReader())
					{
						string CompanyName, City, Province, PostalCode;
						CompanyName = City = Province = PostalCode = String.Empty;
						bool CreditHold = false;


						while (r.Read())
						{
							if (!r.IsDBNull(1))
							{
								CompanyName = r["CompanyName"] as string;
							}

							City = r["City"] as string;
							Province = r["Province"] as string;
							PostalCode = r["PostalCode"] as string;

							if (!r.IsDBNull(4))
							{
								CreditHold = (bool)r["CreditHold"];
							}

							customersByProvince.Add(new Customer(CompanyName, City, Province, PostalCode, CreditHold));

						}
					}
				}
				return customersByProvince;
			}
		}

		/// <summary>
		/// Excercise method to get ALL customers from underlying source;
		/// </summary>
		/// <returns>collectin of customer objects</returns>
		public static CustomerCollection GetAllCustomers()
		{
			CustomerCollection customers;

			using (SqlConnection conn = new SqlConnection(GetConnectionString()))
			{
				var query = @"SELECT CompanyName, City, Province, PostalCode, CreditHold FROM Customer";

				using (SqlCommand cmd = new SqlCommand())
				{

					cmd.CommandType = CommandType.Text;
					cmd.CommandText = query;
					cmd.Connection = conn;

					conn.Open();

					customers = new CustomerCollection();

					using (SqlDataReader dr = cmd.ExecuteReader())
					{
						string CompanyName, City, Province, PostalCode;
						CompanyName = City = Province = PostalCode =  String.Empty;
						bool CreditHold = false;
						

						while (dr.Read())
						{
							if (!dr.IsDBNull(1))
							{
								CompanyName = dr["CompanyName"] as string;
							}

							City = dr["City"] as string;
							Province = dr["Province"] as string;
							PostalCode = dr["PostalCode"] as string;

							if (!dr.IsDBNull(4))
							{
								CreditHold = (bool)dr["CreditHold"];
							}

							customers.Add(new Customer(CompanyName, City, Province, PostalCode, CreditHold));
							
						}
					}

				}
			}
			return customers;
		}

		#endregion

		#region Private Methods

		private static string GetConnectionString()
		{
			return ConfigurationManager.AppSettings["connString"];
		}

		#endregion
	}
}