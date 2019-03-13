using Szewczyk.Boardgames.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szewczyk.Boardgames.DAOMock2.BO
{
    public class Author : IAuthor
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return $"Full name: {FirstName} {LastName} ";
        }
    }
}
