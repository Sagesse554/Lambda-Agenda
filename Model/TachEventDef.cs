using SQLite;


namespace AgendaProjet.Model;
    public class TachEventDef
    {
        [PrimaryKey, AutoIncrement]
        public int IdTach { get; set; }
        public string Titre { get; set; }
        public string Detail { get; set; }
        public string EventLieu { get; set; }
        public DateTime EventDate { get; set; }
        public TimeSpan EventHeure { get; set; }
        public bool Remind { get; set; }
        public DateTime RappDate { get; set; }
        public TimeSpan RappHeure { get; set; }
        public string EventFreq { get; set;}

        // Initilization

        public TachEventDef()
        {
            // Initialise les Dates avec la date actuelle
            EventDate = DateTime.Now;
            RappDate = DateTime.Now;

            // Initialise les heurees avec l'heure actuelle
            EventHeure = DateTime.Now.TimeOfDay;
            RappHeure = DateTime.Now.TimeOfDay;
        }
}