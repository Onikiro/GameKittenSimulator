using System;

namespace Kitty
{
    public class KittySim
    {

        string sex;
        string name;

        public string     Sex => sex;
        public string     Name => name;


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
        

        public KittySim()
        {
            StartGame();
        }

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
            sex = Console.ReadLine();
            sex = sex.ToLower();
            if (sex != "boy" && sex != "girl" || sex == null)
            {
                Console.WriteLine("There are only two genders!");
                ChangeSex();
            }
        }

        void ChangeName()
        {
            Console.Write("Write your cat's name: ");
            name = Console.ReadLine();
        }

        void ChangeStats()
        {
            HungerLevel = 5;
            Happines = 5;
            Points = 10;
        }

    }
}
