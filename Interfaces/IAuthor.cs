using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szewczyk.Boardgames.Interfaces
{
    public interface IAuthor
    {
        int ID { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
    }
}
