using SQLite;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace AgendaProjet.Model;

public class NotesDef
{

    [PrimaryKey, AutoIncrement]
    public int IdNotes { get; set; }
    public int CategoryId { get; set; }
    public string Intitule { get; set; }
    public string Description { get; set; }
    public int Notation { get; set; }
    public DateTime Date { get; set; }
    public TimeSpan Heure { get; set; }
    public string Lieu { get; set; }

    public NotesDef()
    {
        // Initialise la Date avec la date actuelle
        Date = DateTime.Now;

        // Initialise les heurees avec l'heure actuelle
        Heure = DateTime.Now.TimeOfDay;
    }
}
