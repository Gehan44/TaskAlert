using CommunityToolkit.Maui.Core;
using Microsoft.VisualBasic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TaskAlert.Models;

namespace TaskAlert.Views;

public partial class TaskAlertPage : ContentPage
{
    public ViewModels.ActivityVM vm { get; set; }
    public TaskAlertPage()
    {
        InitializeComponent();
        vm = new ViewModels.ActivityVM();
        this.BindingContext = vm;
    }

    
    protected override void OnAppearing()
    {
        base.OnAppearing();
        vm.LoadDataFromDb();
    }

    async void OnNoteAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddTaskPage
        {
            BindingContext = new Activity()
        });
    }

    /*async void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new AddTaskPage
            {
                BindingContext = e.SelectedItem as Activity
            });
        }
    }*/

    

}