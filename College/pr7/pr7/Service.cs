using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace pr7
{
    internal class RentalService
    {
        public ToolCollection ToolCollection { get; set; } 
        public List<Agreement> Agreements { get; set; }
        public List<Client> Clients { get; set; }

        public RentalService()
        {
            ToolCollection = new ToolCollection();
            Agreements = new List<Agreement>();
            Clients = new List<Client>();
        }

        public List<Agreement> this[int clientId]
        {
            get => Agreements.Where(a => a.Renter.ClientId == clientId).ToList();

        }

        public void RentToolToClient(int toolId, int clientId, int days)
        {
            var tool = ToolCollection.FindTool(toolId);
            var client = Clients.FirstOrDefault(c => c.ClientId == clientId);

            if (tool != null && client != null && tool.Status)
            {
                tool.setRental();
                client.AddToHistory(tool.Series);

                var agreement = new Agreement(tool, client, days);
                Agreements.Add(agreement);
            }
            else
            {
                throw new System.Exception("Неможливо оформити оренду (інструмент зайнятий або не знайдено).");
            }
        }

        public void ReturnTool(int toolId)
        {
            var tool = ToolCollection.FindTool(toolId);
            if (tool != null)
            {
                tool.returnToolFromRental();
            }
        }
        public void SaveAllData()
        {
            ToolCollection.SaveToFile("tools.json");
            File.WriteAllText("clients.json", JsonSerializer.Serialize(Clients));
        }

        public void AddClient(Client c) => Clients.Add(c); 
    }
}
