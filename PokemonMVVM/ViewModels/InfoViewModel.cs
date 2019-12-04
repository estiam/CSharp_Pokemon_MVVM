using PokemonMVVM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonMVVM.ViewModels
{
    public class InfoViewModel : INotifyPropertyChanged
    {
        public InfoViewModel(Pokemon p)
        {
            CurrentPokemon = p;
        }
        private Pokemon currentPokemon;


        public Pokemon CurrentPokemon
        {
            get { return currentPokemon; }
            set { currentPokemon = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
