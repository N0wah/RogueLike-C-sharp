using System;
using TPCSharp;
using MySql.Data.MySqlClient;
using System.Threading; // Nécessaire pour avoir un delai a l'affichage du texte
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;

class Program
{
    public static void Main(string[] args)
    {
        StartingGame();
        Explication();
        MenuGame(ChoixPernnage());
        
    }

    public static int combatBoss = 0;

    public static Armes GetWeapon(string id)
    {
        string connectionString = "server=localhost;database=dbrogue;user=root;password=";

        using (var connection = new MySqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                var weaponsMap = new Dictionary<string, Func<MySqlDataReader, Armes>>
                {
                    {"1", reader => new Fist(reader.GetString("Name"), reader.GetInt32("Damage")) },
                    {"2", reader => new CrossBow(reader.GetString("Name"), reader.GetInt32("Damage")) },
                    {"3", reader => new Bow(reader.GetString("Name"), reader.GetInt32("Damage")) },
                    {"4", reader => new Sword(reader.GetString("Name"), reader.GetInt32("Damage")) },
                    {"5", reader => new Dague(reader.GetString("Name"), reader.GetInt32("Damage")) }
                };

                if (weaponsMap.ContainsKey(id))
                {
                    string query = $"SELECT * FROM weapons WHERE Id = {id};";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return weaponsMap[id](reader);
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { }
        }
        return null;
    }

    public static Character GetCharacter(string id)
    {
        string connectionString = "server=localhost;database=dbrogue;user=root;password=";

        using (var connection = new MySqlConnection(connectionString))
        {
            try
            {
                connection.Open();

                var charactersMap = new Dictionary<string, Func<MySqlDataReader, Character>>
            {
                { "1", reader => new Archer(
                    reader.GetString("Name"),
                    reader.GetInt32("Health_Point"),
                    reader.GetInt32("Health_Point"),
                    reader.GetInt32("Attack_Point"),
                    100,
                    null,
                    GetWeapon("1")
                )},
                { "2", reader => new Guerrier(
                    reader.GetString("Name"),
                    reader.GetInt32("Health_Point"),
                    reader.GetInt32("Health_Point"),
                    reader.GetInt32("Attack_Point"),
                    100,
                    null,
                    GetWeapon("1")
                )}
            };

                if (charactersMap.ContainsKey(id))
                {
                    string query = $"SELECT * FROM `character` WHERE Id = {id};";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return charactersMap[id](reader);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur : " + ex.Message);
            }
        }
        return null;
    }

    static Objet GetObjet(string id, Character character)
    {
        string connectionString = "server=localhost;database=dbrogue;user=root;password=";

        using (var connection = new MySqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                Console.WriteLine("Connexion réussie à la base de données.");

                var objetsMap = new Dictionary<string, Func<int, Character, Objet>>
            {
                { "4", (stats, chara) => new Potion(stats, chara) }
            };

                if (objetsMap.ContainsKey(id))
                {
                    string query = $"SELECT * FROM Object WHERE Id = {id};";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int stats = reader.GetInt32("Stats");
                                return objetsMap[id](stats, character);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur : " + ex.Message);
            }
        }
        return null;
    }

    public static Character GetEnnemie(string id)
    {
        string connectionString = "server=localhost;database=dbrogue;user=root;password=";

        using (var connection = new MySqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                Console.WriteLine("Connexion réussie à la base de données.");

                var ennemiesMap = new Dictionary<string, Func<MySqlDataReader, Character>>
            {
                { "3", reader => new Gobelin(
                    reader.GetString("Name"),
                    reader.GetInt32("Health_Point"),
                    reader.GetInt32("Health_Point"),
                    reader.GetInt32("Attack_Point"),
                    reader.GetInt32("Gold_Value"),
                    null,
                    null
                )},
                { "2", reader => new Loup(
                    reader.GetString("Name"),
                    reader.GetInt32("Health_Point"),
                    reader.GetInt32("Health_Point"),
                    reader.GetInt32("Attack_Point"),
                    reader.GetInt32("Gold_Value"),
                    null,
                    null
                )},
                { "4", reader => new Orc(
                    reader.GetString("Name"),
                    reader.GetInt32("Health_Point"),
                    reader.GetInt32("Health_Point"),
                    reader.GetInt32("Attack_Point"),
                    reader.GetInt32("Gold_Value"),
                    null,
                    null
                )},
                { "1", reader => new Boss(
                    reader.GetString("Name"),
                    reader.GetInt32("Health_Point"),
                    reader.GetInt32("Health_Point"),
                    reader.GetInt32("Attack_Point"),
                    reader.GetInt32("Gold_Value"),
                    null,
                    null
                )}
            };

                if (ennemiesMap.ContainsKey(id))
                {
                    string query = $"SELECT * FROM `ennemy` WHERE Id = {id};";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return ennemiesMap[id](reader);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur : " + ex.Message);
            }
        }
        return null;
    }
 // Efface l'écran pour un lancement propre
    public static void StartingGame()
    {
        Console.Clear();
        Console.WriteLine("***************************************");
        Console.WriteLine("* Bienvenue dans le Rogue-like CLI ! *");
        Console.WriteLine("***************************************");
        Console.WriteLine("\nDans ce jeu, vous choisirez une classe, combattrez des ennemis, et améliorerez vos statistiques.\n");
        Console.WriteLine("\nSeule la chance sera votre ami faite confiance à votre Karma!\n");
        Console.WriteLine("Préparez-vous à l'aventure et faites vos choix avec sagesse !\n");
        Console.WriteLine("\nAppuyez sur une touche pour commencer...\n");


        Console.ReadKey(true);

        Console.Clear();
        Console.WriteLine("Place à L'explication");
    } //lancement de Jeu

    public static void Explication()
    {
        Console.Clear();
        Console.WriteLine("***************************************");
        Console.WriteLine("*          Mécaniques du jeu          *");
        Console.WriteLine("***************************************\n");
        Console.WriteLine("1. **Classes :**\n- **Archer :** Attaque à distance avec des arcs ou arbalètes.\n- **Chevalier :** Combattant au corps à corps avec des dagues ou épées.\n\n2. **Statistiques :**\n- **HP :** Points de vie. Si vous tombez à 0, vous mourrez.\n- **Attaque :** Les dégâts que vous infligez à l'ennemi.\n- **Défense :** Réduit les dégâts subis.\n- **Chance de critique :** Probabilité de doubler vos dégâts lors d’une attaque.\n\n3. **Progression :**\n- Lancez 2 dés pour obtenir des points à attribuer à vos statistiques.\n- Gagnez de l’argent en combattant des ennemis (loup, orc, gobelin, etc.).\n- Utilisez l’argent pour acheter des armes et équipements afin d'augmenter vos statistique de combat.\n\n4. **Combat :**\n- Chaque tour, vous et l’ennemi attaquez à tour de rôle.\n- Vous aurez sur votre interface les statitisque de votre ennemie ainsi que le votre\n\n5. **Mort :**\n- Si vous perdez tous vos HP, vous revenez au menu principal.\n- Utilisez votre argent accumulé pour vous améliorer avant de repartir.\n\n6. **Objectif :**\n- Survivez aussi longtemps que possible.\n- Battez des ennemis toujours plus forts et améliorez votre personnage.\n");
        Console.WriteLine("\nAppuyez sur une touche pour commencer l'aventure !\n");

        Console.ReadKey(true);
        Console.Clear();
    } //Explication de Jeu

    public static void MenuGame(Character Personnage)
    {
        int choix = 0;
        
        while (true)
        {

            Console.Clear();
            Console.WriteLine("**************************");
            Console.WriteLine("*          Menu          *");
            Console.WriteLine("**************************\n");

            Console.WriteLine("- **1. Commencer le combat\n- **2. Shop\n- **3. Quitter le jeu\n");

            Console.WriteLine("\nChoisissez une option (1-3) : ");

            try
            {
                string input = Console.ReadLine();

                choix = int.Parse(input);
                if (choix == 1)
                {
                    
                    Console.Clear();
                    Console.WriteLine("Vous avez choisi de commencer le combat !");
                    Combat(Personnage);
                }
                else if (choix == 2)
                {
                    Console.Clear();
                    Shop(Personnage);
                }
                else if (choix == 3)
                {
                    Console.Clear();
                    Console.WriteLine("Merci d'avoir joué ! À bientôt !");
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("\nOption invalide. Veuillez entrer un chiffre entre 1 et 3.");
                    Console.ReadKey(true);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("\nErreur : Vous devez entrer un nombre valide (1, 2 ou 3).");
                Console.ReadKey(true);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"\nUne erreur inattendue s'est produite : {ex.Message}");
                Console.ReadKey(true);
            }
        }
    } //Menu de Joueur

    public static void Shop(Character joueur)
    {
        bool shop = true;
        int choix = 0;
        while (shop)
        {
            Console.Clear();
            Console.WriteLine("**************************");
            Console.WriteLine("*          Shop          *");
            Console.WriteLine("**************************\n");

            Console.WriteLine("Choississez l'arme que vous voulez prendre : \n");

            Armes arme1 = GetWeapon("2");
            Armes arme2 = GetWeapon("3");
            Armes arme3 = GetWeapon("4");
            Armes arme4 = GetWeapon("5");

            Console.WriteLine($"1-{arme1.NomArme}({arme1.GetValue()}$) | 2-{arme2.NomArme}({arme2.GetValue()}$) " +
                $"| 3-{arme3.NomArme}({arme3.GetValue()}$) | 4-{arme4.NomArme}({arme4.GetValue()}$)");
            Console.WriteLine($"Argent : {joueur.Money}");
            Console.WriteLine("5-Quittez le shop");
            

            try
            {
                string input = Console.ReadLine();
                choix = int.Parse(input);
                if (choix == 1 && joueur.Money >= arme1.GetValue()) 
                { joueur.EquipWeapon(arme1); Console.WriteLine($"Vous avez équippée l'arme {arme1.NomArme}"); joueur.Money -= arme1.GetValue(); shop = false; Console.ReadKey(true); }
                if (choix == 2 && joueur.Money >= arme1.GetValue()) 
                { joueur.EquipWeapon(arme2); Console.WriteLine($"Vous avez équippée l'arme {arme2.NomArme}"); joueur.Money -= arme2.GetValue(); shop = false; Console.ReadKey(true); }
                if (choix == 3 && joueur.Money >= arme1.GetValue()) 
                { joueur.EquipWeapon(arme3); Console.WriteLine($"Vous avez équippée l'arme {arme3.NomArme}"); joueur.Money -= arme3.GetValue(); shop = false; Console.ReadKey(true); }
                if (choix == 4 && joueur.Money >= arme1.GetValue()) 
                { joueur.EquipWeapon(arme4); Console.WriteLine($"Vous avez équippée l'arme {arme4.NomArme}"); joueur.Money -= arme4.GetValue(); shop = false; Console.ReadKey(true); }
                if (choix == 5) { shop = false; }
                if (shop == true && joueur.Money < arme1.GetValue() && joueur.Money < arme2.GetValue() && joueur.Money < arme3.GetValue() && joueur.Money < arme4.GetValue())
                {
                    Console.WriteLine("\nVous n'avez pas assez d'argent / Entrez un chiffre entre 1 et 4");
                    Console.ReadKey(true);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("\nErreur : Vous devez entrer un nombre valide (1, 2, 3 ou 4).");
                Console.ReadKey(true);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"\nUne erreur inattendue s'est produite : {ex.Message}");
                Console.ReadKey(true);
            }
        }

    }

    public static void Combat(Character joueur)
    {
        combatBoss += 1;
        Augmentationstat(joueur);
        Console.Clear();
        Console.WriteLine($"Le combat commence ! Vous êtes face à un ennemi !\n");

        bool combatEnCours = true; //Afin de faire une boucle pour le jeu
        Character ennemi = RandomEnnemi();

        // Boucle de combat
        while (combatEnCours)
        {
            
            Console.Clear();
            Console.WriteLine($"HP du joueur : {joueur.Hp}/{joueur.MaxHp}");
            Console.WriteLine($"Attaque : {joueur.GetAttackDamage()}\n");

            // Afficher les statistiques du ennemie
            Console.SetCursorPosition(25, 0);
            Console.WriteLine($"HP de l'ennemi ({ennemi.Name}) : {ennemi.Hp}/{ennemi.MaxHp}\n");
            Console.SetCursorPosition(25, 1);
            Console.WriteLine($"Attaque : {ennemi.GetAttackDamage()}\n");

            Console.ReadKey(true);

            joueur.Attack(ennemi);
            Console.WriteLine($"Vous attaquez {ennemi.Name} et infligez {joueur.GetAttackDamage() + (joueur.Weapon.GetWeaponDamage()/2)} points de dégâts !\n");

            if (ennemi.Hp > 0) 
            {
                ennemi.Attack(joueur);
                Console.WriteLine($"L'ennemie vous attaque et vous inflige {ennemi.GetAttackDamage()} points de dégâts !\n");
                Console.WriteLine("Continu...");
                Console.ReadKey(true);
            }
            

            // Vérifier si le joueur ou l'ennemi est mort (si le joueur perd tout ses HP)
            if (joueur.Hp <= 0)
            {

                Console.Clear();
                Console.WriteLine("Vous avez perdu le combat. Game Over !\n");
                joueur.ResetHp();
                combatBoss = 0;
                combatEnCours = false;
            }

            // Si le joueur a encore de la vie, continuer le combat
            if (joueur.Hp > 0)
            {
                Console.WriteLine("Appuyez sur une touche pour continuer...");
                Console.ReadKey(true);
            }

            // Si l'ennemi a perdu tous ses HP, il est vaincu
            if (ennemi.Hp <= 0)
            {
                Console.Clear();
                Console.WriteLine($"Félicitations ! Vous avez vaincu {ennemi.Name}.\n");
                joueur.Money += ennemi.Money;
                Console.ReadKey(true);
                combatEnCours = false;
                if (combatBoss < 7 ) Combat(joueur);
            }

            if (combatBoss == 7 && ennemi.Hp <= 0)
            {
                Console.Clear();
                Console.WriteLine($"Félicitations ! Vous avez vaincu {ennemi.Name}.\n");
                Console.ReadKey(true);
                Console.Clear();
                Console.WriteLine("L'heure du boss a sonnée....");
                Console.ReadKey(true);
                CombatBossFinal(joueur);
            }
        }
    }

    public static void CombatBossFinal(Character joueur)
    {
        Augmentationstat(joueur);
        Console.Clear();
        Console.WriteLine($"Le combat commence ! Vous êtes face au BOSS !\n");

        bool combatEnCours = true; //Afin de faire une boucle pour le jeu
        Character ennemi = GetBoss();

        // Boucle de combat
        while (combatEnCours)
        {

            Console.Clear();
            Console.WriteLine($"HP du joueur : {joueur.Hp}/{joueur.MaxHp}");
            Console.WriteLine($"Attaque : {joueur.GetAttackDamage()}\n");

            // Afficher les statistiques du ennemie
            Console.SetCursorPosition(25, 0);
            Console.WriteLine($"HP de l'ennemi ({ennemi.Name}) : {ennemi.Hp}/{ennemi.MaxHp}\n");
            Console.SetCursorPosition(25, 1);
            Console.WriteLine($"Attaque : {ennemi.GetAttackDamage()}\n");

            Console.ReadKey(true);

            joueur.Attack(ennemi);
            Console.WriteLine($"Vous attaquez {ennemi.Name} et infligez {joueur.GetAttackDamage() + (joueur.Weapon.GetWeaponDamage() / 2)} points de dégâts !\n");

            if (ennemi.Hp > 0)
            {
                ennemi.Attack(joueur);
                Console.WriteLine($"L'ennemie vous attaque et vous inflige {ennemi.GetAttackDamage()} points de dégâts !\n");
                Console.WriteLine("Continu...");
                Console.ReadKey(true);
            }


            // Vérifier si le joueur ou l'ennemi est mort (si le joueur perd tout ses HP)
            if (joueur.Hp <= 0)
            {

                Console.Clear();
                Console.WriteLine("Vous avez perdu le combat. Game Over !\n");
                joueur.ResetHp();
                combatBoss = 0;
                combatEnCours = false;
            }

            // Si le joueur a encore de la vie, continuer le combat
            if (joueur.Hp > 0)
            {
                Console.WriteLine("Appuyez sur une touche pour continuer...");
                Console.ReadKey(true);
            }

            // Si l'ennemi a perdu tous ses HP, il est vaincu
            if (ennemi.Hp <= 0)
            {
                Console.Clear();
                Console.WriteLine($"Félicitations ! Vous avez vaincu {ennemi.Name}.\n");
                Console.ReadKey(true);
                combatEnCours = false;
                MenuGame(joueur);
            }
        }
    }

    public static void Augmentationstat(Character joueur)
    {
        Console.Clear();
        Dice6 dice6 = new Dice6("");
        int resultat = dice6.Random();
        int choix = 0;
        Console.WriteLine("Appuyer pour lance le dé...");
        Console.ReadKey(true);
        Console.Clear();
        Console.WriteLine("Lancement de .");
        Console.WriteLine("Lancement de ..");
        Console.WriteLine("Lancement de ...");
        Console.WriteLine("Lancement de .");
        Console.WriteLine("Lancement de ..");
        Console.WriteLine("Lancement de ...");
        Console.Clear();
        AffichageDe(resultat);
        Console.WriteLine($"Vous avez obtenu {resultat}!!!");
        Console.WriteLine("Choississez la statistique que vous voulez augmenter (1-Attaque | 2-Hp)");
        while (resultat != 0)
        {
            
            try
            {
                string input = Console.ReadLine();

                choix = int.Parse(input);
                if (choix == 1)
                {
                    int joueurDamage = joueur.GetAttackDamage();
                    joueur.SetAttackDamage(joueurDamage += 1);
                    resultat -= 1;
                    Console.WriteLine($"Augmentation d'attaque de 1");
                }
                else if (choix == 2)
                {
                    joueur.MaxHp += 1;
                    joueur.Hp += 1;
                    resultat -= 1;
                    Console.WriteLine($"Augmentation de HP de 1");
                }
                else
                {
                    Console.WriteLine("\nOption invalide. Veuillez entrer un chiffre entre 1 et 2.");
                    Console.ReadKey(true);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("\nErreur : Vous devez entrer un nombre valide (1 ou 2).");
                Console.ReadKey(true);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"\nUne erreur inattendue s'est produite : {ex.Message}");
                Console.ReadKey(true);
            }
        }
        ;
    }//Systeme Augmentation de stat

    public static Character RandomEnnemi()
    {
        Random random = new Random();
        Character ennemi = GetEnnemie(random.Next(2, 5).ToString());

        return ennemi;
    }//Recupérer ennemie random

    public static Character GetBoss()
    {
        Character ennemi = GetEnnemie("1");
        return ennemi;
    }//Recupérer ennemie random


    public static Character ChoixPernnage()
    {

        Character archer = GetCharacter("1");// Archer
        Character guerrier = GetCharacter("2"); // Chevalier



        Console.Clear();
        Console.WriteLine("**************************");
        Console.WriteLine("*      Choix du héros    *");
        Console.WriteLine("**************************\n");

        Console.WriteLine($"1. {guerrier.Name}");
        Console.WriteLine($"   - Points de vie : {guerrier.Hp}");
        Console.WriteLine($"   - Attaque : {guerrier.GetAttackDamage()}\n");

        Console.WriteLine($"2. {archer.Name}");
        Console.WriteLine($"   - Points de vie : {archer.Hp}");
        Console.WriteLine($"   - Attaque : {archer.GetAttackDamage()}\n");



        Console.WriteLine("Choisissez votre personnage (1 pour Chevalier, 2 pour Archer) :");

        Character selectedCharacter = null;

        while (selectedCharacter == null)
        {
            string input = Console.ReadLine();
            if (input == "1")
            {
                selectedCharacter = guerrier;
                Console.WriteLine("\nVous avez choisi : Guerrier !");
            }
            else if (input == "2")
            {
                selectedCharacter = archer;
                Console.WriteLine("\nVous avez choisi : Archer !");
            }
            else
            {
                Console.WriteLine("Choix invalide. Veuillez taper 1 ou 2.");
            }
        }

        Console.WriteLine("\nAppuyez sur une touche pour continuer...");
        Console.ReadKey(true);
        return selectedCharacter;
    }
    public static void AffichageDe(int number)
    {
        if (number == 1)
        {
            Console.WriteLine("  .=***++++*+=++*++===+++++.\r\n *####**##########**#######:\r\n ##########################:\r\n #######################+##:\r\n #######################=##:\r\n ##########################:\r\n ##########=-+###########=#:\r\n #########+  :###########+#:\r\n ###########*#############*:\r\n #########################=:\r\n ##########################:\r\n ##########################:\r\n ########################=. \r\n");
            //dé1
        }
        if (number == 2)
        {
            Console.WriteLine("  :+#*******+==+******+++++ \r\n.########################## \r\n:#########################* \r\n:####=-+##################- \r\n:###*  :*#################* \r\n:#####*##################*# \r\n:########################-# \r\n:########################+# \r\n:########################## \r\n:###############+--*####=## \r\n:###############=  =####+## \r\n:########################## \r\n.#######################*-  \r\n");
            //dé2
        }
        if (number == 3)
        {
            Console.WriteLine("  .=********+==++++++++++++.\r\n +#########################.\r\n *########################*.\r\n *###############--+####+#=.\r\n *##############+  -####+##.\r\n *################*########.\r\n *#########-:=###########=#.\r\n *########*..-###########*#.\r\n *########################+.\r\n *###- :*###############=#=.\r\n *###-:-*###############*##.\r\n *#########################.\r\n");
            //dé3
        }
        if (number == 4)
        {
            Console.WriteLine("  .=***++=+*+===++++===++++:\r\n *####***#########**#######-\r\n ##########################-\r\n ####+=+#########++*#######-\r\n ####   +#######=  :#######-\r\n #####**#########*+########-\r\n ########################=#-\r\n ########################+#-\r\n ##########################-\r\n ####=:=*#######*--+#######-\r\n ####. .*#######+  -#######-\r\n #################*########-\r\n ########################=: \r\n");
            //dé4
        }
        if (number == 5)
        {
            Console.WriteLine("  -*#*+=-+********+--=***++.\r\n=################***#######:\r\n=#########################*:\r\n=###*==*########*=+*######=:\r\n=###-  -########:  -######*:\r\n=####**##########++########:\r\n=#########*==*###########=#:\r\n=#########-  -###########+#:\r\n=##########**##############:\r\n=###*==*########*=+*####*##:\r\n=###=  -########:  -####+*#:\r\n=####**##########*+########:\r\n=########################*- \r\n");
            //dé5
        }
        if (number == 6)
        {
            Console.WriteLine("  :+****++************+++++.\r\n.#################**#######.\r\n.##########################.\r\n.####=-+########*==*####+##.\r\n.###*  .*#######-  =####+##.\r\n.#####*##########**########.\r\n.####--+########*==*#####=#.\r\n.###*. :*#######-  =#####*#.\r\n.#################*#######+.\r\n.###*-:=########+--*######=.\r\n.###*. :*#######=  =#######.\r\n.##########################.\r\n.#######################*-  \r\n");
            //dé6
        }

    }

}



    
