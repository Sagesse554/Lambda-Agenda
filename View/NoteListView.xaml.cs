using AgendaProjet.Data;
using AgendaProjet.Model;
using System.Collections.ObjectModel;

namespace AgendaProjet.View;
    public partial class NoteListView : ContentPage
    { 

        private readonly Database database;

        public ObservableCollection<NotesDef> NoteItems { get; set; } = new();
        public NoteListView(Database database)
        {

            InitializeComponent();

            this.database = database;

            BindingContext = this;

        }

        private async Task<NotesDef> GetNoteByIntitule(string intitule)
        {
            await database.Initialize();

            return await database.Connection.Table<NotesDef>().FirstOrDefaultAsync(n => n.Intitule == intitule);
        }


        private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is not NotesDef noteItem)
                return;

            NotesDef selectedNote = await GetNoteByIntitule(noteItem.Intitule);

            await Shell.Current.GoToAsync(nameof(NoteEdit), true, new Dictionary<string, object>
            {
                ["NoteItem"] = selectedNote
            });
        }
        protected override async void OnNavigatedTo(NavigatedToEventArgs args)
            {
                base.OnNavigatedTo(args);

                var noteitems = await database.GetNotesItemsAsync();

                MainThread.BeginInvokeOnMainThread(() =>
                {
                    NoteItems.Clear();
                    foreach (var noteitem in noteitems)
                       NoteItems.Add(noteitem);
                });
            }

        private async void OnNoteItemAdd(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(NoteEdit), true, new Dictionary<string, object>
            {
                ["NoteItem"] = new NotesDef()
            });
        }
    }


