using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackendPI.Models
{
    public class ServerResponse<T>
    {
        public bool Result { get; set; }
        public List<T> Data { get; set; }
    }
}