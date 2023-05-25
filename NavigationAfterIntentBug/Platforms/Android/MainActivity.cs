using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;

namespace NavigationAfterIntentBug;

[Activity(Theme = "@style/Maui.SplashTheme", 
    MainLauncher = true, 
    ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density,
    LaunchMode = LaunchMode.SingleTop)]
[IntentFilter(
    new[] { Intent.ActionSend, Intent.ActionView },
    Categories = new[] { Intent.CategoryDefault },
    DataMimeType = @"application/pdf")]
public class MainActivity : MauiAppCompatActivity
{
    public string sharedFilePath;

    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
    }

    protected override void OnNewIntent(Intent intent)
    {
        base.OnNewIntent(intent);

        // create path for the shared file
        if (intent.Action == Intent.ActionSend)
        {
            var pdf = intent.ClipData.GetItemAt(0);
            var pdfStream = ContentResolver.OpenInputStream(pdf.Uri);

            var memoryStream = new MemoryStream();
            pdfStream.CopyTo(memoryStream);

            var filePath = Path.Combine(Path.GetTempPath(), pdf.Uri.LastPathSegment);
            filePath = Path.ChangeExtension(filePath, ".pdf");
            File.WriteAllBytes(filePath, memoryStream.ToArray());

            sharedFilePath = filePath;

        }
        else if (intent.Action == Intent.ActionView)
        {
            var path = intent.Data.Path;
            var pdfStream = ContentResolver.OpenInputStream(intent.Data);

            var memoryStream = new MemoryStream();
            pdfStream.CopyTo(memoryStream);

            var filePath = Path.Combine(Path.GetTempPath(), Path.GetFileName(path));
            filePath = Path.ChangeExtension(filePath, ".pdf");
            File.WriteAllBytes(filePath, memoryStream.ToArray());

            sharedFilePath = filePath;

        }

        if (sharedFilePath != null)
        {
            ((App)Microsoft.Maui.Controls.Application.Current).GoToAnotherPage(sharedFilePath);
        }

        sharedFilePath = null;
    }
}
