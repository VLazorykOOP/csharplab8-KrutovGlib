using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8CSharp.Fourth
{
    internal class Fourth
    {

       public void fourth()
        {
            // Введення кількості чисел у послідовності
            Console.Write("Введіть кількість чисел у послідовності: ");
            int n = int.Parse(Console.ReadLine());

            // Введення чисел у послідовності
            double[] numbers = new double[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Введіть число {i + 1}: ");
                numbers[i] = double.Parse(Console.ReadLine());
            }

            // Запис чисел у файл
            WriteToFile(numbers, "D:\\CHsarp\\Csharp_Lab8\\fourth.bin");

            // Зчитування та виведення чисел з непарними номерами, більших заданого числа
            Console.Write("Введіть задане число: ");
            double threshold = double.Parse(Console.ReadLine());
            ReadAndPrintNumbers("D:\\CHsarp\\Csharp_Lab8\\fourth.bin", threshold);
            Console.ReadKey();
        }



        public void WriteToFile(double[] numbers, string fileName)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.Create)))
            {
                foreach (double num in numbers)
                {
                    writer.Write(num);
                }
            }
            Console.WriteLine($"Числа були успішно записані у файл {fileName}");
        }

        static void ReadAndPrintNumbers(string fileName, double threshold)
        {
            Console.WriteLine($"Числа з непарними номерами, більші за {threshold}:");
            using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
            {
                int i = 1;
                while (reader.PeekChar() > -1)
                {
                    double num = reader.ReadDouble();
                    if (i % 2 != 0 && num > threshold)
                    {
                        Console.WriteLine($"Число на позиції {i}: {num}");
                    }
                    i++;
                }
            }
        }




    }
}
