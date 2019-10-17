using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;

namespace Waterskibaan
{
    public class Game
    {
        private Timer gameTimer;

        public Waterskibaan waterskibaan { get; set; }
        public WachtrijInstructie wachtrijInstructie { get; set; }
        public InstructieGroep instructieGroep { get; set; }
        public WachterijStarten wachterijStarten { get; set; }

        public delegate void NieuweBezoekerHandler(NieuweBezoekerArgs args);
        public event NieuweBezoekerHandler NieuweBezoeker;

        public delegate void InstructieAfgelopenHandler(InstructieAfgelopenArgs args);
        public event InstructieAfgelopenHandler InstructieAfgelopen;

        public delegate void VerplaatsKabelHandler();
        public event VerplaatsKabelHandler VerplaatsKabel;

        public delegate void LoopUpdateHandler();
        public event LoopUpdateHandler LoopUpdate;

        public void Initialize()
        {
            waterskibaan = new Waterskibaan();
            wachtrijInstructie = new WachtrijInstructie();
            instructieGroep = new InstructieGroep();
            wachterijStarten = new WachterijStarten();

            NieuweBezoeker += wachtrijInstructie.OnNieuweBezoeker;
            InstructieAfgelopen += OnInstructieAfgelopen;
            VerplaatsKabel += waterskibaan.VerplaatsKabel;
            VerplaatsKabel += OnVerplaatsKabel;

            SetTimer();

//            Console.WriteLine("\nPress the Enter key to exit the application...\n");
//            Console.WriteLine("The application started at {0:HH:mm:ss.fff}", DateTime.Now);
//            Console.ReadLine();
//            gameTimer.Stop();
//            gameTimer.Dispose();
//
//            Console.WriteLine("Terminating the application...");
        }

        private void SetTimer()
        {
            gameTimer = new Timer(100);
            // Hook up the Elapsed event for the timer. 
            gameTimer.Elapsed += Loop;
            gameTimer.AutoReset = true;
            gameTimer.Enabled = true;
        }

        private int loopCount;

        private void Loop(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff} on loop {1}", e.SignalTime, loopCount);

            if (loopCount % 3 == 0)
            {
                Console.WriteLine("Nieuwe bezoeker");
                Sporter sporter = new Sporter(MoveCollection.GetWillekeurigeMoves());
                NieuweBezoekerArgs args = new NieuweBezoekerArgs();
                args.Sporter = sporter;

                NieuweBezoeker?.Invoke(args);
            }

            if (loopCount % 20 == 0)
            {
                Console.WriteLine("Instructie afgelopen");
                InstructieAfgelopenArgs args = new InstructieAfgelopenArgs();
                args.Sporters = instructieGroep.SportersVerlatenRij(instructieGroep.GetLengte());
                InstructieAfgelopen?.Invoke(args);
            }

            if (loopCount % 4 == 0)
            {
                Console.WriteLine("Verplaats kabel");
                VerplaatsKabel?.Invoke();
            }
            
            Console.WriteLine(waterskibaan);

            loopCount++;

            LoopUpdate?.Invoke();
        }

        public void OnInstructieAfgelopen(InstructieAfgelopenArgs args)
        {
            // Verplaats sporters van de wachtrij voor instructie (de eerste wachtrij waar ze komen) naar
            // de 'wachtrij' om instructie te krijgen. 
            List<Sporter> sporters = wachtrijInstructie.SportersVerlatenRij(instructieGroep.GetLengte());
            foreach (Sporter sporter in sporters)
            {
                instructieGroep.SporterNeemPlaatsInRij(sporter);
            }

            // Voeg de sporters die net instructie hebben gehad toe aan de wachtrij om de waterskibaan
            // op te gaan.
            foreach (Sporter sporter in args.Sporters)
            {
                wachterijStarten.SporterNeemPlaatsInRij(sporter);
            }
        }

        public void OnVerplaatsKabel()
        {
            if (waterskibaan.Kabel.IsStartPositieLeeg())
            {
                List<Sporter> sporters = wachterijStarten.SportersVerlatenRij(1);
                if (sporters.Count == 1)
                {
                    Sporter sporter = sporters.First();
                    sporter.Skies = new Skies();
                    sporter.Zwemvest = new Zwemvest();
                    waterskibaan.SporterStart(sporter);
                }
            }
        }
    }
}