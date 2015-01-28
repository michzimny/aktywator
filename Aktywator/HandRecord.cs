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

        public HandRecord()
        {
            north = new string[4];
            east = new string[4];
            south = new string[4];
            west = new string[4];
        }

        public HandRecord(string pbnString)
        {
            string[] hand = pbnString.Split(' ');
            north = hand[0].Split('.');
            east = hand[1].Split('.');
            south = hand[2].Split('.');
            west = hand[3].Split('.');
        }
    }
}
