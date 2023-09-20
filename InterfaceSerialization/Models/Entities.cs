using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSerialization.Models
{
    public interface ICar
    {
        public string? Brand
        {
            get;
            set;
        }
    }
    public interface IBmw : ICar
    {
        public string? Model
        {
            get;
            set;
        }
    }
    public class CarDetails : IBmw
    {
        public string? Brand
        {
            get;
            set;
        }
        public string? Model
        {
            get;
            set;
        }
    }
}
