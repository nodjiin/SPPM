using System;
using Microsoft.Extensions.Logging;

namespace Application.Utils.Extension
{
    public static class LoggerExtension
    {
        public static void TraceMissingServiceAndExit<TClass>(this ILogger<TClass> logger, string serviceName,
            int exitCode = -1) where TClass : class
        {
            logger.LogError($"Could not find a registered service for type {serviceName}.");
            Environment.Exit(-1);
        }
    }
}