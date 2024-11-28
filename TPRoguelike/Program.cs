using System;
using CharacterClass;
using MySql.Data.MySqlClient;
using System.Threading; // Nécessaire pour avoir un delai a l'affichage du texte

class Program
{
    static void Main()
    {
        
    }

    static Character GetCharacter(string id)
    {
        string connectionString = "server=localhost;database=dbrogue;user=root;password=";

        using (var connection = new MySqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                Console.WriteLine("Connexion réussie à la base de données.");

                var charactersMap = new Dictionary<string, Func<MySqlDataReader, Character>>
            {
                { "1", reader => new Archer(
                    reader.GetString("Name"),
                    100, // Money
                    reader.GetInt32("Health_Point"),
                    reader.GetInt32("Defense_Point"),
                    reader.GetInt32("Attack_Point"),
                    reader.GetInt32("Critical_Chance")
                )},
                { "2", reader => new Chevalier(
                    reader.GetString("Name"),
                    100, // Money
                    reader.GetInt32("Health_Point"),
                    reader.GetInt32("Defense_Point"),
                    reader.GetInt32("Attack_Point"),
                    reader.GetInt32("Critical_Chance")
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
                { "1", (stats, chara) => new Dice6(stats, chara) },
                { "2", (stats, chara) => new Dice10(stats, chara) },
                { "3", (stats, chara) => new Dice20(stats, chara) },
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

        LancerJeu();
        ExplicationJeu();
        Character joueur = SelectionnerPersonnage();
        Menu(joueur);
    }

    public static void LancerJeu()
    {

        Console.Clear(); // Efface l'écran pour un lancement propre
        Console.WriteLine("***************************************");
        Console.WriteLine("* Bienvenue dans le Rogue-like CLI ! *");
        Console.WriteLine("***************************************");
        TEXTE("\nDans ce jeu, vous choisirez une classe, combattrez des ennemis, et améliorerez vos statistiques.\n");
        TEXTE("\nSeule la chance sera votre ami faite confiance à votre Karma!\n");
        TEXTE("Préparez-vous à l'aventure et faites vos choix avec sagesse !\n");
        Console.WriteLine("\nAppuyez sur une touche pour commencer...\n");

        // Attendre une touche du joueur
        Console.ReadKey(true); // true pour ne pas afficher la touche pressée dans le terminal

        Console.Clear(); // Efface l'écran avant de continuer vers le jeu
        Console.WriteLine("Place à L'explication");
    }

    public static void ExplicationJeu()
    {
        Console.Clear(); // Efface l'écran pour une lecture propre
        Console.WriteLine("***************************************");
        Console.WriteLine("*          Mécaniques du jeu          *");
        Console.WriteLine("***************************************\n");
        TEXTE("1. **Classes :**\n- **Archer :** Attaque à distance avec des arcs ou arbalètes.\n- **Chevalier :** Combattant au corps à corps avec des dagues ou épées.\n\n2. **Statistiques :**\n- **HP :** Points de vie. Si vous tombez à 0, vous mourrez.\n- **Attaque :** Les dégâts que vous infligez à l'ennemi.\n- **Défense :** Réduit les dégâts subis.\n- **Chance de critique :** Probabilité de doubler vos dégâts lors d’une attaque.\n\n3. **Progression :**\n- Lancez 2 dés pour obtenir des points à attribuer à vos statistiques.\n- Gagnez de l’argent en combattant des ennemis (loup, orc, gobelin, etc.).\n- Utilisez l’argent pour acheter des armes et équipements afin d'augmenter vos statistique de combat.\n\n4. **Combat :**\n- Chaque tour, vous et l’ennemi attaquez à tour de rôle.\n- Vous aurez sur votre interface les statitisque de votre ennemie ainsi que le votre\n\n5. **Mort :**\n- Si vous perdez tous vos HP, vous revenez au menu principal.\n- Utilisez votre argent accumulé pour vous améliorer avant de repartir.\n\n6. **Objectif :**\n- Survivez aussi longtemps que possible.\n- Battez des ennemis toujours plus forts et améliorez votre personnage.\n");
        Console.WriteLine("\nAppuyez sur une touche pour commencer l'aventure !\n");

        // Attendre une touche du joueur pour revenir
        Console.ReadKey(true);
        Console.Clear();


    // Méthode pour afficher le texte progressivement
    public static void TEXTE(string texte, int delai = 50)
    {
        foreach(char caractere in texte)
        {
            if (Console.KeyAvailable) // Si une touche est pressée
            {
                Console.Write(texte.Substring(texte.IndexOf(caractere))); // Affiche le reste du texte
                Console.ReadKey(true); // Consomme la touche pressée
                break;
            }
            Console.Write(caractere);
            Thread.Sleep(delai); // Délai entre chaque caractère
        }
    }

    public static void Menu(Character Personnage)
    {
        int choix = 0;

        while (true)
        {
            Console.Clear(); // Efface l'écran pour une lecture propre
            Console.WriteLine("**************************");
            Console.WriteLine("*          Menu          *");
            Console.WriteLine("**************************\n");

            TEXTE("- **1. Commencer le combat\n- **2. Shop\n- **3. Quitter le jeu\n");

            Console.WriteLine("\nChoisissez une option (1-3) : ");

            try
            {
                string input = Console.ReadLine();  // Attente de l'entrée de l'utilisateur

                // Tenter de convertir l'entrée en un entier
                choix = int.Parse(input);

                // Vérifier si l'option est valide
                if (choix == 1)
                {
                    Console.Clear();
                    Console.WriteLine("Vous avez choisi de commencer le combat !");
                    Combat(Personnage);
                    // Par exemple, tu peux appeler une fonction de combat
                    Console.WriteLine("\nAppuyez sur une touche pour continuer...");
                    Console.ReadKey(true);
                }
                else if (choix == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Vous êtes dans le Shop !");
                    // Ajouter ici la logique du shop
                    // Par exemple, gérer l'achat d'objets
                    Console.WriteLine("\nAppuyez sur une touche pour revenir au menu principal...");
                    Console.ReadKey(true);
                }
                else if (choix == 3)
                {
                    Console.Clear();
                    Console.WriteLine("Merci d'avoir joué ! À bientôt !");
                    Environment.Exit(0);  // Quitte le jeu
                }
                else
                {
                    Console.WriteLine("\nOption invalide. Veuillez entrer un chiffre entre 1 et 3.");
                    Console.ReadKey(true);  // Attente d'une touche pour continuer
                }
            }
            catch (FormatException)
            {
                // Gestion de l'erreur si l'utilisateur entre un caractère non numérique
                Console.WriteLine("\nErreur : Vous devez entrer un nombre valide (1, 2 ou 3).");
                Console.ReadKey(true);  // Attente d'une touche pour continuer
            }
            catch (Exception ex)
            {
                // Gestion de toute autre exception non prévue
                Console.WriteLine($"\nUne erreur inattendue s'est produite : {ex.Message}");
                Console.ReadKey(true);  // Attente d'une touche pour continuer
            }
        }
    }


    // Méthode pour choisir le personnage entre Archer et Chevalier
    public static Character SelectionnerPersonnage()
    {
        Console.Clear();
        TEXTE("Sélectionnez votre personnage :\n1. Archer (Attaque à distance)\n2. Chevalier (Combat au corps à corps)\n");

        int choix = 0;
        bool valide = false;

        while (!valide)
        {
            try
            {
                Console.Write("\nFaites votre choix (1 ou 2) : ");
                choix = int.Parse(Console.ReadLine());
                if (choix == 1 || choix == 2)
                {
                    valide = true;
                }
                else
                {
                    Console.WriteLine("Choix invalide. Veuillez entrer 1 pour Archer ou 2 pour Chevalier.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Veuillez entrer un numéro valide.");
            }
        }

        Character personnage = null;

        if (choix == 1)
        {
            personnage = new Archer("Archer", 100); // Exemple de stats pour Archer
        }
        else if (choix == 2)
        {
            personnage = new Chevalier("Chevalier", 100); // Exemple de stats pour Chevalier
        }

        // Afficher les stats initiales du personnage choisi
        Console.Clear();
        TEXTE($"Vous avez choisi : {personnage.Name}\n");
        TEXTE($"HP : {personnage.HP}\n");
        TEXTE($"Défense : {personnage.DEF}\n");
        TEXTE($"Attaque : {personnage.AD}\n");
        TEXTE($"Chance de critique : {personnage.CritChance}%\n");
        TEXTE($"Argent : {personnage.Money} pièces\n");
        Console.WriteLine("\nAppuyer pour continuer...");
        Console.ReadKey(true);
        Console.Clear();

        return personnage;
    }

    // Méthode pour gérer l'attaque de l'ennemi


    public static void Combat(Character joueur)
    {
        Console.Clear();
        TEXTE($"Le combat commence ! Vous êtes face à un ennemi !\n");

        // Créer un ennemi aléatoire ou choisir un ennemi spécifique
        Random random = new Random();
        Ennemie ennemi = ChoisirEnnemie(random.Next(1, 5)); // Choisir un ennemi entre Gobelin, Loup, Orc, Boss

        bool combatEnCours = true;

        // Boucle de combat
        while (combatEnCours)
        {
            // Afficher les statistiques du joueur
            Console.Clear();
            TEXTE($"HP du joueur : {joueur.HP}/{joueur.HP}\n");
            TEXTE($"Attaque : {joueur.AD}\n");
            TEXTE($"Défense : {joueur.DEF}\n");

            Console.SetCursorPosition(25, 0);
            TEXTE($"HP de l'ennemi ({ennemi.Name}) : {ennemi.HP}/{ennemi.HP}\n");
            Console.SetCursorPosition(25, 1);
            TEXTE($"Attaque : {ennemi.AD}\n");
            Console.SetCursorPosition(25, 2);
            TEXTE($"Défense : {ennemi.DEF}\n");


            // Menu des actions du joueur
            Console.SetCursorPosition(13, 20);
            Console.WriteLine("Que voulez-vous faire ?");
            Console.SetCursorPosition(13, 21);
            Console.WriteLine("1. Attaquer");
            Console.SetCursorPosition(13, 22);
            Console.WriteLine("2. Défendre");
            Console.SetCursorPosition(13, 23);
            Console.WriteLine("3. Fuir");

            int choixAction = 0;

            try
            {
                string input = Console.ReadLine();  // Lecture du choix de l'action
                choixAction = int.Parse(input);
            }
            catch (FormatException)
            {
                Console.WriteLine("Veuillez entrer un nombre valide.");
                continue;
            }

            int degatsJoueur = 0;

            // Déterminer l'action du joueur
            if (choixAction == 1)
            {
                degatsJoueur = joueur.AD + random.Next(0, 10);  // Attaque avec une petite variation aléatoire
                TEXTE($"Vous attaquez {ennemi.Name} et infligez {degatsJoueur} points de dégâts !\n");

                int ennemiPV = ennemi.GetHp();
                ennemi.SetHp(ennemiPV - degatsJoueur);
                if (ennemi.HP < 0) ennemi.SetHp(0);  // S'assurer que les HP de l'ennemi ne sont pas négatifs
            }
            else if (choixAction == 2)
            {
                TEXTE("Vous vous défendez. Vous recevrez moins de dégâts si l'ennemi attaque.\n");
            }
            else if (choixAction == 3)
            {
                TEXTE("Vous avez choisi de fuir. Le combat est terminé.\n");
                combatEnCours = false;
                break;
            }
            else
            {
                Console.WriteLine("Action invalide. Veuillez choisir 1, 2 ou 3.");
                continue;
            }

            if (ennemi.HP > 0)
            {
                // Calcul des dégâts de l'ennemi
                int degatsEnnemi = EnnemiAttaque(ennemi, joueur, random);

                // Appliquer les dégâts au joueur
                int joueurHP = joueur.GetHp();
                joueur.SetHp(joueurHP -= degatsEnnemi);
                TEXTE($"{ennemi.Name} attaque et vous inflige {degatsEnnemi} points de dégâts.\n");
            }

                // Vérifier si le joueur ou l'ennemi est mort (si le joueur perd tout ses HP)
                if (joueur.HP <= 0)
            {
                Console.Clear();
                TEXTE("Vous avez perdu le combat. Game Over !\n");
                combatEnCours = false;
            }

            // Si le joueur a encore de la vie, continuer le combat
            if (joueur.HP > 0)
            {
                Console.WriteLine("Appuyez sur une touche pour continuer...");
                Console.ReadKey(true);
            }

            // Si l'ennemi a perdu tous ses HP, il est vaincu
            if (ennemi.HP <= 0)
            {
                Console.Clear();
                TEXTE($"Félicitations ! Vous avez vaincu {ennemi.Name}.\n");
                combatEnCours = false;
            }
        }
    }


    public static int EnnemiAttaque(Ennemie ennemi, Character joueur, Random random)
    {
        int degats = ennemi.AD + random.Next(0, 10);  // Attaque de base avec variation
        bool critique = random.Next(0, 100) < ennemi.CritChance;  // Chance de critique de l'ennemi

        // Si critique, doubler les dégâts
        if (critique)
        {
            degats *= 2;
            TEXTE($"{ennemi.Name} inflige un coup critique !\n");
        }

        // Appliquer les dégâts à l'ennemi (en fonction de la défense du joueur)
        int degatsSubis = degats - joueur.DEF;
        if (degatsSubis < 0)
        {
            degatsSubis = 0;  // Pas de dégâts si la défense du joueur est trop élevée
        }

        return degatsSubis;
    }

    // Méthode pour choisir un ennemi aléatoire
    public static Ennemie ChoisirEnnemie(int choix)
    {
        switch (choix)
        {
            case 1: return new Gobelin();
            case 2: return new Loup();
            case 3: return new Orc();
            case 4: return new Boss("Boss Final");
            default: return new Gobelin();
        }
    }

    

}









