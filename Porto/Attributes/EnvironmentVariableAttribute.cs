using System;

namespace Porto.Attributes
{
    /// <summary>
    /// Defines whether the environment variable is Mandatory or Optional.
    /// </summary>
    public enum Presence
    {
        /// <summary>
        /// The environment variable does not have to be set.
        /// </summary>
        Optional,

        /// <summary>
        /// The environment variable must be set, otherwise an exception will be thrown.
        /// </summary>
        Mandatory
    }

    /// <summary>
    /// Adding this attribute to a property and running the type through the parser will extract present environment variables and set the value of the property.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class EnvironmentVariableAttribute : Attribute
    {
        /// <summary>
        /// Constructor for mandatory variable.
        /// </summary>
        /// <param name="name">Environment variable name.</param>
        public EnvironmentVariableAttribute(string name)
        {
            Name = name;
            Presence = Presence.Mandatory;
        }

        /// <summary>
        /// Constructor for mandatory variable with a description.
        /// </summary>
        /// <param name="name">Environment variable name.</param>
        /// <param name="description">An optional description of the environment variable's purpose.</param>
        public EnvironmentVariableAttribute(string name, string description)
        {
            Name = name;
            Presence = Presence.Mandatory;
            Description = description;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name">Environment variable name.</param>
        /// <param name="presence">If presence is set to Mandatory and the variable has not been set then an exception will be thrown.</param>
        /// <param name="description">An optional description of the environment variable's purpose.</param>
        public EnvironmentVariableAttribute(string name, Presence presence = Presence.Mandatory, string description = null)
        {
            Name = name;
            Presence = presence;
            Description = description;
        }

        /// <summary>
        /// Gets the name of the environment variable.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets a description of the environment variable.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Gets a value indicating whether the environment variable must be set or not.
        /// </summary>
        public Presence Presence { get; }
    }
}
