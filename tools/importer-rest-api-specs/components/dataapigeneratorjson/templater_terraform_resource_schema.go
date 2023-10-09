package dataapigeneratorjson

import (
	"sort"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

type SchemaModel struct {
	Fields []SchemaField `json:"Fields"`
}

type SchemaField struct {
	Documentation *string `json:"Documentation,omitempty"`
	HclName       string  `json:"HclName"`
	Required      *bool   `json:"Required,omitempty"`
	ForceNew      *bool   `json:"ForceNew,omitempty"`
	// todo do I need this?
	// public KubernetesFleetManagerResourceFleetHubProfileSchema HubProfile { get; set; }
	// Name is HubProfile from the above line
	Name string `json:"Name"`
	// TerraformObjectDefinition is KubernetesFleetManagerResourceFleetHubProfileSchema from the above line
	TerraformObjectDefinition *TerraformObjectDefinition `json:"TerraformObjectDefinition,omitempty"`
}

type TerraformObjectDefinition struct {
	Type       TerraformSchemaFieldType   `json:"Type"`
	Name       string                     `json:"Name"`
	Reference  string                     `json:"Reference"`
	NestedItem *TerraformObjectDefinition `json:"TerraformObjectDefinition,omitempty"`
}

func codeForTerraformSchemaModelDefinition(terraformNamespace, name string, model resourcemanager.TerraformSchemaModelDefinition, details resourcemanager.TerraformResourceDetails, resource models.AzureApiResource, apiVersionPackageName, resourcePackageName string) ([]byte, error) {

	fieldList := make([]string, 0)
	for f := range model.Fields {
		fieldList = append(fieldList, f)
	}
	sort.Strings(fieldList)

	schemaFields := make([]SchemaField, 0)
	for _, fieldName := range fieldList {
		def := model.Fields[fieldName]

		schemaField := SchemaField{
			HclName: def.HclName,
		}

		if def.ForceNew {
			schemaField.ForceNew = &def.ForceNew
		}

		if def.Documentation.Markdown != "" {
			schemaField.Documentation = &def.Documentation.Markdown
		}
	}
}
