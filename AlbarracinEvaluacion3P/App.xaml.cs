using AlbarracinEvaluacion3P.ServicesJA;

namespace AlbarracinEvaluacion3P
{
    public partial class App : Application
    {
        static EpisodioRepository database;

        public static EpisodioRepository Database
        {
            get
            {
                if (database == null)
                {
                    database = new EpisodioRepository(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "episode.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
