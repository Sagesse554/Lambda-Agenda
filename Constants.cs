using SQLite;

namespace AgendaProjet;

public class Constants
{
    public const string DatabaseFilename = "AgendaDB.db3";

    public static string DatabasePath = Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);

    public const SQLiteOpenFlags Flags = SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.SharedCache;
}
