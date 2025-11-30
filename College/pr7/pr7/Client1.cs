using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr7
{
    internal class Client
    {
        private readonly int clientId;
        private string fullName;
        private string phoneNumber;
        private List<int> rentalHistory;

        public Client()
        {
            this.rentalHistory = new List<int>();
        }

        public Client(int id, string name, string phone)
        {
            this.clientId = id;
            this.fullName = name;
            this.PhoneNumber = phone;
            this.rentalHistory = new List<int>();
        }

        public int ClientId => clientId;
        public string FullName { get => fullName; set => fullName = value; }
        public List<int> RentalHistory => rentalHistory;

        public string PhoneNumber
        {
            get => phoneNumber;
            set
            {
                if (value.Length < 10 || value.Length > 13)
                    throw new ArgumentException("Номер телефону повинен містити від 10 до 13 символів.");
                phoneNumber = value;
            }
        }

        public void AddToHistory(int toolId) => rentalHistory.Add(toolId);

    }
}
