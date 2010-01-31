using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numeric;

namespace TTSCs
{
    public class NumberMachine
    {
        public int _Nr1;
        public int _Nr2;
        Random rand;
        public int iScoop;
        byte[] bytes1 = new byte[100];
        public int Nr1
        {
            get
            {
                return _Nr1;
            }
            set
            {
                _Nr1 = value;
            }
        }
        public int Nr2
        {
            get
            {
                return _Nr2;
            }
            set
            {
                _Nr2 = value;
            }
        }
        public int GetNextNr1()
        {
            _Nr1 = rand.Next(iScoop);
            return _Nr1;
        }
        public int GetNextNr2()
        {
            _Nr2 = rand.Next(iScoop);
            return _Nr2;
        }

        public NumberMachine(int pScoop)
        {
            rand = new Random();
            iScoop = pScoop;
            // Generate and display 5 random byte (integer) values.
            byte[] bytes = new byte[4];


            _Nr1 = rand.Next(iScoop);
            _Nr2 = rand.Next(iScoop);
        }
    }
}
