﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCoreSolution.Models
{
    public interface IRegisterBoat
    {
        IEnumerable<RegisterBoat> GetAllBoats();
        String AddBoats(RegisterBoat registerBoat);
    }
}
