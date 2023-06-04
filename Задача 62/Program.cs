// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07

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

int arrFill (double[,] arr, int x1, int y1, int x2, int y2, int n = 0) {
    int nt = 0;
    int n_max = arr.GetLength(0) * arr.GetLength(1);
    if(x1 == x2 && y2 > y1) {  //Заполнить слева направо
        for(int i = 0; i <= y2 - y1; i++) {
            nt = ++n;
            if(nt <= n_max) arr[x1, y1 + i] = nt;
        }
    }

    if(y1 == y2 && x2 > x1) { //Заполнить сверху вниз
        for(int i = 0; i <= x2 - x1; i++) {
            nt = ++n;
            if(nt <= n_max) arr[x1 + i, y1] = nt;
        }
    }

    if(x1 == x2 && y1 > y2) { //Заполнить справа налево
        for(int i = 0; i <= y1 - y2; i++) {
            nt = ++n;
            if(nt <= n_max) arr[x1, y1 - i] = nt;
        }
    }

    if(y1 == y2 && x1 > x2) { //Заполнить снизу вверх
        for(int i = 0; i <= x1 - x2; i++) {
            nt = ++n;
            if(nt <= n_max) arr[x1 - i, y1] = nt;
        }
    }

    if(y1 == y2 && x1 == x2) { //Заполнить в центре, если есть центр
        nt = ++n;
        if(nt <= n_max) arr[x1, y1] = nt;
    }
    return n;
}

msgStyle("Введите размер массива", "Blue");
msgStyle("x: ", "Red", 0);
string xx = consoleRead(2);
Console.WriteLine();
msgStyle("y: ", "Red", 0);
string yy = consoleRead(2);
Console.WriteLine();

int xm = Convert.ToInt32(xx); 
int ym = Convert.ToInt32(yy);

double[,] arr = new double[xm,ym];

int n = 0;
int x_s = 0, y_s = 0, x, y, x1, y1;

do {
    x = x_s; y = y_s; x1 = x; y1 = ym-1;
    n = arrFill(arr, x, y, x1, y1, n);
    x_s++; 

    x = x1 + 1; y = y1; x1 = xm-1;
    n = arrFill(arr, x, y, x1, y1, n);
    ym--;

    x = x1; y = y1 - 1; y1 = y_s;
    n = arrFill(arr, x, y, x1, y1, n);
    xm--;

    x = x1 - 1; y = y1; x1 = x_s;
    n = arrFill(arr, x, y, x1, y1, n);
    y_s++;
} while(n <= arr.GetLength(0) * arr.GetLength(1));

print_array(arr);


