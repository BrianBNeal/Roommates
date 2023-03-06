using Microsoft.Data.SqlClient;
using Roommates.Models;

namespace Roommates.Repositories;

public class ChoreRepository : BaseRepository
{
    public ChoreRepository(string connectionString) : base(connectionString)
    {
    }


    /* any time you make a repository:
     *      - include the connection string so you can connect to the right db
     *      - include any CRUD methods your app might need for this particular resource
     * 
     */

    public List<Chore> GetAll()
    {
        using (var connection = Connection)
        {
            connection.Open();

            using (var cmd = connection.CreateCommand())
            {
                cmd.CommandText = "SELECT Id, Name FROM Chore";

                var chores = new List<Chore>();
                
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Chore chore = new Chore()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                        };

                        chores.Add(chore);
                    }
                }

                return chores;
            }
        }
    }

    public Chore? GetById(int id)
    {
        using (var conn = Connection)
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT Id, Name FROM Chore WHERE Id = @id";
                cmd.Parameters.AddWithValue("@id", id);
                Chore? chore = null;
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        chore = new Chore()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                        };
                    } 
                }

                return chore;
            }
        }
    }

    public void Insert(Chore chore)
    {
        using (var conn = Connection)
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"INSERT INTO Chore (Name) 
                                    OUTPUT INSERTED.Id 
                                    VALUES (@name)";
                cmd.Parameters.AddWithValue("@name", chore.Name);
                chore.Id = (int)cmd.ExecuteScalar();
            }
        }
    }
}
