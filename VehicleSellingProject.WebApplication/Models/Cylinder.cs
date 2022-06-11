using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace VehicleSellingProject.WebApplication.Models
{
    public partial class Cylinder
    {
        public byte Id { get; set; }
        public byte BodyTypeId { get; set; }
        [DisplayName("تعداد سلندر")]
        [Required(ErrorMessage = "لطفاً {0} را وارد کنید")]
        public byte Qty { get; set; }

        public virtual BodyType BodyType { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
