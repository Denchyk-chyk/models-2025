using Lab1;
using System.Text;

Console.InputEncoding = Console.OutputEncoding = Encoding.UTF8;

// Делегат, що зчитує рядки з прочерками як "0"
var parseEmpty = (string s) => s == "-" ? 0 : float.Parse(s);

// Середовище розробки
var environment = (int)Reader.LocalSelectors("Addition 2 2 1", parseEmpty)[0][0].Select(false) - 1;
// Каталог функції програмного забезпечення
var functions = Reader.LocalSelectors("Addition 2 2 2", int.Parse)[environment].SelectMany(s => s.SelectMany()).ToArray();
// Загальний об’єм (Vз) програмного продукту
var totalVolume = functions.Sum();

Console.WriteLine($"Загальний об’єм (Vз) програмного продукту в рядках вихідного коду - {totalVolume}");

// Категорія складності ПЗ
var category = Reader.LocalSelectors("Addition 2 1", int.Parse)[0][0].Select() - 1;
// Нормативна трудомісткість розробки
var standardCapacity = (int)Reader.LocalSelectors("Addition 2 3", parseEmpty)[category][0].
	Select((options) => options.First(o => int.Parse(o.condition) >= totalVolume).value);

Console.WriteLine($"Нормативна трудомісткість розробки ПЗ - {standardCapacity}");

//Додаткові коефіцієнти складності ПЗ
var additionalFactors = Reader.LocalSelectors("Addition 2 5", float.Parse)[0][0].Select();
// Значення поправочного коефіцієнта, що враховує використання стандартних модулів
var standardModulesFactor = Reader.LocalSelectors("Addition 2 6", float.Parse)[0][0].Select();
// Ступінь новизни ПЗ
var noveltyLevel = Reader.LocalSelectors("Addition 2 7 1", (s) => s[0])[0][0].Select();
// Поправочні коефіцієнти, що враховують новизну ПЗ
var noveltyFactors = Reader.LocalSelectors("Addition 2 7 2", parseEmpty)[noveltyLevel - 'А'][0].Select();
// Загальна трудомісткість розробки ПЗ
var totalCapacity = standardCapacity * additionalFactors * standardModulesFactor * noveltyFactors;

Console.WriteLine($"Загальна трудомісткість розробки ПЗ - {totalCapacity}");

// Значення показника ТР визначається залежно від строку виконання проекту в місяцях
Console.WriteLine("Очікувана тривалість проєкту в місяцях");
var duration = int.Parse(Console.ReadLine()!);
// Ефективний фонд часу роботи одного робітника
var workingDays = (365 - 12 - 24 - 104) / 365f;
// Чисельність виконавців
var employeesCount = totalCapacity / (workingDays * duration);

Console.WriteLine($"Чисельність виконавців проєкту - {employeesCount}");
