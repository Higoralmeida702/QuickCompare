using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickCompare.Domain.Entity
{
    public class CelularEntity : AparelhoEntity
    {
        public bool ExpansaoMicroSd { get; set; }
        public bool DualSim { get; set; }
        public bool Has5G { get; set; }
        public int ComprimentoCelular { get; set; }
        public int LarguraCelular { get; set; }
    }
}