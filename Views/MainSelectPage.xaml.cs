namespace TaskAlert.Views;

public partial class MainSelectPage : ContentPage
{
	public MainSelectPage()
	{
		InitializeComponent();
	}

    private void ActButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new TaskAlertPage());
    }

    private void RoutineButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new RoutinePage());
    }

    private void SoundButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new SoundPage());
    }
}