using System;
using System.Collections.Generic;

namespace Pandora.Data.Transformers;

internal class TypeComparer : IEqualityComparer<Type>
{
    public bool Equals(Type x, Type y)
    {
        if (ReferenceEquals(x, y))
        {
            return true;
        }
        if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
        {
            return false;
        }
        if (x.GetType() != y.GetType())
        {
            return false;
        }

        return x.FullName == y.FullName;
    }

    public int GetHashCode(Type obj)
    {
        return (obj.FullName != null ? obj.FullName.GetHashCode() : 0);
    }
}