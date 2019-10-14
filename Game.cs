using System;
using System.Timers;

namespace Waterskibaan
{
    public class Game
    {
        private Timer gameTimer;

        private Waterskibaan waterskibaan;
        private WachtrijInstructie wachtrijInstructie;
        private InstructieGroep instructieGroep;
        private WachterijStarten wachterijStarten;

        public void Initialize()
        {
            waterskibaan = new Waterskibaan();
            wachtrijInstructie = new WachtrijInstructie();
            instructieGroep = new InstructieGroep();
            wachterijStarten = new WachterijStarten();
            
            SetTimer();

            Console.WriteLine("\nPress the Enter key to exit the application...\n");
            Console.WriteLine("The application started at {0:HH:mm:ss.fff}", DateTime.Now);
            Console.ReadLine();
            gameTimer.Stop();
            gameTimer.Dispose();

            Console.WriteLine("Terminating the application...");

        }

        private void SetTimer()
        {
            gameTimer = new Timer(1000);
            // Hook up the Elapsed event for the timer. 
            gameTimer.Elapsed += Loop;
            gameTimer.AutoReset = true;
            gameTimer.Enabled = true;
        }

        private void Loop(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}", e.SignalTime);
            Sporter sporter = new Sporter(MoveCollection.GetWillekeurigeMoves());
            sporter.Skies = new Skies();
            sporter.Zwemvest = new Zwemvest();
            waterskibaan.SporterStart(sporter);
            Console.WriteLine(waterskibaan);
            waterskibaan.VerplaatsKabel();
            Console.WriteLine(waterskibaan);
        }
    }
}