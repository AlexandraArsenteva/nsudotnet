using System;

namespace NumGes
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			int[] retries = new int[10];
			string[] losing = { "{0}, Sorry, you lose:(", "You were unlucky,{0}. Try a second time", "{0}, Lame duck. You lose!", "{0}, Flopper, you lose:(", "Try  to lose, again, {0}", "Bye, loser", "What a pity, {0}, you're an idiot" };
			Console.WriteLine("Hello! What is your name?");
			String name = Console.ReadLine();
			Random rand = new Random();
			int number = rand.Next(0, 100);
			//Console.WriteLine(number);
			String s = String.Format("{0}, I put forth a number from 0 to 100. Try to guess!", name);
			Console.WriteLine(s);
			DateTime begin = DateTime.Now;
			int v1,k;
			for (int i = 1; i < 5; i++)
			{
				String var = Console.ReadLine();
				if (var.Equals("q"))
				{
					Console.WriteLine("Goodbay! Press any key to exit.");
					break;
				}
				v1 = Int32.Parse(var);
				retries[i] = v1;
				k = v1.CompareTo(number);
				if (k.Equals(0))
				{
					retries[i + 4] = 0;
					Console.WriteLine("Congratulations! You win!");
					DateTime end = DateTime.Now;
					TimeSpan rez = end - begin;
					Console.WriteLine("Time: {0} min {1} sec", rez.Minutes, rez.Seconds);
					Console.WriteLine("Number of retries: {0}", i);
					for (int j = 1; j <= i;j++)
					{
						Console.WriteLine("Retry  {0}", j);
						String flag;
						if (retries[j+4]>0)
						{
							flag ="more";
						}
						else
						{
							if(retries[j+4]<0)
							{
								flag = "less";
							}
							else
							{
								flag = "correct";
							}
						}
						Console.WriteLine("Answer {0}: {1}\n", retries[j], flag);
					}

					break;

				}
				else
				{
					if (k > 0)
					{
						retries[i + 4] = 1;
						Console.WriteLine("Your version is greater then an unknown number.");
					}
					else
					{
						retries[i + 4] = -1;
						Console.WriteLine("Your version is less than an unknown number.");
					}
					if (i != 4)
						Console.WriteLine("Try again");
					else
					{
						int index = rand.Next(0, 3);
						Console.WriteLine(String.Format(losing[index],name));
					}
				}

			}
			// Keep the console window open in debug mode.
			Console.ReadKey();

		}
	}
}