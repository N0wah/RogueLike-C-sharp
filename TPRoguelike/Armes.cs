using System;

public abstract class Armes
{
    public string NomArme { get; private set; }

    public Armes(string nomArme, int weaponDamage)
    {
        NomArme = nomArme;
    }

    public abstract int GetWeaponDamage();
}

class Epee : Armes
{
    public int WeaponDamage { get; private set; }
    public Epee(string name, int weaponDamage) : base("Épée", weaponDamage) 
    {
        WeaponDamage = weaponDamage;
    }

    public override int GetWeaponDamage()
    {
        return WeaponDamage;
    }
}

class Arc : Armes
{
    public Arc() : base("Arc", 30, 20) { }

    public override void Attaque()
    {
        Console.WriteLine($"Vous tirez une flèche avec {NomArme}, infligeant {Degats} dégâts !");
    }
}

class Dague : Armes
{
    public Dague() : base("Dague", 20, 30) { }

    public override void Attaque()
    {
        Console.WriteLine($"Vous frappez rapidement avec {NomArme}, infligeant {Degats} dégâts !");
    }
}

class Poing : Armes
{
    public Poing() : base("Poing", 10, 5) { }

    public override void Attaque()
    {
        Console.WriteLine($"Vous frappez avec {NomArme}, infligeant {Degats} dégâts !");
    }
}

class Arbalette : Armes
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

