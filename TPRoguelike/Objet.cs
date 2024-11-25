using System;

class Objet
{
    private string Name;
    private Character _Character;

    public Objet(string name, Character character)
    {
        Name = name;
        _Character = character;
    }

    public virtual void Use(int id)
    {
        if (id == 3)
        {
            _Character.SetHp(_Character.HP + 20);
            Console.WriteLine($"{_Character.Name} vous vous soignez de 20 PV. Pv actuel : {_Character.HP}");
        }
    }
}

namespace _Objet
{
    class Dice6 : Objet
    {
        private int DiceRange = 6;
        private string Name = "Dice6";

        public Dice6(string name, Character character) : base(name, character)
        {

        }

        public int GetDiceRange() { return DiceRange; }

        public override void Use(int id) 
        {
            Console.WriteLine("Utilisation de " + Name); 
            id = 0;
            base.Use(id);
        }
    }

    class Dice10 : Objet
    {
        private int DiceRange = 10;
        private string Name = "Dice10";

        public Dice10(string name, Character character) : base(name, character)
        {

        }

        public int GetDiceRange() { return DiceRange; }

        public override void Use(int id)
        {
            Console.WriteLine("Utilisation de " + Name);
            id = 1;
            base.Use(id);
        }
    }

    class Dice20 : Objet
    {
        private int DiceRange = 20;
        private string Name = "Dice20";

        public Dice20(string name, Character character) : base(name, character)
        {

        }

        public int GetDiceRange() { return DiceRange; }

        public override void Use(int id)
        {
            Console.WriteLine("Utilisation de " + Name);
            id = 2;
            base.Use(id);
        }
    }

    class Potion : Objet
    {
        private int Soin = 21;
        private string Name = "Potion";

        public Potion(string name, Character character) : base(name, character)
        {

        }

        public int GetSoin() { return Soin; }

        public override void Use(int id)
        {
            Console.WriteLine("Utilisation de " + Name);
            id = 3;
            base.Use(id);
        }
    }
}
