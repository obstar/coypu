using System;
using System.Collections.Generic;

namespace Coypu.Finders
{
    internal class WindowFinder : ElementFinder
    {
        internal WindowFinder(IDriver driver, string locator, DriverScope scope, Options options) : base(driver, locator, scope, options) { }

        public override bool SupportsSubstringTextMatching => true;

        internal override IEnumerable<Element> Find(Options options)
        {
            return Driver.FindWindows(Locator, Scope, options);
        }

        internal override string QueryDescription => "window: " + Locator;

        protected internal override Exception GetMissingException()
        {
            return new MissingWindowException("Unable to find " + QueryDescription);
        }
    }
}