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

class Sword : Armes
{
    public int WeaponDamage { get; private set; }
    public Sword(string name, int weaponDamage) : base("Épée", weaponDamage) 
    {
        WeaponDamage = weaponDamage;
    }

    public override int GetWeaponDamage()
    {
        return WeaponDamage;
    }
}

class Bow : Armes
{
    public int WeaponDamage { get; private set; }
    public Bow(string name, int weaponDamage) : base("Arc", weaponDamage)
    {
        WeaponDamage = weaponDamage;
    }

    public override int GetWeaponDamage()
    {
        return WeaponDamage;
    }
}

class Dague : Armes
{
    public int WeaponDamage { get; private set; }
    public Dague(string name, int weaponDamage) : base("Dague", weaponDamage)
    {
        WeaponDamage = weaponDamage;
    }

    public override int GetWeaponDamage()
    {
        return WeaponDamage;
    }
}

class Fist : Armes
{
    public int WeaponDamage { get; private set; }
    public Fist(string name, int weaponDamage) : base("Poing", weaponDamage)
    {
        WeaponDamage = weaponDamage;
    }

    public override int GetWeaponDamage()
    {
        return WeaponDamage;
    }
}

class CrossBow : Armes
{
    public int WeaponDamage { get; private set; }
    public CrossBow(string name, int weaponDamage) : base("Arbalète", weaponDamage)
    {
        WeaponDamage = weaponDamage;
    }

    public override int GetWeaponDamage()
    {
        return WeaponDamage;
    }
}

