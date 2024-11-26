using System;

abstract class Arme
{
    public string NomArme { get; private set; }
    public int Degats { get; protected set; }
    public int CritChance { get; protected set; }

    public Arme(string nomArme, int degats, int critChance)
    {
        NomArme = nomArme;
        Degats = degats;
        CritChance = critChance;
    }

    public abstract void Attaque();
}

class Epee : Arme
{
    public Epee() : base("Épée", 50, 10) { }

    public override void Attaque()
    {
        Console.WriteLine($"Vous attaquez avec {NomArme}, infligeant {Degats} dégâts !");
    }
}

class Arc : Arme
{
    public Arc() : base("Arc", 30, 20) { }

    public override void Attaque()
    {
        Console.WriteLine($"Vous tirez une flèche avec {NomArme}, infligeant {Degats} dégâts !");
    }
}

class Dague : Arme
{
    public Dague() : base("Dague", 20, 30) { }

    public override void Attaque()
    {
        Console.WriteLine($"Vous frappez rapidement avec {NomArme}, infligeant {Degats} dégâts !");
    }
}

class Poing : Arme
{
    public Poing() : base("Poing", 10, 5) { }

    public override void Attaque()
    {
        Console.WriteLine($"Vous frappez avec {NomArme}, infligeant {Degats} dégâts !");
    }
}

class Arbalette : Arme
{
    public Arbalette() : base("Arbalète", 40, 15) { }

    public override void Attaque()
    {
        int chance = new Random().Next(1, 100);
        if (chance < 15)
        {
            Console.WriteLine($"Vous avez fait un coup critique !! Votre carreau inflige {Degats + 10} de dégats");
        } else {
            Console.WriteLine($"Vous tirez un carreau avec {NomArme}, infligeant {Degats} dégâts !"); 
        }
    }
}

