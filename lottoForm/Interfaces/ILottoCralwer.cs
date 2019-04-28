using lottoForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lottoForm.Interfaces
{
    /// <summary>
    /// 定義爬蟲所需要做的事
    /// </summary>
    public interface ILottoCralwer
    {
        /// <summary>
        /// 取得所有資料
        /// </summary>
        /// <returns></returns>
        List<LottoModel> GetAllData();
        /// <summary>
        /// 匯出CSV檔
        /// </summary>
        void ExportCSV();
    }
}
