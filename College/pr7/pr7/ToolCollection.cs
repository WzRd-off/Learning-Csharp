using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace pr7
{
    internal class ToolCollection
    {
        private List<Tool> tools;

        public ToolCollection()
        {
            tools = new List<Tool>();
        }

        public List<Tool> Tools => tools;

        public void AddTool(Tool tool) => tools.Add(tool);


        public void RemoveTool(int id) 
        {
            var tool = FindTool(id);
            if (tool != null) tools.Remove(tool);
        }

        public Tool FindTool(int id) => tools.FirstOrDefault(t => t.Series == id);


        public List<Tool> FindAvailableTools() => tools.Where(t => t.Status).ToList();


        public void SaveToFile(string filename)
        {
            string json = JsonSerializer.Serialize(tools);
            File.WriteAllText(filename, json);
        }

        public void LoadFromFile(string filename)
        {
            if (File.Exists(filename))
            {
                string json = File.ReadAllText(filename);
                tools = JsonSerializer.Deserialize<List<Tool>>(json);
            }
        }
    }
}
