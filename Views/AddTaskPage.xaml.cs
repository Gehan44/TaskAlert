using Plugin.LocalNotification;
using TaskAlert.Models;
using Plugin.Maui.Audio;

namespace TaskAlert.Views;

public partial class AddTaskPage : ContentPage
{
    Data.ActivityDatabase activityDatabase = new Data.ActivityDatabase();
    public AddTaskPage()
    {
        InitializeComponent();
        BindingContext = this;
        LocalNotificationCenter.Current.NotificationActionTapped +=
    Current_NotificationActionTapped;
    }

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var activity = (Models.Activity)BindingContext;
        if (string.IsNullOrEmpty(activity.Name))
        {
            await DisplayAlert("Empty", "Please enter a name for the activity", "OK");
            return;
        }
        Console.WriteLine(activity.NotiActivity);
        Console.WriteLine("Selected time: " + activity.Time);
        await activityDatabase.SaveActivityAsync(activity);
        if (activity.NotiActivity)
        {
            if (activity.ModeActivity)
            {
                DateTime selectedTime = DateTime.Today.Add(activity.Time);
                var notification = new NotificationRequest
                {
                    NotificationId = activity.ID,
                    Title = activity.Name,
                    Description = activity.Note,
                    Schedule = new NotificationRequestSchedule
                    {
                        NotifyTime = selectedTime,
                        RepeatType = NotificationRepeat.Weekly
                    }
                };
                await LocalNotificationCenter.Current.Show(notification);
            }
            else
            {
                DateTime selectedTime = DateTime.Today.Add(activity.Time);
                var notification = new NotificationRequest
                {
                    NotificationId = activity.ID,
                    Title = activity.Name,
                    Description = activity.Note,
                    Schedule = new NotificationRequestSchedule
                    {
                        NotifyTime = selectedTime,
                        RepeatType = NotificationRepeat.Daily
                    }
                };
                await LocalNotificationCenter.Current.Show(notification);
            }
        }
        await Navigation.PopAsync();
    }

    private void Current_NotificationActionTapped(Plugin.LocalNotification.EventArgs.NotificationActionEventArgs e)
    {
        if (e.IsDismissed)
        {
        }
    }

    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var confirm = await DisplayAlert("Delete Activity", "Are you sure you want to delete this activity?", "Yes", "No");
        if (confirm) {
            var activity = (Activity)BindingContext;
            await activityDatabase.DeleteActivityAsync(activity);
            await Navigation.PopAsync();
        } else { }
    }
}