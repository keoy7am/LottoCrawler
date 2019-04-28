using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lottoForm.Models
{
    public class LottoModel
    {
        /// <summary>
        /// 日期
        /// </summary>
        public string Date { get; set; }
        /// <summary>
        /// 非特別號的數字
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 特別號
        /// </summary>
        public string Special { get; set; }
        public override string ToString()
        {
            return $"{Date}{Content}{Special}";
        }
    }
}
