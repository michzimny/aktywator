using System;
using System.Collections.Generic;
using System.Text;

namespace Aktywator
{
    class HandRecord
    {
        public string[] north;
        public string[] east;
        public string[] south;
        public string[] west;
        public int[] hpcs;

        public HandRecord()
        {
            north = new string[4];
            east = new string[4];
            south = new string[4];
            west = new string[4];
        }

        private int _hpcFromHand(string hand)
        {
            int hpc = 0;
            foreach (char c in hand)
            {
                if (c == 'a' || c == 'A')
                {
                    hpc += 4;
                }
                if (c == 'k' || c == 'K')
                {
                    hpc += 3;
                }
                if (c == 'q' || c == 'Q')
                {
                    hpc += 2;
                }
                if (c == 'j' || c == 'J')
                {
                    hpc += 1;
                }
            }
            return hpc;
        }

        public HandRecord(string pbnString)
        {
            string[] hand = pbnString.Split(' ');
            north = hand[0].Split('.');
            east = hand[1].Split('.');
            south = hand[2].Split('.');
            west = hand[3].Split('.');
            hpcs = new int[4];
            for (int i = 0; i < 4; i++)
            {
                hpcs[i] = this._hpcFromHand(hand[i]);
            }
        }
    }
}
