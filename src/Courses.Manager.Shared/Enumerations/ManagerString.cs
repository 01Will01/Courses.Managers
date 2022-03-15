using System;

namespace Courses.Manager.Shared.Enumerations
{
    [global::System.AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public sealed class StringValueAttribute : StringAttribute
    {
        public StringValueAttribute(string valorString)
            : base(valorString)
        {
        }
    }

    public class StringAttribute : Attribute
    {
        public string ValorString { get; private set; }

        public StringAttribute(string valorString)
        {
            this.ValorString = valorString;
        }
    }
}
