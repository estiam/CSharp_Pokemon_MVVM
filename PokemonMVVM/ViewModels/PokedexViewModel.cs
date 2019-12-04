using PokemonMVVM.DAL;
using PokemonMVVM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace PokemonMVVM.ViewModels
{
    class PokedexViewModel : INotifyPropertyChanged
    {
        #region DATA BINDINGS
        MediaPlayer mp = new MediaPlayer();
        public PokedexViewModel()
        {
            PropertyChanged += PokedexViewModel_PropertyChanged;
            LoadPokemons();
        }

        public async void LoadPokemons()
        {
            Pokemons = await PokemonAPIDAL.LoadPokemonsAsync();
        }

        public async void LoadPokemon(string url)
        {
            LoadedPokemon = await PokemonAPIDAL.LoadPokemonAsync(url);
        }

        private void PokedexViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "SelectedPokemon")
            {
                LoadPokemon(SelectedPokemon.Url);
            }
            if(e.PropertyName == "LoadedPokemon")
            {
                PlayCry();
            }
        }

        private void PlayCry()
        {
            WebClient wc = new WebClient();
            string url = String.Format("https://raw.githubusercontent.com/kuo22/pokemon-cries/master/public/cries/{0}.wav", LoadedPokemon.Id);

            Stream stream = wc.OpenRead(new Uri(url));

            string destPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "temp.wav");
            var fileStream = File.Create(destPath);
            stream.CopyTo(fileStream);
            fileStream.Close();

            mp.Close();
            mp.Open(new Uri(destPath));
            mp.Play();
            mp.MediaEnded += Mp_MediaEnded;

        }

        private void Mp_MediaEnded(object sender, EventArgs e)
        {
            mp.Close();
        }

        private Pokemon selectedPokemon;

        public Pokemon SelectedPokemon
        {
            get { return selectedPokemon; }
            set
            {
                selectedPokemon = value;
                OnPropertyChange("SelectedPokemon");
            }
        }

        private List<Pokemon> pokemons;

        public List<Pokemon> Pokemons
        {
            get { return pokemons; }
            set {
                pokemons = value;
                OnPropertyChange("Pokemons");
            }
        }

        private Pokemon loadedPokemon;

        public Pokemon LoadedPokemon
        {
            get { return loadedPokemon; }
            set
            {
                loadedPokemon = value;
                OnPropertyChange("LoadedPokemon");
            }
        }

        #endregion

        private ICommand moreInfo;

        public ICommand MoreInfo
        {
            get {
                if(moreInfo == null)
                {
                    moreInfo = new MoreInfoCommand();
                }

                return moreInfo;
            }
            set { moreInfo = value; }
        }

        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }

    class MoreInfoCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Info i = new Info((Pokemon) parameter);
            i.Show();
        }
    }
}
