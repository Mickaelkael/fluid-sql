﻿// <copyright company="TTRider, L.L.C.">
// Copyright (c) 2014-2015 All Rights Reserved
// </copyright>

namespace TTRider.FluidSql
{
    public class SetStatement : Token, IStatement
    {
        public BinaryEqualToken Assign { get; set; }
    }
}