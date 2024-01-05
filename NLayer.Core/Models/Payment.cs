using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Models
{
    public class Payment
    {
        public int Id { get; set; }//Ödemenin kimliği
        public string PaymentMethod { get; set; }//Ödeme yöntemi
        public decimal Amount { get; set; }//Ödeme tutarı
        public DateTime Date { get; set; }//Ödeme tarihi
        public string TransactionId { get; set; }//İşlem kimliği

    }

}
