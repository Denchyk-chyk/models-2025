using System.Globalization;

namespace Lab1
{
	/// <summary>
	/// Клас, що містить набір пар опис-значення й дозволяє користувачу вибирати з них
	/// </summary>
	/// <typeparam name="T">Тип значення</typeparam>
	/// <param name="title"></param>
	/// <param name="options"></param>
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

		/// <summary>
		/// Виділяє одне значення
		/// </summary>
		/// <param name="showValues">Варто ставити false при значеннях 1,2,3...</param>
		/// <returns></returns>
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


		/// <summary>
		/// Дозволяє виділити кілька варіантів через пропуск
		/// </summary>
		/// <param name="showValues">Варто ставити false при значеннях 1,2,3...</param>
		/// <returns></returns>
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


		/// <summary>
		/// Автоматично вибирає певний варіант на основі переданої функції
		/// </summary>
		/// <param name="automation"></param>
		/// <returns></returns>
		public T Select(Func<(string condition, T value)[], T> automation) => automation(options);
	}
}
