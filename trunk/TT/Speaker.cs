using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpeechLib;


namespace TTSCs
{
    class Speaker
    {
        public TextQueue tq;
        private SpeechLib.SpVoice myV;
        private string Language;
        public List<string> arrLst = new List<string>();
        public Speaker(string sLang)
        {
            Language = sLang;
            myV = new SpeechLib.SpVoice();
            SetLangague(Language);
            SpeechLib.ISpeechObjectTokens arrVoices = myV.GetVoices("","");
            foreach (SpObjectToken t in arrVoices)
            {
                string temp;
                //System.Console.WriteLine(t.GetAttribute("Name"));
                temp = t.GetAttribute("Name");
                arrLst.Add(temp);
                
            }
            
        }
        public void SetVoice(string v)
        {

            //myV.Voice = myV.GetVoices("name=Erik22k", "").Item(0);
            try
            {

                myV = new SpeechLib.SpVoice();
                //myV.Voice = myV.GetVoices("name=" + v, "").Item(0);
                myV.Voice = myV.GetVoices("", "").Item(0);
            }
            catch
            {
                //System.Console.WriteLine("Failed to set the voice!");
            }
            finally
            {
            }

            }
        public void SetLangague(string strL)
        {

            switch (strL)
            {
             

                case "eng":
                    //myV.Voice = myV.GetVoices("name=Microsoft Mary", "").Item(0);
                    myV.Voice = myV.GetVoices("", "").Item(0);
                    break;
                case "swe":
                        myV.Voice = myV.GetVoices("name=Erik22k", "").Item(0);
                        break;
                default:
                        myV.Voice = myV.GetVoices("name=Microsoft Mike", "").Item(0);
                        break;
            }

        }
        public void Speak(TextSelecter text)
        {
            
            try
            {
                if (text.sText.StartsWith("cmd:setlang:")) {
                    if (text.sText.EndsWith("swe")) {
                        SetLangague("swe");
                    }
                    if (text.sText.EndsWith("eng"))
                    {
                        SetLangague("eng");
                    }
                    tq.GetNextJob();
                    return;
                }
                //SpeechLib.SpVoice myV = new SpeechLib.SpVoice();
                if (text.sLang.Equals(Language))
                {
                    myV.Speak(text.sText, SpeechVoiceSpeakFlags.SVSFlagsAsync);
                    System.Console.WriteLine(text.sText);
                }
                tq.GetNextJob();

            }
            finally 
            {
                System.Console.Write(".");
            }
            
        }
/*                    Dim oVoice As New SpeechLib.SpVoice
        Dim cpFileStream As New SpeechLib.SpFileStream
         
        oVoice.Voice = oVoice.GetVoices.Item(cmbVoices.SelectedIndex)
        oVoice.Volume = trVolume.Value
        oVoice.Speak(txtSpeach.Text, SpeechLib.SpeechVoiceSpeakFlags.SVSFDefault)
*/
        
    }
}
