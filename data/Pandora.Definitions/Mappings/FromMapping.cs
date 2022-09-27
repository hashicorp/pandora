using System;
using System.Linq.Expressions;

namespace Pandora.Definitions.Mappings;

public class FromMapping
{
    /// <summary>
    /// FromModel is the name of the SchemaModel that this mapping is From.
    /// </summary>
    internal string FromModel { get; set; }

    /// <summary>
    /// FromFieldPath is the path to the SchemaField that this mapping is From.
    /// </summary>
    internal string FromFieldPath { get; set; }

    /// <summary>
    /// ToResourceIdSegmentNamed specifies that the Schema Field should be mapped to and from
    /// the Resource ID Segment with the specified name. 
    /// </summary>
    public ResourceIdMapping ToResourceIdSegmentNamed(string name)
    {
        if (FromFieldPath.Contains('.'))
        {
            throw new NotSupportedException("ResourceIDSegments can only be mapped to top-level fields");
        }

        return new ResourceIdMapping
        {
            SchemaFieldName = FromFieldPath,
            SegmentName = name,
        };
    }

    /// <summary>
    /// ToSdkField defines a Mapping between a Schema Field and an SDK Field, however it doesn't specify
    /// the Mapping Type, which must be specified as an extension method.
    ///
    /// For example, use `.Direct()` to specify a DirectAssignment mapping.
    /// </summary>
    public MappingDefinition ToSdkField<TModel>(Expression<Func<TModel, object>> sdkModelFieldFunc)
    {
        var fieldPath = sdkModelFieldFunc.Body.Normalize();
        if (fieldPath.Contains('.'))
        {
            // TODO: implement this
            throw new NotSupportedException("nested fields are not yet supported as expressions");
        }
        return new MappingDefinition
        {
            FromSchemaModelName = FromModel,
            FromSchemaPath = FromFieldPath,
            ToSdkModelName = typeof(TModel).Name,
            ToSdkFieldPath = fieldPath,
        };
    }
}