using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Porto.Attributes
{
    public static class EnvironmentVariableParser
    {
        /// <summary>
        /// Processes the environment variables and returns an object of the parsed values of the type provided.
        /// </summary>
        /// <typeparam name="T">The type of object to parse the values to.</typeparam>
        /// <returns>The created object.</returns>
        public static T Parse<T>(T existing = null) where T : class
        {
            var type = typeof(T);
            var instance = existing ?? (T)Activator.CreateInstance(type);

            var properties = type.GetProperties();
            foreach (var prop in properties)
            {
                var attribute = (EnvironmentVariableAttribute)Attribute.GetCustomAttribute(prop, typeof(EnvironmentVariableAttribute));
                if (attribute != null)
                {
                    var envValue = Environment.GetEnvironmentVariable(attribute.Name);

                    if (envValue != null)
                    {
                        prop.SetValue(instance, ConvertType(prop, envValue));
                    }
                    else if (attribute.Presence == Presence.Mandatory)
                    {
                        throw new Exception($"Mandatory environment variable '{attribute.Name}' has not been set.");
                    }
                }
            }

            return instance;
        }

        /// <summary>
        /// Converts the environment variable value string to the required type based on the PropertyInfo.
        /// </summary>
        /// <param name="propInfo">The PropertyInfo object.</param>
        /// <param name="value">The string value to convert.</param>
        /// <returns>The converted value.</returns>
        private static object ConvertType(PropertyInfo propInfo, string value)
        {
            if (string.IsNullOrEmpty(value))
                return null;

            if (propInfo.PropertyType == typeof(List<string>))
            {
                return value.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList();
            }

            if (propInfo.PropertyType == typeof(string[]))
            {
                return value.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();
            }

            var converter = TypeDescriptor.GetConverter(propInfo.PropertyType);
            return converter.ConvertFromString(value);
        }
    }
}
