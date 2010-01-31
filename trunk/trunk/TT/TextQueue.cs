using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TTSCs
{
    public class TextQueue
    {
        List<TextSelecter> thingsToSay;
        int intNextJob;
        int sLang;
        public delegate void TextHandler(TextSelecter message);

        // Define an Event based on the above Delegate
        public event TextHandler SayIt;

        public void LaunchThread()
        {
            while (true)
            {
                try
                {
                    SendText();
                }
                catch
                {

                }
                finally
                {
                    System.Threading.Thread.Sleep(100);

                }
            }

        }
        public TextQueue()
        {
            thingsToSay = new List<TextSelecter>();
        }
        public void AddJob(string J,string lang)
        {
            TextSelecter ts = new TextSelecter(J,lang);
            thingsToSay.Add(ts);
            //thingsToSay.Add(" ");
        }
        public void GetNextJob()
        {
            intNextJob++;
        }
        public void SendText()
        {
            if (intNextJob < thingsToSay.Count)
            {
                TextSelecter text = thingsToSay[intNextJob];

                SayIt(text);
            }
        }
    }

}
