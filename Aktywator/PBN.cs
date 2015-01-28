using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Aktywator
{
    class PBN
    {
        public HandRecord[] handRecords;
        protected int lowBoard;
        protected int highBoard;
        private int _count;
        public int count
        {
            get { return _count; }
        }

        public PBN(string filename, int lowBoard, int highBoard)
        {
            this.handRecords = new HandRecord[highBoard + 1];

            StreamReader f = new StreamReader(new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read));
            try
            {
                int board = lowBoard;
                bool canBeRead = false;
                _count = 0;
                while (!f.EndOfStream && (board <= highBoard))
                {
                    string line = f.ReadLine();
                    if (line.Trim() == "[Board \"" + board + "\"]")
                        canBeRead = true;
                    else if (canBeRead && (line.Substring(0, 6) == "[Deal "))
                    {
                        line = line.Substring(line.IndexOf(':') + 1);
                        line = line.Substring(0, line.IndexOf('"'));
                        handRecords[board] = new HandRecord(line);
                        canBeRead = false;
                        _count++;
                        board++;
                    }
                }
            }
            finally
            {
                f.Close();
            }
        }

    }
}
