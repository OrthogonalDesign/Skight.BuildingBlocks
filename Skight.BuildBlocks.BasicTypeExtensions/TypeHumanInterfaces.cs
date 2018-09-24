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

        public static bool has_cycle_depends(this Type type, ParameterInfo[] base_types)
        {
            if (base_types.Any(x => x.ParameterType.has_cycle_depends(type))) return true;
            return false;
        }

        public static bool has_cycle_depends(this Type type, Type inherited_type)
        {
            ParameterInfo[] param_infos = type.greediest_constructor().GetParameters();
            if (param_infos.Any(x => x.ParameterType == inherited_type)) return true;
            return false;
        }

        public static bool is_inherited_from(this Type type, Type base_type )
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