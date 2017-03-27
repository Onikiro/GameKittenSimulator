using System;

namespace ConsoleApplication1
{
    public class KittySim
    {

        string sex;
        string name;

        public string Sex => sex;
        public string Name => name;

        public int LevelEating { get; set; }
        public float age { get; set; }
        public int Happines { get; set; }
        public int Points { get; set; }

        public KittySim()
        {
            ChangeSex();
            ChangeName();
            ChangeStats(LevelEating, Happines);
            Console.Clear();
        }

        void ChangeSex()
        {
            Console.WriteLine("Пол вашего котенка (Мальчик/Девочка)");
            try
            {
                sex = Console.ReadLine();
                sex = sex.ToLower();
                if (!sex.Contains("мальчик") && !sex.Contains("девочка") || sex == null)
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Пол выбран неверно" + "\n" + "Нажмите любую клавишу..");
                Console.ReadKey();
                ChangeSex();
            }
        }

        void ChangeName()
        {
            Console.Write("Имя котенка: ");
            name = Console.ReadLine();
        }

        void ChangeStats(int eat, int happy)
        {
            eat = 5;
            happy = 5;
            Points = 10;
        }

        public string GetStat(string stat)
        {
            return stat;
        }
        public int GetStat(int stat)
        {
            return stat;
        }
        public float GetStat(float stat)
        {
            return stat;
        }
    }
}
