using System;

class Character
{
    public string Name { get; private set; }
    public int Money { get; private set; }
    public int HP { get; protected set; }
    public int DEF { get; protected set; }
    public int AD { get; protected set; }
    public int CritChance { get; protected set; }
    public Arme _Arme { get; protected set; }

    public Character(string name, int money)
    {
        Name = name;
        Money = money;
        _Arme = new Poing();
    }

    public void EquipWeapon(Arme weapon)
    {
        _Arme = weapon;
        Console.WriteLine($"{Name} a équipé l'arme : {weapon.NomArme}");
    }

    public void Attack()
    {
        _Arme.Attaque();
    }

    public virtual void SetHp(int hp)
    {
        HP = hp;
    }

    public virtual int GetHp()
    {
        return HP;
    }
}

namespace CharacterClass
{
    class Archer : Character
    {

        public Archer(string name, int money, int hP, int dEF, int aD, int critChance) : base(name, money)
        {
            HP = hP;
            DEF = dEF;
            AD = aD;
            CritChance = critChance;
        }
        
    }

    class Chevalier : Character
    {

        public Chevalier(string name, int money, int hP, int dEF, int aD, int critChance) : base(name, money)
        {
            HP = hP;
            DEF = dEF;
            AD = aD;
            CritChance = critChance;
        }
    }
}
