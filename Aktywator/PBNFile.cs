using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Aktywator
{
    class PBNFile
    {
        public List<PBNBoard> Boards;

        private String filename;

        public PBNFile(String filename)
        {
            this.filename = filename;
            this.Boards = new List<PBNBoard>();
            String[] fileContents = File.ReadAllLines(this.filename);
            List<String> contents = new List<String>();
            foreach (String line in fileContents) {
                contents.Add(line.Trim());
            }
            List<String> lines = new List<String>();
            foreach (String line in contents)
            {
                if (line.Length == 0)
                {
                    if (lines.Count > 0)
                    {
                        this.Boards.Add(new PBNBoard(lines));
                        lines = new List<String>();
                    }
                }
                else
                {
                    lines.Add(line);
                }
            }
            if (lines.Count > 0)
            {
                this.Boards.Add(new PBNBoard(lines));
            }
        }

    }
}
