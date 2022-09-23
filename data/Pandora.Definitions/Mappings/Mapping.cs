using System;
using System.Linq.Expressions;

namespace Pandora.Definitions.Mappings;

public static class Mapping
{
    /// <summary>
    /// FromSchema defines a mapping from a Field within this Schema Model, the destination
    /// (where this maps to) is defined as an extension method on this.
    /// </summary>
    /// <param name="schemaModelFieldFunc">An Expression specifying which Field within this Schema Model should be mapped.</param>
    /// <typeparam name="TModel">The Schema Model</typeparam>
    public static FromMapping FromSchema<TModel>(Expression<Func<TModel, object>> schemaModelFieldFunc)
    {
        var fieldPath = schemaModelFieldFunc.Body.Normalize();
        if (fieldPath.Contains('.'))
        {
            // TODO: implement this
            throw new NotSupportedException("nested fields are not yet supported as expressions");
        }
        return new FromMapping
        {
            FromModel = typeof(TModel).Name,
            FromFieldPath = fieldPath,
        };
    }
}
