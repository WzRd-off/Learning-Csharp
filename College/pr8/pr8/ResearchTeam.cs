using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace pr8
{
    internal class ResearchTeam : Team
    {
        private List<Person> members;
        private List<Paper> publications;

        public List<Person> Members { get => members; set => members = value; }
        public List<Paper> Publications { get => publications; set => publications = value; }

        public ResearchTeam() : base()
        {
            members = new List<Person>();
            publications = new List<Paper>();
        }

        public ResearchTeam(string teamName, int teamID, List<Person> members, List<Paper> publications)
            : base(teamName, teamID)
        {
            this.members = new List<Person>(members);
            this.publications = new List<Paper>(publications);
        }

        public Team BaseTeam
        {
            get => new Team(teamName, teamID);
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                teamName = value.TeamName;
                RegistrationNumber = value.RegistrationNumber;
            }
        }

        public override object DeepCopy()
        {
            List<Person> copiedMembers = new List<Person>();
            foreach (var m in members) copiedMembers.Add((Person)m.DeepCopy());

            List<Paper> copiedPapers = new List<Paper>();
            foreach (var p in publications) copiedPapers.Add((Paper)p.DeepCopy());

            return new ResearchTeam(teamName, teamID, copiedMembers, copiedPapers);
        }

        public IEnumerable<Person> GetMembersWithoutPublications()
        {
            foreach (var member in members)
            {
                bool hasPaper = false;
                foreach (var paper in publications)
                {
                    if (paper.Author.FirstName == member.FirstName && paper.Author.LastName == member.LastName)
                    {
                        hasPaper = true;
                        break;
                    }
                }
                if (!hasPaper) yield return member;
            }
        }

        public IEnumerable<Paper> GetRecentPapers(int years)
        {
            foreach (var paper in publications)
            {
                if (paper.PublicationDate.Year >= DateTime.Now.Year - years)
                {
                    yield return paper;
                }
            }
        }

        public void AddMember(Person p) => members.Add(p);
        public void AddPaper(Paper p) => publications.Add(p);

        public override string ToString()
        {
            string s = base.ToString() + $"\nУчастников: {members.Count}, Публикаций: {publications.Count}\n";
            foreach (var m in members) s += $" - {m}\n";
            return s;
        }

        public static bool Save(string filename, ResearchTeam obj)
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(obj, options);
                File.WriteAllText(filename, jsonString);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static ResearchTeam Load(string filename)
        {
            if (!File.Exists(filename)) throw new FileNotFoundException();
            string jsonString = File.ReadAllText(filename);
            return JsonSerializer.Deserialize<ResearchTeam>(jsonString);
        }

        public bool Save(string filename)
        {
            return Save(filename, this);
        }

        public static ResearchTeam LoadAndSet(string filename)
        {
            try
            {
                if (File.Exists(filename))
                {
                    return Load(filename);
                }
            }
            catch { }

            ResearchTeam rt = new ResearchTeam("Новая Команда (JSON)", 1, new List<Person>(), new List<Paper>());
            Save(filename, rt);
            return rt;
        }
    }
}
