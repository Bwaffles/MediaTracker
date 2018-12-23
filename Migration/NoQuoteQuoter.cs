using FluentMigrator.Runner.Generators.Postgres;
using System;
using System.Collections.Generic;
using System.Text;

namespace Migrations
{
    public class NoQuoteQuoter : PostgresQuoter
    {
        protected override bool ShouldQuote(string name)
        {
            return false;
        }
    }
}