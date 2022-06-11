using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleSellingProject.WebApplication.Models
{
    public class Vehicle
    {
        
        public int Id { get; set; }
        [DisplayName("شرکت")]
        [Required(ErrorMessage = "لطفاً {0} را وارد کنید")]
        public string Brand { get; set; }
        [DisplayName("نام خودرو")]
        [Required(ErrorMessage = "لطفاً {0} را وارد کنید")]
        public string Name { get; set; }
        [DisplayName("مدل")]
        [Range(2000, 2022,
         ErrorMessage = "لطفاً سال {0} را بین {1} و {2} وارد کنید")]
        [Required(ErrorMessage = "لطفاً {0} را وارد کنید")]
        public int Model { get; set; }
        [DisplayName("نوع بدنه")]
        [Required(ErrorMessage = "لطفاً {0} را وارد کنید")]
        public byte BodyTypeId { get; set; }
        [DisplayName("حجم موتور")]
        [Required(ErrorMessage = "لطفاً {0} را وارد کنید")]
        public byte EngineSizeId { get; set; }
        [DisplayName("تعداد درب")]
        [Required(ErrorMessage = "لطفاً {0} را وارد کنید")]
        public byte DoorId { get; set; }
        [DisplayName("تعداد سیلندر")]
        [Required(ErrorMessage = "لطفاً {0} را وارد کنید")]
        public byte CylinderId { get; set; }
        [DisplayName("قیمت تمام شده")]
        [Range(10000, 1000000,
         ErrorMessage = "لطفاً  {0} را بین {1} و {2} وارد کنید")]
        [Required(ErrorMessage = "لطفاً {0} را وارد کنید")]
        public int CostPrice { get; set; }
        [DisplayName("قیمت فروش")]
        [Range(10000, 1000000,
         ErrorMessage = "لطفاً  {0} را بین {1} و {2} وارد کنید")]
        [Required(ErrorMessage = "لطفاً {0} را وارد کنید")]
        public int SellPrice { get; set; }



        public virtual BodyType BodyType { get; set; }
        public virtual EngineSize EngineSize { get; set; }
        public virtual Door Door { get; set; }
        public virtual Cylinder Cylinder { get; set; }
        public virtual ICollection<SellingInfo> SellingInfo { get; set; }
    }
}
