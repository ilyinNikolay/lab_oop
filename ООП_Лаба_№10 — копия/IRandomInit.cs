using System;

namespace OOP__lab10
{
    public interface IRandomInit
    {
        static Random rnd = new Random();
        void RandomInit();
        void ShowInfo();
    }
}
