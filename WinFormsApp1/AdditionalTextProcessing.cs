using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Text.RegularExpressions;

namespace WinFormsApp1
{
    public class AddionalTextProcessing
    {
        public string? finaltext;
        public string? processingtext;
        public string? processedtext;
        public List<string> commentscopy;
        public int holdingnumber;
        public string holdingstring;

        public DataTable dtp;

        public DataTable GatherComments(string p)
        {

            AddionalTextProcessing addionalTextProcessing = new AddionalTextProcessing();

            string originalstring = p + '\n';

            originalstring = originalstring.ToLower();

            List<string> commentlist = new List<string>();

            string[] lines = originalstring.Split('\n', StringSplitOptions.None);

            addionalTextProcessing.holdingnumber = 0;

            DataTable dt = new DataTable();
            dt.Columns.Add("CommentOnly");
            dt.Columns.Add("FirstCharacter");
            dt.Columns.Add("LastCharacter");
            dt.Columns.Add("FullLine");
            dt.Columns.Add("ModifiedFullLine");
            dt.Columns.Add("HoldingValue");
            dt.Columns.Add("Beautified");


            if (originalstring.Contains("\n"))
            {
                string[] values = originalstring.Split("--", StringSplitOptions.None);
                values = values.Where(w => w != values[0]).ToArray();
                Random r = new Random();

                addionalTextProcessing.processingtext = originalstring;

                foreach (string value in lines)
                {

                    if (!value.Contains("--"))
                    {

                        continue;

                    }

                    if (value.Contains("--"))
                    {

                        int linelength = value.Length;
                        int commentindex = value.IndexOf("--");
                        var value2 = value.Substring(commentindex, value.Length - commentindex).ToLower();
                        int value2index = originalstring.IndexOf(value2);
                        string firstcharacter = value.Substring(0, 1);
                        string lastcharacter = StringReverse.reverse(value).Substring(0, 1);

                        string randomstring = Path.GetRandomFileName();
                        addionalTextProcessing.holdingnumber = r.Next();
                        string fullrandomstring = randomstring + r.Next();
                        string beautified = "\n    " + value2;
                        if (firstcharacter.Length > 0)
                        {

                            if (firstcharacter.Length > 0)
                            {
                                string characterbefore = firstcharacter.Substring(firstcharacter.Length - 1, 1);
                                dt.Rows.Add(" " + value2, firstcharacter, lastcharacter, value, firstcharacter + fullrandomstring, fullrandomstring, beautified);

                            }
                            if (firstcharacter.Length == 0)
                            {
                                dt.Rows.Add('\n' + value2, firstcharacter, lastcharacter, value, firstcharacter + fullrandomstring, fullrandomstring, beautified);
                            }
                        }

                    }

                }
            }

            
            

            dt.AcceptChanges();
            return dt.Copy();
 
        }


        public string ReturnComments(string p)
        {

            foreach (DataRow val in dtp.Rows)
            {

                if (!string.IsNullOrEmpty((string?)val["CommentOnly"]))
                {
                    string a = val["CommentOnly"].ToString().ToLower();
                    string b = val["HoldingValue"].ToString();
                    processingtext = processingtext.ToLower().Replace(a, b);

                }
            }

            if (processingtext == null)

            {
                processingtext = p;
            }
        

            return processingtext;
        }
        
    }
}
