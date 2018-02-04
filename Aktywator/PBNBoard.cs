using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Aktywator
{

    class PBNField
    {
        public String Key;
        public String Value;
        public String RawField;

        public PBNField() { }

        public PBNField(String key, String value)
        {
            this.Key = key;
            this.Value = value;
            this.RawField = String.Format("[{0} \"{1}\"]", this.Key, this.Value);
        }

        public PBNField(String rawData)
        {
            this.RawField = rawData;
        }
    }

    class FieldNotFoundException : Exception
    {
        public FieldNotFoundException() : base() { }
        public FieldNotFoundException(String msg) : base(msg) { }
    }

    class PBNBoard
    {
        public List<PBNField> Fields;

        private bool? hasOptimumResultTable = null;
        private bool? hasAbility = null;

        private static Regex linePattern = new Regex(@"\[(.*) ""(.*)""\]");
        private static Regex abilityPattern = new Regex(@"\b([NESW]):([0-9A-D]{5})\b");
        private static Regex optimumResultTablePattern = new Regex(@"^([NESW])\s+([CDHSN])T?\s+(\d+)$");

        public PBNBoard(List<string> lines)
        {
            this.Fields = new List<PBNField>();
            foreach (String line in lines)
            {
                PBNField field = new PBNField();
                field.RawField = line;
                Match lineParse = PBNBoard.linePattern.Match(line);
                if (lineParse.Success)
                {
                    field.Key = lineParse.Groups[1].Value;
                    field.Value = lineParse.Groups[2].Value;
                }
                this.Fields.Add(field);
            }
        }

        public bool HasField(String key)
        {
            foreach (PBNField field in this.Fields)
            {
                if (key.Equals(field.Key))
                {
                    return true;
                }
            }
            return false;
        }

        public String GetField(String key)
        {
            foreach (PBNField field in this.Fields)
            {
                if (key.Equals(field.Key))
                {
                    return field.Value;
                }
            }
            throw new FieldNotFoundException(key + " field not found");
        }

        public String GetLayout()
        {
            string[] dealParts = this.GetField("Deal").Split(':');
            string layout = dealParts[dealParts.Length - 1];
            if (dealParts.Length > 1)
            {
                string[] layoutParts = layout.Split(' ');
                string[] rotatedLayout = { "", "", "", "" };
                char dealer = dealParts[0][0];
                int rotation = Array.IndexOf(DDTable.PLAYERS, dealer);
                for (int i = 0; i < rotatedLayout.Length; i++)
                {
                    rotatedLayout[(i + rotation) % rotatedLayout.Length] = layoutParts[i];
                }
                layout = String.Join(" ", rotatedLayout);
            }
            return layout;
        }

        public String GetNumber()
        {
            return this.GetField("Board");
        }

        public String GetVulnerable()
        {
            return this.GetField("Vulnerable");
        }

        public String GetDealer()
        {
            return this.GetField("Dealer");
        }

        public MatchCollection ValidateAbility(String ability)
        {
            MatchCollection matches = PBNBoard.abilityPattern.Matches(ability);
            if (matches.Count != 4)
            {
                this.hasAbility = false;
                throw new DDTableInvalidException("Invalid Ability line: " + ability);
            }
            List<String> players = new List<String>();
            foreach (Match match in matches)
            {
                if (players.Contains(match.Groups[1].Value))
                {
                    this.hasAbility = false;
                    throw new DDTableInvalidException("Duplicate entry in Ability: " + match.Groups[0].Value);
                }
                else
                {
                    players.Add(match.Groups[1].Value);
                }
            }
            this.hasAbility = true;
            return matches;
        }

        public String GetAbility()
        {
            return this.GetField("Ability");
        }

        public String GetOptimumResult()
        {
            return this.GetField("OptimumResult");
        }

        public List<Match> ValidateOptimumResultTable(List<String> table)
        {
            List<Match> matches = new List<Match>();
            List<String> duplicates = new List<String>();
            foreach (String line in table)
            {
                Match match = PBNBoard.optimumResultTablePattern.Match(line);
                if (!match.Success)
                {
                    this.hasOptimumResultTable = false;
                    throw new DDTableInvalidException("Invalid OptimumResultTable line: " + line);
                }
                String position = match.Groups[1].Value + " - " + match.Groups[2].Value;
                if (duplicates.Contains(position))
                {
                    this.hasOptimumResultTable = false;
                    throw new DDTableInvalidException("Duplicate OptimumResultTable line: " + line);
                }
                else
                {
                    duplicates.Add(position);
                }
                matches.Add(match);
            }
            this.hasOptimumResultTable = true;
            return matches;
        }

        public List<String> GetOptimumResultTable()
        {
            bool fieldFound = false;
            List<String> result = new List<String>();
            foreach (PBNField field in this.Fields)
            {
                if ("OptimumResultTable".Equals(field.Key))
                {
                    fieldFound = true;
                }
                else
                {
                    if (fieldFound)
                    {
                        if (field.Key == null)
                        {
                            result.Add(field.RawField);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            if (!fieldFound)
            {
                this.hasOptimumResultTable = false;
                throw new FieldNotFoundException("OptimumResultTable field not found");
            }
            return result;
        }

    }
}
