    using System;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    namespace REG_MARK_LIB
    {
        public class Class1
        {
            private static Regex ChekMark = new Regex(@"^[ABEKMHPOTCYX]\d{3}[ABEKMHPOTCYX]{2}(\d{2,3})$");
            private static string[] regions = new string[]
            {
"01", "02", "102", "03", "04", "05", "06", "07", "08", "09", "10", "11",
"12", "13", "113", "14", "15", "16", "116", "17", "18", "19", "20", "95",
"21", "121", "22", "23", "93", "123", "24", "84", "88", "124", "25", "125",
"26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "136", "37",
"38", "85", "138", "39", "91", "40", "41", "82", "42", "142", "43", "44", "45",
"46", "47", "48", "49", "50", "90", "150", "190", "51", "52", "152", "53", "54",
"154", "55", "56", "57", "58", "59", "81", "159", "60", "61", "161", "62", "63",
"163", "64", "164", "65", "66", "96", "67", "68", "69", "169", "70", "71", "72",
"73", "173", "74", "174", "75", "80", "76", "77", "97", "99", "177", "197", "199",
"78", "98", "178", "79", "83", "84", "85", "86", "87", "88", "89", "94"
            };
            public static bool CheckMark(string mark)
            {
                Match match = ChekMark.Match(mark);
                if (match.Success)
                {
                    return regions.Contains(match.Groups[1].Value);
                }
                else return match.Success;
            }

            public static string GetNextMarkAfter(string mark)
            {
                Match match = ChekMark.Match(mark);
                if (match.Success)
                {
                    if (mark.Contains("999"))
                    {
                        return GetNewSeriesMark(mark);
                    }
                    else
                    {
                        StringBuilder s = new StringBuilder(" ");
                        s[0] = mark[1];
                        s[1] = mark[2];
                        s[2] = mark[3];
                        int markAfter = Convert.ToInt32(s.ToString());
                        StringBuilder newMark = new StringBuilder(mark);
                        markAfter++;
                        newMark[1] = markAfter.ToString()[0];
                        newMark[2] = markAfter.ToString()[1];
                        newMark[3] = markAfter.ToString()[2];
                        return newMark.ToString();
                    }
                }
                return "Номер задан в неверном формате";
            }
            public static string GetNewSeriesMark(string mark)
            {
                StringBuilder newMark = new StringBuilder(mark);

                newMark[1] = '0';
                newMark[2] = '0';
                newMark[3] = '1';
                Match match;
                do
                {
                    if (mark[5] != 'X')
                    {
                        newMark[5] = (char)(newMark[5] + 1);
                    }
                    else if (mark[4] != 'X')
                    {
                        newMark[4] = (char)(newMark[5] + 1);
                    }
                    else if (mark[0] != 'X')
                    {
                        newMark[0] = (char)(newMark[5] + 1);
                    }
                    match = ChekMark.Match(newMark.ToString());

                } while (!match.Success);
                return newMark.ToString();
            }
            public static string GetNextMarkAfterInRange(string prevMark, string rangeStart, string rangeEnd)
            {
                if (rangeStart[0] == rangeEnd[0])
                {
                    if (rangeStart[4] >= rangeEnd[4])
                    {
                        if (rangeStart[5] >= rangeEnd[5])
                        {
                            return "out of stock";
                        }
                    }
                }
                else if (rangeStart[0] > rangeEnd[0])
                {
                    return "out of stock";
                }
                Match match = ChekMark.Match(prevMark);
                if (match.Success)
                {
                    if (prevMark.Contains("999"))
                    {
                        return GetNewSeriesMark(prevMark);
                    }
                    else
                    {
                        int markAfter = Convert.ToInt32((prevMark[1] + prevMark[2] + prevMark[3]));
                        StringBuilder newMark = new StringBuilder(prevMark);
                        markAfter++;
                        newMark[1] = markAfter.ToString()[0];
                        newMark[2] = markAfter.ToString()[1];
                        newMark[3] = markAfter.ToString()[2];
                        return newMark.ToString();
                    }
                }
                return "Номер задан в неверном формате";
            }
            public static int GetCombinationsCountInRange(string mark1, string mark2)
            {
                return 1;
            }
        }
    }
