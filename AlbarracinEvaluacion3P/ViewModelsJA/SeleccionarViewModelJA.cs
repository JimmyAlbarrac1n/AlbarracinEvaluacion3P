using AlbarracinEvaluacion3P.ModelsJA;
using AlbarracinEvaluacion3P.ServicesJA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AlbarracinEvaluacion3P.ViewModelsJA
{
    public class SeleccionarViewModelJA : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private readonly EpisodioServiceJA service;

        public SeleccionarViewModelJA()
        {
            service = new EpisodioServiceJA();
            SaveEpisodeCommand = new Command(async () => await SaveEpisode());
            BuscarEpisodeCommand = new Command(async () => await BuscarEpisode());
        }

        private int id;
        public int Id
        {
            get { return id; }
            set
            {
                if (value != id)
                {
                    id = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (value != name)
                {
                    name = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string air_date;
        public string Air_date
        {
            get { return air_date; }
            set
            {
                if (value != air_date)
                {
                    air_date = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string episode;
        public string Episode
        {
            get { return episode; }
            set
            {
                if (value != episode)
                {
                    episode = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string url;
        public string Url
        {
            get { return url; }
            set
            {
                if (value != url)
                {
                    url = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private string created;
        public string Created
        {
            get { return created; }
            set
            {
                if (value != created)
                {
                    created = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public Command SaveEpisodeCommand { get; }
        public Command BuscarEpisodeCommand { get; }

        private async Task SaveEpisode()
        {
            if (Id != 0)
            {
                var episode = new EpisodioJA
                {
                    name = Name,
                    air_date = Air_date,
                    episode = Episode,
                    url = Url,
                    created = Created
                };

                await App.Database.SaveEpisodeAsync(episode);
                await Application.Current.MainPage.DisplayAlert("Éxito", "Episodio guardado correctamente", "OK");
            }
        }

        private async Task BuscarEpisode()
        {
            var episode = await service.GetEpisode(Id);
            if (episode != null)
            {
                Name = episode.name;
                Air_date = episode.air_date;
                Episode = episode.episode;
                Url = episode.url;
                Created = episode.created;
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Episodio no encontrado", "OK");
            }
        }
    }
}
