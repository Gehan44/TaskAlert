using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskAlert.Models;

namespace TaskAlert.ViewModels
{
    public partial class ActivityVM : ObservableObject
    {
        public ICommand EditCommand { get; private set; }
        public ICommand DelCommand { get; private set; }

        [ObservableProperty]
        private ObservableCollection<Models.Activity> activities;
        Data.ActivityDatabase activityDatabase = new Data.ActivityDatabase();

        public ActivityVM()
        {
            Activities = new ObservableCollection<Models.Activity>();
            EditCommand = new Command<Models.Activity>((actObj) =>
            {
                EditActivity(actObj);
            });

            DelCommand = new Command<Models.Activity>((actObj) =>
            {
                DelActivity(actObj);
            });
        }


        public async void LoadDataFromDb()
        {
            var actDb = await activityDatabase.GetActivitiesAsync();
            Activities.Clear();
            if(actDb !=null && actDb.Count>0)
            {
                foreach (var item in actDb)
                {
                    Activities.Add(item);
                }
            }
        }

        private async void EditActivity(Activity obj)
        {
            if (obj != null)
            {
                await Application.Current.MainPage.Navigation.PushAsync(new Views.AddTaskPage
                {
                    BindingContext = obj as Activity
                });
            }
        }

        private async void DelActivity(Activity obj)
        {
            var confirm = 
                await Application.Current.MainPage.DisplayAlert("Delete Activity", 
                "Are you sure you want to delete this activity?", "Yes", "No");
            if (confirm)
            {
                await activityDatabase.DeleteActivityAsync(obj);
            }
            else { }
        }

    }
}
