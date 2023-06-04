//Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
#pragma warning disable

void msgStyle (string message, string status = "Green", int newLine = 1) {
    //Black, DarkBlue, DarkGreen, DarkCyan, 
    //DarkRed, DarkMagenta, DarkYellow, Gray, 
    //DarkGray, Blue, Green, Cyan, 
    //Red, Magenta, Yellow, White

    var cons_color = new Dictionary<string, int>();
    for (int i = 0; i < 16; i++) cons_color.Add(((ConsoleColor)i).ToString(), i);

    Console.ForegroundColor = (ConsoleColor)cons_color[status];
    if(newLine == 1) Console.WriteLine(message);
    else Console.Write(message);
    Console.ForegroundColor = ConsoleColor.Gray;
}

string consoleRead(int len, string charList = "1234567890") {  //Ограничение ввода с клавиатуры
    string str = string.Empty;
    while (true)
    {
        char ch = Console.ReadKey(true).KeyChar;
        if (ch == '\r' && str.Length > 0) break;
        if (ch == 'q' || ch == 'Q') System.Environment.Exit(0);
        if (ch == '\b' && str.Length > 0) {
                str = str.Substring(0, str.Length - 1);
                Console.Write("\b \b");
        }
        else if (str.Length < len && charList.IndexOf(ch) != -1)
        {
            if(ch == '-' && str.Length > 0) continue;
            Console.Write(ch);
            str += ch;
        }
    }
    return str;
}

void print_array (double[,] arr) {
    for(int i = 0; i < arr.GetLength(0); i++) {
        for(int j = 0; j < arr.GetLength(1); j++) {
            msgStyle($"{arr[i,j]}\t", "DarkCyan", 0);
        }
        Console.WriteLine();
    }
}

double[,] create_array (int x, int y, double diapazon_start = 1, double diapazon_end = 9, int len = 0) {
    double[,] result_array = new double[x, y];
    Random rnd = new Random();
    for(int i = 0; i < x; i++) {
        for(int j = 0; j < y; j++) {
            result_array[i,j] = Math.Round(rnd.NextDouble() * (diapazon_start - diapazon_end) + diapazon_end, len);
        }
    }
    return result_array;
}

msgStyle("Введите размер первого массива", "Blue");
msgStyle("x: ", "Red", 0);
string xx = consoleRead(2);
Console.WriteLine();
msgStyle("y: ", "Red", 0);
string yy = consoleRead(2);
Console.WriteLine();

msgStyle("Введите размер второго массива", "Blue");
msgStyle("y2: ", "Red", 0);
string yy2 = consoleRead(2);
Console.WriteLine();

int x = Convert.ToInt32(xx); 
int y = Convert.ToInt32(yy);
int y2 = Convert.ToInt32(yy2);

double[,] arr = create_array(x, y);
double[,] arr2 = create_array(y, y2);
double[,] arr3 = new double[x, y2];

Console.WriteLine();
msgStyle("Первый массив", "Red");
print_array(arr);
Console.WriteLine();
msgStyle("Второй массив", "Red");
print_array(arr2);

for(int i = 0; i < arr.GetLength(0); i++) {
    for(int j = 0; j < arr2.GetLength(1); j++) {
        for(int k = 0; k < arr.GetLength(1); k++) {
            arr3[i, j] = arr3[i, j] + arr[i,k]*arr2[k,j];
        }
    }
}

Console.WriteLine();
msgStyle("Произведение", "Red");
print_array(arr3);
