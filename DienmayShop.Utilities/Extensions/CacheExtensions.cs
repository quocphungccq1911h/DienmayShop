using System.Diagnostics;
using System.Reflection;
using System.Text.RegularExpressions;

namespace DienmayShop.Utilities.Extensions
{
    public static class CacheExtensions
    {
        public static string CreateCacheName(params object[] args)
        {
            StackTrace stackTrace = new StackTrace();
            MethodBase method = stackTrace?.GetFrame(1).GetMethod();
            var callingMethod = method.Name;
            if(method.ReflectedType != null)
            {
                if(callingMethod == "MoveNext")
                {
                    callingMethod = method.ReflectedType.FullName;
                    MatchCollection matchCollection = Regex.Matches(callingMethod, @"\+<[^>]*>");
                    if (matchCollection.Count > 0)
                    {
                        var methodName = matchCollection[0].ToString();
                        var i = callingMethod.IndexOf("+", StringComparison.Ordinal);

                        callingMethod = callingMethod.Substring(0, i) + "." + methodName.Substring(2, methodName.Length - 3);
                    }
                }
                else
                {
                    callingMethod = method.ReflectedType.FullName + "." + callingMethod;
                }
            }
            var paramString = string.Empty;
            if (args != null)
            {
                foreach (var param in args)
                {
                    if (param == null)
                    {
                        paramString += "null,";
                    }
                    else
                    {
                        var paramType = param.GetType();
                        if (paramType.IsValueType || paramType == typeof(string))
                        {
                            if (paramType == typeof(DateTime))
                            {
                                paramString += ((DateTime)param).ToString("yyyyMMddHHmmss");
                            }
                            else
                            {
                                paramString += param;
                            }
                        }
                        else
                        {
                            paramString += param.GetMD5Hash();
                        }

                        paramString += ",";
                    }
                }
            }
            return $"DienmayShop-{callingMethod}-{(paramString.Length > 120 ? paramString.GetMD5Hash() : paramString.Trim(','))}";
        }
    }
}
