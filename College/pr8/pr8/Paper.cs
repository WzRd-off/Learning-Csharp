using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr8
{
    internal class Paper
    {
        public string Title { get; set; }
        public Person Author { get; set; }
        public DateTime PublicationDate { get; set; }

        public Paper(string title, Person author, DateTime publicationDate)
        {
            Title = title;
            Author = author;
            PublicationDate = publicationDate;
        }

        public Paper()
        {
            Title = "Default Paper";
            Author = new Person("Unknown", "Author", DateTime.Now);
            PublicationDate = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{Title} by {Author.GetType().Name} ({PublicationDate.ToShortDateString()})";
        }

        public object DeepCopy()
        {
            return new Paper(Title, (Person)Author.DeepCopy(), PublicationDate);
        }


    }
}
