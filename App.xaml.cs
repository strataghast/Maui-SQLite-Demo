namespace Maui_SQLite_Demo
{
    public partial class App : Application
    {
        public App(MainPage mainPage) // We can pass MainPage as a parameter to the constructor
        {
            InitializeComponent();

            MainPage = mainPage; // We can designate it as the initial page for our application

            
        }
    }
}
