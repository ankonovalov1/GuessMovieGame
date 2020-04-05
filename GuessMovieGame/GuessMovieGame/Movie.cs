using System;
using System.Collections.Generic;
using System.Text;

namespace GuessMovieGame
{
    public class Movie
    {
        public string Name { get; set; }
        public string HelpDiscription { get; set; }

        public Movie(string name, string discription)
        {
            Name = name;
            HelpDiscription = discription;
        }

        public int GetMovieLength()
        {
            int length = 0;
            foreach(char letter in Name)
            {
                length++;
            }
            return length;
        }
    }
}
