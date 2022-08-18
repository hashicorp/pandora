using System;

namespace Pandora.Definitions.Mappings;

public class Mapping
{
    public MappingExpression FromExpression { get; set; }

    public MappingExpression ToExpression { get; set; }

    public bool Manual { get; set; }

    public static Mapping FromSchema<T>(Func<T, object> func)
    {
        throw new NotImplementedException();
    }

    public Mapping ToSdkModel<T>()
    {
        throw new NotImplementedException();
    }

    public Mapping ToSdkModelField<T>(Func<T, object> func)
    {
        throw new NotImplementedException();
    }

    public Mapping WithBooleanEquals(object value)
    {
        throw new NotImplementedException();
    }

    public Mapping WithManualBinding()
    {
        throw new NotImplementedException();
    }

    public Mapping ToResourceIdSegmentNamed(string name)
    {
        throw new NotImplementedException();
    }
}

public class MappingExpression
{
    public string Path { get; set; }

    public string? BooleanWhenEquals { get; set; }
}