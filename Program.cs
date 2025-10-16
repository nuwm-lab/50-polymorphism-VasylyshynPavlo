using System;

namespace LabWork
{
    // Даний проект є шаблоном для виконання лабораторних робіт
    // з курсу "Об'єктно-орієнтоване програмування та патерни проектування"
    // Необхідно змінювати і дописувати код лише в цьому проекті
    // Відео-інструкції щодо роботи з github можна переглянути 
    // за посиланням https://www.youtube.com/@ViktorZhukovskyy/videos 

    static public class Randomizer
    {
        private static Random _random = new Random();
        
        static public int Next(int min, int max)
        {
            return _random.Next(min, max);
        }
    }
    
    class Matrix2D
    {
        protected const int Rows = 3;
        protected const int Cols = 3;
        protected int[,] matrix = new int[Rows, Cols];

        public virtual void InputFromKeyboard()
        {
            Console.WriteLine("Enter elements of 2d matrix (3x3):");
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    Console.Write($"matrix[{i},{j}] = ");
                    matrix[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
        }

        public virtual void InputRandom()
        {
            for (int i = 0; i < Rows; i++)
            for (int j = 0; j < Cols; j++)
                matrix[i, j] = Randomizer.Next(0, 100);
        }

        public virtual int MinElement()
        {
            int min = matrix[0, 0];
            for (int i = 0; i < Rows; i++)
            for (int j = 0; j < Cols; j++)
                if (matrix[i, j] < min)
                    min = matrix[i, j];
            return min;
        }

        public virtual void Show()
        {
            Console.WriteLine("2D matrix:");
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                    Console.Write(matrix[i, j] + "\t");
                Console.WriteLine();
            }
        }
    }

    class Matrix3D : Matrix2D
    {
        private int[,,] matrix3D = new int[3, 3, 3];

        public override void InputFromKeyboard()
        {
            Console.WriteLine("Enter elements of 3D matrix (3x3x3):");
            for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
            for (int k = 0; k < 3; k++)
            {
                Console.Write($"matrix[{i},{j},{k}] = ");
                matrix3D[i, j, k] = Convert.ToInt32(Console.ReadLine());
            }
        }

        public override void InputRandom()
        {
            for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
            for (int k = 0; k < 3; k++)
                matrix3D[i, j, k] = Randomizer.Next(0, 100);
        }

        public override int MinElement()
        {
            int min = matrix3D[0, 0, 0];
            for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
            for (int k = 0; k < 3; k++)
                if (matrix3D[i, j, k] < min)
                    min = matrix3D[i, j, k];
            return min;
        }

        public override void Show()
        {
            Console.WriteLine("3D matrix:");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Depth {i + 1}:");
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 3; k++)
                        Console.Write(matrix3D[i, j, k] + "\t");
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }
    }
    
    class Program
    {
        static void ShowMin(Matrix2D matrix)
        {
            Console.WriteLine("Minimum element = " + matrix.MinElement());
        }

        static void Main(string[] args)
        {
            Matrix2D matrix2D = new Matrix2D();
            Matrix3D matrix3D = new Matrix3D();

            matrix2D.InputRandom();
            matrix3D.InputRandom();

            matrix2D.Show();
            matrix3D.Show();

            Console.WriteLine("Minimum in 2D matrix: " + matrix2D.MinElement());
            Console.WriteLine("Minimum in 3D matrix: " + matrix3D.MinElement());

            Console.WriteLine("\nDemonstration of polymorphism:");
            ShowMin(matrix2D); 
            ShowMin(matrix3D);
        }
    }
}
