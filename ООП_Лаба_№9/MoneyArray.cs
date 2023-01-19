using System;


namespace OOP_Lab9
{
    public class MoneyArray
    {
        private Money[] array = null;
        private int size;
        private int counter;
        static Random rnd = new Random();
        public int Counter 
        {
            get { return counter; }
            private set { counter = value; }
        }
        public MoneyArray()
        {
            array = new Money[0];
            size = array.Length;
            Counter += 0;
        }
        public MoneyArray(int size)
        {
            array = new Money[size];
            for (int i = 0; i < size; i++)
            {
                Money tempMoney = new Money(rnd.Next(20), rnd.Next(100));
                array[i] = tempMoney;
            }
            Counter += size;
        }

        public MoneyArray(params Money[] list)
        {
            array = new Money[list.Length];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = list[i];
            }
            Counter += array.Length;
        }
        public int Length
        {
            get { return array.Length; }
        }

        public void Show()
        {
            Console.WriteLine("{");
            for (int i = 0; i < this.Length; i++)
            {
                Console.Write((i + 1) + ":\t");
                array[i].Show();
            }
            Console.WriteLine("}");
        }
        public Money this[int index]
        {
            get
            {
                if (index >= 0 && index < array.Length)
                {
                    return array[index];              
                }
                throw new IndexOutOfRangeException();
            }
            set
            {
                if (index >= 0 && index < array.Length)
                {
                    array[index] = value;
                }
                else
                {
                    Console.WriteLine("Выход за границу массива");
                }
            }
        }
    }
}
