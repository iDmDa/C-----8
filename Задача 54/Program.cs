//Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.

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

msgStyle("Введите размер массива", "Blue");
msgStyle("x: ", "Red", 0);
string xx = consoleRead(2);
Console.WriteLine();
msgStyle("y: ", "Red", 0);
string yy = consoleRead(2);
Console.WriteLine();

int x = Convert.ToInt32(xx); 
int y = Convert.ToInt32(yy);

double[,] arr = create_array(x, y);

print_array(arr);

for(int i = 0; i < arr.GetLength(0); i++) {
    double[] tmpArr = new double[arr.GetLength(1)];
    for(int j = 0; j < arr.GetLength(1); j++) {
        tmpArr[j] = arr[i, j];
        Array.Sort(tmpArr);
        Array.Reverse(tmpArr);
    }
    for(int j = 0; j < arr.GetLength(1); j++) {
        arr[i, j] = tmpArr[j];
    }
}

Console.WriteLine();
msgStyle("Отсортированный массив", "Red");
print_array(arr);