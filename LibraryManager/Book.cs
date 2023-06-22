using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager
{
    [AddINotifyPropertyChangedInterface]
    public class Book
    {
        public string Name { get; set; }
        public string AuthorName { get; set; }
        public string Description { get; set; }
        public int YearRelease { get; set; }

        public Book(string name, string authorName, string description, int yearRelease)
        {
            Name = name;
            AuthorName = authorName;
            Description = description;
            YearRelease = yearRelease;
        }

        [DependsOn("Name", "AuthorName", "YearRelease")]
        public string Bio => $"\"{Name}\"  by {AuthorName}               {YearRelease}";

        public Book() { }
    }
}
