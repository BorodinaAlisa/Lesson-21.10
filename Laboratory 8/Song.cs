using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory_8
{
    internal class Song
    {
        string name; 
        string author; 
        Song prev; 
        public void SetName(string name)
        {
            this.name = name;
        }
        public void SetAuthor(string author)
        {
            this.author = author;
        }

        public void SetPrev(Song prev)
        {
            this.prev = prev;
        }
        public string Title()
        {
            return $"{name} - {author}";
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Song otherSong = (Song)obj;
            return name == otherSong.name && author == otherSong.author;
        }
    }
}
    

