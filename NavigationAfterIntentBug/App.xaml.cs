namespace NavigationAfterIntentBug;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
    }

    public void GoToAnotherPage(string sharedFilePath)
    {
        Shell.Current.GoToAsync(nameof(AnotherPage));
    }
}
