using ControllerUI.CustomExceptions;
using ControllerUI.Entities;
using ControllerUI.Extensions;
using ControllerUI.Services.Classes;
using ControllerUI.Services.Interfaces;
using ControllerUI.Singletons;
using SharpDX.XInput;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ControllerUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IGameService _gameService;
        private List<GameEntity> _gameList;
        public MainWindow(IGameService gameService)
        {
            _gameService = gameService;
           
        }

        public MainWindow(): this (new GameService())
        {
            InitializeComponent();
        }

        private async void Grid_Loaded(object sender, RoutedEventArgs e)
        {
                _gameList = await _gameService.GetAllGamesAsync();
                await XControllerSingleton.XControllerInstance.RunAppAsync(Dispatcher, txtGetKeyPressed);
        }
    }
}