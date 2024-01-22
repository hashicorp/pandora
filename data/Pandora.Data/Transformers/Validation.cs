// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Linq;
using System.Reflection;
using Pandora.Data.Models;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using ValidationDefinition = Pandora.Data.Models.ValidationDefinition;

namespace Pandora.Data.Transformers;

public static class Validation
{
    public static Models.ValidationDefinition? Map(PropertyInfo input)
    {
        try
        {
            // TODO: let's change this to be a range attribute, rather than a combo attribute?
            var optional = input.GetCustomAttribute<FieldValidationAttribute>();
            if (optional == null)
            {
                return null;
            }

            var definition = optional.Definition();
            return new Models.ValidationDefinition
            {
                ValidationType = MapValidationType(definition.ValidationType),
                Values = definition.Values,
            };
        }
        catch (Exception ex)
        {
            throw new Exception($"Mapping Validation {input.Name}", ex);
        }
    }


    private static ValidationType MapValidationType(FieldValidationType input)
    {
        switch (input)
        {
            case FieldValidationType.Range:
                return ValidationType.Range;

            default:
                throw new NotSupportedException($"unsupported validation type {input.ToString()}");
        }
    }
}