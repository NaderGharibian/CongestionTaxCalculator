using System;
using System.IO;

namespace Helpers;

public static class Utilities
{
    public static bool IsValidDate(string date)
    {
        DateTime temp;
        if (DateTime.TryParse(date, out temp)) return true;
        
        return false;   
    }

    public static class EnvironmentHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetSolutionName()
        {
            var solutionFullPath = Directory.GetParent(Directory.GetCurrentDirectory())!.FullName;
            var tempStrings = solutionFullPath.Split('\\');

            var solutionName = tempStrings[^1];
            return solutionName;
        }
    }
}