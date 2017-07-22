using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{
    public interface ITile
    {
        int X { get; set; }
        int Y { get; set; }
        int Height { get; set; }
        Texture texture { get; set; }
    }
}
