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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Waterskibaan;

namespace WaterskibaanVisualisatie
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Game game;

        public MainWindow()
        {
            InitializeComponent();

            game = new Game();
            game.Initialize();

            game.NieuweBezoeker += OnNieuweBezoeker;
        }

        public void OnNieuweBezoeker(NieuweBezoekerArgs args)
        {
            Console.WriteLine("Nieuwe bezoeker in instructie wachtrij");
            TestLabel.Dispatcher.Invoke(() =>
            {
                TestLabel.Content = "Aantal mensen in instructie wachtrij " + game.wachtrijInstructie.AantalInWachtrij();
            });
        }
    }
}
