using System;

class Objet
{
    public string Nom { get; private set; }
    public Character Character { get; private set; }
    public int Stats {  get; protected set; }

    public Objet(string nom, Character character)
    {
        Nom = nom;
        Character = character;
    }

    public virtual void Utiliser() { }
}

class Potion : Objet
{

    public Potion(int stats, Character character) : base("Potion", character) { Stats = stats; }


    public override void Utiliser()
    {
        // Implémenter le soin
    }
}

class Dice : Objet
{
    public int Range { get; protected set; }

    public Dice(string nom, Character character) : base(nom, character)
    {
    }

    public override void Utiliser()
    {
        //Implémenter le jet de 3 dés 
    }
}

class Dice6 : Dice
{
    public Dice6(int stats, Character character) : base("Dé 6", character) { Range = stats; }
}

class Dice10 : Dice
{
    public Dice10(int stats, Character character) : base("Dé 10", character) { Range = stats; }
}

class Dice20 : Dice
{
    public Dice20(int stats, Character character) : base("Dé 20", character) { Range = stats; }
}