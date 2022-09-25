using System;
using System.Globalization;

namespace hw2
{
    class Programm
    {
        static double seg1(double x)
        {
            int k = 1;
            int b = 3;
            double y = k * x + b;
            return y;
        }
        static double seg2(double x)
        {
            double k = -0.5;
            int b = 0;
            double y = k * x + b;
            return y;
        }
        static double seg3(double x)
        {
            int k = 0;
            int b = -2;
            double y = k * x + b;
            return y;
        }
        static double seg4(double x, double r)
        {
            int a = 8;
            int b = 2;
            double y = Math.Sqrt(r*r - (x-a)*(x-a))-b;
            return y;
        }
        public static int Main(string[] args)
        {
            int f = 1;
            do
            {
                int r;
                string R;
                Console.WriteLine("Введите радиус окружности.");
                do
                {
                    R = Console.ReadLine();
                    if (int.TryParse(R, out r))
                    {
                        break;
                    }
                    Console.WriteLine("Радиус должен быть целым числом.");
                } while (true);
                if (r<0)
                {
                    Console.WriteLine("Я надеюсь вы знаете, что радиус не может быть <0 и поставили минус случайно, переведу радиус в положительное число");
                    r = -1 * r;
                    Console.WriteLine($"Радиус(r) = {r}");
                }
                if (r == 0)
                {
                    Console.WriteLine("Радиус не может быть равен 0, возьму ближайшее, т.е 1");
                    r = 1;
                }
                if (r<2)
                {
                    Console.WriteLine("Функция в некоторых точках будет неопределена, хотите если хотите перезаписать -  введите 1, нет - 0.");
                    int z = Convert.ToInt32(Console.ReadLine());
                    while (true)
                    {
                        if (z == 1)
                        {
                            Console.WriteLine("Введите новый радиус.");
                            do
                            {
                                R = Console.ReadLine();
                                if (int.TryParse(R, out r))
                                {
                                    break;
                                }
                                Console.WriteLine("Радиус должен быть целым числом.");
                            } while (true);
                            break;
                        }
                        else if (z == 0)
                        {
                            break;
                        }
                    }
                    
                }
                for (double x = -4; x<=10; x = x + 0.2)
                {
                    if ((x >= -4) && (x <= -2))
                    {
                        Console.WriteLine("y({0:0.00}) = {1:0.00}", x, seg1(x));
                    }
                    else if ((x > -2) && (x <= 4))
                    {
                        Console.WriteLine("y({0:0.00}) = {1:0.00}", x, seg2(x));
                    }
                    else if ((x > 4) && (x < 6.1))
                    {
                        Console.WriteLine("y({0:0.00}) = {1:0.00}", x, seg3(x));
                    }
                    if ((x >= 6) && (x <= 10))
                    {
                        if (r < 2)
                        {
                            Console.WriteLine($"Фунция не определена в точках, где x больше 6(не включая) до {8 - r}(не включая) и от {10 - r}(не включая) до 10");
                            for (x = 8 - r; x <= 10 - r; x = x + 0.2)
                            {
                                Console.WriteLine("y({0:0.00}) = {1:0.00}", x, seg4(x, r));
                            }
                            break;
                        }
                        if ((r>2) && (x>=6))
                        {
                            Console.WriteLine("y({0:0.00}) = {1:0.00}", x, seg4(x, r));
                        }
                        if ((r==2) && (x>6.1))
                        {
                            Console.WriteLine("y({0:0.00}) = {1:0.00}", x, seg4(x, r));
                        }
                    }               
                }
                Console.WriteLine("Чтобы повторить 1, чтобы завершить - 0.");
                f = Convert.ToInt32(Console.ReadLine());
            } while (f == 1);
            return 0;
        }
    }
}
