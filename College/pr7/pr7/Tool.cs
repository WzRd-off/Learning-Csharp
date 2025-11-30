using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr7
{
    internal class Tool
    {
        private readonly int seriesNumber;
        private string name;
        private string category;
        private decimal pricePerDay;
        private string state;
        private bool toolStatus;

        public Tool() { }

        public Tool(int seriesNumber, string name, string category, decimal pricePerDay, string state)
        {
            this.seriesNumber = seriesNumber;
            this.Name = name;
            this.Category = category;
            this.Price = pricePerDay;
            this.State = state;
            this.Status = true;
        }



        public int Series { 
            get => this.seriesNumber;
        }
            

        public string Name
        {
            get => this.name;
            set => this.name = value;
        }

        public string Category
        {
            get => this.category;
            set => this.category = value;
        }

        public decimal Price
        {
            get => this.pricePerDay;
            set
            {
                if (value > 0)
                    this.pricePerDay = value;
                else
                    this.pricePerDay = 10.1M;
            }
        }

        public string State
        {
            get => this.state;
            set => this.state = value;
        }

        public bool Status
        {
            get => this.toolStatus;
            set => this.toolStatus = value;
        }

        public void setRental() => this.toolStatus = false;

        public void returnToolFromRental() => this.toolStatus = true;

        public string this[string i] 
        {
            get
            {
                if (i == "інформація")
                    return $"Назва: {this.name}\nКатегорія: {this.category}\nЦіна за добу: {this.pricePerDay}\nСтан: {this.state}\nСтатус: {this.toolStatus}\nСеріний номер: {this.seriesNumber}";
                else if (i == "ціна")
                    return this.pricePerDay.ToString();
                else if (i == "стан")
                    return this.state;
                else
                    return "error";
            }

        }
        public static bool operator ==(Tool t1, Tool t2)
        {

            if (ReferenceEquals(t1, t2))
                return true;

            if (ReferenceEquals(t1, null) || ReferenceEquals(t2, null))
                return false;

            return t1.seriesNumber == t2.seriesNumber;
        }

        public static bool operator !=(Tool t1, Tool t2)
        {
            return !(t1 == t2);
        }
        public static bool operator >(Tool a, Tool b) => a.pricePerDay > b.pricePerDay;
        public static bool operator <(Tool a, Tool b) => a.pricePerDay < b.pricePerDay;
        ~Tool() => Console.WriteLine("Tool with series number {0} is being destroyed", this.seriesNumber);
        }
    }


