using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Pandora.Data.Helpers;
using Pandora.Data.Models;
using Pandora.Definitions.Attributes;

namespace Pandora.Data.Transformers
{
    public static class Model
    {
        public static List<ModelDefinition> Map(Type input)
        {
            try
            {
                if (input.IsAGenericCsv())
                {
                    var valueType = input.GenericCsvElement();
                    return Map(valueType);
                }
                if (input.IsAGenericDictionary())
                {
                    var valueType = input.GenericDictionaryValueElement();
                    return Map(valueType);
                }
                if (input.IsAGenericList())
                {
                    var valueType = input.GenericListElement();
                    return Map(valueType);
                }

                if (Helpers.IsNativeType(input) || Helpers.IsPandoraCustomType(input))
                {
                    // there's no types to parse out here
                    return new List<ModelDefinition>();
                }

                return MapObject(input).Distinct(new ModelComparer()).OrderBy(m => m.Name).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Mapping Models from Model {input.FullName}", ex);
            }
        }

        private static IEnumerable<ModelDefinition> MapObject(Type input)
        {
            try
            {
                if (input.IsEnum)
                {
                    return new List<ModelDefinition>();
                }

                var models = new List<ModelDefinition>();
                var properties = new List<PropertyDefinition>();

                var props = input.GetProperties();
                foreach (var property in props)
                {
                    if (property.PropertyType.IsGenericType)
                    {
                        // if this is a list of some description, it has to be a List
                        // otherwise it could be a nilable item (e.g. Int?, Float?, Enum?)
                        var genericType = property.PropertyType.GetGenericTypeDefinition();
                        if (genericType.IsAssignableTo(typeof(IEnumerable<>)))
                        {
                            if (property.PropertyType.GetGenericTypeDefinition() != typeof(List<>))
                            {
                                throw new NotSupportedException(
                                    string.Format($"{input.FullName} - {property.Name}: Generic lists types have to be List<T>"));
                            }
                        }

                        var innerType = property.PropertyType.GetGenericArguments()[0];
                        // e.g. List<string>
                        if (!Helpers.IsNativeType(innerType))
                        {
                            if (innerType.FullName != input.FullName)
                            {
                                var mappedInner = MapObject(innerType);
                                models.AddRange(mappedInner);
                            }
                        }
                    }
                    else if (property.PropertyType.IsClass && !property.PropertyType.IsEnum &&
                             !Helpers.IsNativeType(property.PropertyType) &&
                             !Helpers.IsPandoraCustomType(property.PropertyType))
                    {
                        if (property.PropertyType.FullName != input.FullName)
                        {
                            models.AddRange(MapObject(property.PropertyType));
                        }
                    }

                    var mappedProperty = Property.Map(property, input.FullName!);
                    properties.Add(mappedProperty);
                }

                var name = input.Name.TrimSuffix("Model");
                var model = new ModelDefinition
                {
                    Name = name,
                    Properties = properties.OrderBy(p => p.Name).ToList(),
                };

                // this is an abstract class, meaning it's a Discriminated Type
                if (input.IsAbstract && !input.IsInterface)
                {
                    // 1: sanity checking: ensure one, and only one, of the fields has the DiscriminatesUsing field
                    var propsWithTypeHints = input.GetProperties().Where(p => p.HasAttribute<ProvidesTypeHintAttribute>()).ToList();
                    if (propsWithTypeHints.Count != 1)
                    {
                        throw new NotSupportedException($"Exactly one attribute within {input.FullName} needs to contain the [ProvidesTypeHint] Attribute");
                    }

                    // 2: find all of the implementations for this type
                    var allTypes = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes());
                    var implementations = allTypes.Where(t => t.IsAssignableTo(input) && !t.IsAbstract && !t.IsInterface).ToList();
                    foreach (var implementation in implementations)
                    {
                        var mappedImplementations = MapObject(implementation);
                        foreach (var mappedImpl in mappedImplementations)
                        {
                            // ensure the nested model contains the name of the parent type so this can be
                            // easily mapped across later
                            mappedImpl.ParentTypeName = input.Name.TrimSuffix("Model");
                            models.Add(mappedImpl);
                        }
                    }

                    // 3: map the property containing the type hint across
                    var propWithTypeHint = propsWithTypeHints.First();
                    model.TypeHintIn = propWithTypeHint.Name;
                }

                if (input.HasAttribute<ValueForTypeAttribute>())
                {
                    if (input.IsInterface)
                    {
                        throw new NotSupportedException($"Interface {input.FullName} may not have a [ValueForType] attribute");
                    }

                    var attr = input.GetCustomAttribute<ValueForTypeAttribute>();
                    model.TypeHintValue = attr.Value;

                    var fieldContainingTypeHint = input.GetProperties().Where(p => p.HasAttribute<ProvidesTypeHintAttribute>()).ToList();
                    if (fieldContainingTypeHint.Count != 1)
                    {
                        throw new NotSupportedException($"Exactly one attribute within {input.FullName} needs to contain the [ProvidesTypeHint] Attribute");
                    }
                    var propWithTypeHint = fieldContainingTypeHint.First();
                    model.TypeHintIn = propWithTypeHint.Name;
                }

                models.Add(model);
                return models;
            }
            catch (Exception ex)
            {
                throw new Exception($"Mapping Model {input.FullName}", ex);
            }
        }
    }
}
