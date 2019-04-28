using HtmlAgilityPack;
using lottoForm.Interfaces;
using lottoForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lottoForm.CrawlerDrivers
{
    /*
     * domain = "https://www.pilio.idv.tw/ltobig/list.asp"
     */
    public class PilioDriver : ILottoCralwer
    {
        private string baseUrl = "https://www.pilio.idv.tw/ltobig/list.asp";
        private List<LottoModel> _lottos = new List<LottoModel>();
        public void ExportCSV()
        {
            // _lottos
            throw new NotImplementedException();
        }

        public List<LottoModel> GetAllData()
        {
            int pageCount = GetPageCount();
            for(int i = 1; i < pageCount; i++)
            {
                GetData(i);
                Thread.Sleep(10);
            }
            return _lottos;
        }

        private void GetData(int index)
        {
            List<LottoModel> lottos = new List<LottoModel>();
            var web = new HtmlWeb();
            var docs = web.Load(baseUrl + "?indexpage=" + index + "&orderby=new");

            var query = docs.QuerySelectorAll(".auto-style1>tr").ToList();
            var ssss = query.Where(x => x.Name == "tr").Skip(1);
            foreach (var result in ssss)
            {
                var data = result.QuerySelectorAll("td");
                string rawDate = data[0].InnerText.Split('(')[0];

                _lottos.Add(new LottoModel()
                {
                    Date = rawDate.Substring(0, 4) + "/" + rawDate.Substring(4),
                    Content = data[1].InnerText.Trim().Replace("&nbsp;", ""),
                    Special = data[2].InnerText.Trim().Replace("&nbsp;", "")
                });
            }
        }

        private int GetPageCount()
        {
            var web = new HtmlWeb();
            var docs = web.Load(baseUrl);

            var str = docs.QuerySelectorAll("a")[31].Attributes[1].Value.Replace("list.asp?indexpage=", "").Replace("&orderby=new", "");

            return Convert.ToInt32(str);
        }
    }
}
