using System;
using System.Linq;
using Pandora.Data.Models;

namespace Pandora.Data.Transformers
{
    public static class TerraformFunction
    {
        public static TerraformFunctionDefinition Map(Definitions.Interfaces.TerraformFunctionDefinition input)
        {
            // TODO: tests
            // protect against bad data
            if (input.Type == Definitions.Interfaces.FunctionType.Unknown)
            {
                throw new NotSupportedException($"invalid function type for {input.GetType().FullName}");
            }
            
            var functionType = MapFunctionType(input.Type);
            var mapper = TerraformSchemaMapper.Map(input.SchemaMapper);
            var operationDefinitions = input.Operations.Select(o => Operation.Map(o.Operation, o.ApiDefinition.ApiVersion, o.ApiDefinition.Name)).ToList();
            return new TerraformFunctionDefinition
            {
                DefaultTimeoutInMinutes = input.DefaultTimeoutInMinutes,
                FunctionType = functionType,
                Mapper = mapper,
                Operations = operationDefinitions,
            };
        }

        private static TerraformFunctionType MapFunctionType(Definitions.Interfaces.FunctionType input)
        {
            switch (input)
            {
                case Definitions.Interfaces.FunctionType.DataSourceRead:
                    return TerraformFunctionType.DataSourceRead;
                
                case Definitions.Interfaces.FunctionType.ResourceCreate:
                    return TerraformFunctionType.ResourceCreate;
                
                case Definitions.Interfaces.FunctionType.ResourceDelete:
                    return TerraformFunctionType.ResourceDelete;
                
                case Definitions.Interfaces.FunctionType.ResourceRead:
                    return TerraformFunctionType.ResourceRead;
                
                case Definitions.Interfaces.FunctionType.ResourceUpdate:
                    return TerraformFunctionType.ResourceUpdate;
            }
            
            throw new NotSupportedException($"Function Type {input.ToString()} is not mapped/supported");
        }
    }
}