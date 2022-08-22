package dataapigenerator

import (
	"fmt"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func codeForTerraformSchemaDefinition(terraformNamespace string, details resourcemanager.TerraformResourceDetails) string {
	// TODO: output the Field Object Definition(details.SchemaModels[""].Fields[""].ObjectDefinition
	// using the FieldObjectDefinitionType in a method basically duplicating dotNetTypeNameForCustomType
	// @mbfrahry ^^^

	// TODO: schema models are available in details.SchemaModels
	// TODO: the main schema name is available in details.SchemaModelName

	// TODO: output the real schema
	//log.Printf("[DEBUG] Details: %+v", details)
	//log.Printf("[DEBUG] Schema for %s: %+v", details.SchemaModelName, details.SchemaModels)
	return fmt.Sprintf(`using Pandora.Definitions.Attributes;

namespace %[1]s;

public class %[2]sResourceSchema
{
	// TODO: populate with a real schema hi steve

    [HclName("location")]
    [ForceNew]
    [Required]
    public CustomTypes.Location Location { get; set; }

    [HclName("name")]
    [ForceNew]
    [Required]
    public string Name { get; set; } 
    
    [HclName("tags")]
    [Optional]
    public CustomTypes.Tags Tags { get; set; }

    [HclName("host_id")]
    [Optional]
	[ForceNew]
    public string HostId { get; set; }

}
`, terraformNamespace, details.ResourceName)
}
