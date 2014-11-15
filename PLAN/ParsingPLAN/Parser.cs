using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Newtonsoft.Json;

namespace ParsingPLAN
{
    public class Parser
    {
        private int n;
        public string URL { get; set; }
        public HtmlDocument HtmlDoc { get; set; }
        public HtmlWeb HtmlWww { get; set; }
        public HtmlNode HtmlRoot { get; set; }
        public HtmlNode HtmlTable { get; set; }

        public Parser(string url)
        {
            n = 7;
            URL = url;
            HtmlWww = new HtmlWeb();
            HtmlDoc = new HtmlDocument();
            Encoding iso = Encoding.GetEncoding("iso-8859-2");
            HtmlWww.OverrideEncoding = iso;
            HtmlDoc = HtmlWww.Load(URL);
            HtmlRoot = HtmlDoc.DocumentNode;
        }

        public string Parsing()
        {
            HtmlNodeCollection NodeColl = HtmlDoc.DocumentNode.SelectNodes("//table");
            HtmlNodeCollection[] kol = new HtmlNodeCollection[n];
            Dictionary<string, string>[] dict = new Dictionary<string, string>[n];
            HtmlNode node;
            string temp;
            HtmlTable = NodeColl[2];
            List<string> [] lista = new List<string>[n];
            for (int i = 0; i < n; i++)
            {
                lista[i] = new List<string>();
                kol[i] = new HtmlNodeCollection(HtmlTable);
                dict[i] = new Dictionary<string, string>();
            }
            foreach (var item in HtmlTable.ChildNodes)
            {
                if (item.InnerHtml != "\r\n")
                {
                    node = item.FirstChild;
                    for (int i = 0; i < n; i++)
                    {
                        node = node.NextSibling;
                        temp = "";
                        foreach (var item2 in node.ChildNodes)
                        {
                            temp += item2.InnerText;
                        }
                        lista[i].Add(temp);
                        node = node.NextSibling;

                    }
                }
                
            }
            
            for (int i = 1; i < n; i++)
			{
			    for (int j = 0; j < lista[0].Count; j++)
			    {
			        dict[i].Add(lista[0][j], lista[i][j]);
			    }
			}

            string json = JsonConvert.SerializeObject(dict);
            return json;
        }

    }
}
