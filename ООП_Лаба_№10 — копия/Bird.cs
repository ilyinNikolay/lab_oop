using System;

namespace OOP__lab10
{
    public class Bird : Animal
    {
        public int wingLength;
        public static int cost = 5000;
        public int WingLength
        {
            get { return wingLength; }
            set { wingLength = value; }
        }
        public Bird(string _name, int _weight, int _wingLength) : base(_name, _weight)
        {
            wingLength = _wingLength;
        }
        public Bird() : base()
        {
            wingLength = 0;
        }
        public Bird(Bird _animal) : base(_animal)
        {
            wingLength = _animal.wingLength;
        }
        public override void ShowInfo()
        {
            Console.WriteLine($"{this.GetType().Name} weight: {Weight} kg");
        }
        public override void Show()
        {
            Console.WriteLine("Птица!");
        }
        public override string ToString()
        {
            return $"Животное: {Name}, weight: {Weight}, WingLength: {wingLength}";
        }
        public override void RandomInit()
        {
            this.Name = Names[IRandomInit.rnd.Next(0, Names.Length)];
            this.Weight = IRandomInit.rnd.Next(100, 10000);
            this.WingLength = IRandomInit.rnd.Next(2, 10);
        }
        public override object Clone()
        {
            var temp = new Bird(this.Name, this.Weight, this.WingLength);
            temp.money = new Money(this.money.Rubles);
            return temp;
        }
        public override bool Equals(Object o)
        {
            return this.Compare((Bird)o);
        }

        public bool Compare(Bird a1)
        {
            return (this.Name == a1.Name
                && this.Weight == a1.Weight
                && this.WingLength == a1.WingLength);
        }
        /* public static string nameBirdMore4WL(Bird[] aB)
         {
             string nB = "";

             for (int i = 0; i < aB.GetLength(0); i++)
             {
                 if (aB[i].WingLength > 4)
                     nB += aB[i].Name + " ";
             }

             return nB;
         }*/
    }
}
