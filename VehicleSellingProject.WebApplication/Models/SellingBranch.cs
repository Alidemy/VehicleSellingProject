using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleSellingProject.WebApplication.Models
{
    public class SellingBranch
    {
        [Required(ErrorMessage = "لطفاً {0} را وارد کنید")]
        public byte Id { get; set; }
        [DisplayName("کد شعبه")]
        [Required(ErrorMessage = "لطفاً {0} را وارد کنید")]
        public byte BNumber { get; set; }
        [DisplayName("نام شعبه")]
        [Required(ErrorMessage = "لطفاً {0} را وارد کنید")]
        public string BName { get; set; }
        [DisplayName("آدرس شعبه")]
        [Required(ErrorMessage = "لطفاً {0} را وارد کنید")]
        public string BAddress { get; set; }
        [DisplayName("تلفن شعبه")]
        [Required(ErrorMessage = "لطفاً {0} را وارد کنید")]
        public string BTel { get; set; }

        public virtual ICollection<SellingInfo> SellingInfo { get; set; }
    }

}
