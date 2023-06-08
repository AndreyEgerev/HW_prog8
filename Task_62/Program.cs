// Задача 62 *** Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07

// функция ввода числа и возврата в числовом формате
int GetNumberInt( string text)
{
    Console.Write(text);
    return Convert.ToInt32(Console.ReadLine());
}

// метод заполнения массива по спирали
int[,] FillSpiralArray(int[,] array)
{
    int size = array.GetLength(0);
    int row = 0; 
    int column = 0;
    int value = 1;

        while (value <= size * size) 
        {
            
            // заполнение вправо
            while (column < size && array[row, column] == 0)
            {
                array[row, column] = value++;
                column++;
            }
            column--; // возврат на последнее заполненое значение и переход в другое направление
            row++;

            // заполнение вниз
            while (row < size && array[row, column] == 0)
            {
                array[row, column] = value++;
                row++;
            }
            row--; 
            column--; 

            // заполнение влево
            while (column >= 0 && array[row, column] == 0)
            {
                array[row, column] = value++;
                column--;
            }
            column++; 
            row--; 

            // заполнение вверх
            while (row >= 0 && array[row, column] == 0)
            {
                array[row, column] = value++;
                row--;
            }
            row++; 
            column++; 
        }
    return array;
}

//Вывод 2-мерного массива на экран
void Print2sizeArray (int[,] array)
{
	for (int row = 0; row < array.GetLength(0); row++)
	{
		Console.Write("[ ");
        for (int column = 0; column < array.GetLength(1); column++)
		{
			if (array[row, column] < 10 )
            {
                Console.Write($"0{array[row, column]} ");
            }
            else
            {
                Console.Write($"{array[row, column]} ");
            }
		}
		Console.WriteLine("]");
	}
}

//Приветствие
Console.Clear();
Console.WriteLine("Программа спирального заполнения 2х-мерного массива");
int size = GetNumberInt("Введите размер массива N*N - ");
int[,] spiralArray = new int[size,size];
Print2sizeArray (FillSpiralArray (spiralArray));