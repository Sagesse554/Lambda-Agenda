using SQLite;
namespace AgendaProjet.Model;
public class NotesDefWithCategory
{
    public int IdNotes { get; set; }
    public string Intitule { get; set; }
    public string Description { get; set; }
    public int Notation { get; set; }
    public string Lieu { get; set; }
    public DateTime Date { get; set; }
    public TimeSpan Heure { get; set; }
    public string CategoryName { get; set; }
}
