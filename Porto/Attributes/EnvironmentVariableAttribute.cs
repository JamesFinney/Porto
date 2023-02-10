using System;

namespace Porto.Attributes
{
    /// <summary>
    /// Attribute for marking properties which will be populated from an environment variable.
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
            Optional = false;
        }

        /// <summary>
        /// Constructor for mandatory variable with a description.
        /// </summary>
        /// <param name="name">Environment variable name.</param>
        /// <param name="description">An optional description of the environment variable's purpose.</param>
        public EnvironmentVariableAttribute(string name, string description)
        {
            Name = name;
            Optional = false;
            Description = description;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name">Environment variable name.</param>
        /// <param name="optional">True if the environment variable must be set; False otherwise. Default is mandatory.</param>
        /// <param name="description">An optional description of the environment variable's purpose.</param>
        public EnvironmentVariableAttribute(string name, bool optional = false, string description = null)
        {
            Name = name;
            Optional = optional;
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
        public bool Optional { get; }
    }
}
