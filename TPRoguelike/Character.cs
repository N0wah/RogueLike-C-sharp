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

    public virtual int GetHp() { return HP; }
    public virtual void SetHp(int hp)
    {
        HP = hp;
    }
}

namespace CharacterClass
{
    class Archer : Character
    {

        public Archer(string name, int money) : base(name, money)
        {
            HP = 80;        
            DEF = 5;       
            AD = 25;       
            CritChance = 30;
        }
        
    }

    class Chevalier : Character
    {

        public Chevalier(string name, int money) : base(name, money)
        {
            HP = 150;
            DEF = 15;
            AD = 15;
            CritChance = 10;
        }
    }
}
