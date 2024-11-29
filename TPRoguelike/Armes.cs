using System;
using Google.Protobuf.WellKnownTypes;

public abstract class Armes
{
    public string NomArme { get; set; }

    public Armes(string nomArme, int weaponDamage)
    {
        NomArme = nomArme;
    }

    public abstract int GetWeaponDamage();
    public abstract int GetValue();
}

class Sword : Armes
{
    public int WeaponDamage { get; set; }
    public int Value { get; set; }
    public Sword(string name, int weaponDamage) : base("Épée", weaponDamage) 
    {
        WeaponDamage = weaponDamage;
        Value = 150;
    }

    public override int GetWeaponDamage()
    {
        return WeaponDamage;
    }
    public override int GetValue() { return Value; }
}

class Bow : Armes
{
    public int WeaponDamage { get; set; }
    public int Value { get; set; }
    public Bow(string name, int weaponDamage) : base("Arc", weaponDamage)
    {
        WeaponDamage = weaponDamage;
        Value = 150;
    }

    public override int GetWeaponDamage()
    {
        return WeaponDamage;
    }
    public override int GetValue() { return Value; }
}

class Dague : Armes
{
    public int WeaponDamage { get; set; }
    public int Value { get; set; }
    public Dague(string name, int weaponDamage) : base("Dague", weaponDamage)
    {
        WeaponDamage = weaponDamage;
        Value = 150;
    }

    public override int GetWeaponDamage()
    {
        return WeaponDamage;
    }
    public override int GetValue() { return Value; }
}

class Fist : Armes
{
    public int WeaponDamage { get; set; }
    public Fist(string name, int weaponDamage) : base("Poing", weaponDamage)
    {
        WeaponDamage = weaponDamage;
    }

    public override int GetWeaponDamage()
    {
        return WeaponDamage;
    }

    public override int GetValue() { return 0; }
}

class CrossBow : Armes
{
    public int WeaponDamage { get; set; }
    public int Value { get; set; }
    public CrossBow(string name, int weaponDamage) : base("Arbalète", weaponDamage)
    {
        WeaponDamage = weaponDamage;
        Value = 150;
    }

    public override int GetWeaponDamage()
    {
        return WeaponDamage;
    }
    public override int GetValue() { return Value; }
}

