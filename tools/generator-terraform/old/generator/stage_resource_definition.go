package generator

import "fmt"

var _ stage = resourceDefinitionStage{}

type resourceDefinitionStage struct {
}

func (r resourceDefinitionStage) applicable(data *Data) bool {
	return data.IsResource
}

func (r resourceDefinitionStage) filePath(data Data) string {
	return fmt.Sprintf("%s.go", data.fileNamePrefix)
}

func (r resourceDefinitionStage) generate(data Data) (*string, error) {
	contents := fmt.Sprintf(`package %[1]s

import (
	tfsdk "github.com/terraform-providers/terraform-provider-azurerm/azurerm/internal/sdk"
	gosdk "github.com/terraform-providers/terraform-provider-azurerm/azurerm/internal/services/%[1]s/sdk"
	"github.com/terraform-providers/terraform-provider-azurerm/azurerm/internal/tf/pluginsdk"
)

var _ tfsdk.Resource = %[2]sResource{}

type %[2]sResource struct{}

func (r %[2]sResource) IDValidationFunc() pluginsdk.SchemaValidateFunc {
	return nil // TODO
}

func (r %[2]sResource) ModelObject() interface{} {
	return %[2]sResourceModel{}
}

func (r %[2]sResource) ResourceType() string {
	return %[3]q
}
`, data.PackageName, data.ResourceName, data.ResourceType)
	return &contents, nil
}
