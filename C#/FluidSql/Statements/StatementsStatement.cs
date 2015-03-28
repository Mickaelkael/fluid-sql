﻿// <license>
// The MIT License (MIT)
// </license>
// <copyright company="TTRider, L.L.C.">
// Copyright (c) 2014-2015 All Rights Reserved
// </copyright>

using System.Collections.Generic;

namespace TTRider.FluidSql
{
    public class StatementsStatement : IStatement
    {
        public StatementsStatement()
        {
            this.Statements = new List<IStatement>();
        }

        public List<IStatement> Statements { get; private set; }
    }
}