using System;

namespace TPCSharp
{
     public abstract class Dice
    {
        public string Type { get; set; }

        public Dice(string type)
        {
            Type = type;
        }

        public abstract int Random();
    }

    class Dice6 : Dice
    {
        public Dice6(string type) : base(type)
        {
            Type = "Dée 6";
        }

        public override int Random()
        {
            Random random = new Random();
            return random.Next(0,7);
        }
    }

    class Dice10 : Dice
    {
        public Dice10(string type) : base(type)
        {
            Type = "Dée 10";
        }

        public override int Random()
        {
            Random random = new Random();
            return random.Next(0, 11);
        }
    }

    class Dice20 : Dice
    {
        public Dice20(string type) : base(type)
        {
            Type = "Dée 20";
        }

        public override int Random()
        {
            Random random = new Random();
            return random.Next(0, 21);
        }
    }
}
