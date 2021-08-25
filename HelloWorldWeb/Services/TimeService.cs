// <copyright file="TimeService.cs" company="Principal33 Solutions">
// Copyright (c) Principal33 Solutions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldWeb.Services
{
    public class TimeService : ITimeService
    {
        public DateTime Now()
        {
            return DateTime.Now;
        }
    }
}
