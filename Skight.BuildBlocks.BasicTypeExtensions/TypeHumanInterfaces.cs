﻿using System;
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
        
    }
}