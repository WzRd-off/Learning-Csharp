using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr8
{
    internal class Team
    {
        protected string teamName;
        protected int teamID;

        public string TeamName { get => teamName; set => teamName = value; }

        public Team() {  }

        public Team(string teamName, int teamID)
        {
            this.teamName = teamName;
            RegistrationNumber = teamID;
        }

        public int RegistrationNumber
        {
            get { return teamID; }
            set 
            {
                if (0 > value)
                {
                    throw new ArgumentOutOfRangeException("Registration number must be non-negative.");
                }
                else
                {
                    teamID = value;
                }
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is Team other)
            {
                return teamName == other.teamName &&
                       teamID == other.teamID;
            }
            return false;
        }

        public static bool operator ==(Team t1, Team t2)
        {
            return t1.Equals(t2);
        }
        public static bool operator !=(Team t1, Team t2)
        {
            return !(t1 == t2);
        }

        public virtual object DeepCopy()
        {
            return new Team(teamName, teamID);
        }

        public override int GetHashCode()
        {
            return (teamName, teamID).GetHashCode();
        }

        public override string ToString() => $"Команда: {teamName}, ID: {teamID}";

    }
}
