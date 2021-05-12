using System;
using System.Collections.Generic;
using System.Linq;
using Pandora.Data.Models;

namespace Pandora.Data.Transformers
{
    public static class SchemaModelDefinition
    {
        public static IEnumerable<TerraformModelDefinition> Map(Type input)
        {
            var models = new List<TerraformModelDefinition>();
            
            // TODO: recursively go through the properties finding any models then map them into one big list
            foreach (var property in input.GetProperties())
            {
                if (property.PropertyType.IsGenericType)
                {
                    var typeDef = property.PropertyType.GetGenericTypeDefinition();
                    if (typeDef != typeof(HashSet<>) && typeDef != typeof(List<>)) {
                        throw new NotSupportedException("Generic types have to be HashSets or Lists");
                    }
                    
                    var innerType = property.PropertyType.GetGenericArguments()[0];
                    var innerTypeModels = Map(innerType);
                    models.AddRange(innerTypeModels);
                }

                if (typeof(Definitions.Interfaces.TerraformSchemaDefinition).IsAssignableFrom(property.PropertyType))
                {
                    var propertiesForType = property.PropertyType.GetProperties();
                    var fields = propertiesForType.Select(SchemaFieldDefinition.Map).ToList();
                    models.Add(new TerraformModelDefinition
                    {
                        Name = property.PropertyType.Name,
                        Fields = fields,
                    });
                }
            }

            return models;
        }
    }
}