using System;

namespace OOP__lab10
{
    public class Mammal : Animal
    {
        protected static readonly string[] Groups = { "Гагарообразные", "Поганкообразные", "Курообразные", "Трубконосые", "Журавлеобразные", "Ржанкообразные", "Голубеобразные", "Кукушкообразные", "Стрижеобразные", "Совообразные" };
        public static int cost = 7500;
        protected string group;
        public string Group
        {
            get { return group; }
            set { group = value; }
        }
        public override string ToString()
        {
            return $"Животное: {Name}, weight: {Weight}, group:  {group}";
        }
        public Mammal(string _name, int _weight, string _group) : base(_name, _weight)
        {
            group = _group;
        }
        public Mammal() : base()
        {
            group = "";
        }
        public Mammal(Mammal _animal) : base(_animal)
        {
            group = _animal.group;
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"{this.GetType().Name} weight: {Weight} kg");
        }
        public override void Show()
        {
            Console.WriteLine("Млекопитающее!");
        }
        public override void RandomInit()
        {
            this.Name = Names[IRandomInit.rnd.Next(0, Names.Length)];
            this.Weight = IRandomInit.rnd.Next(100, 10000);
            this.Group = Groups[IRandomInit.rnd.Next(0, Groups.Length)];
        }
        public override object Clone()
        {
            var temp = new Mammal(this.Name, this.Weight, this.Group);
            temp.money = new Money(this.money.Rubles);
            return temp;
        }
        public override bool Equals(Object o)
        {
            return this.Compare((Mammal)o);
        }

        public bool Compare(Mammal a1)
        {
            return (this.Name == a1.Name
                && this.Weight == a1.Weight 
                && this.Group == a1.Group);
        }
    }
}
