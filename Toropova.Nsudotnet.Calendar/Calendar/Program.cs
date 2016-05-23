using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCalendar
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Введите дату: ");
			String input = Console.ReadLine();
			DateTime dateValue;
			if(DateTime.TryParse(input, out dateValue))
			{
				int day = dateValue.Day;
				int month = dateValue.Month;
				int year = dateValue.Year;
				int daysInMonth = DateTime.DaysInMonth(year, month);
				object[] daysOfWeek = new object[]{DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday,DayOfWeek.Friday,DayOfWeek.Saturday, DayOfWeek.Sunday};
				DateTime date1 = new DateTime(year, month, 1);

				DateTime now = DateTime.Now;
				int currentdate=0;
				if ((now.Month==month)&&(now.Year ==year))
				{
					currentdate = now.Day;
				}

				DateTime monday = new DateTime (2016, 5, 23);
				String[] labels = new String[7];
				for (int j = 0; j < 7; j++)
				{
					labels[j] = monday.ToString("ddd", CultureInfo.GetCultureInfo("ru-ru"));
					monday = monday.AddDays(1);
					Console.Write(" {0,3} ", labels[j]);
				}
				Console.WriteLine();

				int holidays = 0;
				int d = Array.IndexOf(daysOfWeek, date1.DayOfWeek);
				for (int i = 0; i < d; i++)
					Console.Write("     ");
				for (int i = 1; i <= daysInMonth; i++)
				{
					if (((i+d)%7==0)||((i+d+1)%7==0))
					{
						Console.BackgroundColor = ConsoleColor.Red;
						Console.ForegroundColor = ConsoleColor.Black;
						holidays++;
					}
					if(i==day)
					{
						Console.BackgroundColor = ConsoleColor.Blue;
						Console.ForegroundColor = ConsoleColor.Black;
					}
					if(i==currentdate)
					{
						Console.BackgroundColor = ConsoleColor.Gray;
						Console.ForegroundColor = ConsoleColor.Black;
					}
					Console.Write(" {0,3} ", i);
					Console.BackgroundColor = ConsoleColor.Black;
					Console.ForegroundColor = ConsoleColor.Gray;
					if (((i + d) % 7 == 0) || (i == daysInMonth)) Console.WriteLine();
				}
				Console.WriteLine("Число рабочих дней: {0}", daysInMonth - holidays);

			}
			else
			{
				Console.WriteLine("Дата введена не верно!");
			}

			Console.ReadKey();
		}
	}
}

