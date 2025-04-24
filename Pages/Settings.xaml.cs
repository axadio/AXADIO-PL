namespace AXADIO.Pages;

public partial class Settings : ContentPage
{
    public Settings()
    {
        InitializeComponent();
    }
    public void DarkModeSwitch_Toggled(object sender, ToggledEventArgs e)
    {
        Preferences.Set("DarkMode", e.Value);
        Application.Current.UserAppTheme = e.Value ? AppTheme.Dark : AppTheme.Light;
    }
}
