using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ejer2_2Michelle.Models
{
    public class firma
    {
           [PrimaryKey, AutoIncrement]
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public Byte[] ArrayByteImage { get; set; }
        
    }
}
