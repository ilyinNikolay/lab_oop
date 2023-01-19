using System;

namespace OOP__lab10
{   
    class Program
    {
        static void Main(string[] args)
        {
            Animal[] animals =
            {
                new Animal(),
                new Bird(),
                new Mammal(),
                new Artiodactyl()
            };

            Console.WriteLine("Просмотр элементов с помощью виртуальных функций\n");
            
            foreach (Animal _animal in animals)
            {
                _animal.Show();
            }

            Console.WriteLine("\n-------------------------------------------------------------------------------");

            Console.WriteLine("\nВыполнение запросов");

            Animal[] animalRequests =
            {
                new Bird("Стеша", 20, 3),
                new Bird("Кеша", 30, 5),
                new Bird("Шуша", 5, 1),
                new Bird("Арчи", 1, 6),
                new Bird("Веня", 3, 7),
                new Artiodactyl("Стеша", 50, "Хоботные", "Жвачные"),
                new Artiodactyl("Паша", 45,  "Грызуны", "Мозоленогие"),
                new Artiodactyl("Даша", 76,  "Хищные", "Нежвачные"),
                new Artiodactyl("Маша", 32,  "Приматы",  "Жвачные"),
                new Artiodactyl("Саша", 14,  "Ластоногие",  "Нежвачные")
            };

            Random rnd = new Random();

            int aB = IRandomInit.rnd.Next(1, 5);
            int aM = IRandomInit.rnd.Next(1, 5);
            int aA = IRandomInit.rnd.Next(1, 5);

            Console.WriteLine($"\nОбщая стоимость всех купленных животных: {Animal.TotalCost(aB, aM, aA)}");

            Console.WriteLine($"\nИмена птиц c длиной крыльев больше 4: {Animal.nameBirdMore4WL(animalRequests)}");

            Console.WriteLine($"\nСредний вес всех парнокопытных: {Animal.averageWeightArtiodactyl(animalRequests)}");           

            Console.WriteLine("\n-------------------------------------------------------------------------------");

            Console.WriteLine("\nИнициализация элементов с помощью метода RandomInit и просмотр массива IRandomInit из элементов разных классов\n");
            
            IRandomInit[] array =
            {
                    new Money(),
                    new Money(),
                    new Bird(),
                    new Mammal(),
                    new Artiodactyl()
            };

            foreach (IRandomInit init in array)
            {
                init.RandomInit();
                Console.WriteLine(init);
            }

            Console.WriteLine("\n-------------------------------------------------------------------------------");

            IRandomInit[] newAnimals  =
            { 
                new Animal(),
                new Bird(),
                new Mammal(),
                new Artiodactyl(),
                new Artiodactyl(),
                new Mammal()
            };

            Console.WriteLine("\nСортировка массива с помощью интерфейса ICompareable\n");
            
            foreach (IRandomInit item in newAnimals)
            {
                item.RandomInit();
                Console.WriteLine(item);
            }

            Array.Sort(newAnimals);

            Console.WriteLine("\nОтсортированный массив:\n");

            foreach (IRandomInit item in newAnimals)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nСортировка массива с помощью интерфейса IComparer\n");
            
            foreach (IRandomInit item in newAnimals)
            {
                item.RandomInit();
                Console.WriteLine(item);
            }

            Array.Sort(newAnimals, new SortByWeight());

            Console.WriteLine("\nОтсортированный массив:\n");

            foreach (IRandomInit item in newAnimals)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\n-------------------------------------------------------------------------------");

            Console.Write("\nБинарный поиск\nВведите ключевое значение: ");

            string str;

            int _keyValue, index;

            try
            {
                str = Console.ReadLine();

                _keyValue = Int32.Parse(str);

                Animal _toFindAnimal = new Animal();

                _toFindAnimal.Weight = _keyValue;

                index = Array.BinarySearch(newAnimals, _toFindAnimal);

                Console.WriteLine($"Индекс элемента с атрибутом weight = {_toFindAnimal.Weight}:\t{index}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Введено некорректное занчение!");
            }

            Console.WriteLine("\n-------------------------------------------------------------------------------");
            
            
            Console.WriteLine("\nКлонирование\n");

            Animal animal = new Animal("Кеша", 200);

            Console.WriteLine($"animal:\nMoney = {animal.money.Rubles}\nWeight = {animal.Weight}\n");

            Animal newAnimal = (Animal)animal.Clone();
            
            Console.WriteLine($"newAnimal:\nMoney = {newAnimal.money.Rubles}\nWeight = {newAnimal.Weight}");
            
            newAnimal.money.Rubles += 400;
           
            newAnimal.Weight = 345;

            Console.WriteLine("newAnimal.Money += 400;\r\nnewAnimal.Weight = 345;\n");
           
            Console.WriteLine($"animal:\nMoney = {animal.money.Rubles}\nWeight = {animal.Weight}\n");

            Console.WriteLine($"newAnimal:\nMoney = {newAnimal.money.Rubles}\nWeight = {newAnimal.Weight}\n");

            Console.WriteLine("-------------------------------------------------------------------------------\n");
            
            Console.WriteLine("Поверностное клонирование\n");

            Animal __animal = new Animal("Кеша", 200);

            Console.WriteLine($"animal:\nMoney = {__animal.money.Rubles}\nWeight = {__animal.Weight} \n");

            Animal __newAnimal = (Animal)__animal.ShallowCopy();
            
            Console.WriteLine($"newAnimal:\nMoney = {__newAnimal.money.Rubles}\nWeight = {__newAnimal.Weight}");
            
            __newAnimal.money.Rubles += 400;
            
            __newAnimal.Weight = 345;

            Console.WriteLine("newAnimal.Money += 400;\r\nnewAnimal.Weight = 345;\n");
            
            Console.WriteLine($"animal:\nMoney = {__animal.money.Rubles}\nWeight = {__animal.Weight} \n");

            Console.WriteLine($"newAnimal:\nMoney = {__newAnimal.money.Rubles}\nWeight = {__newAnimal.Weight}");
        }
    }
}
