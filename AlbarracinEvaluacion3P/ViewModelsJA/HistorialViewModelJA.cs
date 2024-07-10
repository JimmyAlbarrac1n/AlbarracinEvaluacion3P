using AlbarracinEvaluacion3P.ModelsJA;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AlbarracinEvaluacion3P.ViewModelsJA
{
    public class HistorialViewModelJA : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<EpisodioJA> SavedEpisodes { get; set; }

        public HistorialViewModelJA()
        {
            LoadEpisodeCommand = new Command(async () => await LoadEpisode());
            SavedEpisodes = new ObservableCollection<EpisodioJA>();
            LoadEpisodeCommand.Execute(null);
        }

        public Command LoadEpisodeCommand { get; }

        private async Task LoadEpisode()
        {
            var characters = await App.Database.GetSavedEpisodeAsync();
            SavedEpisodes.Clear();
            foreach (var character in characters)
            {
                SavedEpisodes.Add(character);
            }
        }
    }
}
