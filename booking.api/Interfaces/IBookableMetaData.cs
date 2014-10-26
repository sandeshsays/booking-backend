using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booking.api.Interfaces
{
    public interface IBookableMetaData
    {
        long Id { get; set; }
        string Name { get; set; }
    }
}
