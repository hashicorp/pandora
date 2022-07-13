package generator

import "fmt"

var _ stage = dataSourceDefinitionStage{}

type dataSourceDefinitionStage struct {
}

func (r dataSourceDefinitionStage) applicable(data *Data) bool {
	return !data.IsResource
}

func (r dataSourceDefinitionStage) filePath(data Data) string {
	return fmt.Sprintf("%s.go", data.fileNamePrefix)
}

func (r dataSourceDefinitionStage) generate(data Data) (*string, error) {
	contents := fmt.Sprintf(`package %[1]s

import (
	tfsdk "github.com/terraform-providers/terraform-provider-azurerm/azurerm/internal/sdk"
	gosdk "github.com/terraform-providers/terraform-provider-azurerm/azurerm/internal/services/%[1]s/sdk"
	"github.com/terraform-providers/terraform-provider-azurerm/azurerm/internal/tf/pluginsdk"
)

var _ tfsdk.DataSource = %[2]sDataSource{}

type %[2]sDataSource struct{}

func (r %[2]sDataSource) ModelObject() interface{} {
	return %[2]sDataSourceModel{}
}

func (r %[2]sDataSource) ResourceType() string {
	return %[3]q
}
`, data.PackageName, data.ResourceName, data.ResourceType)
	return &contents, nil
}
