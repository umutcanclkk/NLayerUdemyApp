using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Models
{
    public class Customers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string E_Mail { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}
