using System;

namespace TPCSharp
{
    public abstract class Character
    {
        public string Name { get; set; }
        public int Hp { get; set; }
        public int MaxHp { get; set; }
        public int Money { get; set; }
        public Objet Item { get; set; }
        public Armes Weapon { get; set; }

        public Character(string name, int hp, int maxHp, int money, Objet item, Armes weapon)
        {
            Name = name;
            Hp = hp;
            MaxHp = maxHp;
            Money = money;
            Item = item;
            Weapon = weapon;
        }

        public void ResetHp()
        {
            Hp = MaxHp;
        }

        public void SetHp(int hp)
        {
            Hp = hp;
            if (Hp > MaxHp)
            {
                Hp = MaxHp;
            }
        }

        public void TakeDamage(int damage)
        {
            Hp -= damage;
            if (Hp < 0)
            {
                Hp = 0;
            }
        }

        public void EquipWeapon(Armes weapon)
        {
            Weapon = weapon;
        }

        public void UseObject(Objet item)
        {
            item.Use();
        }

        public abstract void Attack(Character target);
        public abstract int GetAttackDamage();
        public abstract void SetAttackDamage(int damage);
    }

    public class Archer : Character
    {
        public int AttackDamage { get; set; }
        public Archer(string name, int hp, int maxHp, int attackDamage, int money, Objet item, Armes weapon) : base(name, hp, maxHp, money, item, weapon)
        {
            AttackDamage = attackDamage;
            Name = name;
            Hp = hp;
            MaxHp = maxHp;
            Money = money ;
            Item = item;
            Weapon = weapon;
        }

        public override void Attack(Character target)
        {
            target.TakeDamage(AttackDamage);
        }

        public override int GetAttackDamage() { return AttackDamage; }
        public override void SetAttackDamage(int damage) { AttackDamage = damage; }
    }

    public class Guerrier : Character
    {
        public int AttackDamage { get; set; }
        public Guerrier(string name, int hp, int maxHp, int attackDamage, int money, Objet item,Armes weapon) : base(name, hp, maxHp, money, item, weapon)
        {
            AttackDamage = attackDamage;
            Name = name;
            Hp = hp;
            MaxHp = maxHp;
            Money = money;
            Item = item;
            Weapon = weapon;
        }

        public override void Attack(Character target)
        {
            target.TakeDamage(AttackDamage);
        }

        public override int GetAttackDamage() { return AttackDamage; }
        public override void SetAttackDamage(int damage) { AttackDamage = damage; }
    }

    public class Orc : Character
    {
        public int AttackDamage { get; set; }
        public Orc(string name, int hp, int maxHp, int attackDamage, int money, Objet item, Armes weapon) : base(name, hp, maxHp, money, item, weapon)
        {
            AttackDamage = attackDamage;
            Name = "Orc";
            Hp = hp;
            MaxHp = maxHp;
            Money = money;
            Item = null;
            Weapon = null;
        }

        public override void Attack(Character target)
        {
            target.TakeDamage(AttackDamage);
        }

        public override int GetAttackDamage() { return AttackDamage; }
        public override void SetAttackDamage(int damage) { AttackDamage = damage; }
    }

    public class Loup : Character
    {
        public int AttackDamage { get; set; }
        public Loup(string name, int hp, int maxHp, int attackDamage, int money, Objet item, Armes weapon) : base(name, hp, maxHp, money, item, weapon)
        {
            AttackDamage = attackDamage;
            Name = "Loup";
            Hp = hp;
            MaxHp = maxHp;
            Money = money;
            Item = null;
            Weapon = null;
        }

        public override void Attack(Character target)
        {
            target.TakeDamage(AttackDamage);
        }

        public override int GetAttackDamage() { return AttackDamage; }
        public override void SetAttackDamage(int damage) { AttackDamage = damage; }
    }

    public class Gobelin : Character
    {
        public int AttackDamage { get; set; }
        public Gobelin(string name, int hp, int maxHp, int attackDamage, int money, Objet item, Armes weapon) : base(name, hp, maxHp, money, item, weapon)
        {
            AttackDamage = attackDamage;
            Name = "Gobelin";
            Hp = hp;
            MaxHp = maxHp;
            Money = money;
            Item = null;
            Weapon = null;
        }

        public override void Attack(Character target)
        {
            target.TakeDamage(AttackDamage);
        }

        public override int GetAttackDamage() { return AttackDamage; }
        public override void SetAttackDamage(int damage) { AttackDamage = damage; }
    }

    public class Boss : Character
    {
        public int AttackDamage { get; set; }
        public Boss(string name, int hp, int maxHp, int attackDamage, int money, Objet item, Armes weapon) : base(name, hp, maxHp, money, item, weapon)
        {
            AttackDamage = attackDamage;
            Name = "Boss";
            Hp = hp;
            MaxHp = maxHp;
            Money = money;
            Item = null;
            Weapon = null;
        }

        public override void Attack(Character target)
        {
            target.TakeDamage(AttackDamage);
        }

        public override int GetAttackDamage() { return AttackDamage; }
        public override void SetAttackDamage(int damage) { AttackDamage = damage; }
    }
}