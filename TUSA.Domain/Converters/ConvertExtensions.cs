using System;
using System.Collections.Generic;
using System.Linq;
using TUSA.Domain.Converters;

namespace TUSA.Domain.Converters
{
    public static class ConvertExtensions
    {
        public static IEnumerable<TTarget> ConvertAll<TSource, TTarget>(
            this IEnumerable<IConvertModel<TSource, TTarget>> values)
            => values.Select(value => value.Convert());
    }
}
