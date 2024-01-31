using AgendaProjet.Model;
using SQLite;

namespace AgendaProjet.Data;

public class Database
{
    public SQLiteAsyncConnection Connection { get; set; }

    public Database()
    {

    }
    public async Task Initialize()
    {
        if (Connection is not null)
            return;

        Connection = new SQLiteAsyncConnection(Constants.DatabasePath);

        await Connection.CreateTableAsync<CategorieDef>();//creation table categorie

        await Connection.CreateTableAsync<NotesDef>();//creation table note

        await Connection.CreateTableAsync<TachEventDef>();//creation table Tache/event


    }

    //-----------GESTION DES Categories----------------------

    public async Task<List<CategorieDef>> GetCatgItemsAsync()
    {
        await Initialize();
        return await Connection.Table<CategorieDef>().ToListAsync();
    }

    
    public async Task<int> SaveItemAsync(CategorieDef item)
    {
        await Initialize();

        if (item.IdCatg != 0)
        {
            return await Connection.UpdateAsync(item);
        }
        else
        {
            return await Connection.InsertAsync(item);
        }
    }
    
    public async Task<int> DeleteItemAsync(CategorieDef item)
    {
        await Initialize();
        return await Connection.DeleteAsync(item);
    }


    //enregistrement de la categorie selectionne pour la note
    public async Task SaveCategory(CategorieDef category)
    {
        await Initialize();

        if (category.IdCatg == 0)
        {
            // Nouvelle catégorie, effectuer une insertion
            await Connection.InsertAsync(category);
        }
        else
        {
            // Catégorie existante, effectuer une mise à jour
            await Connection.UpdateAsync(category);
        }
    }

    //-----------GESTION DES NOTES----------------------

    public async Task<List<NotesDef>> GetNotesItemsAsync()
    {
        await Initialize();
        return await Connection.Table<NotesDef>().ToListAsync();
    }


    public async Task<int> SaveNoteItemAsync(NotesDef Noteitem)
    {
        await Initialize();

        if (Noteitem.IdNotes != 0)
        {
            return await Connection.UpdateAsync(Noteitem);
        }
        else
        {
            return await Connection.InsertAsync(Noteitem);
        }
    }

    public async Task<int> DeleteItemAsync(NotesDef Noteitem)
    {
        await Initialize();
        return await Connection.DeleteAsync(Noteitem);
    }

    //------------Gestion des evenements/taches---------------

    public async Task<List<TachEventDef>> GetEvItemsAsync()
    {
        await Initialize();
        return await Connection.Table<TachEventDef>().ToListAsync();
    }


    public async Task<int> SaveEvItemAsync(TachEventDef Tachitem)
    {
        await Initialize();

        if (Tachitem.IdTach != 0)
        {
            return await Connection.UpdateAsync(Tachitem);
        }
        else
        {
            return await Connection.InsertAsync(Tachitem);
        }
    }

    public async Task<int> DeleteItemAsync(TachEventDef Tachitem)
    {
        await Initialize();
        return await Connection.DeleteAsync(Tachitem);
    }



    // affichage de la note par date d'enregistrement

    public async Task<List<TachEventDef>> GetEvItemsByDateAsync(DateTime selectedDate)
    {
        await Initialize();

        // Effectuez une requête sur la base de données pour récupérer les tâches pour la date spécifique
        return await Connection.Table<TachEventDef>()
            .Where(t => t.EventDate.Date == selectedDate.Date)
            .ToListAsync();
    }




    public async Task<List<NotesDefWithCategory>> GetNotesWithCategories()
    {
        await Initialize();

        return await Connection.QueryAsync<NotesDefWithCategory>(
            @"SELECT NotesDef.*, CategorieDef.CategoryName 
              FROM NotesDef 
              JOIN CategorieDef ON NotesDef.CategoryId = CategorieDef.IdCatg");
    }


}
