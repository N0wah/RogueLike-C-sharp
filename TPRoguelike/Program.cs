using System;
using CharacterClass;
using MySql.Data.MySqlClient;

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

}
