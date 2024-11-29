using System;

namespace TPCSharp
{
    public abstract class Objet
    {
        public string Nom { get; private set; }
        public Character Character { get; private set; }
        public int Stats { get; protected set; }

        public Objet(string nom, Character character)
        {
            Nom = nom;
            Character = character;
        }

        public abstract void Use();
    }

    class Potion : Objet
    {
        private int stats;

        public Potion(int stats, Character character) : base("Potion", character) { Stats = stats; }

        public override void Use()
        {
            Character.SetHp(Character.Hp + stats);
        }
    }
}