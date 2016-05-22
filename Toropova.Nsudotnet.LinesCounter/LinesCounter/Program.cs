using System;
using System.IO;

namespace LinesCounter
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			String extension = args[0];
			String dirName = AppDomain.CurrentDomain.BaseDirectory;
			int ind = dirName.IndexOf ("/bin");
			dirName = dirName.Substring (0, ind);
			int count = 0;
			if (Directory.Exists(dirName))
			{
				count = exploreDirectory (dirName,extension);
				Console.WriteLine ("Line counts:" + count.ToString ());
			}


		}
		public static int exploreDirectory(String dirName, String extension)
		{
			int n = 0;
			string[] dirs = Directory.GetDirectories(dirName);
			foreach (string s in dirs)
			{
				n = n + exploreDirectory (s,extension);
			}
			string[] files = Directory.GetFiles(dirName);
			foreach (string s in files)
			{
				if (Path.GetExtension(s).Equals (extension)) {
					n = n + exploreFile (s);
					//Console.WriteLine (s);
				}

			}
			return n;
		}
		public static int exploreFile(String fileName)
		{
			int i=0;
			try 
			{
				using (StreamReader sr = new StreamReader(fileName)) 
				{
					String line;
					String temp=null;
					while ((line = sr.ReadLine()) != null) 
					{
						line.Trim();
						if (line.StartsWith("/*"))
						{
							line = "";
							while (((temp = sr.ReadLine()) != null)&&(!temp.Contains("*/")))
							{

		
							}
						}
						if((line.Length!=0)&&(!line.StartsWith("//")))
						{
							i++;
						}

					}
					//Console.WriteLine("Line counts:"+i.ToString());
				}
			}
			catch (Exception e) 
			{
				Console.WriteLine(e.Message);
			}
			return i;
		}

}

}
