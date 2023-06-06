// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка

// функция ввода числа и возврата в числовом формате
int GetNumberInt( string text)
{
    Console.Write(text);
    return Convert.ToInt32(Console.ReadLine());
}

//Вывод 2-мерного массива на экран
void Print2sizeArray (int[,] arr)
{
	for (int row = 0; row < arr.GetLength(0); row++)
	{
		Console.Write("[ ");
        for (int column = 0; column < arr.GetLength(1); column++)
		{
			Console.Write($"{arr[row, column]} ");
		}
		Console.WriteLine("]");
	}
}

//Функция генерации массива целыми числами в заданном диапазоне
int[,] GetArrayInt(int[,] arrayInt, int minValue, int maxValue)
{
    for (int row = 0; row < arrayInt.GetLength(0); row++)
	{
		for (int column = 0; column < arrayInt.GetLength(1); column++)
		{
		 arrayInt[row,column] = new Random().Next(minValue, maxValue);
        }		
	}
    return arrayInt;
}

//функция подсчета суммы элементов в строке массива
int SummRowArray(int[,] array, int row)
{
    int summRow = 0;
    for (int column = 0; column < array.GetLength(1); column++)
    {
        summRow += array[row,column];
    }
    return summRow;
}

// функция нахождения строки с минимальной суммой элементов 
int FindMinRowArray(int[,] array)
{
    int minRowArray = 0;
    int minRowArraySumm = SummRowArray(array, 0);
    int minRowArraySummCurrent = minRowArraySumm;
    
    for (int row = 1; row < array.GetLength(0); row++)
    {
        minRowArraySummCurrent = SummRowArray(array, row);
        
        if (minRowArraySummCurrent < minRowArraySumm)
        {
            minRowArraySumm = minRowArraySummCurrent;
            minRowArray = row;
        }
    }
    return minRowArray;
}

//Приветствие
Console.WriteLine("Программа нахождения строки с наименьшей суммой элементов");
//Задание размера 2х-мерного массива
int row = GetNumberInt("Введите размер массива - ");
int[,] arrayIntNumbers = new int[row,row+1];
//генерация 2х-мерного массива с элементамми в диапазоне от 0 до 9 и вывод на экран
arrayIntNumbers = GetArrayInt(arrayIntNumbers,0,10);
Print2sizeArray(arrayIntNumbers);
Console.WriteLine();
Console.WriteLine($"Строка с наименьшей суммой элементов - {FindMinRowArray(arrayIntNumbers)+1}");