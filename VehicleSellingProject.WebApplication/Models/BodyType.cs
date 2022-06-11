using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VehicleSellingProject.WebApplication.Models
{
    public class BodyType
    {
        public byte Id { get; set; }
        [DisplayName("نوع بدنه")]
        [Required(ErrorMessage ="لطفاً {0} را وارد کنید")]
        public string TypeName { get; set; }


        public virtual ICollection<Vehicle> Vehicles { get; set; }
        public virtual ICollection<EngineSize> EngineSizes { get; set; }
        public virtual ICollection<Door> Doors { get; set; }
        public virtual ICollection<Cylinder> Cylinders { get; set; }
    }
}
