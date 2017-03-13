using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Aktywator
{
    class PBN
    {
        public HandRecord[] handRecords;
        public DDTable[] ddTables;
        protected int lowBoard;
        protected int highBoard;
        private int _count;
        public int count
        {
            get { return _count; }
        }
        private String _title;
        public String title
        {
            get { return _title; }
        }

        public PBN(string filename, int lowBoard, int highBoard)
        {
            this.handRecords = new HandRecord[highBoard + 1];
            this.ddTables = new DDTable[highBoard + 1];

            this.lowBoard = lowBoard;
            this.highBoard = highBoard;

            this._count = 0;
            PBNFile pbn = new PBNFile(filename);
            foreach (PBNBoard board in pbn.Boards)
            {
                int boardNo = Int32.Parse(board.GetNumber());
                if (lowBoard <= boardNo && boardNo <= highBoard)
                {
                    this.handRecords[boardNo] = new HandRecord(board.GetLayout());
                    this.ddTables[boardNo] = new DDTable(board);
                    this._count++;
                }
            }
            if (pbn.Boards.Count > 0 && pbn.Boards[0].HasField("Event"))
            {
                this._title = pbn.Boards[0].GetField("Event");
            }
        }

    }
}
