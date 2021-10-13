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
                // first find all of the types within these types
                var types = FindTypesWithinType(input, new List<Type>());
                var mappedTypes = types.Select(t => MapTypeToModelDefinition(t, types));
                return mappedTypes.Distinct(new ModelComparer()).OrderBy(m => m.Name).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Mapping Models from Model {input.FullName}", ex);
            }
        }

        private static List<Type> FindTypesWithinType(Type input, List<Type> knownTypes)
        {
            // find the top level model - if it's a List of a List or something find the Type
            var innerType = input.GetActualType();
            var foundTypes = new List<Type>();

            // for example if it's a built-in, custom or enum type there's nothing to map
            if (innerType == null)
            {
                return foundTypes;
            }

            foundTypes.Add(innerType);

            // whilst this looks superflurous - discriminated types can be Request/Response objects so won't get
            // pulled out the traditional way - and since these are de-duped below this is "fine"
            var parentType = PullOutParentType(innerType, knownTypes);
            if (parentType != null)
            {
                foundTypes.Add(parentType);
            }

            var allTypes = new List<Type>();
            allTypes.AddRange(knownTypes);
            allTypes.AddRange(foundTypes);

            // find all of the Types used within the Properties and any Discriminators applicable this Type, which we don't know about
            var typesWithinProperties = FindTypesWithinPropertiesForType(innerType, allTypes);
            foundTypes.AddRange(typesWithinProperties);
            foundTypes = foundTypes.Distinct(new TypeComparer()).OrderBy(t => t.FullName).ToList();

            // now that we have all of the types for that type, let's iterate over _all_ of the types and process each of them
            var processedTypes = new Dictionary<string, bool> { { innerType.FullName, true } };
            while (true)
            {
                var typesToFind = foundTypes.Where(ft => !processedTypes.ContainsKey(ft.FullName)).ToList();
                if (!typesToFind.Any())
                {
                    break;
                }

                allTypes = new List<Type>();
                allTypes.AddRange(knownTypes);
                allTypes.AddRange(typesToFind);

                var newlyFoundTypes = new List<Type>();
                foreach (var type in typesToFind)
                {
                    processedTypes.Add(type.FullName, true);

                    var nestedTypesWithinProperties = FindTypesWithinPropertiesForType(type, allTypes);
                    foundTypes.AddRange(typesWithinProperties);
                    foundTypes = foundTypes.Distinct(new TypeComparer()).OrderBy(t => t.FullName).ToList();
                    newlyFoundTypes.AddRange(nestedTypesWithinProperties);
                }

                foundTypes.AddRange(newlyFoundTypes);
                foundTypes = foundTypes.Distinct(new TypeComparer()).OrderBy(t => t.FullName).ToList();
            }

            // finally re-distinct them
            foundTypes = foundTypes.Distinct(new TypeComparer()).OrderBy(t => t.FullName).ToList();
            return foundTypes;
        }

        private static List<Type> FindTypesWithinPropertiesForType(Type input, List<Type> knownTypes)
        {
            var foundTypes = new List<Type>();

            // find all of the types used by properties in this model
            // NOTE: discriminated types within properties are discovered below
            foreach (var property in input.GetProperties())
            {
                var elementType = property.PropertyType.GetActualType();
                // for example if it's a built-in, custom or enum type there's nothing to map
                if (elementType == null)
                {
                    continue;
                }

                foundTypes.Add(elementType);

                // whilst this looks superflurous - discriminated types can be Request/Response objects so won't get
                // pulled out the traditional way - and since these are de-duped below this is "fine"
                var parentType = PullOutParentType(elementType, knownTypes);
                if (parentType != null)
                {
                    foundTypes.Add(parentType);
                }
            }

            // now that we've got these, distinct them in-case the same type appears multiple types
            foundTypes = foundTypes.Distinct(new TypeComparer()).OrderBy(t => t.FullName).ToList();

            // find all of the implementations for these types
            var typesToFindImplementationsFor = foundTypes.Where(t => knownTypes.All(kt => t.FullName != kt.FullName)).ToList();
            var implementations = FindImplementationsForTypes(typesToFindImplementationsFor);
            foreach (var implementation in implementations)
            {
                // pass the list of known models along to avoid circular references
                var allTypes = new List<Type>();
                allTypes.AddRange(knownTypes);
                allTypes.AddRange(foundTypes);

                // check to see if we've already looked up this type, if so, skip it.
                // this avoids circular references.
                if (allTypes.Any(t => t.FullName == implementation.FullName))
                {
                    continue;
                }

                var typesForImplementation = FindTypesWithinType(implementation, allTypes);
                foundTypes.AddRange(typesForImplementation);
                // re-distinct them
                foundTypes = foundTypes.Distinct(new TypeComparer()).OrderBy(t => t.FullName).ToList();
            }

            return foundTypes;
        }

        private static Type? PullOutParentType(Type input, List<Type> knownTypes)
        {
            var attr = input.GetCustomAttribute<ValueForTypeAttribute>();
            if (attr != null)
            {
                var baseType = input.BaseType.GetActualType();
                if (baseType != null && knownTypes.All(t => t.FullName != input.BaseType.FullName))
                {
                    return baseType;
                }
            }

            return null;
        }

        private static IEnumerable<Type> FindImplementationsForTypes(List<Type> input)
        {
            var newTypes = new List<Type>();
            foreach (var type in input)
            {
                if (!type.IsAbstract)
                {
                    continue;
                }

                var implementations = ImplementationsForType(type);
                foreach (var impl in implementations)
                {
                    // if we know about it, skip it
                    if (input.Any(t => t.FullName == impl.FullName))
                    {
                        continue;
                    }

                    newTypes.Add(impl);

                    var allTypes = new List<Type>();
                    allTypes.AddRange(input);
                    allTypes.AddRange(newTypes);

                    // then find all of the types used by that type
                    var typesUsedByImpl = FindTypesWithinType(impl, allTypes);
                    newTypes.AddRange(typesUsedByImpl);
                }
            }

            return newTypes;
        }

        /// <summary>
        /// MapTypeToModelDefinition takes a top-level type (e.g. Model from List<Model>) and
        /// returns a ModelDefinition for it
        /// </summary>
        private static ModelDefinition MapTypeToModelDefinition(Type input, List<Type> allTypes)
        {
            try
            {
                var properties = input.GetProperties().Select(p => Property.Map(p, input.FullName!)).ToList();

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
                    // 1: ensure we've mapped the parent type out - the ProvidesTypeHint check will be performed above
                    var baseTypeIsKnown = allTypes.FirstOrDefault(t => t.FullName == input.BaseType.FullName);
                    if (baseTypeIsKnown == null)
                    {
                        throw new NotSupportedException($"Base Type {input.BaseType.FullName} for {input.FullName} was not found in the allTypes list");
                    }

                    // 2: sanity checking: ensure one, and only one, of the fields has the DiscriminatesUsing field
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

        /// <summary>
        /// ImplementationsForType finds all of the implementations for this type, which assumes that
        /// this type is a Discriminator (represented as an Abstract Class) 
        /// </summary>
        private static List<Type> ImplementationsForType(Type input)
        {
            // 1: sanity checking: ensure one, and only one, of the fields has the DiscriminatesUsing field
            var propsWithTypeHints = PropertiesContainingTypeHints(input);
            if (propsWithTypeHints.Count != 1)
            {
                throw new NotSupportedException($"Exactly one attribute within {input.FullName} needs to contain the [ProvidesTypeHint] Attribute");
            }

            // 2: find all of the implementations for this type
            var allTypes = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes());
            var implementations = allTypes.Where(t => t.IsAssignableTo(input) && !t.IsAbstract && !t.IsInterface).ToList();
            return implementations;
        }

        private static List<PropertyInfo> PropertiesContainingTypeHints(Type input)
        {
            return input.GetProperties().Where(p => p.HasAttribute<ProvidesTypeHintAttribute>()).ToList();
        }

        // ---

        private static IEnumerable<ModelDefinition> MapObjectLegacy(Type input)
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

                        // we're not concerned with the wrapper list/dictionary - just find the model
                        var innerType = property.PropertyType.GetGenericArguments()[0];
                        while (innerType.IsGenericType)
                        {
                            innerType = innerType.GetGenericArguments()[0];
                        }

                        // e.g. List<string>
                        if (!innerType.IsNativeType())
                        {
                            if (innerType.FullName != input.FullName)
                            {
                                var mappedInner = MapObjectLegacy(innerType);
                                models.AddRange(mappedInner);
                            }
                        }
                    }
                    else if (property.PropertyType.IsClass && !property.PropertyType.IsEnum &&
                             !property.PropertyType.IsNativeType() &&
                             !property.PropertyType.IsPandoraCustomType())
                    {
                        if (property.PropertyType.FullName != input.FullName)
                        {
                            models.AddRange(MapObjectLegacy(property.PropertyType));
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
                        var modelName = implementation.Name.RemoveSuffixFromTypeName();
                        var mappedImplementations = MapObjectLegacy(implementation);

                        foreach (var mappedImplementation in mappedImplementations)
                        {
                            if (mappedImplementation.Name == modelName)
                            {
                                var parentName = input.Name.RemoveSuffixFromTypeName();
                                mappedImplementation.ParentTypeName = parentName;
                            }

                            models.Add(mappedImplementation);
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
