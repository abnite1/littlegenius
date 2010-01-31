using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TTSCs
{
    class GameCentral
    {
        public TextQueue tq;
        private NumberMachine myNumbers;
        private NumberMachine myLetters;
        private int intNr1, intNr2;
        private string sLetter;
        private string Language;
        public enum CalcType { Plus=1, Minus, Times, Div };
        public CalcType theCT;
        public string sCTeng;
        public string sCTswe;
        public delegate void GameCentralEv(string message);
        public event GameCentralEv SetVoice;
        List<string> mvcs;
        private enum GSTAT { GameSelect, GameRunning, GameEnding };
        private enum GAMERUNNING { Multiply, Addition, Abc ,Minus,Config};
        GSTAT pGameStatus;
        GAMERUNNING pGameRunning;
        Match tempM;
        public void SetLanguage(string sLang)
        {
            Language = sLang;

        }
        public GameCentral(string sLang, CalcType pCT)
        {
            Language = sLang;
            theCT = pCT;
            pGameStatus = GSTAT.GameSelect;
            tempM = new Match();


        }
        public void Welcome(){
            tq.AddJob("Hello, Welcome to the Number kruncher!", "eng");
            tq.AddJob("Hej, välkommen till talknäckarn!", "swe");
        }
        private void GenerateQuestionConfig()
        {
            tq.AddJob(" Choose voice: " + sLetter, "eng");
            tq.AddJob(" Välj röst " + sLetter, "swe");
            int i=1;
            foreach (string o in mvcs)
            {
                tq.AddJob(i.ToString() + o, "eng");
                tq.AddJob(i.ToString() + o, "swe");
                i++;
            }
        }

        public void PopCombo(List<string> vcs)
        {
            mvcs = vcs;
        }
        private void GenerateQuestionAbc()
        {
            int iNr = myLetters.GetNextNr1();
            sLetter = System.Convert.ToChar(65 + iNr).ToString();
            tq.AddJob(" Write the letter " + sLetter, "eng");
            tq.AddJob(" Skriv bokstaven " + sLetter, "swe");
        }
        private void GenerateQuestion()
        {
            myNumbers = new NumberMachine(10);
            intNr1 = myNumbers.Nr1;
            intNr2 = myNumbers.Nr2;
            if (intNr1 < intNr2)
            {
                int iTemp = intNr1;
                intNr1 = intNr2;
                intNr2 = iTemp;
            }
            tq.AddJob(" What is  " + intNr1.ToString() + sCTeng + intNr2.ToString() + " ? ", "eng");
            tq.AddJob(" Vad är  " + intNr1.ToString() + sCTswe + intNr2.ToString() + " ? ", "swe");
        }
        private void RepeteQuestion()
        {
            //myNumbers = new NumberMachine(10);
            tq.AddJob(" Vad är " + intNr1.ToString() + sCTswe + intNr2.ToString() + " ? ", "swe");
            tq.AddJob(" What is  " + intNr1.ToString() + sCTeng + intNr2.ToString() + " ? ", "eng");
        }
        private void RepeteQuestionAbc()
        {
            //myNumbers = new NumberMachine(10);
            tq.AddJob(" Skriv " + sLetter + " ? ", "swe");
            tq.AddJob(" Write " + sLetter + " ? ", "eng");
        }
        public void StartGame()
        {
            pGameStatus=GSTAT.GameSelect;

            tq.AddJob("Välj mellan inställningar i,multiplicera press t , plussa press p,m tryck m eller abc press a", "swe");
            tq.AddJob("Choose between configuration c, multiply press t, adding press p, minus press m or abc press a", "eng");

            //GenerateQuestion();

        }

        private void SelectGame(string ans)
        {
            if (GSTAT.GameSelect == pGameStatus)
            {
                switch (ans)
                {
                    case "t":
                        pGameRunning = GAMERUNNING.Multiply;
                        theCT=CalcType.Times;
                        SetString();
                        GenerateQuestion();

                        break;
                    case "p":
                        pGameRunning = GAMERUNNING.Addition;
                        theCT = CalcType.Plus;
                        SetString();
                        GenerateQuestion();
                        break;
                    case "a":
                        pGameRunning = GAMERUNNING.Abc;
                        myLetters = new NumberMachine(25);
                        SetString();
                        GenerateQuestionAbc();
                        break;
                    case "T":
                        pGameRunning = GAMERUNNING.Multiply;
                        theCT = CalcType.Times;
                        SetString();
                        GenerateQuestion();
                        break;
                    case "M":
                        pGameRunning = GAMERUNNING.Minus;
                        theCT = CalcType.Minus;
                        SetString();
                        GenerateQuestion();
                        break;
                    case "m":
                        pGameRunning = GAMERUNNING.Minus;
                        theCT = CalcType.Minus;
                        SetString();
                        GenerateQuestion();
                        break;
                    case "P":
                        pGameRunning = GAMERUNNING.Addition;
                        theCT = CalcType.Plus;
                        SetString();
                        GenerateQuestion();
                        break;
                    case "A":
                        pGameRunning = GAMERUNNING.Abc;
                        myLetters = new NumberMachine(25);
                        SetString();
                        GenerateQuestionAbc();
                        break;
                    case "c":
/*                        pGameRunning = GAMERUNNING.Config;
                        GenerateQuestionAbc();
                        break;*/
                    case "C":
                        pGameRunning = GAMERUNNING.Config;
                        GenerateQuestionConfig();
                        break;

                }
            }
            pGameStatus = GSTAT.GameRunning;
        }
        void SetString()
        {
            switch (theCT)
            {
                case CalcType.Times:
                    sCTeng = " multiplied with ";
                    sCTswe = " multiplicerat med ";
                    break;
                case CalcType.Minus:
                    sCTeng = "Less";
                    sCTswe = "Minus";
                    break;
                case CalcType.Plus:
                    sCTeng = " plus ";
                    sCTswe = " plus ";
                    break;
                case CalcType.Div:
                    sCTeng = "Divided";
                    sCTswe = "Delat med";
                    break;
            }
        }
        private void SetTheVoice(string ans)
        {
            int iAns = System.Convert.ToInt16(ans);

        }
        private void ConfigAnswer(string ans)
        {
            int i= System.Convert.ToInt16(ans);
            string sVoice=mvcs.ElementAt(i);
            SetVoice(sVoice);
            tq.AddJob("Välj mellan inställningar i,multiplicera press t , plussa press p,m tryck m eller abc press a", "swe");
            tq.AddJob("Choose between configuration c, multiply press t, adding press p, minus press m or abc press a", "eng");

        }
        private void CorrectMathAnswer(string ans, int pintCorrect)
        {
            if (System.Convert.ToInt32(ans) == pintCorrect)
            {
                tq.AddJob("Det är rätt! " + intNr1.ToString() + sCTswe + intNr2.ToString() + " är " + ans + ".", "swe");
                tq.AddJob("That is right! " + intNr1.ToString() + sCTeng + intNr2.ToString() + " is " + ans + ".", "eng");
                if (!tempM.Complete())
                {
                    tq.AddJob("Nästa fråga är ", "swe");
                    tq.AddJob("Next question is ", "eng");
                    tempM.iHIT++;

                    GenerateQuestion();
                } else FinishGame();
            }
            else
            {
                tq.AddJob("Tyvär det är fel! ", "swe");
                tq.AddJob("Sorry it is wrong! ", "eng");
                RepeteQuestion();
            }
        }
        public void FinishGame()
        {
            tq.AddJob("Klart! ", "swe");
            tq.AddJob("Du hade " + tempM.iHIT.ToString() + " rätt!", "swe");
            tq.AddJob("av " + tempM.iSET_NR--.ToString()+ " försök.", "swe");
            tq.AddJob("Finished! ", "eng");
            tq.AddJob("You had " + tempM.iHIT.ToString() + " correct answers!", "eng");
            tq.AddJob("from " + tempM.iSET_NR--.ToString() + " trial.", "eng");
            tempM.iLEVEL++;
            tempM.iHIT = 0;
            tempM.iSET_NR = 0;
            tq.AddJob("Level  " + tempM.iLEVEL.ToString() + " Begins.", "eng");
            tq.AddJob("Level  " + tempM.iLEVEL.ToString() + " Startar.", "swe");
            GenerateQuestion();

        }
        public void AnswerGiven(string ans)
        {
            if (GSTAT.GameSelect == pGameStatus)
            {
                SelectGame(ans);
                return;
            }
            int intCorrect = 0;
            tq.AddJob("Ditt svar var " + ans + ".", "swe");
            tq.AddJob("Your answer was " + ans + ".", "eng");

            switch (theCT)
            {
                case CalcType.Times:
                    intCorrect = intNr1 * intNr2;
                    break;
                case CalcType.Plus:
                    intCorrect = intNr1 + intNr2;
                    break;
                case CalcType.Minus:
                    intCorrect = intNr1 - intNr2;
                    break;
                case CalcType.Div:
                    intCorrect = intNr1 / intNr2;
                    break;
            }
            try
            {
            tempM.iSET_NR++;
            switch (pGameRunning)
            {
                case GAMERUNNING.Abc:
                    if (sLetter.ToLower().Equals(ans.ToLower()))
                    {
                        tq.AddJob("Det är rätt! ", "swe");
                        tq.AddJob("That is right! ", "eng");
                        if (tempM.Complete())
                        {
                            FinishGame();
                            return;
                        }
                        tq.AddJob("Nästa fråga är ", "swe");
                        tq.AddJob("Next question is ", "eng");
                        tempM.iHIT++;
                        GenerateQuestionAbc();

                    }
                    else
                    {
                        tq.AddJob("Tyvär det är fel! ", "swe");
                        tq.AddJob("Sorry it is wrong! ", "eng");
                        RepeteQuestionAbc();
                    }
                    break;
                case GAMERUNNING.Multiply:
                    CorrectMathAnswer(ans, intCorrect);
                    break;
                case GAMERUNNING.Addition:
                    CorrectMathAnswer(ans, intCorrect);
                    break;
                case GAMERUNNING.Minus:
                    CorrectMathAnswer(ans, intCorrect);
                    break;
                case GAMERUNNING.Config:
                    ConfigAnswer(ans);
                    break;
            }
            }
            catch {
                tq.AddJob("Konstigt svar - försök igen.", "swe");
                tq.AddJob("Strange answer - try again", "eng");
                RepeteQuestion();
 
            }
        }

    }
}

