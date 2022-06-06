int m = Convert.ToInt32(Console.ReadLine());
int n = Convert.ToInt32(Console.ReadLine());
int[,] mas = new int[m,n+1];
Random r = new Random();

for (int i = 0; i < m; i++)
{
    for (int j = 0; j<n+1; j++)
    {
        mas[i, j] = r.Next(10,20);
    }
}//заполнение матрицы рандомом
for (int i = 0; i < m; i++)
{
    int c = 0;
    for (int j = 0; j < n; j++)
    {
        c+=mas[i,j];
    }
    mas[i,n] = c;
}//заполнение четвертого столбца суммой строки
for (int i = 0; i < m; i++)
{
    for (int j = 0; j < n+1; j++)
    {
        Console.Write("{0}\t", mas[i,j]);
    }
    Console.WriteLine();
}//вывод
while (true)
{
    int count = 0;
    for (int i = 0; i < m-1; i++)
    {
        int tmp;
        if (mas[i, n] <= mas[i+1,n])
        {
            for (int j = 0; j < n+1; j++)
            {
                tmp = mas[i, j];
                mas[i, j] = mas[i + 1, j];
                mas[i + 1, j] = tmp;
            }
        }        
    }
    for (int i = 1; i < m; i++)
    {
        if (mas[i, n] <= mas[i - 1, n]) { count++; }
    }
    if (count == m-1) { break; }
}//реализация пузырька
Console.WriteLine();
for (int i = 0; i < m; i++)
{
    for (int j = 0; j < n+1; j++)
    {
        Console.Write("{0}\t", mas[i, j]);
    }
    Console.WriteLine();
}//вывод

int[] sum = new int[n];
int min = mas[0,0];

for (int j = 0; j < n; j++)
{
    if (mas[0, j] < min) { min = mas[0, j];}
}
for (int j = 0; j < n; j++)
{
    if (mas[0, j] != min) { mas[0, j] = 0;}
    if(mas[0, j] == min) { sum[j] = min; for (int k = j+1;k<n;k++) { mas[0, k] = 0; } }    
}
Console.WriteLine();//нашли первый минимальный элемент

for (int j = 0; j < n; j++)
{
    sum[j] = mas[0,j];
}

for (int i = 1; i < m; i++)//циклы для алгоритма
{
    for (int j = 0; j < n; j++)
    {
        sum[j] += mas[i, j];//прибавил строку к первой
    }
    min = 1000;
    for (int j = 0; j < n; j++)
    {
        if (sum[j] < min) { min = sum[j]; }//обозначил минимальный элемент
    }
    for (int j = 0; j < n; j++)
    {
        if (sum[j] == min) { min = 1000; }else { sum[j] -= mas[i, j]; }//вычел строку из первой, кроме минимума
    }
}

//вывод
Console.WriteLine();
for (int j = 0; j < n; j++)
{
    Console.Write("{0}\t", sum[j]);
}