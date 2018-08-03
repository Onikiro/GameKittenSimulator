using System;
using Newtonsoft.Json;

namespace Kitty
{
    [Serializable]
    public class KittySim
    {
        public string     Sex { get; set; }
        public string     Name { get; set; }

        private int       hungerLevel;
        public int        HungerLevel
        {
            get => hungerLevel;
            set
            {
                if (value > 11)
                    value = 11;
                if (value < 0)
                    value = 0;
                hungerLevel = value;
            }
        }

        private float     age;
        public  float     Age
        {
            get => age;
            set
            {
                if (value < 0)
                    value = 0;
                age = value;
            }
        }

        public  int       Happines { get; set; }
        public  int       Points { get; set; }
        

        public void StartGame()
        {
            ChangeName();
            ChangeSex();
            ChangeStats();
            Console.Clear();
        }

        void ChangeSex()
        {
            Console.Write("Write your cat's sex (Boy/Girl): ");
            Sex = Console.ReadLine();
            Sex = Sex.ToLower();
            if (Sex != "boy" && Sex != "girl" || Sex == null)
            {
                Console.WriteLine("There are only two genders!");
                ChangeSex();
            }
        }

        void ChangeName()
        {
            Console.Write("Write your cat's name: ");
            Name = Console.ReadLine();
        }

        void ChangeStats()
        {
            HungerLevel = 5;
            Happines = 5;
            Points = 10;
        }
    }
}
