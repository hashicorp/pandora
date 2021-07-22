using System;
using System.Collections.Generic;

namespace Pandora.Definitions.Attributes
{
    public class FieldValidationAttribute : Attribute
    {
        public FieldValidationType Type { get; set; }

        public int StartRange { get; set; }

        public int EndRange { get; set; }

        public ValidationDefinition Definition()
        {
            switch (Type)
            {
                case FieldValidationType.Range:
                    return new ValidationDefinition
                    {
                        ValidationType = FieldValidationType.Range,
                        Values = new List<object>
                        {
                            StartRange,
                            EndRange
                        }
                    };

                default:
                    throw new NotSupportedException($"unsupported validation type {Type.ToString()}");
            }
        }
    }

    public enum FieldValidationType
    {
        Range,

        // TODO: support for MaxLength in the API & Generator
        MaxLength,
        Regex,
        Location // for where something is only supported in certain locations
    }

    public class ValidationDefinition
    {
        public FieldValidationType ValidationType { get; set; }

        public List<object>? Values { get; set; }
    }
}