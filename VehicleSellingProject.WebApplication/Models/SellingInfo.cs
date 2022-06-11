using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleSellingProject.WebApplication.Models
{
    public class SellingInfo
    {
        public int Id { get; set; }
        [DisplayName("نام خودرو")]
        [Required(ErrorMessage = "لطفاً {0} را وارد کنید")]
        public int VehicleId { get; set; }
        [DisplayName("آدرس شعبه")]
        [Required(ErrorMessage = "لطفاً {0} را وارد کنید")]
        public byte BranchId { get; set; }
        [DisplayName("مشخصات خریدار")]
        [Required(ErrorMessage = "لطفاً {0} را وارد کنید")]
        public string BuyerName { get; set; }
        [DisplayName("تلفن خریدار")]
        [Required(ErrorMessage = "لطفاً {0} را وارد کنید")]
        public string BuyerTel { get; set; }

        
        public virtual Vehicle Vehicle { get; set; }
        public virtual SellingBranch SellingBranch { get; set; }
    }
}
