using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_man_sys.Model
{
    internal class Appointments
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int Pat_ID { get; set; }

        [ForeignKey(nameof(Pat_ID))]
        public Patients Patients { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        public Appointments() { }

        public Appointments(int patId, DateTime dateTime)
        {
            Pat_ID = patId;
            DateTime = dateTime;
        }
    }
}