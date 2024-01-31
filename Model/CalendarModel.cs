using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaProjet.Model;
public class CalendarModel: PropertyChangedModel
{
    public DateTime Date {get; set;}
    private bool _isCurrentDate;
    public bool IsCurrentDate
    {
        get { return _isCurrentDate; } set { SetProperty(ref _isCurrentDate, value); }
    }
}
