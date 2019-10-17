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

            game.LoopUpdate += LoopUpdate;
        }

        public void LoopUpdate()
        {
            Console.WriteLine("Update UI");

            UpdateLijnen();
            UpdateWachtrijen();
            UpdateStats();
        }

        private void UpdateLijnen()
        {
            bool[] resetLijnen = {true, true, true, true, true, true, true, true, true, true};
            foreach (Lijn lijn in game.waterskibaan.Kabel.Lijnen)
            {
                switch (lijn.PositieOpDeKabel)
                {
                    case 0:
                        resetLijnen[0] = false;
                        UpdateLijn(lijn, Position0Label, Position0Rectangle);
                        break;
                    case 1:
                        resetLijnen[1] = false;
                        UpdateLijn(lijn, Position1Label, Position1Rectangle);
                        break;
                    case 2:
                        resetLijnen[2] = false;
                        UpdateLijn(lijn, Position2Label, Position2Rectangle);
                        break;
                    case 3:
                        resetLijnen[3] = false;
                        UpdateLijn(lijn, Position3Label, Position3Rectangle);
                        break;
                    case 4:
                        resetLijnen[4] = false;
                        UpdateLijn(lijn, Position4Label, Position4Rectangle);
                        break;
                    case 5:
                        resetLijnen[5] = false;
                        UpdateLijn(lijn, Position5Label, Position5Rectangle);
                        break;
                    case 6:
                        resetLijnen[6] = false;
                        UpdateLijn(lijn, Position6Label, Position6Rectangle);
                        break;
                    case 7:
                        resetLijnen[7] = false;
                        UpdateLijn(lijn, Position7Label, Position7Rectangle);
                        break;
                    case 8:
                        resetLijnen[8] = false;
                        UpdateLijn(lijn, Position8Label, Position8Rectangle);
                        break;
                    case 9:
                        resetLijnen[9] = false;
                        UpdateLijn(lijn, Position9Label, Position9Rectangle);
                        break;
                }
            }

            for (int i = 0; i < resetLijnen.Length; i++)
            {
                if (resetLijnen[i])
                {
                    switch (i)
                    {
                        case 0:
                            ResetLijn(Position0Label, Position0Rectangle);
                            break;
                        case 1:
                            ResetLijn(Position1Label, Position1Rectangle);
                            break;
                        case 2:
                            ResetLijn(Position2Label, Position2Rectangle);
                            break;
                        case 3:
                            ResetLijn(Position3Label, Position3Rectangle);
                            break;
                        case 4:
                            ResetLijn(Position4Label, Position4Rectangle);
                            break;
                        case 5:
                            ResetLijn(Position5Label, Position5Rectangle);
                            break;
                        case 6:
                            ResetLijn(Position6Label, Position6Rectangle);
                            break;
                        case 7:
                            ResetLijn(Position7Label, Position7Rectangle);
                            break;
                        case 8:
                            ResetLijn(Position8Label, Position8Rectangle);
                            break;
                        case 9:
                            ResetLijn(Position9Label, Position9Rectangle);
                            break;
                    }
                }
            }

            LijnenVoorraadLabel.Dispatcher?.Invoke(() =>
            {
                LijnenVoorraadLabel.Content = "Lijnen voorraad " + game.waterskibaan.LijnenVoorraad.GetAantalLijnen() + "/15";
            });
        }

        private void UpdateLijn(Lijn lijn, Label label, Rectangle rectangle)
        {
            rectangle.Dispatcher?.Invoke(() =>
            {
                System.Drawing.Color color = lijn.Sporter.KledingKleur;
                rectangle.Fill = new SolidColorBrush(Color.FromArgb(color.A, color.R, color.G, color.B));
            });
            label.Dispatcher?.Invoke(() =>
            {
                string content = "Lijn" + lijn.ID;
                if (lijn.Sporter.HuidigeMove != null)
                {
                    content += "\n" + lijn.Sporter.HuidigeMove;
                }
                label.Content = content;
            });
        }

        private void ResetLijn(Label label, Rectangle rectangle)
        {
            rectangle.Dispatcher?.Invoke(() =>
            {
                rectangle.Fill = new SolidColorBrush(Color.FromArgb(255, 244, 244, 245));
            });
            label.Dispatcher?.Invoke(() => { label.Content = ""; });
        }

        private void UpdateWachtrijen()
        {
            PaintInstructieWachtrij();
            PaintInstructieGroep();
            PaintStartWachtrij();
        }

        private void PaintInstructieWachtrij()
        {
            InstructieWachtrijLabel.Dispatcher?.Invoke(() =>
            {
                InstructieWachtrijLabel.Content = "Instructie wachtrij " + game.wachtrijInstructie.AantalInWachtrij() + "/" + game.wachtrijInstructie.GetLengte();
            });
            Grid grid = InstructieWachtrij;
            grid.Dispatcher?.Invoke(() =>
            { 
                grid.Children.Clear();
                List<Sporter> sporters = game.wachtrijInstructie.GetAlleSporters();
                int nextRow = 0;
                int nextColumn = 0;
                for (int i = 0; i < sporters.Count; i++)
                {
                    Sporter sporter = sporters[i];
                    Rectangle rectangle = new Rectangle();
                    rectangle.Fill = new SolidColorBrush(Color.FromRgb(sporter.KledingKleur.R, sporter.KledingKleur.G, sporter.KledingKleur.B));
                    Grid.SetColumn(rectangle, nextColumn);
                    Grid.SetRow(rectangle, nextRow);
                    grid.Children.Add(rectangle);

                    nextColumn++;
                    if (nextColumn == 17)
                    {
                        nextColumn = 0;
                        nextRow++;
                    }
                }
            });
        }

        private void PaintInstructieGroep()
        {
            InstructieGroepLabel.Dispatcher?.Invoke(() =>
            {
                InstructieGroepLabel.Content = "Instructie groep " + game.instructieGroep.AantalInWachtrij() + "/" + game.instructieGroep.GetLengte();
            });
            Grid grid = InstructieGroep;
            grid.Dispatcher?.Invoke(() =>
            {
                grid.Children.Clear();
                List<Sporter> sporters = game.instructieGroep.GetAlleSporters();
                int nextColumn = 0;
                foreach (Sporter sporter in sporters)
                {
                    Rectangle rectangle = new Rectangle();
                    rectangle.Fill = new SolidColorBrush(Color.FromRgb(sporter.KledingKleur.R, sporter.KledingKleur.G, sporter.KledingKleur.B));
                    Grid.SetColumn(rectangle, nextColumn);
                    Grid.SetRow(rectangle, 0);
                    grid.Children.Add(rectangle);

                    nextColumn++;
                }
            });
        }

        private void PaintStartWachtrij()
        {
            StartWachtrijLabel.Dispatcher?.Invoke(() =>
            {
                StartWachtrijLabel.Content = "Start wachtrij " + game.wachterijStarten.AantalInWachtrij() + "/" + game.wachterijStarten.GetLengte();
            });
            Grid grid = StartWachtrij;
            grid.Dispatcher?.Invoke(() =>
            {
                grid.Children.Clear();
                List<Sporter> sporters = game.wachterijStarten.GetAlleSporters();
                int nextColumn = 0;
                int nextRow = 0;
                for (int i = 0; i < sporters.Count; i++)
                {
                    Sporter sporter = sporters[i];
                    Rectangle rectangle = new Rectangle();
                    rectangle.Fill = new SolidColorBrush(Color.FromRgb(sporter.KledingKleur.R, sporter.KledingKleur.G, sporter.KledingKleur.B));
                    Grid.SetColumn(rectangle, nextColumn);
                    Grid.SetRow(rectangle, nextRow);
                    grid.Children.Add(rectangle);

                    nextColumn++;
                    if (nextColumn == 17)
                    {
                        nextColumn = 0;
                        nextRow++;
                    }
                }
            });
        }

        private void UpdateStats()
        {
            AantalBezoekers.Dispatcher?.Invoke(() =>
            {
                AantalBezoekers.Content = "Aantal bezoekers: " + game.Logger.AantalBezoekers();
            });
            HoogsteScore.Dispatcher?.Invoke(() =>
            {
                HoogsteScore.Content = "Hoogste score: " + game.Logger.HoogsteScore();
            });
            RodeKleding.Dispatcher?.Invoke(() =>
            {
                RodeKleding.Content = "Rode kleding: " + game.Logger.RodeKleding();
            });
            TotaleRondjes.Dispatcher?.Invoke(() =>
            {
                TotaleRondjes.Content = "Totale rondjes: " + game.Logger.TotaalAantalRondjes();
            });

            Grid grid = LichtseKleding;
            grid.Dispatcher?.Invoke(() =>
            {
                grid.Children.Clear();

                int count = 0;
                foreach (Sporter sporter in game.Logger.LichtsteKleding())
                {
                    Rectangle rectangle = new Rectangle();
                    rectangle.Fill = new SolidColorBrush(Color.FromRgb(sporter.KledingKleur.R, sporter.KledingKleur.G, sporter.KledingKleur.B));
                    Grid.SetColumn(rectangle, 0);
                    Grid.SetRow(rectangle, count);
                    grid.Children.Add(rectangle);

                    count++;
                }
            });

            int[] uniekeMoves = game.Logger.UniekeMoves();
            SpringMoves.Dispatcher?.Invoke(() => { SpringMoves.Content = "Spring: " + uniekeMoves[0]; });
            OmdraaienMoves.Dispatcher?.Invoke(() => { OmdraaienMoves.Content = "Omdraaien: " + uniekeMoves[1]; });
            EenHandMoves.Dispatcher?.Invoke(() => { EenHandMoves.Content = "Een hand: " + uniekeMoves[2]; });
            EenBeenMoves.Dispatcher?.Invoke(() => { EenBeenMoves.Content = "Een been: " + uniekeMoves[3]; });

        }
    }
}
