using System.Linq;
using System.Reflection.PortableExecutable;
using PZ3;

// Заполнение рандомными отрезками
var lines = Enumerable.Range(0, 100)
    .Select(l => {
        var r = Random.Shared;
        var point1 = (r.Next(0, 50), r.Next(0, 50));
        var point2 = (r.Next(0, 50), r.Next(0, 50));
        return new Line(point1, point2);
    }).ToList();

// Отрезки, у которых ордината (y) второй точки больше чем у первой
var y2GreaterThanY1 = lines.Where(l => l.Point2.y > l.Point1.y).ToList();

// Все абсциссы
var xes = new List<double>();
xes.AddRange(lines.Select(l => l.Point1.x));
xes.AddRange(lines.Select(l => l.Point2.x));

PrintLines(lines, "Все отрезки");
PrintLines(y2GreaterThanY1, "Отрезки где y2 > y1");
PrintDoubles(xes, "Абсциссы");

void PrintLines(IEnumerable<Line> lines, string header = "Линии") {
    Console.ForegroundColor = ConsoleColor.Black;
    Console.BackgroundColor = ConsoleColor.White;
    Console.WriteLine(header);
    Console.ResetColor();
    Console.WriteLine();
    var linesList = lines.ToList();
    linesList.ToList().ForEach(l => {
        Console.WriteLine($"{linesList.IndexOf(l)+1}\t-\t{l}");
    });
}

void PrintDoubles(IEnumerable<double> doubles, string header = "Значения") {
    Console.ForegroundColor = ConsoleColor.Black;
    Console.BackgroundColor = ConsoleColor.White;
    Console.WriteLine(header);
    Console.ResetColor();
    Console.WriteLine();
    var xesList = doubles.ToList();
    xesList.ForEach(x => {
        Console.WriteLine($"{xesList.IndexOf(x)+1}\t-\t{x}");
    });
}