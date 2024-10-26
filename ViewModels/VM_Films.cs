using Films_kazumov.Classes;
using Films_kazumov.Context;
using Films_kazumov.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Films_kazumov.ViewModels
{
    public class VM_Films : Notification
    {
        public FilmsContext filmsContext = new FilmsContext();
        public ObservableCollection<Films> Films { get; set; }
        public VM_Films() =>
            Films = new ObservableCollection<Films>(filmsContext.Films);
        public RealyCommand OnAddTask
        {
            get
            {
                return new RealyCommand(obj =>
                {
                    Films NewFilm = new Films()
                    {
                        DateStart = DateTime.Now
                    };
                    Films.Add(NewFilm);
                    filmsContext.Films.Add(NewFilm);
                    filmsContext.SaveChanges();
                });
            }
        }
    }
}
