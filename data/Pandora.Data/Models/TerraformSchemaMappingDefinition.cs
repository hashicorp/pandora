namespace Pandora.Data.Models
{
    public class TerraformSchemaMappingDefinition
    {
        // field paths being `Foo.Bar` to indicate the property `Bar` within the Object `Foo`
        
        public string SchemaModelName { get; set; }
        public string SchemaFieldPath { get; set; }
        public string ObjectModelName { get; set; }
        public string ObjectFieldPath { get; set; }
    }
}