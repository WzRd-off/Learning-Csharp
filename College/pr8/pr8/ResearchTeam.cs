using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pr8;

namespace pr8
{
    internal class ResearchTeam : Team
    {
        private ArrayList members;
        private ArrayList publishs;

        public Team Team
        {
            get => this;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                if (value is ResearchTeam rt)
                {
                    teamName = rt.teamName;
                    teamID = rt.teamID;
                }
                else
                {
                    throw new InvalidOperationException("Cannot set base fields from a non-Student Person instance.");
                }
            }
        }

        public ResearchTeam(string teamName, int teamID, ArrayList members, ArrayList publishs) : base(teamName, teamID)
        {
            this.members = new ArrayList(members);
            this.publishs = new ArrayList(publishs);
        }

        public override object DeepCopy()
        {
            return new ResearchTeam(teamName, teamID, new ArrayList(members), new ArrayList(publishs));
        }

    }
}
