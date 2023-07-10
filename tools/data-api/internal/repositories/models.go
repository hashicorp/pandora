package repositories

type ServiceType string

const (
	MicrosoftGraphV1BetaServiceType   ServiceType = "microsoft-graph-beta"
	MicrosoftGraphV1StableServiceType ServiceType = "microsoft-graph-v1-stable"
	ResourceManagerServiceType        ServiceType = "resource-manager"
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
}

type ServiceApiVersionResourceDetails struct {
	// TODO: impl.
}
