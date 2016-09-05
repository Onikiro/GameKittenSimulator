using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace Kitty
{
    enum Food { рыба = 6, сосиски = 5, хлеб = 3, мясо = 8, }
    class Cat
    {
        #region Переменные 
        string MJ { get; set; } //Пол 
        string Name { get; set; }
        int LevelEating { get; set; }
        float age { get; set; }
        string enter { get; set; } //Вводные данные
        int Happines { get; set; }
        int points = 10;
        #endregion

        public void StartGame()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Пол вашего котенка (Мальчик/Девочка)");
                MJ = Console.ReadLine();
                MJ = MJ.ToLower();
                if (MJ != "мальчик" && MJ != "девочка" || MJ == null) throw new Exception();
                Console.Write("Имя котенка: ");
                Name = Console.ReadLine();
                LevelEating = 4;
                Happines = 5;

            }
            catch (Exception)
            {
                Console.WriteLine("Пол выбран неверно" + "\n" + "Нажмите любую клавишу..");
                Console.ReadKey();
                StartGame();
            }
            Console.Clear();
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
        }

        public void GUI()
        {
            while (true)
            {
                Console.Clear();
                Warns();
                Console.WriteLine("Пол питомца - " + MJ + "\n" + "Возраст питомца: " + age +" дней" + "\n" + "Голод: " + LevelEating + "\n" + "Настроение: " + Happines + "\n" + "Очки: " + points);
                if (MJ == "мальчик") Console.WriteLine("Имя кота: " + Name);
                else if (MJ == "девочка") Console.WriteLine("Имя кошечки: " + Name);
                Console.WriteLine("\n");
                try
                {
                    Console.WriteLine("Возможные действия: Покормить, Погулять, Поиграть, Тренировать");
                    Console.Write("Напишите действие: ");
                    enter = Console.ReadLine();
                    enter = enter.ToLower();
                    switch (enter)
                    {
                        case "покормить":
                            {
                                try
                                {
                                    Console.WriteLine("Чем будем кормить? Напиши: \nРыба    || 6 очков \nСосиски || 3 очка \nХлеб    || 2 очка \nМясо    || 8 очков ");
                                    string food = Convert.ToString(Console.ReadLine());
                                    food = food.ToLower();
                                    Food foodChange = (Food)Enum.Parse(typeof(Food), food);
                                    EatSomething(foodChange);
                                    Console.ReadKey();
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("Выбрано что-то не из списка" + "\n" + "Нажмите любую клавишу..");

                                    Console.ReadKey();
                                    GUI();
                                }
                                break;
                            }
                        case "погулять":
                            {
                                Walking();
                                break;
                            }
                        case "поиграть":
                            {
                                Happines += 5;
                                LevelEating += 3;
                                Console.WriteLine("Вы поиграли с котейкой, по имени {0}, настроение повысилось на 5!" + "\n" + "Нажмите любую клавишу..", Name);
                                Console.ReadKey();
                                break;
                            }
                        case "тренировать":
                            {
                                Train();
                                break;
                            }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Ошибка выбора");
                    GUI();
                }
                age += 0.5f;
                LevelEating += 2;
                Happines -= 1;
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine();
                Console.Clear();
                GUI();
            }
        }

        void Warns()
        {
            if (LevelEating > 8) Console.WriteLine("Котик голоден!");
            if (Happines < 2) Console.WriteLine("Котик грустит!");
            Console.WriteLine();
            if (LevelEating > 10)
            {
                Console.WriteLine("Котик ушел к другому хозяину, потому что вы его не кормили.");
                Console.ReadKey();
                Console.Clear();
                age = 0;
                StartGame();
            }
            if (Happines < 0)
            {
                Console.WriteLine("Котик ушел к другому хозяину, потому что ему стало очень грустно.");
                Console.ReadKey();
                Console.Clear();
                age = 0;
                StartGame();
            }
        }

        public void EatSomething(Food something)
        {
            switch ((int)something)
            {
                case 6:
                    {
                        if (6 < points)
                        {
                            LevelEating -= (int)something;
                            Console.WriteLine("Голод уменьшился на {0}!", (int)something);
                            points -= 6;
                        }
                        else Console.WriteLine("Не хватает очков!" + "\n" + "Нажмите любую клавишу...");
                        break;
                    }
                case 5:
                    {
                        if (3 < points)
                        {
                            LevelEating -= (int)something;
                            Console.WriteLine("Голод уменьшился на {0}!", (int)something);
                            points -= 3;
                        }
                        else Console.WriteLine("Не хватает очков!" + "\n" + "Нажмите любую клавишу...");
                        break;
                    }
                case 3:
                    {
                        if (2 < points)
                        {
                            LevelEating -= (int)something;
                            Console.WriteLine("Голод уменьшился на {0}!", (int)something);
                            points -= 2;
                        }
                        else Console.WriteLine("Не хватает очков!" + "\n" + "Нажмите любую клавишу...");
                        break;
                    }
                case 8:
                    {
                        if (8 < points)
                        {
                            LevelEating -= (int)something;
                            Console.WriteLine("Голод уменьшился на {0}!", (int)something);
                            points -= 8;
                        }
                        else Console.WriteLine("Не хватает очков!" + "\n" + "Нажмите любую клавишу...");
                        break;
                    }
            }
            if (LevelEating > 11) LevelEating = 11;
            if (LevelEating < 0) LevelEating = 0;
        }

        public void Walking()
        {
            string[] Events = { "Котик поймал вкусного жучка! Голод -2, настроение +3", "Котик подрался с другим котиком! Голод +2, настроение -1" };
            Random randomEvent = new Random();
            if (randomEvent.Next(0,5) < 3)
            {
                Console.WriteLine(Events[0]);
                Happines += 3;
                LevelEating -= 2;
            }
            else
            {
                Console.WriteLine(Events[1]);
                Happines -= 1;
                LevelEating += 2;
            }
            Console.WriteLine();
            Console.WriteLine("Вы погуляли с котейкой по имени {0}!" + "\n" + "\n" + "Нажмите любую клавишу..", Name);
            Console.ReadKey();
        }

        public void Train ()
        {
            string[] Events = { "Котик отлично позанимался! +5 поинтов", "Котик неплохо позанимался! +3 поинта", "Котик слабовато занимался.. +1 поинт", "Котик всё время отвлекался! +0 поинтов"};
            string Warn = "\n"+ "Нажмите любую клавишу...";
            Random Train = new Random();
            switch(Train.Next(0,3))
            {
                case 0:
                    {
                        Console.WriteLine(Events[0] + Warn);
                        Console.ReadKey();
                        points += 5;
                        break;
                    }
                case 1:
                    {
                        Console.WriteLine(Events[1] + Warn);
                        Console.ReadKey();
                        points += 3;
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine(Events[2] + Warn);
                        Console.ReadKey();
                        points += 1;
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine(Events[3] + Warn);
                        Console.ReadKey();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Ошибка!!!");
                        break;
                    }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Cat kitty = new Cat();
            kitty.StartGame();
            kitty.GUI();
        }
    }
}