using System;
using System.Collections.Generic;
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

        public static bool has_cycle_depends(this Type type)
        {
            List<Type> depends = new List<Type>() { type };
            return type.is_depend(depends);
        }

        private static bool is_depend(this Type type, List<Type> depends_types)
        {
            var param_types = type.greediest_constructor().GetParameters().Select(x => x.ParameterType);
            foreach (var param_type in param_types)
            {
                if (depends_types.Contains(param_type)) return true;
                depends_types.Add(param_type);

                if (param_type.is_depend(depends_types)) return true;
            }
            return false;
        }

        public static bool is_inherited_from(this Type type, Type base_type)
        {
            if (base_type.IsGenericTypeDefinition)
            {
                foreach (var item in type.GetInterfaces())
                {
                    if (item.IsGenericType && item.GetGenericTypeDefinition() == base_type)
                    {
                        return true;
                    }
                }
            }
            return !(type == base_type) && base_type.IsAssignableFrom(type);
        }

        public static bool is_assignable_to(this Type type, Type base_type)
        {
            return base_type.IsAssignableFrom(type);
        }
    }
}