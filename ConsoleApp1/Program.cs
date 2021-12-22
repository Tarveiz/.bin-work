using System;
using System.IO;


namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            FileOpen();
        }

        static void FileOpen()
        {
            //-----Открытие файла-------
            string path = @"udk_dump.bin";
            if (File.Exists(path))
            {
                Console.WriteLine("Файл найден");
            }
            else
            {
                Console.WriteLine("Ошибка открытия файла");
                return;
            }
            Devi(path);
        }

        static void Devi(string path)
        {
            
            //------Считывание файла------
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                int i = 0;
                int i1 = 0;
                Console.WriteLine("Введите количество байт, которое нужно считать: ");
                i1 = Convert.ToInt32(Console.ReadLine());

                while (reader.BaseStream.Position != reader.BaseStream.Length + 1 && i != i1)
                {
                    Console.WriteLine("///////////////////");
                    int cc8 = Convert.ToInt32(reader.ReadByte()); // целочисленное значение байта
                    int Copy = cc8;  //копия 1
                    int Copy1 = Copy;  //копия 2
                    int n = 0;  //Счетчик количества цифр в числе байта
                    while (cc8 > 0)
                    {
                        cc8 /= 10;
                        n++;
                    }
                    int cc10 = 0; //Само 10-ричное число
                    double g;  //буфер типа double для использования Math.Pow
                    for (int j = 0; j != n; j++)
                    {
                        g = Copy % 10 * Math.Pow(8, j);
                        Copy /= 10;
                        cc10 += Convert.ToInt32(g);
                        if (j >= n - 1)
                        {
                            string str = Convert.ToString(cc10, 2); //конвертация в тип string для вывода первых двух цифр двоичной записи
                            Console.WriteLine("Байт: " + Copy1 + "\nДвоичная запись: " + str + "\nПервый бит байта: " + str[0] + "\nВторой бит байта: " + str[1] + "\nОба бита сразу: " + str[0] + Convert.ToChar(str[1]));
                        }
                    }

                    Console.WriteLine("///////////////////\n");
                    i++;
                }

            }
        }
    }
}