using System;

namespace GemsCLI.Attributes
{
    /// <summary>
    /// Marks a property as optional with a default value.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class CliOptional : Attribute
    {
    }
}