using PokemonMVVM.Models;
using PokemonMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PokemonMVVM
{
    /// <summary>
    /// Logique d'interaction pour Info.xaml
    /// </summary>
    public partial class Info : Window
    {
        private InfoViewModel _viewModel;
        public Info(Pokemon p)
        {
            InitializeComponent();
            _viewModel = new InfoViewModel(p);
            DataContext = _viewModel;
        }
    }
}
