using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Skight.BuildBlocks.BasicTypeExtensions
{
    public static class EnumerableHumanInterfaces
    {
        public static void each<T>(this IEnumerable<T> source, Action<T> act)
        {
            foreach (var item in source)
            {
                act(item);
            }
        }
    }
}