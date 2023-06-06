// Задача 60. ***...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, 
// которая будет построчно выводить массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)

// функция ввода числа и возврата в числовом формате
int GetNumberInt( string text)
{
    Console.Write(text);
    return Convert.ToInt32(Console.ReadLine());
}

//проверка на наличие числа в массиве
bool ExistNumberArray(int value, int[,,] array)
{
    bool existNumber = false;
    for (int row = 0; row < array.GetLength(0); row++)
	{
		for (int column = 0; column < array.GetLength(1); column++)
		{
		    for(int depth = 0; depth < array.GetLength(2); depth++)
            {
                if (value == array[row,column,depth]) 
                {
                    existNumber = true;
                }
            }
        }
    }
    return existNumber;
}

//генерация трехмерного массива целыми числами в заданном диапазоне
int[,,] Generate3sizeArray(int[,,] array, int minValue, int maxValue)
{
    int value = 0;
    for (int row = 0; row < array.GetLength(0); row++)
	{
		for (int column = 0; column < array.GetLength(1); column++)
		{
		    for(int depth = 0; depth < array.GetLength(2); depth++)
            {
                value = new Random().Next(minValue, maxValue);
                while (ExistNumberArray(value,array))
                {
                    value = new Random().Next(minValue, maxValue);                        
                }
                array[row,column,depth] = value;                
            }
        }		
	}
    return array;
}

void Print3SizeArray (int[,,] array)
{
    for (int depth = 0; depth < array.GetLength(2); depth++)
	{		
        for (int row = 0; row < array.GetLength(0); row++)
		{
		    Console.Write("[ ");
            for(int column = 0; column < array.GetLength(1); column++)
            {
                Console.Write($"| {array[row,column,depth]} ({row},{column},{depth}) | ");
            }
            Console.WriteLine("]");
        }        		
	}    
}

//Приветствие
Console.Clear();
Console.WriteLine("Программа генерации 3х-мерного массива");
int rowX = GetNumberInt("Введите количество строк - ");
int columnY = GetNumberInt("Введите количество столбцов - ");
int depthZ = GetNumberInt("Введите количество слоев - ");
const int min = 10;
const int max = 100;
int[,,] array = new int[rowX,columnY,depthZ];
array = Generate3sizeArray(array, min, max);
Print3SizeArray(array);
