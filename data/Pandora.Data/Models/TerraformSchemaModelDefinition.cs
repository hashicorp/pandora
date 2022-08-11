using System.Collections.Generic;
using System.Linq;

namespace Pandora.Data.Models;

public class TerraformSchemaModelDefinition
{
    public Dictionary<string, TerraformSchemaFieldDefinition> Fields { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj is not TerraformSchemaModelDefinition)
        {
            return false;
        }

        var other = (TerraformSchemaModelDefinition)obj;
        if (Fields.Count != other.Fields.Count)
        {
            return false;
        }

        // check both ways
        var mismatchingKeys = Fields.Where(f => other.Fields.All(of => f.Key != of.Key)).ToList();
        if (mismatchingKeys.Count > 0)
        {
            return false;
        }

        // check both ways
        mismatchingKeys = other.Fields.Where(f => Fields.All(of => f.Key != of.Key)).ToList();
        if (mismatchingKeys.Count > 0)
        {
            return false;
        }

        // finally each Field itself should match
        foreach (var field in Fields)
        {
            var matchingField = other.Fields[field.Key];
            if (!field.Value.Equals(matchingField))
            {
                return false;
            }
        }

        return true;
    }
}