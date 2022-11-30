namespace NavigationAfterIntentBug;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(AnotherPage), typeof(AnotherPage));
        Routing.RegisterRoute(nameof(AnotherDetailPage), typeof(AnotherDetailPage));
    }
}
