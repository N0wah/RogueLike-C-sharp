using System;
using System.Reflection.PortableExecutable;
using TPCSharp;

class Program
{
    public static void Main()
    {
        StartingGame();
        Explication();
        MenuGame(//mettre Character//);
    }

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
                    Combat(Personnage, Ennemie);
                    Console.WriteLine("\nAppuyez sur une touche pour continuer...");
                    Console.ReadKey(true);
                }
                else if (choix == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Vous êtes dans le Shop !");
                    Console.WriteLine("\nAppuyez sur une touche pour revenir au menu principal...");
                    Console.ReadKey(true);
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

    public static void Combat(Character joueur, Character ennemi)
    {
        Console.Clear();
        Console.WriteLine($"Le combat commence ! Vous êtes face à un ennemi !\n");
        // Afficher les statistiques du joueur
        Console.Clear();
        Console.WriteLine($"HP du joueur : {joueur.HP}/{joueur.HP}\n");
        Console.WriteLine($"Attaque : {joueur.AD}\n");
        // Console.WriteLine($"Défense : {joueur.DEF}\n");

        // Afficher les statistiques du ennemie
        Console.SetCursorPosition(25, 0);
        Console.WriteLine($"HP de l'ennemi ({ennemi.Name}) : {ennemi.HP}/{ennemi.HP}\n");
        Console.SetCursorPosition(25, 1);
        Console.WriteLine($"Attaque : {ennemi.AD}\n");
        //Console.SetCursorPosition(25, 2);
        //Console.WriteLine($"Défense : {ennemi.DEF}\n");

        Augmentationstat(Charjoueur);

        Console.WriteLine("Continu...");
        Console.ReadKey(true);

        bool combatEnCours = true; //Afin de faire une boucle pour le jeu

        // Boucle de combat
        while (combatEnCours)
        {
            Console.Clear();
            Console.WriteLine($"HP du joueur : {joueur.HP}/{joueur.HP}\n");
            Console.WriteLine($"Attaque : {joueur.AD}\n");
            Console.WriteLine($"Défense : {joueur.DEF}\n");

            // Afficher les statistiques du ennemie
            Console.SetCursorPosition(25, 0);
            Console.WriteLine($"HP de l'ennemi ({ennemi.Name}) : {ennemi.HP}/{ennemi.HP}\n");
            Console.SetCursorPosition(25, 1);
            Console.WriteLine($"Attaque : {ennemi.AD}\n");
            Console.SetCursorPosition(25, 2);
            Console.WriteLine($"Défense : {ennemi.DEF}\n");

            Console.WriteLine("Continu...");
            Console.ReadKey(true);



            //(Fonction) Joueur.Attaque(ennemie);
            Console.WriteLine($"Vous attaquez {ennemi.Name} et infligez {joueur.AttackDMG} points de dégâts !\n");

            //(Fonction) ennemie.Attaque(joueur);
            Console.WriteLine($"L'ennemie vous attaque et vous inflige {joueur.AttackDMG} points de dégâts !\n");

            // Vérifier si le joueur ou l'ennemi est mort (si le joueur perd tout ses HP)
            if (joueur.HP <= 0)
            {

                Console.Clear();
                Console.WriteLine("Vous avez perdu le combat. Game Over !\n");
                joueur.resetHP();
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
                Console.WriteLine($"Félicitations ! Vous avez vaincu {ennemi.Name}.\n");
                combatEnCours = false;
                Combat(joueur, ennemi);
            }
        }
    } //Systeme de Combat

    public int Augmentationstat(Joueur)
    {
        int resultat = Dice6.Random();
        int choix = 0;
        while (resultat != 0)
        {
            try
            {
                string input = Console.ReadLine();

                choix = int.Parse(input);
                if (choix == 1)
                {
                    Joueur.Attack += 1;
                    resultat -= 1;
                    Console.WriteLine($"Augmentation d'attaque de 1");
                }
                else if (choix == 2)
                {
                    Joueur.Hp += 1;
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
    }//Systeme Augmentation de stat

    public static RandomEnnemi(Character Ennemie)
    {
        Random random = new Random();
        Ennemie ennemi = GetEnnemie(random.Next(1, 3).ToString());
    }//Recupérer ennemie random

}