using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var input = Console.ReadLine();
        var numbers = input.Split(' ').Select(x => double.Parse(x)).ToArray();

        Point M0, M1, S;

        M0 = new Point(numbers[0], numbers[1], numbers[2]); //Данный пункт.
        M1 = new Point(numbers[3], numbers[4], numbers[5]); //Точка на линии.
         S = new Point(numbers[6], numbers[7], numbers[8]); //Вектор направления линии.

        Vector M0_M1 = new Vector(ref M0, ref M1);
        Vector M0_M1__S = VectorProductOfVectors(ref M0_M1, ref S);

        Console.Write((M0_M1__S.Length / S.Module)); 
    }

    static Vector VectorProductOfVectors(ref Vector V1, ref Point V2)
    {
        Vector NewVector = new Vector(V1.y * V2.z - V2.y * V1.z,
                                        V1.x * V2.z - V2.x * V1.z,
                                        V1.x * V2.y - V2.x * V1.y);
        return NewVector;
    }

    class Point
    {
        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }
        public double Module { get; set; }

        public Point(double X, double Y, double Z)
        {
            x = X;
            y = Y;
            z = Z;
            VectorModule();
        }
        public void VectorModule()
        {
            Module = Math.Sqrt(x * x + y * y + z * z);
        }
    }
    class Vector
    {
        public double Length { get; set; }
        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }

        public void LengthVectorF()
        {
            Length = Math.Sqrt(x * x + y * y + z * z);
        }
        public Vector(ref Point FirstCoordinate, ref Point SecondCoordinate)
        {
            x = SecondCoordinate.x - FirstCoordinate.x;
            y = SecondCoordinate.y - FirstCoordinate.y;
            z = SecondCoordinate.z - FirstCoordinate.z;
        }
        public Vector(double X, double Y, double Z)
        {
            x = X;
            y = Y;
            z = Z;
            Length = Math.Sqrt(x * x + y * y + z * z);
        }
    }

}