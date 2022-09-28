using System.Linq.Expressions;

namespace Pandora.Definitions.Mappings;

static class ExpressionHelpers
{
    internal static string Normalize(this Expression input)
    {
        var val = input.ToString();
        // val will be `s.Foo.Bar` - so trim whatever label we've given it
        var dot = val.IndexOf(".");
        // then we should have `Foo.Bar`
        var output = val.Substring(dot + 1);
        if (output.Contains(","))
        {
            var position = output.IndexOf(",");
            output = output.Substring(0, position);
        }
        return output;
    }
}