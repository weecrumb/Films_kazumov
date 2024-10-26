using Films_kazumov.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using Schema = System.ComponentModel.DataAnnotations.Schema;

namespace Films_kazumov.Models
{
    public class Films : Notification
    {
        public int Id { get; set; }
        public string name;
        public string Name
        {
            get { return name; }
            set
            {
                Match match = Regex.Match(value, "^.{1,50}$");
                if (!match.Success)
                    MessageBox.Show("Наименование не должно быть пустым, и не более 50 символов.", "Не корректный ввод значения.");
                else
                {
                    name = value;
                    OnPropertyChanged("Name");
                }

            }
        }
        private string price;
        public string Price
        {
            get { return price; }
            set
            {
                Match match = Regex.Match(value, "^.{1,30}$");
                if (!match.Success)
                    MessageBox.Show("Цена не должна быть пустая, и не более 30 символов.", "Не корректный ввод значения.");
                else
                {
                    price = value;
                    OnPropertyChanged("Price");
                }
            }
        }
        private DateTime dateStart;
        public DateTime DateStart
        {
            get { return dateStart; }
            set
            {
                dateStart = value;
                OnPropertyChanged("DateStart");
            }
        }

        [Schema.NotMapped]
        public bool isEnable;
        [Schema.NotMapped]
        public bool IsEnable
        {
            get { return isEnable; }
            set
            {
                isEnable = value;
                OnPropertyChanged("IsEnable");
                OnPropertyChanged("IsEnableText");
            }
        }
        [Schema.NotMapped]
        public string IsEnableText
        {
            get
            {
                if (IsEnable) return "Сохранить";
                else return "Изменить";
            }
        }
        
        [Schema.NotMapped]
        public RealyCommand OnEdit
        {
            get
            {
                return new RealyCommand(obj =>
                {
                    IsEnable = !IsEnable;
                    if (!IsEnable)
                        (MainWindow.init.DataContext as ViewModels.VM_Pages).vm_films.filmsContext.SaveChanges();
                });
            }
        }
        [Schema.NotMapped]
        public RealyCommand OnDelete
        {
            get
            {
                return new RealyCommand(obj =>
                {
                    if (MessageBox.Show("Вы уверены что хотите удалить фильм?", "Предупреждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        (MainWindow.init.DataContext as ViewModels.VM_Pages).vm_films.Films.Remove(this);
                        (MainWindow.init.DataContext as ViewModels.VM_Pages).vm_films.filmsContext.Remove(this);
                        (MainWindow.init.DataContext as ViewModels.VM_Pages).vm_films.filmsContext.SaveChanges();
                    }
                });
            }
        } 
    }
}
