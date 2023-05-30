using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Text.RegularExpressions;
using PoorMansTSqlFormatterLib.Formatters;

namespace WinFormsApp1
{
    public class SqlPrettifyCustom
{
    public static string Pretty(string q)
    {
        q += " ";
        int num = 0;
        string item = "";
        int num2 = 0;
        List<string> list = new List<string>
            {
                "select",
                "from",
                "where",
                "inner",
                "outer",
                "left",
                "right",
                "full",
                "join",
                "group",
                ";",
                "set nocount on",
                ",''",
                ", ''"
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
                "full"
            };
        List<string> list4 = new List<string>
            {
                "order",
                "group"
            };
        string text = "";
        string text2 = "";
        string text3 = "";
        for (int i = 0; i < q.Length; i++)
        {
            char c = q[i];
            text3 += c;
            if (c == '\'' && q[i - 1] != '\\')
            {
                num2++;
                num2 %= 2;
            }

            if (num2 == 0 && c == ',')
            {
                text3 += "";
            }
        }

        q = text3;
        for (int j = 0; j < q.Length; j++)
        {
            char c2 = q[j];
            if (c2 != ' ' && c2 != '\n' && c2 != '\r' && c2 != '\t')
            {
                text2 += c2;
                    //if (c2 == '(')
                    //{
                    //    num--;
                    //}

                    //if (c2 == ')')
                    //{
                    //    num++;
                    //}
                }
            else
            {
                if (!(text2 != ""))
                {
                    continue;
                }

                if (!list.Contains(text2.Trim().ToLower()))
                {
                    text = (list2.Contains(text2.Trim().ToLower()) ? (text + "\n" + SpaceAdder((num + 1) * 4) + text2 + " ") : ((text2[^1] != ',') ? (text + text2 + " ") : (text + text2 + "\n" + SpaceAdder((num + 1) * 4))));
                }
                else if (text2.Trim().ToLower() == "join")
                {
                    if (list3.Contains(item))
                    {
                        text = text.Substring(0, text.Length - 1 - (num + 1) * 4) + " ";
                        text = text + " " + text2 + "\n" + SpaceAdder((num + 1) * 4);
                    }
                    else
                    {
                        text = text + "\n" + SpaceAdder(num * 4) + text2 + "\n" + SpaceAdder((num + 1) * 4);
                    }
                }
                else if (text2.Trim().ToLower() == "by")
                {
                    if (list4.Contains(item))
                    {
                        text = text.Substring(0, text.Length - 1 - (num + 1) * 4) + " ";
                        text = text + " " + text2 + "\n" + SpaceAdder((num + 1) * 4);
                    }
                    else
                    {
                        text = text + text2 + " \n" + SpaceAdder((num + 1) * 4);
                    }
                }
                else
                {
                    text = text + "\n" + SpaceAdder(num * 4) + text2 + "\n" + SpaceAdder((num + 1) * 4);
                }

                item = text2.ToLower();
                text2 = "";
            }
        }

        if (text[0] == '\n')
        {
            return text[1..];
        }

        return text;
    }

    private static string SpaceAdder(int spaces)
    {
        string text = "";
        while (spaces > 0)
        {
            text += " ";
            spaces--;
        }

        return text;
    }
}
}