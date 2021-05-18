using System;
using System.Collections.Generic;
using System.Linq;
using Pandora.Data.Models;

namespace Pandora.Data.Transformers
{
    public static class Model
    {
        public static List<ModelDefinition> Map(object input)
        {
            if (input.GetType().IsAGenericList())
            {
                // TODO: implement me
                throw new NotSupportedException("create a wrapper type");
            }
            
            return MapObject(input.GetType()).Distinct(new ModelComparer()).OrderBy(m => m.Name).ToList();
        }

        private static IEnumerable<ModelDefinition> MapObject(Type input)
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
                    if (property.PropertyType.GetGenericTypeDefinition() != typeof(List<>)) {
                        throw new NotSupportedException(string.Format($"{input.FullName} - {property.Name}: Generic types have to be lists"));
                    }
                    
                    var innerType = property.PropertyType.GetGenericArguments()[0];
                    models.AddRange(MapObject(innerType));
                }
                else if (property.PropertyType.IsClass && !property.PropertyType.IsEnum && !Helpers.IsNativeType(property.PropertyType) && !Helpers.IsPandoraCustomType(property.PropertyType))
                {
                    models.AddRange(MapObject(property.PropertyType));
                }

                var mappedProperty = Property.Map(property);
                properties.Add(mappedProperty);      
            }
            
            models.Add(new ModelDefinition
            {
                Name = input.Name,
                Properties = properties.OrderBy(p => p.Name).ToList(),
            });
            return models;
        }
    }
}
