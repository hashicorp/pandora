package dataapigenerator

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func codeForTerraformSchemaDefinition(terraformNamespace string, details resourcemanager.TerraformResourceDetails) string {
	// TODO: output the real schema
	return fmt.Sprintf(`using Pandora.Definitions.Attributes;

namespace %[1]s;

public class %[2]sResourceSchema
{
	// TODO: populate with a real schema

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
}
`, terraformNamespace, details.ResourceName)
}
