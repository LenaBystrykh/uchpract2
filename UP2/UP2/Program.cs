using System;

namespace UP2
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            bool ok;
            int n;
            do
            {
                ok = int.TryParse(Console.ReadLine(), out n);                     //ввод количества чисел
            } while (!ok || n < 1 || n > 100);

            string userNumbers = Console.ReadLine();                              //ввод N чисел-вероятностей
            string[] stringNumbers = userNumbers.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            double[] doubleNumbers = new double[0];
            for (int i = 0; i < stringNumbers.Length; i++)
            {
                double[] newDoubleNumbers = new double[doubleNumbers.Length + 1]; //вспомогательный массив размером на 1 больше текущего
                doubleNumbers.CopyTo(newDoubleNumbers, 0);                        //вносим все значения текущего массива во вспомогательный массив
                doubleNumbers = new double[newDoubleNumbers.Length];              //увеличиваем размер текущего массива
                newDoubleNumbers.CopyTo(doubleNumbers, 0);                        //переносим значения из вспомогательного массива обратно в текущий
                ok = double.TryParse(stringNumbers[i], out doubleNumbers[i]);
                if (!ok)
                {
                    //некорректные данные
                    return;
                }
            }
            double p = 1;
            double q;
            for (int i = 0; i < doubleNumbers.Length; i++)
            {
                q = 1 - p;
                p = p * doubleNumbers[i] + q * (1 - doubleNumbers[i]);
            }
            string res = Math.Round(p, 6).ToString();
            Console.WriteLine(res);
        }
    }
}
