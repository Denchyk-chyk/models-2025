using Lab1;
using System.Text;

Console.InputEncoding = Console.OutputEncoding = Encoding.UTF8;

// Рядки коду
Console.WriteLine("Кількість тисяч рядків коду:");
var codeSize = int.Parse(Console.ReadLine()!);

// Делегат, що зчитує рядки з прочерками як "0"
var parseEmpty = (string s) => s == "-" ? 0 : float.Parse(s);

// Показники розробки, Ri 
var developmentParameters = Reader.LocalSelectors("Table 3", float.Parse)[0];
// E - показник масштабу трудомісткостістворення (розробки)
var scaleParameter = 0.91 + 0.01 * developmentParameters.Select(p => p.Select()).Sum();
Console.WriteLine($"Показник масштабу трудомісткостістворення (розробки) - {scaleParameter:f2}");

// Драйвери витрат
var driverSelectors = Reader.LocalSelectors("Addition 3", parseEmpty)[0];
// Показник витрат трудомісткості
var expencesParameter = driverSelectors.Select(s => s.Select()).Aggregate((x, y) => x * y);
Console.WriteLine($"Показник витрат трудомісткостістворення (розробки) - {expencesParameter:f2}");

// Т - трудомісткостірозробка прикладного програмного забезпечення інформаційної системи в людино-місяцях
var labor = 2.94 * Math.Pow(codeSize, scaleParameter) * expencesParameter;
Console.WriteLine($"Розрахована трудомісткостірозробка прикладного програмного забезпечення інформаційної системи в людино-місяцях - {labor:f2}");
