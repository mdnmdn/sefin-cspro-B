﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefin.CsProB.Commons
{
    public interface IAppContext
    {
        int UserId { get; }
        string UserMail { get; }

        T ResolveObject<T>();
    }
}
