int InsertValue(string text)
{
    System.Console.WriteLine($"{text}");
    var value = Convert.ToInt32(Console.ReadLine());
    return value;
}

// // // Графический символ

void Point(int x, int y)
{
    Console.SetCursorPosition(x, y);
    Console.WriteLine("+");
}
// // Генерация значений функции

int[,] LinearFunction(int minX, int countX, int k, int b)
{
    int[,] farray = new int[countX, countX];

    for (int i = 0; i < countX; i++)
    {
        farray[0, i] = minX;
        farray[1, i] = k * minX + b;
        minX++;
    }
    System.Console.WriteLine();
    return farray;
}

// // // Вычисление точки пересечения

string FindCrossValid(double k1, double k2, double b1, double b2)
{
    string findcross = " ";

    if (k1 == k2)
    {
        if (k1 == k2 && b1 == b2)
        {   
            findcross = "Прямые совпадают";
        }
        else findcross = "Прямые параллельны";
    }
    else
    {
        var crossX = Math.Round((b2 - b1) / (k1 - k2), 2);
        var crossY = Math.Round(k1 * (b2 - b1) / (k1 - k2) + b1, 2);
        findcross = "Координаты точки пересечений[ {crossX},{crossY}]";

    }
    return findcross;
}
void MessagePrint(string findcross)
{
    System.Console.WriteLine(findcross);
}


// // // Печать значений

void PrintMassive(int[,] massive)
{
    var lenght = massive.GetLength(0);
    for (int i = 0; i < lenght; i++)
    {
        System.Console.WriteLine($"{i + 1} => x = {massive[0, i]} <> у = {massive[1, i]}");
    }
    System.Console.WriteLine();
}

// // Печать функции

void PrintFunction(int[,] parray, int zeroX, int zeroY, bool color)
{
    int length = parray.GetLength(0);
    if (color == true) { Console.ForegroundColor = ConsoleColor.Red; }
    else { Console.ForegroundColor = ConsoleColor.Green; }
    for (int j = 0; j < length; j++)
    {
        var xpoint = 2 * parray[0, j] + zeroX;
        var ypoint = -parray[1, j] + zeroY;

        var buffer = Console.BufferHeight;
        if (ypoint > buffer) j += 1;

        else if (xpoint >= 0 & ypoint >= 0) Point(xpoint, ypoint);
        else
        {
            while (xpoint <= 0 && ypoint <= 0)
            {
                length -= 1;
            }
        }
    }
}
// // Вывод графики
void PrintResult(int fildwidth, int fildheight, int[,] arr1, int[,] arr2)
{
    int centrex = fildwidth / 2;
    int centrey = 2 + fildheight / 2;
    Console.ForegroundColor = ConsoleColor.White;
    // Циклы рабочего поля
    for (int c = 2; c <= fildheight + 2; c++)
    {
        Point(0, c);
        Point(fildwidth / 2, c);
        Point(fildwidth, c);
        Thread.Sleep(25);
    }

    for (int c = 0; c <= fildwidth; c++)
    {
        if (c % 2 == 0)
        {
            Point(c, 2);
            Point(c, 2 + fildheight / 2);
            Point(c, 2 + fildheight);
            Thread.Sleep(25);
        }
    }
    // Вывод функции
    PrintFunction(arr1, centrex, centrey, true);
    PrintFunction(arr2, centrex, centrey, false);
    Point(0, fildheight + 2);
    Console.ForegroundColor = ConsoleColor.White;

}


var n1 = InsertValue("Введите количество значений Х для первой функции");
var ferstX1 = InsertValue("Ведите первое значение интервала для первой функции");
var k1 = InsertValue("Ведите значение переменой k1");
var b1 = InsertValue("Ведите значение переменой b1");
var n2 = InsertValue("Введите количество значений Х для второй функции");
var ferstX2 = InsertValue("Ведите первое значение интервала для второй функции");
var k2 = InsertValue("Ведите значение переменой k2");
var b2 = InsertValue("Ведите значение переменой b2");
Console.Clear();

//Red                      xstart  n  k1 b1
int[,] array1 = LinearFunction(ferstX1, n1, k1, b1);
//Green                    xstart  n  k1 b1
int[,] array2 = LinearFunction(ferstX2, n2, k2, b2);

System.Console.WriteLine();

PrintResult(100, 40, array1, array2);

System.Console.WriteLine("Значения x и y -  функция 1 / Red");
PrintMassive(array1);
System.Console.WriteLine("Значения x и y -  функция 2 / Green");
PrintMassive(array2);

MessagePrint(FindCrossValid(k1, k2, b1, b2));
