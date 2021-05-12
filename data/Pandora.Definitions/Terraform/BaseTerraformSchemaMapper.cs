using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.Terraform
{
    public abstract class BaseTerraformSchemaMapper : TerraformSchemaMapper
    {
        public abstract List<Mapping> GetMappings();

        protected static Mapping MapProperty<Schema, Object>(Expression<Func<Schema, object>> schema, Expression<Func<Object, object>> obj)
        {
            var schemaMapping = NormalizeMappingExpression(schema.Body);
            var objectMapping = NormalizeMappingExpression(obj.Body);

            return new Mapping
            {
                Schema = new MappingDetails
                {
                    Model = typeof(Schema).Name,
                    Field = schemaMapping
                },
                Object = new MappingDetails{
                    Field = objectMapping,
                    Model = typeof(Object).Name
                }
            };
        }

        private static string NormalizeMappingExpression(Expression input)
        {
            var val = input.ToString();
            // val will be `s.Foo.Bar` - so trim whatever label we've given it
            var dot = val.IndexOf(".");
            // then we should have `Foo.Bar`
            return val.Substring(dot +1);
        }
    }
}