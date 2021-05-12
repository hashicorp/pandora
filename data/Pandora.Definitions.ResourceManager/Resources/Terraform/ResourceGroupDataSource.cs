using System.Collections.Generic;
using System.ComponentModel;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Terraform;

namespace Pandora.Definitions.ResourceManager.Resources.Terraform
{
    public class ResourceGroupDataSource : TerraformResourceDefinition
    {
        public string ResourceName => "azurerm_resource_group";
        public TerraformResourceType ResourceType => TerraformResourceType.DataSource;
        public bool Generate => true;
        public ApiDefinition Api => new v2018_05_01.ResourceGroup.Definition();
        public TerraformSchemaDefinition Schema => new ResourceGroupDataSourceSchema();
        
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
            new ResourceGroupDataSourceReadTerraformFunction(),
        };

        public List<TerraformSchemaTestDefinition> Tests => new List<TerraformSchemaTestDefinition>
        {
            new ResourceGroupDataSourceBasicTest()
        };
        
        private class ResourceGroupDataSourceSchema : TerraformSchemaDefinition
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
            [Computed]
            public Tags Tags { get; set; }
        }

        private class ResourceGroupDataSourceReadTerraformFunction : TerraformFunctionDefinition
        {
            public int DefaultTimeoutInMinutes => 5;
            public FunctionType Type => FunctionType.DataSourceRead;
            public List<ApiReference> Operations => new List<ApiReference>
            {
                new ApiReference
                {
                    ApiDefinition = new v2018_05_01.ResourceGroup.Definition(),
                    Operation = new v2018_05_01.ResourceGroup.Get(), 
                }
            };

            public TerraformSchemaMapper? SchemaMapper => new ResourceGroupDataSourceSchemaMapper();
        }

        private class ResourceGroupDataSourceBasicTest : TerraformSchemaTestDefinition
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

data ""azurerm_resource_group"" ""test"" {{
  name = azurerm_resource_group.test.name
}}
                        "; 
                    }),
                }
            };
        }

        private class ResourceGroupDataSourceSchemaMapper : BaseTerraformSchemaMapper
        {
            public override List<Mapping> GetMappings()
            {
                return new List<Mapping>
                {
                    MapProperty<ResourceGroupDataSourceSchema, v2018_05_01.ResourceGroup.GetResourceGroup>(s => s.Name, r => r.Name),
                    MapProperty<ResourceGroupDataSourceSchema, v2018_05_01.ResourceGroup.GetResourceGroup>(s => s.Location, r => r.Location),
                    MapProperty<ResourceGroupDataSourceSchema, v2018_05_01.ResourceGroup.GetResourceGroup>(s => s.Tags, r => r.Tags),
                };
            }
        }
    }
}