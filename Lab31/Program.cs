using Lab1;
using System.Text;

Console.InputEncoding = Console.OutputEncoding = Encoding.UTF8;

// Рядки коду
Console.WriteLine("Кількість тисяч рядків коду:");
var codeSize = int.Parse(Console.ReadLine()!);

// Коефіцієнти a, b, c, d, що залежать від режиму
var factors = Reader.LocalSelectors("Factors", (s) => s.Split().Select(float.Parse).ToArray())[0][0].Select(false);

// Трудовитрати
var e = factors[0] * Math.Pow(codeSize, factors[1]);
Console.WriteLine($"Трудовитрати в людино місяцях - {e:f2}");

// Тривалість розробки
var tdev = factors[2] * Math.Pow(e, factors[3]);
Console.WriteLine($"Тривалість розробки в місяцях - {tdev:f1}");

// Середня числеьність персоналу
var ss = e / tdev;
Console.WriteLine($"Середня чисельність персоналу - {ss:f1}");

// Рівень продуктивності
var p = codeSize / e;
Console.WriteLine($"Продуктивність (KLOC на людино-місяць) - {p:f2}");
