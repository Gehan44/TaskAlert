namespace TaskAlert;

public partial class App : Application
{
    public static string FolderPath { get; private set; }
    public App()
    {
        InitializeComponent();

        FolderPath = Path.Combine(
            Environment.GetFolderPath(
                Environment.SpecialFolder.LocalApplicationData));

        MainPage = new NavigationPage(new Views.MainSelectPage());
    }
}
