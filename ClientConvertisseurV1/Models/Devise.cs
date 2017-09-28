using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientConvertisseurV1.Models
{
    public class Devise
    {
        public int Id { get; set; }

        public string Nom { get; set; }

        public double Taux { get; set; }
    }
}
