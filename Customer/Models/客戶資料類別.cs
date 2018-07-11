using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Customer.Models
{
    public class 客戶資料類別
    {
        [Required(ErrorMessage = "客戶名稱必填")]
        public string 客戶名稱 { get; set; }
        [Required(ErrorMessage = "統一編號必填")]
        public string 統一編號 { get; set; }
        [Required(ErrorMessage = "電話必填")]
        public string 電話 { get; set; }
        [Required(ErrorMessage = "傳真必填")]
        public string 傳真 { get; set; }
        [Required(ErrorMessage = "地址必填")]
        public string 地址 { get; set; }
        [Required(ErrorMessage = "Email必填")]
        public string Email { get; set; }
    }
}