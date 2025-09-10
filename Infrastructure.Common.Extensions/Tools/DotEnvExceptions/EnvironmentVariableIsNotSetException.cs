using System;

namespace Infrastructure.Common.Extensions.Tools.DotEnvExceptions
{
    /// <summary>
    /// When a matching CONSTANTCASE of Property is not found within Environment variables.
    /// </summary>
    public class EnvironmentVariableIsNotSetException : Exception
    {
        public EnvironmentVariableIsNotSetException(string property) :
            base($"Property of `{property}` is not set within environment variables")
        { }
    }
}
