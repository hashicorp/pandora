package repositories

type ServiceType string
type ApiDefinitionSource string

const (
	MicrosoftGraphV1BetaServiceType   ServiceType = "microsoft-graph-beta"
	MicrosoftGraphV1StableServiceType ServiceType = "microsoft-graph-v1-stable"
	ResourceManagerServiceType        ServiceType = "resource-manager"

	HandWrittenApiDefinitionsSource                 ApiDefinitionSource = "HandWritten"
	MicrosoftGraphMetadataApiDefinitionsSource      ApiDefinitionSource = "MicrosoftGraphMetadata"
	ResourceManagerRestApiSpecsApiDefinitionsSource ApiDefinitionSource = "ResourceManagerRestApiSpecs"
)

type ServiceDetails struct {
	Name                 string
	ApiVersions          map[string]*ServiceApiVersionDetails
	Generate             bool
	ResourceProvider     string
	TerraformPackageName *string
}

type ServiceApiVersionDetails struct {
	Name      string
	Generate  bool
	Resources map[string]*ServiceApiVersionResourceDetails
	Source    ApiDefinitionSource
}

type ServiceApiVersionResourceDetails struct {
	// TODO: impl.
}
