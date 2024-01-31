using SQLite;
using System.ComponentModel;

namespace AgendaProjet.Model;

public class CategorieDef
{
    [PrimaryKey, AutoIncrement]
    public int IdCatg { get; set;}
    public string CategoryName { get; set; }
    public string CategoryColor { get; set; }

}



