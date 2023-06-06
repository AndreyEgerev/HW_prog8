// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2

// функция ввода числа и возврата в числовом формате
int GetNumberInt( string text)
{
    Console.Write(text);
    return Convert.ToInt32(Console.ReadLine());
}

//Вывод 2-мерного массива на экран
void Print2sizeArray (int[,] arr)
{
	for (int i = 0; i < arr.GetLength(0); i++)
	{
		Console.Write("[ ");
        for (int j = 0; j < arr.GetLength(1); j++)
		{
			if (arr[i,j] < 10 )
            {
                Console.Write($"0{arr[i, j]} ");
            }
            else
            {
                Console.Write($"{arr[i, j]} ");
            }
		}
		Console.WriteLine("]");
	}

}

//Функция генерации массива целыми числами в заданном диапазоне
int[,] GetArrayInt(int[,] arrayInt, int minValue, int maxValue)
{
    //int[,] arrayInt = new int[row,column];
    for (int i = 0; i < arrayInt.GetLength(0); i++)
	{
		for (int j = 0; j < arrayInt.GetLength(1); j++)
		{
		 arrayInt[i,j] = new Random().Next(minValue, maxValue);
        }
		
	}
    return arrayInt;
}

//Сортировка 2-мерного массива на экран по стокам по убыванию элементов
// not complete
int[,] Sort2sizeArray (int[,] arr)
{
	int maxElement = arr[0,0];
	for (int i = 0; i < arr.GetLength(0); i++)
	{
		for (int j = 0; j < arr.GetLength(1); j++)
		{
			for (int k = 0; k < arr.GetLength(1)-1; k++)
            {
                if (arr[i, k ] < arr[i, k + 1])
                {
                    maxElement = arr [i, k+1];
                    arr[i,k+1] = arr [i, k];
                    arr[i, k] = maxElement;                
                }
            }
		}		
	}
    return arr;
}

//Задание размера 2х-мерного массива
const int rows = 3;
const int columns = 4;


//Приветствие
Console.WriteLine("Программа упорядочивание элементов массива по убыванию по строчно");
//Задание размера 2х-мерного массива
int row = GetNumberInt("Введите количество строк - ");
int column = GetNumberInt("Введите количество столбцов - ");
int[,] arrayIntNumbers = new int[row,column];
int[,] arrayIntNumbersSort = new int[row,column];
//генерация 2х-мерного массива с элементамми в диапазоне от 0 до 10
arrayIntNumbers = GetArrayInt(arrayIntNumbers,0,50);
Print2sizeArray(arrayIntNumbers);
arrayIntNumbersSort = Sort2sizeArray(arrayIntNumbers);
Console.WriteLine("Отсортированный массив");
Print2sizeArray(arrayIntNumbersSort);