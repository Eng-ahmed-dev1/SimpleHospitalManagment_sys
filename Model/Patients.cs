using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_man_sys.Model
{
    internal class Patients
    {
        [Key,Required]
        public int ID { get; set; }
        [Required,MaxLength(25)]
        public string Name { get; set; }
        [Required]
        public string Condition { get; set; }
        public Patients(){}
        public ICollection<Appointments> appointments { get; set; } = new List<Appointments>();
        public Patients(int id , string name , string condition)
        {
            ID = id;
            Name = name;
            Condition = condition;
        }
    }
}
