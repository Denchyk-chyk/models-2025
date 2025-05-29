using System.Globalization;

namespace Lab1
{
	public class Selector<T>((string name, string description) title, (string condition, T value)[] options)
	{
		protected readonly (string name, string description) title = title;
		protected readonly (string condition, T value)[] options = options;

		protected virtual void Display(bool showValues)
		{
			Console.WriteLine((string.IsNullOrEmpty(title.description) ? title.name : $"{title.name} - {title.description}").Replace(@"\n", "\n"));

			for (int i = 0; i < options.Length; i++)
			{
				Console.WriteLine($"{i + 1}. {options[i].condition.Replace(@"\n", "\n")}" + (showValues ? $" {options[i].value}" : string.Empty));
			}
		}

		public List<T> SelectMany(bool showValues = true)
		{
			Display(showValues);

			try
			{
				var input = Console.ReadLine()!;

				if (string.IsNullOrEmpty(input))
				{
					return [];
				}

				var chosen = input.Split(' ');
				return [.. chosen.Select(c => options[int.Parse(c, CultureInfo.InvariantCulture) - 1].value)];
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				return SelectMany();
			}
		}

		public T Select(bool showValues = true)
		{
			Display(showValues);

			try 
			{
				return options[int.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture) - 1].value;
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				return Select();
			}
		}

		public T Select(Func<(string condition, T value)[], T> automation) => automation(options);
	}
}
