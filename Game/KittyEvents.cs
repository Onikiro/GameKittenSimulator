using System;

namespace Kitty
{
    enum Food { рыба = 6, сосиски = 5, хлеб = 3, мясо = 8, }
    public class KittyEvents
    {
        bool isLive = false;
        public bool IsLive => isLive;

        public KittyEvents(KittySim cat)
        {
            GUI(cat);
        }

        void GUI(KittySim cat)
        {
            isLive = true;
            while (isLive)
            {
                Console.Clear();
                CatInfo(cat);
                Warns(cat);
                Actions(cat);
                AddCatStats(cat);
            }
        }

        void AddCatStats(KittySim cat)
        {
            cat.age += 0.5f;
            cat.LevelEating += 2;
            cat.Happines -= 1;
        }

        void CatInfo(KittySim cat)
        {
            Console.WriteLine($"Имя питомца: {cat.Name}\nПол питомца - {cat.Sex}\nВозраст питомца: {cat.age} дней\nГолод: {cat.LevelEating}\nНастроение: {cat.Happines}\nОчки: {cat.Points}");
        }

        void Actions(KittySim cat)
        {
            try
            {
                string input; //Вводные данные
                Console.WriteLine("Возможные действия: Покормить, Погулять, Поиграть, Тренировать");
                Console.Write("Напишите действие: ");
                input = Console.ReadLine();
                input = input.ToLower();
                switch (input)
                {
                    case "покормить":
                        {
                            GiveEat(cat);
                            break;
                        }
                    case "погулять":
                        {
                            Walking(cat);
                            break;
                        }
                    case "поиграть":
                        {
                            Play(cat);
                            break;
                        }
                    case "тренировать":
                        {
                            Train(cat);
                            break;
                        }
                    default:
                        {
                            throw new Exception();
                        }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка выбора\n{e.Message}");
                GUI(cat);
            }
        }

        void GiveEat(KittySim cat)
        {
            try
            {
                Console.WriteLine($"Чем будем кормить? Напиши: \nРыба    || {(int)Food.рыба/2} очков \nСосиски || {(int)Food.сосиски / 2} очка \nХлеб    || {(int)Food.хлеб / 2} очка \nМясо    || {(int)Food.мясо / 2} очков ");
                string food = Convert.ToString(Console.ReadLine());
                food = food.ToLower();
                Food foodChange = (Food)Enum.Parse(typeof(Food), food);
                EatSomething(foodChange, cat);
                Console.ReadKey();
            }
            catch (Exception)
            {
                Console.WriteLine("Выбрано что-то не из списка\nНажмите любую клавишу..");
                Console.ReadKey();
                GUI(cat);
            }
        }

        void Play(KittySim cat)
        {
            cat.Happines += 5;
            cat.LevelEating += 3;
            Console.WriteLine("Вы поиграли с котейкой, настроение повысилось на 5!\nНажмите любую клавишу..");
            Console.ReadKey();
        }

        void Warns(KittySim cat)
        {
            if (cat.LevelEating > 8)
            {
                Console.WriteLine("Котик голоден!");
            }
            if (cat.Happines < 2)
            {
                Console.WriteLine("Котик грустит!");
            }
            Console.WriteLine();
            if (cat.LevelEating > 10)
            {
                Console.Clear();
                Console.WriteLine("Котик ушел к другому хозяину, потому что вы его не кормили.");
                GameOver(cat);
            }
            if (cat.Happines < 0)
            {
                Console.Clear();
                Console.WriteLine("Котик ушел к другому хозяину, потому что ему стало очень грустно.");
                GameOver(cat);
            }
        }

        void GameOver(KittySim cat)
        {
            Console.ReadKey();
            Console.Clear();
            cat.age = 0;
            cat.StartGame();
            GUI(cat);
        }

        void EatSomething(Food something, KittySim cat)
        {
            if ((int)something <= cat.Points)
            {
                cat.LevelEating -= (int)something;
                cat.Points -= (int)something/2;
                Console.WriteLine($"Голод уменьшился на {(int)something}!");
            }
            else
            {
                Console.WriteLine("Не хватает очков!\nНажмите любую клавишу...");
            }

            if (cat.LevelEating > 11) cat.LevelEating = 11;
            if (cat.LevelEating < 0) cat.LevelEating = 0;
        }

        void Walking(KittySim cat)
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

            Console.WriteLine("\nВы погуляли с котейкой!\nНажмите любую клавишу..");
            Console.ReadKey();
        }

        void Train(KittySim cat)
        {
            string[] Events = { "Котик отлично позанимался! +5 поинтов", "Котик неплохо позанимался! +3 поинта", "Котик слабовато занимался.. +1 поинт", "Котик всё время отвлекался! +0 поинтов" };
            string Warn = "\nНажмите любую клавишу...";
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
