﻿// <license>
//     The MIT License (MIT)
// </license>
// <copyright company="TTRider Technologies, Inc.">
//     Copyright (c) 2014-2017 All Rights Reserved
// </copyright>

namespace TTRider.FluidSql
{
    public abstract class TransactionStatement : IStatement
    {
        public Name Name { get; set; }

        public Parameter Parameter { get; set; }
    }
}