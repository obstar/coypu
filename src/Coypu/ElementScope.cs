using System;
using Coypu.Actions;
using Coypu.Finders;
using Coypu.Queries;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace Coypu
{
    public abstract class ElementScope : DriverScope, Element
    {
        internal ElementScope(ElementFinder elementFinder,
                              DriverScope outerScope)
            : base(elementFinder, outerScope) { }

        public string Id
        {
            get
            {
                return Try(() => Now()
                               .Id);
            }
        }

        public string Text
        {
            get
            {
                return Try(() => Now()
                               .Text);
            }
        }

        public string Value
        {
            get
            {
                return Try(() => Now()
                               .Value);
            }
        }

        public string Name
        {
            get
            {
                return Try(() => Now()
                               .Name);
            }
        }

        public string OuterHTML
        {
            get
            {
                return Try(() => Now()
                               .OuterHTML);
            }
        }

        public string InnerHTML
        {
            get
            {
                return Try(() => Now()
                               .InnerHTML);
            }
        }

        public string Title
        {
            get
            {
                return Try(() => Now()
                               .Title);
            }
        }

        public string SelectedOption
        {
            get
            {
                return Try(() => Now()
                               .SelectedOption);
            }
        }

        public bool Selected
        {
            get
            {
                return Try(() => Now()
                               .Selected);
            }
        }

        public object Native
        {
            get
            {
                return Try(() => Now()
                               .Native);
            }
        }

        public bool Disabled
        {
            get
            {
                return Try(() => Now()
                               .Disabled);
            }
        }

        public string this[string attributeName]
        {
            get { return Try(() => Now()[attributeName]); }
        }

        public ElementScope Click(Options options = null)
        {
            Try(new ClickAction(this, _driver, Merge(options), Waiter));
            return this;
        }

        /// <summary>
        ///     Treat this scope as an input field and fill in with the specified value
        /// </summary>
        /// <param name="value">The value to fill in with</param>
        /// <param name="options">
        ///     <para>Override the way Coypu is configured to find elements for this call only.</para>
        ///     <para>E.g. A longer wait:</para>
        ///     <returns>The current scope</returns>
        /// </param>
        public ElementScope FillInWith(string value,
                                       Options options = null)
        {
            Try(new FillIn(_driver, this, value, Merge(options)));
            return this;
        }

        /// <summary>
        ///     Treat this scope as a select element and choose the specified option
        /// </summary>
        /// <param name="value">The text or value of the option</param>
        /// <param name="options">
        ///     <para>Override the way Coypu is configured to find elements for this call only.</para>
        ///     <para>E.g. A longer wait</para>
        ///     <returns>The current scope</returns>
        /// </param>
        public ElementScope SelectOption(string value,
                                         Options options = null)
        {
            Try(new Select(_driver, this, value, DisambiguationStrategy, Merge(options)));
            return this;
        }

        public ElementScope Hover(Options options = null)
        {
            Try(new Hover(this, _driver, Merge(options)));
            return this;
        }

        public ElementScope SendKeys(string keys,
                                     Options options = null)
        {
            Try(new SendKeys(keys, this, _driver, Merge(options)));
            return this;
        }

        public ElementScope Check(Options options = null)
        {
            Try(new CheckAction(_driver, this, Merge(options)));
            return this;
        }

        public ElementScope Uncheck(Options options = null)
        {
            Try(new Uncheck(_driver, this, Merge(options)));
            return this;
        }

        public abstract bool Exists(Options options = null);

        public abstract bool Missing(Options options = null);

        public bool HasValue(string text,
                             Options options = null)
        {
            return Try(new HasValueQuery(this, text, Merge(options)));
        }

        public bool HasNoValue(string text,
                               Options options = null)
        {
            return Try(new HasNoValueQuery(this, text, Merge(options)));
        }

        internal abstract void Try(DriverAction action);
        internal abstract bool Try(Query<bool> query);
        internal abstract T Try<T>(Func<T> getAttribute);
    }
}