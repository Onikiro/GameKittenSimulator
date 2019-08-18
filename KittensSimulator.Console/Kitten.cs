using KittensSimulator.Console.Enums;

namespace KittensSimulator.Console
{
    internal class Kitten
    {
        public string Name { get; set; }
        public Sex Sex { get; set; }
        public float Age { get; set; }
        public int HungerLevel { get; set; }
        public int HappinessLevel { get; set; }
    }
}