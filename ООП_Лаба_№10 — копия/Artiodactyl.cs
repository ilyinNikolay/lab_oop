using System;

namespace OOP__lab10
{
    public class Artiodactyl : Mammal
    {
        protected static readonly string[] SubOrders = { "Рукокрылые", "Насекомоядные", "Ластоногие", "Хоботные", "Грызуны", "Приматы", "Хищные" };
        protected string subOrder;
        public static int cost = 12000;
        public string SubOrder
        {
            get { return subOrder; }
            set { subOrder = value; }
        }
        public Artiodactyl() : base()
        {
            subOrder = "";
        }
        public Artiodactyl(string _name, int _weight, string _group, string _subOrder) : base(_name, _weight, _group)
        {
            subOrder = _subOrder;
        }      
        public Artiodactyl(Artiodactyl _animal) : base(_animal)
        {
            subOrder = _animal.subOrder;
        }
        public override void ShowInfo()
        {
            Console.WriteLine($"{this.GetType().Name} weight: {Weight} kg");
        }
        public override void Show()
        {
            Console.WriteLine("Парнокопытное Млекопитающее!");
        }
        public override void RandomInit()
        {
            this.Name = Names[IRandomInit.rnd.Next(0, Names.Length)];
            this.Weight = IRandomInit.rnd.Next(100, 10000);
            this.Group = Groups[IRandomInit.rnd.Next(0, Groups.Length)];
            this.SubOrder = SubOrders[IRandomInit.rnd.Next(0, SubOrders.Length)];
        }
        public override string ToString()
        {
            return $"Животное: {Name}, weight: {Weight}, group:  {group}, subOrder:  {SubOrder}";
        }
        public override object Clone()
        {
            var temp = new Artiodactyl(this.Name, this.Weight, this.Group, this.SubOrder);
            temp.money = new Money(this.money.Rubles);
            return temp;
        }
        public override bool Equals(Object o)
        {
            return this.Compare((Artiodactyl)o);
        }

        public bool Compare(Artiodactyl a1)
        {
            return (this.Name == a1.Name
                && this.Weight == a1.Weight
                && this.Group == a1.Group
                 && this.SubOrder == a1.SubOrder);
        }

        /* public static double averageWeightArtiodactyl(Artiodactyl[] aA)
         {
             double aW = 0.0;

             for (int i = 0; i < aA.GetLength(0); i++)
             {
                 aW += (double)aA[i].Weight;
             }

             aW = aW / aA.GetLength(0);

             return aW;
         }*/
    }
}
