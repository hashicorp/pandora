using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Terraform;

namespace Pandora.Definitions.ResourceManager.Resources.Terraform
{
    public class ResourceGroupResource : TerraformResourceDefinition
    {
        public string ResourceName => "azurerm_resource_group";
        public TerraformResourceType ResourceType => TerraformResourceType.Resource;
        public bool Generate => true;
        public ApiDefinition Api => new v2018_05_01.ResourceGroup.Definition();
        public TerraformSchemaDefinition Schema => new ResourceGroupResourceSchema();
        
        // TODO: we could potentially use Properties to build up/define the resource id, but I digress 
        public ResourceID ResourceId => new v2018_05_01.ResourceGroup.ResourceGroupId();
        public List<SchemaToResourceIdMapping> SchemaToResourceIdMappings => new List<SchemaToResourceIdMapping>
        {
            new SchemaToResourceIdMapping("SubscriptionId", SpecialFieldType.SubscriptionId),
            new SchemaToResourceIdMapping("Name", "Name"),
        };
        
        // TODO: should we also have the inverse, to set these into the state?
        
        public IEnumerable<TerraformFunctionDefinition> Functions => new List<TerraformFunctionDefinition>
        {
            new ResourceGroupResourceCreateTerraformFunction(),
            new ResourceGroupResourceReadTerraformFunction(),
            new ResourceGroupResourceDeleteTerraformFunction(),
        };

        public List<TerraformSchemaTestDefinition> Tests => new List<TerraformSchemaTestDefinition>
        {
            new ResourceGroupResourceBasicTest()
        };
        
        private class ResourceGroupResourceSchema : TerraformSchemaDefinition
        {
            [HclLabel("name")]
            [Required]
            [ForceNew]
            public string Name { get; set; }
            
            [HclLabel("location")]
            [Required]
            [ForceNew]
            public Location Location { get; set; }
        
            [HclLabel("tags")]
            [Optional]
            [Computed]
            public Tags Tags { get; set; }
        }

        private class ResourceGroupResourceCreateTerraformFunction : TerraformFunctionDefinition
        {
            public int DefaultTimeoutInMinutes => 5;
            public FunctionType Type => FunctionType.ResourceCreate;
            public List<ApiReference> Operations => new List<ApiReference>
            {
                new ApiReference
                {
                    ApiDefinition = new v2018_05_01.ResourceGroup.Definition(),
                    Operation = new v2018_05_01.ResourceGroup.Create(), 
                }
            };

            public TerraformSchemaMapper? SchemaMapper => new ResourceGroupResourceCreateSchemaMapper();
            
            private class ResourceGroupResourceCreateSchemaMapper : BaseTerraformSchemaMapper
            {
                public override List<Mapping> GetMappings()
                {
                    return new List<Mapping>
                    {
                        MapProperty<ResourceGroupResourceSchema, v2018_05_01.ResourceGroup.CreateInput>(s => s.Location, r => r.Location),
                        MapProperty<ResourceGroupResourceSchema, v2018_05_01.ResourceGroup.CreateInput>(s => s.Tags, r => r.Tags),
                    };
                }
            }
        }

        private class ResourceGroupResourceReadTerraformFunction : TerraformFunctionDefinition
        {
            public int DefaultTimeoutInMinutes => 5;
            public FunctionType Type => FunctionType.ResourceRead;
            public List<ApiReference> Operations => new List<ApiReference>
            {
                new ApiReference
                {
                    ApiDefinition = new v2018_05_01.ResourceGroup.Definition(),
                    Operation = new v2018_05_01.ResourceGroup.Get(), 
                }
            };
            public TerraformSchemaMapper? SchemaMapper => new ResourceGroupResourceReadSchemaMapper();
            
            private class ResourceGroupResourceReadSchemaMapper : BaseTerraformSchemaMapper
            {
                public override List<Mapping> GetMappings()
                {
                    return new List<Mapping>
                    {
                        MapProperty<ResourceGroupResourceSchema, v2018_05_01.ResourceGroup.GetResourceGroup>(s => s.Name, r => r.Name),
                        MapProperty<ResourceGroupResourceSchema, v2018_05_01.ResourceGroup.GetResourceGroup>(s => s.Location, r => r.Location),
                        MapProperty<ResourceGroupResourceSchema, v2018_05_01.ResourceGroup.GetResourceGroup>(s => s.Tags, r => r.Tags),
                    };
                }
            }
        }

        private class ResourceGroupResourceDeleteTerraformFunction : TerraformFunctionDefinition
        {
            public int DefaultTimeoutInMinutes => 5;
            public FunctionType Type => FunctionType.ResourceDelete;
            public List<ApiReference> Operations => new List<ApiReference>
            {
                new ApiReference
                {
                    ApiDefinition = new v2018_05_01.ResourceGroup.Definition(),
                    Operation = new v2018_05_01.ResourceGroup.Delete(), 
                }
            };
            public TerraformSchemaMapper? SchemaMapper => null;
        }

        private class ResourceGroupResourceBasicTest : TerraformSchemaTestDefinition
        {
            public string Name => "Basic";

            public List<TerraformSchemaTestData> Steps => new List<TerraformSchemaTestData>
            {
                new TerraformSchemaTestData
                {
                    ImportAfterApply = true,
                    TestConfiguration = TestConfigurationFormatter.WithHclString(delegate(TestDataFormatValues values)
                    {
                        // TODO: source from a file?
                        return @$"
resource ""azurerm_resource_group"" ""test"" {{
  name = ""acctest-{values.RandomIntegerFormat}""
  location = ""{values.PrimaryLocationFormat}""
}}
                        "; 
                    }),
                }
            };
        }
    }
}