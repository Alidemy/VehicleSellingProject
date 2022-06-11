using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VehicleSellingProject.WebApplication.Models
{
    public class EngineSize
    {
        public byte Id { get; set; }
        public byte BodyTypeId { get; set; }
        [DisplayName("حجم موتور")]
        [Range(1500, 4000,
         ErrorMessage = "لطفاً  {0} را بین {1} و {2} وارد کنید")]
        public int Size { get; set; }


        public virtual BodyType BodyType { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
