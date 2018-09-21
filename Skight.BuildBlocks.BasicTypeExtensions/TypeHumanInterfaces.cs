using System;
using System.Linq;
using System.Reflection;

namespace Skight.BuildBlocks.BasicTypeExtensions
{
    public static class TypeHumanInterfaces
    {
        public static ConstructorInfo greediest_constructor(this Type type)
        {
            return type.GetConstructors()
                .OrderByDescending(x => x.GetParameters().Count())
                .First();
        }
    }
}