using System;
using System.IO;
using Ci.ServerMap.Enums;

namespace Ci.ServerMap
{
    public static class ServerMap
    {
        private static readonly string RootPath = Directory.GetCurrentDirectory();

        public static string VirtualAbsolutePath(string virtualAbsolutePath,
            RootPathType rootPathType = RootPathType.ContentRoot)
        {
            if (!virtualAbsolutePath.StartsWith("~/"))
                throw new InvalidOperationException($"{nameof(virtualAbsolutePath)} not start with ~/");

            string wwwrootPath = rootPathType == RootPathType.WebRoot ? "wwwroot" : string.Empty;

            var path = Path.Combine(RootPath, wwwrootPath, virtualAbsolutePath.Replace("~/", ""));
            return path;
        }
    }
}
