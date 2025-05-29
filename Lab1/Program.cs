using Lab1;
using System.Text;

Console.InputEncoding = Console.OutputEncoding = Encoding.UTF8;

// K1 - масштаб об’єкту автоматизації; K2 - тип замовника; K3 - тип програмного забезпечення. 
var projectParameters = Reader.Selectors(Path.Combine(AppContext.BaseDirectory, "Data", "Table 1.txt"), int.Parse)[0];
// Функціональний розмір прикладного програмного забезпечення інформаційних систем
var functionalSize = Math.Pow(projectParameters.Select(s => s.Select()).Sum(), 2.35);
Console.WriteLine($"Функціональний розмір - {functionalSize:f2}");

// Коефіцієнт переводу балу функціональності в кількість логічних рядків коду
var conversion = Reader.Selectors(Path.Combine(AppContext.BaseDirectory, "Data", "Addition 1.txt"), int.Parse)[0][0];
// Розмір коду
var codeSize = functionalSize * conversion.Select() / 1000;
Console.WriteLine($"Розмір коду в тисячах логічних рядків вихідного коду - {codeSize:f2}");

// Показники розробки, Ri 
var developmentParameters = Reader.Selectors(Path.Combine(AppContext.BaseDirectory, "Data", "Table 3.txt"), float.Parse)[0];
// E - показник масштабу трудомісткостістворення (розробки)
var scaleParameter = 0.91 + 0.01 * developmentParameters.Select(p => p.Select()).Sum();
Console.WriteLine($"Показник масштабу трудомісткостістворення (розробки) - {scaleParameter:f2}");

// Множники витрат, Zi
var expencesFactors = Reader.Selectors(Path.Combine(AppContext.BaseDirectory, "Data", "Table 4.txt"), float.Parse)[0];
// Z - показник витрат трудомісткостістворення (розробки)
var expencesParameter = expencesFactors.Select(p => p.Select()).Aggregate((x, y) => x * y);
Console.WriteLine($"Показник витрат трудомісткостістворення (розробки) - {expencesParameter:f2}");

// Т - трудомісткостірозробка прикладного програмного забезпечення інформаційної системи в людино-місяцях
var labor = 2.94 * Math.Pow(codeSize, scaleParameter) * expencesParameter;
Console.WriteLine($"Розрахована трудомісткостірозробка прикладного програмного забезпечення інформаційної системи в людино-місяцях - {labor:f2}");
