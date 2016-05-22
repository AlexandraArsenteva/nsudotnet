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
            int[] daysOfMonth = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            Console.WriteLine("Введите дату: ");
            String input = Console.ReadLine();
            DateTime dateValue;
            if(DateTime.TryParse(input, out dateValue))
            {
                int day = dateValue.Day;
                int month = dateValue.Month;
                int year = dateValue.Year;
                int[] days = {0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};
                if (month == 2 && isLeapYear(year)) days[month] = 29;
                object[] daysOfWeek = new object[]{DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday,DayOfWeek.Friday,DayOfWeek.Saturday, DayOfWeek.Sunday};
                DateTime date1 = new DateTime(year, month, 1);
                DateTime now = DateTime.Now;
                int currentdate=0;
                if ((now.Month==month)&&(now.Year ==year))
                {
                    currentdate = now.Day;
                }
                String[] labels = new String[] { "ПН", "ВТ", "СР", "ЧТ", "ПТ", "СБ", "ВС" };
                for (int i = 0; i < 7;i++)
                    Console.Write(" {0,3} ", labels[i]);
                Console.WriteLine();
                int holidays = 0;
                int d = Array.IndexOf(daysOfWeek, date1.DayOfWeek);
                for (int i = 0; i < d; i++)
                    Console.Write("     ");
                for (int i = 1; i <= days[month]; i++)
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
                    if (((i + d) % 7 == 0) || (i == days[month])) Console.WriteLine();
                }
                Console.WriteLine("Число рабочих дней: {0}", days[month] - holidays);

            }
            else
            {
                Console.WriteLine("Дата введена не верно!");
            }

            Console.ReadKey();
        }
        public static bool isLeapYear(int year)
        {
            if ((year % 4 == 0) && (year % 100 != 0)) return true;
            if (year % 400 == 0) return true;
            return false;
        }
       
       
    }
}
