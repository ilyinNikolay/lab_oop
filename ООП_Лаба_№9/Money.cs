using System;

namespace OOP_Lab9
{
    public class Money
    {
        private int rubles = 0;
        private int kopeks = 0;
        private static int counter;
        public static int Counter
        {
            get { return counter; }
            private set { counter = value; }
        }

        public Money()
        {
            rubles = 0;
            kopeks = 0;
            Counter = counter + 1;
        }
        public Money(int rub, int kop)
        {
            Rub = rub;
            Kop = kop;
            Counter = counter + 1;
        }
        public Money(Money money)
        {
            Rub = money.rubles;
            Kop = money.kopeks;
            Counter = counter + 1;
        }

        public int Rub
        {
            get => rubles;
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Рублей не может быть меньше нуля!!!");
                    rubles = 0;
                }
                else
                {
                    rubles = value;
                }
            }
        }
        public int Kop
        {
            get => kopeks;
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Копеек не может быть меньше нуля!!!");
                    kopeks = 0;
                }
                else if (value > 99)
                {
                    rubles += value / 100;
                    kopeks = value % 100;
                }
                else
                {
                    kopeks = value;
                }
            }
        }
        public void Show()
        {
            if (kopeks < 10) 
            {
                Console.WriteLine($"{rubles}.0{kopeks}");
            }
            else
                Console.WriteLine($"{rubles}.{kopeks}");
        }

        public static Money operator --(Money money)
        {
            if (money.rubles == 0 && money.kopeks == 0)
            {
                Console.WriteLine("Отрицательная сумма");
                money.rubles = 0;
                money.kopeks = 0;
            }
            else
            {
                int M = money.rubles * 100 + money.kopeks - 1;
                money.rubles = (M) / 100;
                money.kopeks = (M) % 100;
            }
            return money;
        }
        public static Money operator ++(Money money)
        {
            if (money.kopeks == 99)
            {
                money.rubles++;
                money.kopeks = 0;
            }
            else
            {
                money.kopeks++; ;
            }
            return money;
        }

        public Money subtractionMoney(int cop)
        {
            Money temp = new Money();
            if (this.rubles * 100 + this.kopeks < cop)
            {
                temp.rubles = 0;
                temp.kopeks = 0;
                Console.WriteLine("Отрицательная сумма");
            }
            else 
            {
                int thisSum = this.rubles * 100 + this.kopeks;
                temp.rubles = (thisSum - cop) / 100;
                temp.kopeks = (thisSum - cop) % 100;
            }
            return temp;
        }

        public static Money operator +(Money money, int kop)
        {
            int moneySum = money.rubles * 100 + money.kopeks ;
            if (moneySum <= kop && kop < 0)
            {
                money.kopeks = 0;
                money.rubles = 0;
                Console.WriteLine("Отрицательная сумма");
            }
            else
            {
                moneySum +=  kop;

                money.kopeks = moneySum % 100;
                money.rubles = moneySum / 100;
            }
            return money;
        }
        public static Money operator +(int kop, Money money)
        {
            return money + kop;
        }

        public static Money operator -(Money m1, Money m2)
        {
            Money temp = new Money();
            if (m1.rubles * 100 + m1.kopeks < m2.rubles * 100 + m2.kopeks)
            {
                temp.rubles = 0;
                temp.kopeks = 0;
                Console.WriteLine("Отрицательная сумма");
            }
            else
            {
                int M1 = m1.rubles * 100 + m1.kopeks;
                int M2 = m2.rubles * 100 + m2.kopeks;
                temp.rubles = (M1 - M2) / 100;
                temp.kopeks = (M1 - M2) % 100;
            }
            return temp;
        }
        public static Money operator +(Money m1, Money m2)
        {
            Money temp = new Money();
            if (m1.rubles * 100 + m1.kopeks < m2.rubles * 100 + m2.kopeks)
            {
                temp.rubles = 0;
                temp.kopeks = 0;
                Console.WriteLine("Отрицательная сумма");
            }
            else
            {
                int M1 = m1.rubles * 100 + m1.kopeks;
                int M2 = m2.rubles * 100 + m2.kopeks;
                temp.rubles = (M1 + M2) / 100;
                temp.kopeks = (M1 + M2) % 100;
            }
            return temp;
        }
        public static Money operator -(int kop, Money money)
        {
            return money + kop;
        }

        //public static bool operator ==(Money m1, Money m2)
        //{
        //    int M1 = m1.rubles * 100 + m1.kopeks;
        //    int M2 = m2.rubles * 100 + m2.kopeks;
        //    return M1 == M2;
        //}
        //public static bool operator !=(Money m1, Money m2)
        //{
        //    int M1 = m1.rubles * 100 + m1.kopeks;
        //    int M2 = m2.rubles * 100 + m2.kopeks;
        //    return M1 != M2;
        //}

        public static explicit operator int(Money money)
        {
            return money.rubles;
        }

        public static implicit operator bool(Money money)
        {
            return (money.rubles + money.kopeks * 0.01) != 0;
        }
    }
}

//public static Money operator--(Money money)
//{
//    if (money.rubles > 0 && money.kopeks == 0)
//    {
//        money.rubles--;
//        money.kopeks = 99;
//    }
//    else
//    {
//        money.kopeks--;
//    }
//    return money;
//}

//public static Money operator ++(Money money)
//{
//    if (money.kopeks == 99)
//    {
//        money.rubles++;
//        money.kopeks = 0;
//    }
//    else
//    {
//        money.kopeks++; ;
//    }
//    return money;
//}

//public static explicit operator int(Money money)
//{
//    return money.rubles;
//}

//public static implicit operator bool(Money money)
//{
//    return (money.rubles + money.kopeks * 0.01) != 0;
//}

//public override string ToString()
//    => $"{Rub},{Kop:00}";

//public static Money operator +(Money m1, Money m2)
//{
//    int k = (m1.Rub < 0 ? -100 - m1.Kop : m1.Kop)
//        + (m2.Rub < 0 ? -100 - m2.Kop : m2.Kop);

//    int delta = k / 100;
//    k %= 100;
//    int r = (m1.Rub < 0 ? 1 : 0) + m1.Rub + (m2.Rub < 0 ? 1 : 0) + m2.Rub + delta;
//    return new Money(r, Math.Abs(k));
//}

//public static Money operator -(Money m1, Money m2)
//{
//    int k = (m1.Rub < 0 ? -100 - m1.Kop : m1.Kop)
//        - (m2.Rub < 0 ? -100 - m2.Kop : m2.Kop);

//    int delta = k / 100;
//    k %= 100;
//    int r = (m1.Rub < 0 ? 1 : 0) + m1.Rub - ((m2.Rub < 0 ? 1 : 0) + m2.Rub) + delta;
//    return new Money(r, Math.Abs(k));
//}

//public override bool Equals(object obj)
//    => Equals(obj as Money);
//public bool Equals(Money money)
//    => money != null &&
//           Rub == money.Rub &&
//           Kop == money.Kop;

//public override int GetHashCode()
//=> Rub ^ Kop;

//public static bool operator ==(Money m1, Money m2)
//    => object.Equals(m1, m2);
//public static bool operator !=(Money m1, Money m2)
//    => !object.Equals(m1, m2);