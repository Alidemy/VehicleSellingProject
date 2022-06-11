using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VehicleSellingProject.WebApplication.Models
{
    public class Door
    {
        public byte Id { get; set; }
        public byte BodyTypeId { get; set; }
        [DisplayName("تعداد درب")]
        [Range(2, 6,
         ErrorMessage = "لطفاً  {0} را بین {1} و {2} وارد کنید")]
        public byte Qty { get; set; }


        public virtual BodyType BodyType { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
