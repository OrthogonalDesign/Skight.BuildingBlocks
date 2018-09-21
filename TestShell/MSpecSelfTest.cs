using System;
using System.Collections.Generic;
using System.Text;
using Machine.Specifications;

namespace TestShell
{
    class MSpecSelfTest
    {
        private It should_run_testing = () => 1.ShouldEqual(1);
    }
}
