using System;
using System.Collections.Generic;
using System.Text;

namespace TUSA.Domain.Converters
{
    public interface IConvertModel<TSource, TTarget>
    {
        TTarget Convert();
    }
}
