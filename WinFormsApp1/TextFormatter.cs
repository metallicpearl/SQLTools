using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Text.RegularExpressions;

namespace WinFormsApp1
{
    public class TextFormatter
    {
       

        public string? finaltext;
        public string? processingtext;
        public string? processedtext;
        public List<string> commentscopy;
        public int holdingnumber;
        public string holdingstring;

        

        public static string FormatText(string originalstring)
        {
            
            originalstring = originalstring.ToLower();

            List<string> commentlist = new List<string>();

            string[] lines = originalstring.Split('\n', StringSplitOptions.None);

            TextFormatter tf = new TextFormatter();

            tf.holdingnumber = 0;


            DataTable dt = new DataTable();
            dt.Columns.Add("CommentOnly");
            dt.Columns.Add("TextBeforeComment");
            dt.Columns.Add("FullLine");
            dt.Columns.Add("ModifiedFullLine");
            dt.Columns.Add("HoldingValue");


            if (originalstring.Contains("\n")) 
            {
                string[] values = originalstring.Split("--", StringSplitOptions.None);
                values = values.Where(w => w != values[0]).ToArray();
                Random r = new Random();

                foreach (string value0 in lines)
                {
                    string value = value0.Trim();
                    tf.processingtext = originalstring;

                    if (value.Contains("--"))
                    {
                            
                            int commentindex = value.IndexOf("--");
                            var value2 = value.Substring(commentindex, value.Length-commentindex);
                            int value2index = originalstring.IndexOf(value2);
                            string textbeforecomment = value.Substring(0, commentindex);
                            string randomstring = Path.GetRandomFileName();
                            tf.holdingnumber = r.Next();
                            string fullrandomstring = randomstring + r.Next();
                            dt.Rows.Add(value2, textbeforecomment, value, textbeforecomment+fullrandomstring,fullrandomstring);
                            
                    }

                    foreach (DataRow val in dt.Rows)
                    {
                        string a = val["CommentOnly"].ToString();
                        string b = val["HoldingValue"].ToString();
                        tf.processingtext = tf.processingtext.Replace(a, b);
                    }

                    if (tf.processingtext == null)
                        
                    {
                        tf.processingtext = originalstring;
                    }
                }

        
            }

            if (tf.processingtext == null)

            {
                tf.processingtext = originalstring;
            }


            List<string> comments = new List<string>();

            originalstring = tf.processingtext.Replace("\n", "");
            int num = 0;
            string item = "";
            int num2 = 0;

            List<string> words = new List<string>();
            foreach (string word in originalstring.Split(" ",'\n'))
            {
                if (word.Length > 0)
                {
                    word.Replace('\n', '\0');
                }
                    word.Trim();
                    words.Add(word);  
            }


            char[] wordstoremove = new char[2];
            wordstoremove[0] = '\n';
            wordstoremove[1] = '\0';

            tf.finaltext = String.Join(" ", words);
            tf.finaltext = tf.finaltext.Replace("\n ", "\n");

            List<string> list0 = new List<string>
            {
                "select",
                "where",
                "inner",
                "outer",
                "left",
                "right",
                "full",
                "join",
                "by"
            };

            List<string> list1 = new List<string>
            {
                "from",
                "group",
                "order",
                ","
            };

            List<string> list2 = new List<string>
            {
                "and",
                "or",
                "between"
            };
            List<string> list3 = new List<string>
            {
                "left",
                "right",
                "inner",
                "outer",
                "full",
            };
            List<string> list4 = new List<string>
            {
                "order",
                "group"
            };


            foreach (string list1item in list0)
            {
                tf.finaltext = tf.finaltext.Replace(list1item, Environment.NewLine+Environment.NewLine +list1item + Environment.NewLine);
            }

            foreach (string list1item1 in list1)
            {
                tf.finaltext = tf.finaltext.Replace(list1item1, Environment.NewLine + Environment.NewLine + list1item1 + Environment.NewLine);
            }

            foreach (DataRow val in dt.Rows)
            {
                string a = val["HoldingValue"].ToString();
                string b = val["CommentOnly"].ToString()+Environment.NewLine;
                tf.finaltext = tf.finaltext.Replace(a,b);
                tf.finaltext = tf.finaltext.Replace("\r\n" + b, b);
                tf.finaltext = tf.finaltext.Replace("\n ", "\n") + Environment.NewLine;
            }


            return tf.finaltext;
        }

    }
    
}
