﻿using PharmacyClassLib.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyClassLib.Service.Interface
{
    public interface IObjectionService
    {
        Objection Add(Objection objection);

        List<Objection> GetAll();
    }
}
