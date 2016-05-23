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
				count = ExploreDirectory (dirName,extension);
				Console.WriteLine ("Line counts:" + count.ToString ());
			}


		}
		public static int ExploreDirectory(String dirName, String extension)
		{
			int n = 0;
			string[] dirs = Directory.GetDirectories(dirName);
			foreach (string s in dirs)
			{
				n = n + ExploreDirectory (s,extension);
			}
			string[] files = Directory.GetFiles(dirName);
			foreach (string s in files)
			{
				if (Path.GetExtension(s).Equals(extension,StringComparison.Ordinal)) {
					n = n + ExploreFile (s);
					//Console.WriteLine (s);
				}

			}
			return n;
		}
		public static int ExploreFile(String fileName)
		{
			int i=0;
			try 
			{
				using (StreamReader sr = new StreamReader(fileName)) 
				{
					String line;
					while ((line = sr.ReadLine()) != null) 
					{
						line.Trim();
						if (line.Contains("/*"))
						{
							if (!line.StartsWith("/*"))
								i++;
							while ((line!=null)&&(!line.Contains("*/")))
							{
								line = sr.ReadLine();
							}
							line = "";
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
