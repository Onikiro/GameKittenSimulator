using System;
using Newtonsoft.Json;
using System.IO;

namespace Kitty
{
    enum Food { fish = 6, sausages = 5, bread = 3, meat = 8 }
    public class KittyEvents
    {
        bool isLive = false;
        public bool IsLive => isLive;

        string defaultSavePath = ".\\save.json";

        public KittyEvents(KittySim cat)
        {
            if(!isLoading(ref cat))
                cat.StartGame();
            GUI(cat);
        }

        bool isLoading(ref KittySim cat)
        {
            Console.Write("Start new game or load existing one? (Start|Load): ");
            switch(Console.ReadLine().ToLower())
            {
                case "load":
                    {
                        try
                        {
                            cat = Load(defaultSavePath);
                            Console.WriteLine("Successfully loaded your cat!");
                        }
                        catch (FileNotFoundException)
                        {
                            Console.WriteLine("We didn't find your save file!");
                            isLoading(ref cat);
                        }
                        Console.ReadLine();
                        return true;
                    }
                case "start":
                    {
                        return false;
                    }
                default:
                    {
                        Console.WriteLine("Wrong option!");
                        isLoading(ref cat);
                        break;
                    }       
            }
            return false;
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
            }
        }

        void AddCatStats(KittySim cat)
        {
            cat.Age += 0.5f;
            cat.HungerLevel += 2;
            cat.Happines -= 1;
        }

        void CatInfo(KittySim cat)
        {
            Console.WriteLine($"Pet's name: {cat.Name}\n" +
                              $"Pet's sex: {cat.Sex}\n" +
                              $"Pet's age: {cat.Age} days\n" +
                              $"Pet's hunger: {cat.HungerLevel}\n" +
                              $"Pet's happines: {cat.Happines}\n" +
                              $"Pet's points: {cat.Points}");
        }

        void Actions(KittySim cat)
        {
            try
            {
                string input; //Вводные данные
                Console.WriteLine("Possible actions: feed, walk, play, train, save, load");
                Console.Write("Choose one action: ");
                input = Console.ReadLine();
                input = input.ToLower();
                switch (input)
                {
                    case "feed":
                        {
                            Feed(cat);
                            Console.ReadLine();
                            break;
                        }
                    case "walk":
                        {
                            Walking(cat);
                            Console.ReadLine();
                            break;
                        }
                    case "play":
                        {
                            Play(cat);
                            Console.ReadLine();
                            break;
                        }
                    case "train":
                        {
                            Train(cat);
                            Console.ReadLine();
                            break;
                        }
                    case "save":
                        {
                            Save(cat, ".\\save.json");
                            Console.WriteLine("Successfully saved your cat!");
                            Console.ReadLine();
                            break;
                        }
                    case "load":
                        {
                            try
                            {
                                cat = Load(defaultSavePath);
                                Console.WriteLine("Successfully loaded your cat!");
                            } catch (FileNotFoundException)
                            {
                                Console.WriteLine("We didn't find your save file!");
                            }
                            Console.ReadLine();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Wrong action!");
                            break;
                        }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
                GUI(cat);
            }
        }

        void Feed(KittySim cat)
        {
            try
            {
                Console.WriteLine($"What you will feed to the cat?\nFish\t\t|| {(int)Food.fish/2} cat points \nSausages\t|| {(int)Food.sausages / 2} cat points \nBread\t\t|| {(int)Food.bread / 2} cat ponts \nMeat\t\t|| {(int)Food.meat / 2} cat points ");
                string food = Convert.ToString(Console.ReadLine());
                food = food.ToLower();
                Food foodChange = (Food)Enum.Parse(typeof(Food), food);
                EatSomething(foodChange, cat);
                AddCatStats(cat);
            }
            catch (Exception)
            {
                Console.WriteLine("Wrong food!");
                GUI(cat);
            }
        }

        void Play(KittySim cat)
        {
            cat.Happines += 5;
            cat.HungerLevel += 3;
            Console.WriteLine("You played with the cat! It's happines got increased by 5!");
            AddCatStats(cat);
        }

        void Warns(KittySim cat)
        {
            if (cat.HungerLevel > 8)
            {
                Console.WriteLine("Your cat is hungry! Feed it!");
            }
            if (cat.Happines < 2)
            {
                Console.WriteLine("Your cat is bored! Play with it!");
            }
            if (cat.HungerLevel > 10)
            {
                Console.WriteLine("Your cat left you because you didn't feed it.");
                GameOver(cat);
            }
            if (cat.Happines < 0)
            {
                Console.WriteLine("Your cat left you because you didn't played with it.");
                GameOver(cat);
            }
        }

        void GameOver(KittySim cat)
        {
            Console.ReadLine();
            Console.Clear();
            cat.Age = 0;
            cat.StartGame();
            GUI(cat);
        }

        void EatSomething(Food food, KittySim cat)
        {
            int foodPoints = (int)food;
            if (foodPoints / 2 <= cat.Points)
            {
                cat.HungerLevel -= foodPoints;
                cat.Points -= foodPoints / 2;
                Console.WriteLine($"Cat's hunger was decreased by {foodPoints}!");
            }
            else
            {
                Console.WriteLine("Not enough cat points!");
            }
        }

        void Walking(KittySim cat)
        {
            string[] Events = { "Your cat catched a mouse!\nHunger -2\nHappines +3", "Your cat got into a fight with another cat!\nHunger +2\nHappines -1" };
            Random randomEvent = new Random();

            if (randomEvent.Next(0, 5) < 3)
            {
                Console.WriteLine(Events[0]);
                cat.Happines += 3;
                cat.HungerLevel -= 2;
            }
            else
            {
                Console.WriteLine(Events[1]);
                cat.Happines -= 1;
                cat.HungerLevel += 2;
            }

            Console.WriteLine("You've walked with your cat!");
            AddCatStats(cat);
        }

        void Train(KittySim cat)
        {
            string[] Events = { "Your cat have trained great! +5 points",
                                "Your cat have trained good! +3 points",
                                "Your cat have trained mediocre.. +1 point",
                                "Your cat have trained bad! +0 points" };
            Random Train = new Random();
            switch (Train.Next(0, 3))
            {
                case 0:
                    {
                        Console.WriteLine(Events[0]);
                        cat.Points += 5;
                        break;
                    }
                case 1:
                    {
                        Console.WriteLine(Events[1]);
                        cat.Points += 3;
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine(Events[2]);
                        cat.Points += 1;
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine(Events[3]);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Error!!!");
                        break;
                    }
            }
            AddCatStats(cat);
        }

        void Save(KittySim cat, string savePath)
        {
            string serialized = JsonConvert.SerializeObject(cat);
            using (StreamWriter sw = new StreamWriter(savePath, false))
            {
                sw.Write(serialized);
            }
        }

        KittySim Load(string loadPath)
        {
            string deserializable = null;
            using (StreamReader sr = new StreamReader(loadPath))
            {
                try
                {
                    deserializable = sr.ReadToEnd();
                }
                catch(FileNotFoundException)
                {
                    throw;
                }
            }
            return JsonConvert.DeserializeObject<KittySim>(deserializable);
        }
    }
}
