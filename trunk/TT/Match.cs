using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TTSCs
{
    class Match
    {
        public int iMAX_NR_OF_SET;
        public int iSET_NR;
        public int iLEVEL;
        public int iHIT;
        public Match()
        {
            iMAX_NR_OF_SET=10;
            iSET_NR=0;
            iLEVEL=1;
            iHIT = 0;
        }
        public bool Complete()
        {
            if (iMAX_NR_OF_SET < iSET_NR)
            {
                return true;
            }
            return false;
        }
    }
}
