﻿using Mandatory2DGameFramework.Cretures;
using Mandatory2DGameFramework.State;
using Mandatory2DGameFramework.worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.state
{
    public interface ICreatureState : Iattack, Imove, Iloot, IreceiveHit
    {
             
    
    }
}
