using Microsoft.Maui.Controls;
using Plugin.LocalNotification;
using System.Collections.ObjectModel;
using TaskAlert.Data;
using TaskAlert.Models;

namespace TaskAlert.Views;

public partial class RoutinePage : ContentPage
{
    Data.ActivityDatabase activityDatabase = new Data.ActivityDatabase();
    public RoutinePage()
    {
        InitializeComponent();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        List<Activity> activities = new List<Activity>()
        {
            new Activity
            {
                Name = "Wakeup",
                Note = "The best way to wake you up is stand up",
                Time = TimeSpan.Parse("07:30"),
                NotiActivity = false,
                ModeActivity = false
            },
            new Activity
            {
                Name = "Breakfast",
                Note = "The best time to eat Breakfast",
                Time = TimeSpan.Parse("08:30"),
                NotiActivity = false,
                ModeActivity = false
            },
            new Activity
            {
                Name = "Workout",
                Note = "The most effective time of day to Workout",
                Time = TimeSpan.Parse("10:00"),
                NotiActivity = false,
                ModeActivity = false
            },
            new Activity
            {
                Name = "Lunch",
                Note = "The best time to eat Lunch",
                Time = TimeSpan.Parse("12:00"),
                NotiActivity = false,
                ModeActivity = false
            },
            new Activity
            {
                Name = "Dinner",
                Note = "The best time to eat Dinner",
                Time = TimeSpan.Parse("19:00"),
                NotiActivity = false,
                ModeActivity = false
            }
        };
        foreach (var activity in activities)
        {
            await activityDatabase.SaveActivityAsync(activity);
        }
        await DisplayAlert("Routine", "Routine have been add to your Activity achieve optimal health", "OK");
        await Navigation.PopAsync();
    }
}