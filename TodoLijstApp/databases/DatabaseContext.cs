using LiteDB;

namespace TodoLijstApp.databases;

public class DatabaseContext
{
    private static LiteDatabase? _database;

    public static LiteDatabase Database
    {
        get
        {
            if (_database == null)
            {
                string databasePath = Path.Combine(
                    FileSystem.AppDataDirectory,
                    "todolijst.db"
                );

                _database = new LiteDatabase(databasePath);
            }

            return _database;
        }
    }

    public ILiteCollection<T> GetCollection<T>(string name)
    {
        return Database.GetCollection<T>(name);
    }
}