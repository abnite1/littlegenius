using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpeechLib;
using System.Threading;

namespace TTSCs
{
    class Program
    {
        static Thread thrTextQueue;
        static Thread thrKeyListener;
        static CrunchKeyEvents cke;
        static string sLangauge;

        public static void KillApp()
        {
            thrTextQueue.Abort();
            cke.Close();
        }

        static void Main(string[] args)
        {

          /*  Random rand = new Random();
            //iScoop = pScoop;
            // Generate and display 5 random byte (integer) values.
            byte[] bytes = new byte[4];
            int _Nr1; 
            for (int k = 1; k < 300; k++)
            {
                _Nr1 = rand.Next(100);
                System.Console.Write(" " + _Nr1.ToString());
            }
            string sLetter;
            for (int i = 1; i < 300; i++)
            {
                sLetter = System.Convert.ToChar( i).ToString();
                System.Console.WriteLine(sLetter + " " + i.ToString());
            }
            */
            
            System.Console.SetWindowSize(1, 1);
            //System.Console.WriteLine("Enter Main:");
            sLangauge = "eng";
            
            cke = new CrunchKeyEvents();
            GameCentral gc = new GameCentral(sLangauge, GameCentral.CalcType.Plus);
            TextQueue program_tq = new TextQueue();
            Speaker mrspeak = new Speaker(sLangauge);
            mrspeak.tq = program_tq;
            program_tq.SayIt += new TextQueue.TextHandler(mrspeak.Speak);
            program_tq.SayIt += new TextQueue.TextHandler(cke.PutToDisplay);
            gc.SetVoice += new GameCentral.GameCentralEv(mrspeak.SetVoice);

            thrTextQueue = new Thread(new ThreadStart(program_tq.LaunchThread));
            thrTextQueue.Start();



            gc.tq = program_tq;
            gc.PopCombo(mrspeak.arrLst);
            gc.Welcome();
            gc.StartGame();
            cke.theTQ = program_tq;
            cke.theAnswer += new CrunchKeyEvents.AnswerGiven(gc.AnswerGiven);
            cke.Show();
            cke.TopMost = true;
            cke.Opacity = 100;
            cke.Language = sLangauge;
            Application.Run(cke);
            
        }
    }
}
