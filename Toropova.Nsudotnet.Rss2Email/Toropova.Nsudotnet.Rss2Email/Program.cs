using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Toropova.Nsudotnet.Rss2Email
{
	class MainClass
	{
		//program.exe url.com/news.rss mailserver.com to@mail.com from@mail.com password
		static void Main(String[] args)
		{
			if (args.Length < 5)
			{
				PrintLine("Wrong arguments");
				return;
			}

			MainClass program = new MainClass(args[0], args[1], args[2], args[3], args[4]);
			program.StartSendRssToEmail();
		}

		private MainClass(String rss, String server, String to, String from, String password)
		{
			rssUrl = rss;
			mailServer = server;
			mailTo = to;
			mailFrom = from;
			mailFromPassword = password;
		}

		private void StartSendRssToEmail()
		{
			Timer timer = new Timer();
			timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
			timer.Interval = 1000 * 60;
			timer.Enabled = true;

			Console.ReadLine();
		}

		private void OnTimedEvent(object source, ElapsedEventArgs e)
		{
			string body = XMLUtils.GetTextFromXML(rssUrl);
			SMTPUtils.Send(mailServer, mailTo, mailFrom, mailFromPassword, rssUrl, body);
		}

		private static void PrintLine(string message)
		{
			#if DEBUG
			System.Diagnostics.Debug.WriteLine(message);
			#endif
			Console.WriteLine(message);
		}

		private string rssUrl;
		private string mailServer;
		private string mailTo;
		private string mailFrom;
		private string mailFromPassword;
	}
}
