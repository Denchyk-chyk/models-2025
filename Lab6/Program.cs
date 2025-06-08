using Lab1;
using System.Text;

Console.InputEncoding = Console.OutputEncoding = Encoding.UTF8;

// Через специфічність завдання код нижче не є повноцінною консольною програмою 
// Окремі фрагменти виконувалися в режимі налагодження (для отримання проміжних значень)
// Ці значення вручну вставлялися в наступні фрагменти, які розроблялися пізніше
// ";" позначають ці фрагменти
// Запуск програми в звичайному режимі виведе на екран вибір драйверів витрат (другий фрагмент)

// Знаходження кілкіості рядків коду
var ksloc = (4000 - 250 - 150) * ((50 * 20 / 100) + 30) / 1000;

;

// Поділ драверів витрат на 2 ктегорії і знаходження добутку в межах кожної
var driverSelectors = Reader.LocalSelectors("Addition 3", (string s) => s == "-" ? 0 : float.Parse(s))[0].ToArray();
var technologicalSelctors = new Selector<float>[3];
var difficultyAndExperienceSelctors = new Selector<float>[12];
Array.Copy(driverSelectors, 12, technologicalSelctors, 0, 3);
Array.Copy(driverSelectors, difficultyAndExperienceSelctors, 12);

var product = (Selector<float>[] s) => s.Select(s => s.Select()).Aggregate((x, y) => x * y);

var technologicalFactor = product(technologicalSelctors);
var difficultyAndExperienceFactor = product(difficultyAndExperienceSelctors);

;

// Обрахунок часу розробки та трудомісткості з урахуванням тестування
var time = 144 * 0.82 * 0.41 / (2.5 * 3);

var capacity = 144 * 0.82 * 0.41;
var min = capacity * 1.3;
var man = capacity * 1.4;

;
