using System;

namespace Kitty
{
    enum Food { рыба = 6, сосиски = 5, хлеб = 3, мясо = 8, }
    class Cat
    {
        string Sex { get; set; } //Пол 
        string Name { get; set; }
        int LevelEating { get; set; }
        float age { get; set; }
        string enter { get; set; } //Вводные данные
        int Happines { get; set; }
        int points = 10;

        private void SetSex(string sex)
        {
            try
            {
                Console.WriteLine("Пол вашего котенка (Мальчик/Девочка)");
                sex = Console.ReadLine();
                sex = sex.ToLower();
                if (!sex.Contains("мальчик") && !sex.Contains("девочка") || sex == null) throw new Exception();
            }
            catch (Exception)
            {
                Console.WriteLine("Пол выбран неверно\nНажмите любую клавишу..");
                Console.ReadKey();
                StartGame();
            }
        }

        private void SetStats(int eatStat, int happyStat)
        {
            eatStat = 4;
            happyStat = 5;
        }

        private void SetName(string name)
        {
            Console.Write("Имя котенка: ");
            name = Console.ReadLine();
        }

        public void StartGame()
        {
            SetSex(Sex);
            SetName(Name);
            SetStats(LevelEating, Happines);
            Console.Clear();
        }

        private void UISexName(string sex, string catName)
        {
            if (sex == "мальчик") Console.WriteLine($"Имя кота: {catName}");
            else if (sex == "девочка") Console.WriteLine($"Имя кошечки: {catName}");
        }

        private void Warns()
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

        public void GUI()
        {
            while (true)
            {
                Warns();
                Console.WriteLine($"Пол питомца - {Sex}\nВозраст питомца: {age} дней\nГолод: {LevelEating}\nНастроение: {Happines}\nОчки: {points}\n\n");
                UISexName(Sex, Name);

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
