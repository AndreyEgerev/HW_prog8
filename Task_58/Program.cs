// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

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
			if (arr[row,column] < 10 )
            {
                Console.Write($"0{arr[row, column]} ");
            }
            else
            {
                Console.Write($"{arr[row, column]} ");
            }
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
//функция перемножения столбца со строкой
int MultiplicateElement (int[,] matrixA, int[,] matrixB, int row, int column)
{
    int MultiplicateElementAB = 0;
    for (int i = 0; i < matrixA.GetLength(1); i++)
    {
        MultiplicateElementAB += matrixA[row,i]*matrixB[i,column];
    }
    return MultiplicateElementAB;
}

//функция перемножения матриц
int[,] MultiplicationMatrix (int[,] matrixA, int[,] matrixB)
{
    int[,] matrixC = new int[matrixA.GetLength(0),matrixB.GetLength(1)];
    int rowMax = matrixA.GetLength(0);
    int columnMax = matrixB.GetLength(1);
    for (int row = 0; row < matrixC.GetLength(0); row++)
    {
        for (int column = 0; column < matrixC.GetLength(1); column++)
        {
            matrixC[row,column] = MultiplicateElement(matrixA,matrixB,row,column);
        }
    }
    return matrixC;
}

//Приветствие
Console.Clear();
Console.WriteLine("Программа перемножения двух матриц");
//Задание размера 2х-мерного массива
// int[,] matrixAint = {
//                 {9, 2, 3},
//                 {1, 0, 7}                
//             };
// int[,] matrixBint = {
//                 {5, 2},
//                 {8, 2},
//                 {3, 2}
//             };
int row = GetNumberInt("Введите количество строк первой матрицы - ");
int column = GetNumberInt("Введите количество столбцов первой матрицы - ");
int[,] matrixA = new int[row, column];
int[,] matrixB = new int[column, row];
int[,] matrixC = new int[matrixA.GetLength(0),matrixB.GetLength(1)];
//генерация 2х-мерного массива с элементамми в диапазоне от 0 до 10 с выводом на экран
matrixA = GetArrayInt(matrixA,0,10);
matrixB = GetArrayInt(matrixB,0,10);
Print2sizeArray(matrixA);
Console.WriteLine(" X");
Print2sizeArray(matrixB);
Console.WriteLine(" =");
matrixC = MultiplicationMatrix(matrixA, matrixB);
Print2sizeArray(matrixC);