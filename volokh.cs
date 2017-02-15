using System;

namespace volokhmi2
{
	class MainClass
	{
		static void func(int N,int[] arr) {
			int[] buff = new int[Int16.MaxValue];//буферный массив для подсчета кол-ва чисел
			int max_buf = int.MinValue, max_pos = 0;//буферная переменная для нахождения максимального,буферная переменная позиции
			int buf_count = 0;//буферная переменная на максимальное кол-ва раз
			long geom=1;//переменная для нахождения среднего геометрического ряда
			int summ = 0;
			double moda;
			double res;
			int i=0;
			for (i = 0; i < buff.Length; i++) {
				buff[i] = 0;//обнуляем его
			}
			for (i = 0; i < N; i++) {
				geom *= arr[i];//нахождение произведения всех чисел массива
				buff[arr[i]]++;//заполнение a[i] ячекк и увеличение их на один
							   //нахождение количество раз употребления каждого числа 
			}
			/*
			 По определению моды,мода-число наиболее встречающиеся, если их несколько одинаково встречающихся,
			 то это их среднее
			 что сделал мой алгоритм созда массив из 0 и в каждую ячейку с индексом равным числу прибавил, тем с
			 тем самым найдя кол-во каждого из чисел
			 потом нашел максимальное и сложил все максимальные и поделил на их колчесво 
			 */
			for (i = 0; i < buff.Length; i++) {
				if (buff[i] > max_buf) {
					max_pos = i;
					max_buf = buff[i];
				}
			}
			for (i = 0; i < buff.Length; i++)
			{
				if (buff[i] == max_buf)
				{
					summ += i;
					buf_count++; 
				}
			}
			moda = summ / (double)buf_count;
			res = Math.Pow((double)geom, (double)(1.0 / N));
			Console.WriteLine("Мода массива {0} Среднее геометрическое {1:0.000}",moda,res);
		}
		public static void Main(string[] args)
		{
			Console.WriteLine("Введите кол-во чисел");
			while (true)
			{
				int s = int.Parse(Console.ReadLine());
				if (s == -1) {
					break;
				}
				int[] array = new int[s];
				int i = 0;
				for (i = 0; i < s; i++)
				{
					Console.Write("Введите число номер {0} ", i + 1);
					array[i] = int.Parse(Console.ReadLine());
				}
				Console.Write("Массив ");
				for (i = 0; i < s; i++)
				{
					Console.Write("{0} ", array[i]);
				}
				Console.WriteLine();
				func(s, array);
				Console.WriteLine("Если хотите закончить введите -1");
			}
		}
	}
}
