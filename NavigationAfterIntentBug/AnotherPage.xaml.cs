namespace NavigationAfterIntentBug;

public partial class AnotherPage : ContentPage
{
    public AnotherPage()
    {
        InitializeComponent();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(AnotherDetailPage));
    }
}