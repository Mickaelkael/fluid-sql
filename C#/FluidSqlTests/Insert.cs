﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TTRider.FluidSql;

namespace FluidSqlTests
{
    [TestClass]
    public class Insert
    {
        [TestMethod]
        public void InsertDefault()
        {
            var statement = Sql.Insert.Into(Sql.Name("foo.bar")).DefaultValues();

            var command = Utilities.GetCommand(statement);

            Assert.IsNotNull(command);
            Assert.AreEqual("INSERT INTO [foo].[bar] DEFAULT VALUES;", command.CommandText);
        }

        [TestMethod]
        public void InsertFrom()
        {
            var statement = Sql.Insert.Into(Sql.Name("foo.bar")).From(Sql.Select.From(Sql.Name("bar.foo")));

            var command = Utilities.GetCommand(statement);

            Assert.IsNotNull(command);
            Assert.AreEqual("INSERT INTO [foo].[bar] SELECT * FROM [bar].[foo];", command.CommandText);
        }

        [TestMethod]
        public void InsertTopFrom()
        {
            var statement = Sql.Insert.Into(Sql.Name("foo.bar")).Top(1).From(Sql.Select.From(Sql.Name("bar.foo")));

            var command = Utilities.GetCommand(statement);

            Assert.IsNotNull(command);
            Assert.AreEqual("INSERT TOP (1) INTO [foo].[bar] SELECT * FROM [bar].[foo];", command.CommandText);
        }

        [TestMethod]
        public void InsertColumnsFrom00()
        {
            var statement = Sql.Insert.Into(Sql.Name("foo.bar")).From(Sql.Select.From(Sql.Name("bar.foo"))).Columns("id", "value");

            var command = Utilities.GetCommand(statement);

            Assert.IsNotNull(command);
            Assert.AreEqual("INSERT INTO [foo].[bar] ([id], [value]) SELECT * FROM [bar].[foo];", command.CommandText);
        }

        [TestMethod]
        public void InsertColumnsFrom01()
        {
            var statement = Sql.Insert.Into(Sql.Name("foo.bar")).From(Sql.Select.From(Sql.Name("bar.foo"))).Columns(Sql.Name("id"), Sql.Name("value"));

            var command = Utilities.GetCommand(statement);

            Assert.IsNotNull(command);
            Assert.AreEqual("INSERT INTO [foo].[bar] ([id], [value]) SELECT * FROM [bar].[foo];", command.CommandText);
        }

        [TestMethod]
        public void InsertColumnsFromOutput()
        {
            var statement = Sql.Insert.Into(Sql.Name("foo.bar"))
                .From(Sql.Select.From(Sql.Name("bar.foo")))
                .Columns(Sql.Name("id"), Sql.Name("value"))
                .Output(Sql.Name("inserted", "id"));

            var command = Utilities.GetCommand(statement);

            Assert.IsNotNull(command);
            Assert.AreEqual("INSERT INTO [foo].[bar] ([id], [value]) OUTPUT [inserted].[id] SELECT * FROM [bar].[foo];", command.CommandText);
        }

        [TestMethod]
        public void InsertColumnsValues00()
        {
            var statement = Sql.Insert.Into(Sql.Name("foo.bar"))
                .Columns(Sql.Name("id"), Sql.Name("value"))
                .Values(Sql.Scalar(123), Sql.Scalar("val0"))
                .Values(Sql.Scalar(234), Sql.Scalar("val1"))
                .Values(Sql.Scalar(345), Sql.Scalar("val2"));

            var command = Utilities.GetCommand(statement);

            Assert.IsNotNull(command);
            Assert.AreEqual("INSERT INTO [foo].[bar] ([id], [value]) VALUES (123, N'val0'), (234, N'val1'), (345, N'val2');", command.CommandText);
        }
    }
}