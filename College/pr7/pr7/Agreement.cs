using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr7
{
    internal class Agreement
    {
        public Tool RentedTool { get; set; }
        public Client Renter { get; set; }
        public DateTime StartDate { get; set; }
        public int Days { get; set; }
        public Agreement(Tool tool, Client client, int days)
        {
            RentedTool = tool;
            Renter = client;
            StartDate = DateTime.Now;
            Days = days;
        }
        public decimal CalculateTotalPrice()
        {
            decimal basePrice = RentedTool.Price * Days;
            if (RentedTool.State == "пошкоджений")
            {
                basePrice *= 0.5m;
            }
            return basePrice;
        }
        public string GetAgreementInfo() => $"Угода: {Renter.FullName} орендував {RentedTool.Name} на {Days} днів. Сума: {CalculateTotalPrice()} грн.";

    }     
}
