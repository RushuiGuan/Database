﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Albatross.Database
{
    public interface IGetDbConnection
    {
		IDbConnection Get(Server server);
    }
}
