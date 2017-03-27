using System;

namespace ConsoleApplication1
{
    enum Food { рыба = 6, сосиски = 5, хлеб = 3, мясо = 8, }
    class KittyEvents
    {
        string enter; //Вводные данные
        bool isLive = false;

        public void GUI(KittySim cat)
        {
            isLive = true;
            while (isLive)
            {
                Console.Clear();
                CatInfo(cat);
                Warns(cat.LevelEating, cat.Happines, cat.age);
                Actions(cat);
                AddCatStats(cat.age, cat.LevelEating, cat.Happines);
            }
        }

        void AddCatStats(float age, int eat ,int happy)
        {
            age += 0.5f;
            eat += 2;
            happy -= 1;
        }

        void CatInfo(KittySim cat)
        {
            Console.WriteLine($"Пол питомца - {cat.Sex}\nВозраст питомца: {cat.age} дней\nГолод: {cat.LevelEating}\nНастроение: {cat.Happines}\nОчки: {cat.Points}");
            if (cat.Sex == "мальчик")
            {
                Console.WriteLine($"Имя кота: {cat.Name}");
            }
            else if (cat.Sex == "девочка")
            {
                Console.WriteLine($"Имя кошечки: {cat.Name}");
            }
        }

        void Actions(KittySim cat)
        {
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
                                EatSomething(foodChange, cat);
                                Console.ReadKey();
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Выбрано что-то не из списка" + "\n" + "Нажмите любую клавишу..");
                                Console.ReadKey();
                                GUI(cat);
                            }
                            break;
                        }
                    case "погулять":
                        {
                            Walking(cat);
                            break;
                        }
                    case "поиграть":
                        {
                            cat.Happines += 5;
                            cat.LevelEating += 3;
                            Console.WriteLine("Вы поиграли с котейкой, по имени {0}, настроение повысилось на 5!" + "\n" + "Нажмите любую клавишу..", cat.Name);
                            Console.ReadKey();
                            break;
                        }
                    case "тренировать":
                        {
                            Train(cat);
                            break;
                        }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка выбора");
                GUI(cat);
            }
        }

        void Warns(int eats, int happy, float age)
        {
            if (eats > 8)
            {
                Console.WriteLine("Котик голоден!");
            }
            if (happy < 2)
            {
                Console.WriteLine("Котик грустит!");
            }
            Console.WriteLine();
            if (eats > 10)
            {
                Console.WriteLine("Котик ушел к другому хозяину, потому что вы его не кормили.");
                GameOver(age);
            }
            if (happy < 0)
            {
                Console.WriteLine("Котик ушел к другому хозяину, потому что ему стало очень грустно.");
                GameOver(age);
            }
        }

        void GameOver(float age)
        {
            Console.ReadKey();
            Console.Clear();
            age = 0;
            isLive = false;
        }

        public void EatSomething(Food something, KittySim cat)
        {
            switch ((int)something)
            {
                case 6:
                    {
                        if (6 < cat.Points)
                        {
                            cat.LevelEating -= (int)something;
                            Console.WriteLine("Голод уменьшился на {0}!", (int)something);
                            cat.Points -= 6;
                        }
                        else Console.WriteLine("Не хватает очков!" + "\n" + "Нажмите любую клавишу...");
                        break;
                    }
                case 5:
                    {
                        if (3 < cat.Points)
                        {
                            cat.LevelEating -= (int)something;
                            Console.WriteLine("Голод уменьшился на {0}!", (int)something);
                            cat.Points -= 3;
                        }
                        else Console.WriteLine("Не хватает очков!" + "\n" + "Нажмите любую клавишу...");
                        break;
                    }
                case 3:
                    {
                        if (2 < cat.Points)
                        {
                            cat.LevelEating -= (int)something;
                            Console.WriteLine("Голод уменьшился на {0}!", (int)something);
                            cat.Points -= 2;
                        }
                        else Console.WriteLine("Не хватает очков!" + "\n" + "Нажмите любую клавишу...");
                        break;
                    }
                case 8:
                    {
                        if (8 < cat.Points)
                        {
                            cat.LevelEating -= (int)something;
                            Console.WriteLine("Голод уменьшился на {0}!", (int)something);
                            cat.Points -= 8;
                        }
                        else Console.WriteLine("Не хватает очков!" + "\n" + "Нажмите любую клавишу...");
                        break;
                    }
            }
            if (cat.LevelEating > 11) cat.LevelEating = 11;
            if (cat.LevelEating < 0) cat.LevelEating = 0;
        }

        public void Walking(KittySim cat)
        {
            string[] Events = { "Котик поймал вкусного жучка! Голод -2, настроение +3", "Котик подрался с другим котиком! Голод +2, настроение -1" };
            Random randomEvent = new Random();
            if (randomEvent.Next(0, 5) < 3)
            {
                Console.WriteLine(Events[0]);
                cat.Happines += 3;
                cat.LevelEating -= 2;
            }
            else
            {
                Console.WriteLine(Events[1]);
                cat.Happines -= 1;
                cat.LevelEating += 2;
            }
            Console.WriteLine();
            Console.WriteLine("Вы погуляли с котейкой по имени {0}!" + "\n" + "\n" + "Нажмите любую клавишу..", cat.Name);
            Console.ReadKey();
        }

        public void Train(KittySim cat)
        {
            string[] Events = { "Котик отлично позанимался! +5 поинтов", "Котик неплохо позанимался! +3 поинта", "Котик слабовато занимался.. +1 поинт", "Котик всё время отвлекался! +0 поинтов" };
            string Warn = "\n" + "Нажмите любую клавишу...";
            Random Train = new Random();
            switch (Train.Next(0, 3))
            {
                case 0:
                    {
                        Console.WriteLine(Events[0] + Warn);
                        Console.ReadKey();
                        cat.Points += 5;
                        break;
                    }
                case 1:
                    {
                        Console.WriteLine(Events[1] + Warn);
                        Console.ReadKey();
                        cat.Points += 3;
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine(Events[2] + Warn);
                        Console.ReadKey();
                        cat.Points += 1;
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
}
