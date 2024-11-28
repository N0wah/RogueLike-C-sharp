abstract class Ennemie
{
    public string Name { get; protected set; }
    public string Classe { get; protected set; }
    public int HP { get; protected set; }
    public int DEF { get; protected set; }
    public int AD { get; protected set; }
    public int CritChance { get; protected set; }
    public int Valeur { get; protected set; }

    public Ennemie(string name, string classe, int hp, int def, int ad, int critChance, int valeur)
    {
        Name = name;
        Classe = classe;
        HP = hp;
        DEF = def;
        AD = ad;
        CritChance = critChance;
        Valeur = valeur;
    }

    public virtual void Attaque()
    {
        Console.WriteLine($"{Name} attaque avec {AD} points de dégâts !");
    }
    public virtual int GetHp() { return HP; }
    public virtual void SetHp(int hp)
    {
        HP = hp;
    }
}

class Gobelin : Ennemie
{
    public Gobelin() : base("Gobelin", "Gobelin", 50, 10, 15, 5, 10) { }

    public override void Attaque()
    {
        Console.WriteLine($"{Name} (Gobelin) attaque rapidement et inflige {AD} dégâts !");
    }
}

class Loup : Ennemie
{
    public Loup() : base("Loup", "Loup", 70, 8, 20, 10, 15) { }

    public override void Attaque()
    {
        Console.WriteLine($"{Name} (Loup) bondit et inflige {AD} dégâts !");
    }
}

class Orc : Ennemie
{
    public Orc() : base("Orc", "Orc", 100, 20, 25, 5, 20) { }

    public override void Attaque()
    {
        Console.WriteLine($"{Name} (Orc) attaque avec une force brutale de {AD} dégâts !");
    }
}

class Boss : Ennemie
{
    public Boss(string name) : base(name, "Boss", 200, 40, 50, 20, 100) { }

    public override void Attaque()
    {
        Console.WriteLine($"{Name} (Boss) attaque puissamment, infligeant {AD} dégâts avec une chance critique de {CritChance}% !");
    }
}
