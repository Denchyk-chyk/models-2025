namespace Lab1
{
	public static class Reader
	{
		public static List<Selector<T>>[] Selectors<T>(string file, Func<string, T> parse)
		{
			var selectors = new List<Selector<T>>[File.ReadAllLines(file)[1].Count(c => c == '|')];

			for (int i = 0; i < selectors.Length; i++)
			{
				selectors[i] = [];
			}

			var reader = new StreamReader(file);
			(string, string) header = default;
			List<(string, List<T>)> options = [];
			string line;
			bool firstLine = true;

			while (true)
			{
				line = reader.ReadLine()!;

				if (string.IsNullOrEmpty(line))
				{
					firstLine = true;

					for (int i = 0; i < selectors.Length; i++)
					{
						selectors[i].Add(new Selector<T>(header, [.. options.Select(o => (o.Item1, o.Item2[i]))]));
					}

					options.Clear();

					if (line == null)
					{
						reader.Close();
						return selectors;
					}
				}
				else
				{
					var data = line.Split('|').ToList();

					if (firstLine)
					{
						header = (data[0], data.Count == 1 ? string.Empty : data[1]);
						firstLine = false;
					}
					else
					{
						var name = data[0];
						data.RemoveAt(0);

						options.Add((name, data.Select(parse).ToList()));
					}
				}
			}
		}

		public static int Code(string directory)
		{
			var paths = Directory.GetFiles(directory, "*.cs", SearchOption.AllDirectories);
			int lines = 0;

			foreach (var path in paths)
			{
				var reader = new StreamReader(path);
				int fileLines = 0;
				string line;

				while ((line = reader.ReadLine()!) is not null)
				{
					if (line != string.Empty)
					{
						fileLines++;
					}
				}

				Console.WriteLine($"{path[directory.Length..]}: {fileLines}");
				lines += fileLines;
				reader.Close();
			}

			return lines;
		}

		public static List<Selector<T>>[] LocalSelectors<T>(string file, Func<string, T> parse) =>
			Selectors(Path.Combine(AppContext.BaseDirectory, "Data", $"{file}.txt"), parse);
	}
}
