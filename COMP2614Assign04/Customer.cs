using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP2614Assign04
{
	class Customer
	{
		public string CompanyName { get; set; }
		public string City { get; set; }
		public string Province { get; set; }
		public string PostalCode { get; set; }
		public bool CreditHold { get; set; }

		public Customer(string companyName, string city, string province, string postalCode, bool creditHold)
		{
			CompanyName = companyName;
			City = city;
			Province = province;
			PostalCode = postalCode;
			CreditHold = creditHold;
		}

		public Customer() { }
	}
}
