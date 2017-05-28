using System;
using System.Collections.Generic;
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
		}
	}
}
