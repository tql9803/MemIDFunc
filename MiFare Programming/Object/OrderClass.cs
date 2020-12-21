using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainUI_namespace.Object
{
    public class OrderClass
    {
        public int OrderID { get; set; }
        public string OrderItem { get; set; }
        public double TaxAmount { get; set; }
        public double OrderTotal { get; set; }
        public double Payment { get; set; }
        public string PaymentMed { get; set; }
        public DateTime PaymentDate { get; set; }
        public int CustomerID { get; set; }
    }
}
