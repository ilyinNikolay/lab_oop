using System;


namespace OOP_Lab9
{
    public class Program
    {
        public static Money subtractionMoney(Money m1, int cop)
        {
            return m1.subtractionMoney(cop);
        }
        public static double arithmeticMean(MoneyArray array)
        {
            Money temp = new Money();
            if (array.Length != 0)
            {
                int sumMoneyArray = 0;
                for (int i = 0; i < array.Length; i++)
                {
                    sumMoneyArray += array[i].Rub * 100 + array[i].Kop;
                }

                double arithmeticMeanSumMoneyArray = (double)sumMoneyArray / ((array.Length) * 100);
                             
                return arithmeticMeanSumMoneyArray;
            }
            else
            {
                Console.WriteLine("Массив пустой");
                return 0;
            }
        }
        static void Main(string[] args)
        {
            Money m1 = new Money();
            m1.Show();

            Money m2 = new Money(1,02);
            m2.Show();


            Money m3 = new Money(3,20);
            m3.Show();

            m3 = subtractionMoney(m3,200);
            m3.Show();
            

            MoneyArray array = new MoneyArray(100);      
            array.Show();

            Console.WriteLine($"Среднее арифметическое: " + Math.Round(arithmeticMean(array), 3));
           
            array[100] = new Money(100, 100);
            Console.WriteLine("\n");

            try
            {
                array[100].Show();
            }
            catch 
            {
                Console.WriteLine("Error: IndexOutOfRangeException");
            }


            MoneyArray array1 = new MoneyArray(m1, m2, m3);
            array1.Show();
            Console.WriteLine($"Среднее арифметическое: " + Math.Round(arithmeticMean(array1), 3));
        }
    }
}
