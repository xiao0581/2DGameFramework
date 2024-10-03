﻿using Mandatory2DGameFramework.worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.model.defence
{
    public class DefenceItem:WorldObject
    {
        public string Name { get; set; }
        public int ReduceHitPoint { get; set; }
        public int DefenseValue { get; private set; }


        public DefenceItem()
        {
            Name = string.Empty;
            ReduceHitPoint = 0;
        }


        public override string ToString()
        {
            return $"{{{nameof(Name)}={Name}, {nameof(ReduceHitPoint)}={ReduceHitPoint.ToString()}}}";
        }
    }
}
