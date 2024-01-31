using System.Collections.ObjectModel;
using System.Windows.Input;
using AgendaProjet.Data;

namespace AgendaProjet.View;
using Model;
using System.Threading.Tasks;

public partial class CalendarView : StackLayout
{
    private readonly Database database;

    private ObservableCollection<TachEventDef> item;

    public CalendarView(Database database)
    {
        InitializeComponent();

        this.database = database;
        BindingContext = this;

        item = new ObservableCollection<TachEventDef>();
        taskListView.ItemsSource = item;

        datePicker.DateSelected += LoadTachItemsForSelectedDate;
    }


    private ObservableCollection<TachEventDef> TachItems { get; set; } = new ObservableCollection<TachEventDef>();

    private async void LoadTachItemsForSelectedDate(object sender, DateChangedEventArgs e)
    {
        if (database is null)
            return;

        DateTime selectedDate = e.NewDate;

        // Charger les tâches enregistrées pour la date sélectionnée
        TachItems.Clear();
        var tachItems = await database.GetEvItemsByDateAsync(selectedDate);
        foreach (var item in tachItems)
        {
            TachItems.Add(item);
        }

        taskListView.ItemsSource = TachItems;
    }

    private async void OnTachItemAdd(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new TachEventEdit(database, TachItems)
        {
            TachItem = new TachEventDef()
        });
    }


    //ESSAI DE TRI PAR DATE AU CLIC
    //protected async void OnCalendarDateClicked(DateTime selectedDate)
    //{
    //    // Récupérer les tâches enregistrées pour la date spécifique
    //    var tachItems = await database.GetEvItemsByDateAsync(selectedDate);

    //    await Shell.Current.GoToAsync(nameof(TachEventList));

    //}

    ////protected async void OnCalendarDateClicked(DateTime selectedDate)
    ////{
    ////    SelectedDate = selectedDate;
    ////    await Shell.Current.GoToAsync(nameof(TachEventList));
    ////}


    //Daniel a ajoute <typeof(CalendarView),>

    #region BindableProperty
    public static readonly BindableProperty SelectedDateProperty = BindableProperty.Create(
		nameof(SelectedDate),
		typeof(DateTime),
        //typeof(CalendarView),
        declaringType: typeof(CalendarModel),
		defaultBindingMode: BindingMode.TwoWay,
		defaultValue: DateTime.Now,
	    propertyChanged : SelectedDataPropertyChanged
		);

    private static void SelectedDataPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var controls = (CalendarView)bindable;
		if ( newValue != null )
		{
			var newDate = (DateTime)newValue;

			if(controls._tempDate.Month == newDate.Month && controls._tempDate.Year ==newDate.Year )
			{
				var currentDate = controls.Dates.Where(f => f.Date == newDate).FirstOrDefault();
				if ( currentDate != null )
				{
                    controls.Dates.ToList().ForEach(f => f.IsCurrentDate = false);
                    currentDate.IsCurrentDate = true;
				}
			}
			else
			{
                controls.BindDates(newDate);
            }
			
		}
    }

    public DateTime SelectedDate
	{
		get => (DateTime)GetValue(SelectedDateProperty);
		set => SetValue(SelectedDateProperty, value);
	}

    public DateTime SelectedDateMonth(DateTime date)
    {
		return date;
    }
	//c'etait en commentaire
	public static readonly BindableProperty SelectedDateCommandProperty = BindableProperty.Create(
		nameof(SelectedDateCommand),
		typeof(ICommand),
		declaringType: typeof(CalendarModel));

	public ICommand SelectedDateCommand
	{
		get => (ICommand)GetValue(SelectedDateCommandProperty);
		set => SetValue(SelectedDateProperty, value);
	}

	public event EventHandler<DateTime> OnDateSelected;
	private DateTime _tempDate;
    #endregion
    //c'etait en commentaire
    public ObservableCollection<CalendarModel> Dates { get; set; } = new ObservableCollection<CalendarModel>();
	public CalendarView()
	{
		InitializeComponent();
		BindDates(DateTime.Now);
    }

    public void BindDates(DateTime date)
	{
		Dates.Clear();
		int daysCount = DateTime.DaysInMonth(date.Year, date.Month);

		for(int day = 1;day<=daysCount;day++) 
		{
			Dates.Add(new CalendarModel
			{
				Date = new DateTime(date.Year, date.Month, day)
			});
            
		}

		var selectedDate = Dates.Where(f => f.Date.Date==SelectedDate.Date).FirstOrDefault();
		if (selectedDate!= null)
		{
            selectedDate.IsCurrentDate = true;
			_tempDate = selectedDate.Date;
		}
	}

    #region Command
    public ICommand CurrentDateCommand => new Command<CalendarModel>((currentDate) =>
	{
		_tempDate = currentDate.Date;
        SelectedDate = currentDate.Date;
		//OnDateSelected?.Invoke(null, currentDate.Date);
		//SelectedDateCommand?.Execute(currentDate.Date);

    });

	public ICommand NextMonthCommad => new Command(() =>
	{
		
		_tempDate = _tempDate.AddMonths(1);
		BindDates(_tempDate);
        SelectedDateMonth(_tempDate);
        

    });

    public ICommand PreviousMonthCommad => new Command(() =>
    {
		_tempDate = _tempDate.AddMonths(-1);
        BindDates(_tempDate);
		SelectedDateMonth(_tempDate);
    });
    #endregion
}