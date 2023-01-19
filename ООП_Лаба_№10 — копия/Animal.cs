using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace OOP__lab10
{
    public  class Animal  : IRandomInit, IComparable, ICloneable
    {
        protected static readonly string[] Names = { "Кузя", "Рыжик", "Барсик", "Вася", "Боня", "Ричи", "Мишка", "Юта", "Оскар", "Рокс", "Девид", "Чарли" };
       
        protected string name;
        protected int weight;

        public Money money = new Money(IRandomInit.rnd.Next(10, 500));

        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public Animal() 
        {
            name = "";
            weight = 0;
        }
        public Animal(string name, int weight)
        {
            this.name = name;
            this.weight = weight;
        }
        public Animal(Animal animal)
        {
            this.name = animal.name;
            this.weight = animal.weight;
            this.money.Rubles = animal.money.Rubles;
        }
        public int CompareTo(Object? obj)
        {
            if (obj is Animal other)
                return this.Weight.CompareTo(other.Weight);
            else
                throw new ArgumentException("Object is not an Animal");
        }
        public virtual void RandomInit()
        {
            this.Name = Names[IRandomInit.rnd.Next(0, Names.Length)];
            this.Weight = IRandomInit.rnd.Next(100, 10000);
        }
        public override string ToString()
        {
            return $"Животное: {Name}, weight: {Weight}";
        }
        public virtual void Show()
        {
            Console.WriteLine("Животное!");
        }
        public virtual void ShowInfo()
        {
            Console.WriteLine($"{this.GetType().Name}  weight: {Weight} kg");
        }
        public virtual object Clone()
        {
            var temp = new Animal(this.Name, this.Weight);
            temp.money = new Money(this.money.Rubles);
            return temp;
        }
        public object ShallowCopy()
        {
            return MemberwiseClone();
        }

        public static int TotalCost(int aB, int aM, int aA)
        {
            int sum = 0;

            Console.WriteLine($"\nКоличество птиц {aB}");
            Console.WriteLine($"\nКоличество млекопитающих {aM}");
            Console.WriteLine($"\nКоличество парнокопытных млекопитающих {aA}");

            for (int i = 0; i < aB; i++) 
            {
                sum +=  Bird.cost;
            }

            for (int i = 0; i < aM; i++)
            {
                sum += Mammal.cost;
            }

            for (int i = 0; i < aA; i++)
            {
                sum += Artiodactyl.cost;
            }

            return sum;
        }
        public static string nameBirdMore4WL(Animal[] aB)
        {
            string nB = "";

            for (int i = 0; i < aB.GetLength(0); i++)
            {
                if ((aB[i]) is Bird) 
                {
                    Bird b = (Bird)aB[i];
                    if (b.wingLength > 4) 
                    {
                        nB += aB[i].Name + " ";

                    }
                }
            }

            return nB;
        }
        public static double averageWeightArtiodactyl(Animal[] aA)
        {
            double aW = 0.0;

            int count = 0;

            for (int i = 0; i < aA.GetLength(0); i++)
            {
                if ((aA[i]) is Artiodactyl)
                {
                    Artiodactyl a = (Artiodactyl)aA[i];
                    aW += (double)a.Weight;
                    count++;
                }
            }         

            if(count != 0)
                aW = aW / aA.GetLength(0);

            return aW;
        }

        public override bool Equals(Object o)
        {
            return this.Compare((Animal)o);
        }

        public bool Compare(Animal a1)
        {
            return (this.Name == a1.Name
                && this.Weight == a1.Weight);
        }
    }
}
