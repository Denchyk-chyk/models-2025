namespace Lab1
{
	/// <summary>
	/// Метод для зчитування Selector з файлів
	/// </summary>
	public static class Reader
	{
		/// <summary>
		/// Метод, що повертає Selector із тектсового файлу (детальніше в Readme)
		/// </summary>
		/// <typeparam name="T">Тип значення</typeparam>
		/// <param name="file">Повний шлях до файлу</param>
		/// <param name="parse">Функція зчитування значення з тексту в файл</param>
		/// <returns></returns>
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

		/// <summary>
		/// Автоматизація методу Selectors для отримання даних із файлів Тека проекту/Data/{file}.txt
		/// </summary>
		/// <typeparam name="T">Тип значення</typeparam>
		/// <param name="file">Назва файлу</param>
		/// <param name="parse">Функція зчитування значення з тексту в файлі</param>
		/// <returns></returns>
		public static List<Selector<T>>[] LocalSelectors<T>(string file, Func<string, T> parse) =>
			Selectors(Path.Combine(AppContext.BaseDirectory, "Data", $"{file}.txt"), parse);
	}
}
