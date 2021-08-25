// <copyright file="StartupTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HelloWorldWeb.Tests
{
    public class StartupTests
    {
        [Fact]
        public void ConvertHerokuStringToAspNetString()
        {
            // Assume
            string herokuConnectionString = "postgres://hboapgcvkrkteu:518b66b8a997733a33672e7a9f19d698f51d32984377b0549e93e1adbeb9e76a@ec2-34-251-245-108.eu-west-1.compute.amazonaws.com:5432/dedb4hou2vdcv3";

            // Act
            string aspNetConnectionString = Startup.ConvertHerokuConnToAspNetConnString(herokuConnectionString);

            // Assert
            Assert.Equal(
                    "Host=ec2-34-251-245-108.eu-west-1.compute.amazonaws.com;Port=5432;Database=dedb4hou2vdcv3;User Id=hboapgcvkrkteu;Password=518b66b8a997733a33672e7a9f19d698f51d32984377b0549e93e1adbeb9e76a;Pooling=true;SSL Mode=Require;TrustServerCertificate=True;Include Error Detail=True;",
                    aspNetConnectionString);
        }
    }
}
