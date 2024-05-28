using System;
using System.Linq;

namespace Extensions
{
    public static class TypeExtensions
    {
        public static Type[] FindAllSubTypes(this Type t) => AppDomain.CurrentDomain
                                                                         .GetAssemblies()
                                                                         .SelectMany(s => s.GetTypes())
                                                                         .Where(type => t.IsAssignableFrom(type)
                                                                                 && !type.IsAbstract
                                                                                 && !type.IsGenericType)
                                                                         .ToArray();
    }
}