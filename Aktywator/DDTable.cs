using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace Aktywator
{
    class DDTableInvalidException : FieldNotFoundException
    {
        public DDTableInvalidException() : base() { }
        public DDTableInvalidException(String msg) : base(msg) { }
    }

    class DDTable
    {
        public static char[] DENOMINATIONS = { 'C', 'D', 'H', 'S', 'N' };
        public static char[] PLAYERS = { 'N', 'E', 'S', 'W' };

        private PBNBoard board;

        private int[,] getEmptyTable()
        {
            int[,] result = new int[4, 5];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    result[i, j] = -1;
                }
            }
            return result;
        }

        private int[,] validateTable(int[,] table)
        {
            foreach (int t in table)
            {
                if (t > 13 || t < 0)
                {
                    throw new DDTableInvalidException("Invalid number of tricks: " + t.ToString());
                }
            }
            return table;
        }

        public DDTable(PBNBoard board)
        {
            this.board = board;
        }

        public int[,] GetJFRTable()
        {
            int[,] result = this.getEmptyTable();
            String ability = this.board.GetAbility();
            MatchCollection abilities = this.board.ValidateAbility(ability);
            foreach (Match playerAbility in abilities)
            {
                char player = playerAbility.Groups[1].Value[0];
                int playerID = Array.IndexOf(PLAYERS, player);
                int denomID = 4;
                foreach (char tricks in playerAbility.Groups[2].Value.ToCharArray())
                {
                    result[playerID, denomID] = (tricks > '9') ? (tricks - 'A' + 10) : (tricks - '0');
                    denomID--;
                }
            }
            return this.validateTable(result);
        }

        public int[,] GetPBNTable()
        {
            List<String> table = this.board.GetOptimumResultTable();
            List<Match> parsedTable = this.board.ValidateOptimumResultTable(table);
            int[,] result = this.getEmptyTable();
            foreach (Match lineMatch in parsedTable)
            {
                char player = lineMatch.Groups[1].Value[0];
                char denom = lineMatch.Groups[2].Value[0];
                int tricks = Int16.Parse(lineMatch.Groups[3].Value);
                int playerID = Array.IndexOf(PLAYERS, player);
                int denomID = Array.IndexOf(DENOMINATIONS, denom);
                result[playerID, denomID] = tricks;
            }
            return this.validateTable(result);
        }

        public int[,] GetDDTable()
        {
            try
            {
                return this.GetJFRTable();
            }
            catch (FieldNotFoundException)
            {
                try
                {
                    return this.GetPBNTable();
                }
                catch (FieldNotFoundException)
                {
                    return null;
                }
            }
        }
    }
}
