using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Pandora.Data.Models;

namespace Pandora.Data.Transformers
{
    public class SchemaFieldComparer : IEqualityComparer<TerraformSchemaFieldDefinition>
    {
        public bool Equals(TerraformSchemaFieldDefinition x, TerraformSchemaFieldDefinition y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return x.CaseInsensitive == y.CaseInsensitive && x.Computed == y.Computed && x.ConstantType == y.ConstantType && Equals(x.Default, y.Default) && x.FieldType == y.FieldType && x.ForceNew == y.ForceNew && x.HclLabel == y.HclLabel && x.MaxItems == y.MaxItems && x.MinItems == y.MinItems && x.ModelType == y.ModelType && x.Name == y.Name && x.Optional == y.Optional && x.Required == y.Required && Equals(x.Validation, y.Validation);
        }

        public int GetHashCode(TerraformSchemaFieldDefinition obj)
        {
            var hashCode = new HashCode();
            hashCode.Add(obj.CaseInsensitive);
            hashCode.Add(obj.Computed);
            hashCode.Add(obj.ConstantType);
            hashCode.Add(obj.Default);
            hashCode.Add((int) obj.FieldType);
            hashCode.Add(obj.ForceNew);
            hashCode.Add(obj.HclLabel);
            hashCode.Add(obj.MaxItems);
            hashCode.Add(obj.MinItems);
            hashCode.Add(obj.ModelType);
            hashCode.Add(obj.Name);
            hashCode.Add(obj.Optional);
            hashCode.Add(obj.Required);
            hashCode.Add(obj.Validation);
            return hashCode.ToHashCode();
        }
    }
}