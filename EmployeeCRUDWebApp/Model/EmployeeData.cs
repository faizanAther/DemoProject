using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeCRUDWebApp.Model
{
    public class EmployeeData
    {
        
        public Guid Id { get; set; }

        [Required]
        [MaxLength(10, ErrorMessage = "Name Cannot exceed 10 chars")]
        public string Name { get; set; }
    }
}
