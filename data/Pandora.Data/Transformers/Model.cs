// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Pandora.Data.Helpers;
using Pandora.Data.Models;
using Pandora.Definitions.Attributes;

namespace Pandora.Data.Transformers;

public static class Model
{
    public static ModelDefinition? Map(Type input)
    {
        // Rather than recursively looking up the Models used by this model, all of the Models used within an
        // API Definition must be defined within the associated Definition, thus we can simply map the model.
        try
        {
            var innerType = input.GetActualType(false);
            if (innerType != null)
            {
                return MapTypeToModelDefinition(innerType);
            }
            return null;
        }
        catch (Exception ex)
        {
            throw new Exception($"Mapping Models from Model {input.FullName}", ex);
        }
    }


    /// <summary>
    /// MapTypeToModelDefinition takes a top-level type (e.g. Model from List<Model>) and
    /// returns a ModelDefinition for it
    /// </summary>
    private static ModelDefinition MapTypeToModelDefinition(Type input)
    {
        try
        {
            var properties = input.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public).Select(p => Property.Map(p, input.FullName!)).ToList();

            var name = input.Name.RemoveModelSuffixFromTypeName();
            var model = new ModelDefinition
            {
                Name = name,
                Properties = properties.OrderBy(p => p.Name).ToList(),
            };

            // if it's an Abstract class (e.g. Discriminated Parent Type) find the field
            if (input.IsAbstract)
            {
                // 1: sanity checking: ensure one, and only one, of the fields has the DiscriminatesUsing field
                var propsWithTypeHints = PropertiesContainingTypeHints(input);
                if (propsWithTypeHints.Count != 1)
                {
                    throw new NotSupportedException($"Exactly one attribute within {input.FullName} needs to contain the [ProvidesTypeHint] Attribute");
                }
                model.TypeHintIn = propsWithTypeHints.First().Name;
            }

            // this is an Implementation of a Discriminator - so we should pull out the parent type & discriminator value
            var attr = input.GetCustomAttribute<ValueForTypeAttribute>();
            if (attr != null)
            {
                // 1: sanity checking: ensure one, and only one, of the fields has the DiscriminatesUsing field
                var propsWithTypeHints = PropertiesContainingTypeHints(input.BaseType);
                if (propsWithTypeHints.Count != 1)
                {
                    throw new NotSupportedException($"Exactly one attribute within {input.BaseType.FullName} needs to contain the [ProvidesTypeHint] Attribute");
                }
                model.TypeHintIn = propsWithTypeHints.First().Name;
                model.ParentTypeName = input.BaseType.Name.RemoveModelSuffixFromTypeName();

                if (attr == null)
                {
                    throw new NotSupportedException($"Type {input.FullName} is missing a [ValueForType] Attribute");
                }

                model.TypeHintValue = attr.Value;
            }

            return model;
        }
        catch (Exception ex)
        {
            throw new Exception($"Mapping Model {input.FullName}", ex);
        }
    }

    private static List<PropertyInfo> PropertiesContainingTypeHints(Type input)
    {
        return input.GetProperties().Where(p => p.HasAttribute<ProvidesTypeHintAttribute>()).ToList();
    }
}