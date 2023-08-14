package models

type ServiceDetails struct {
	// ResourceProvider is the Resource Provider this service represents
	ResourceProvider string `json:"resourceProvider,omitempty"`

	// TerraformPackageName is the name of the Service Package within
	// the Terraform Provider associated with this service.
	TerraformPackageName *string `json:"terraformPackageName,omitempty"`

	// TerraformUri is an endpoint which contains information about the Terraform
	// metadata (incl. Data Sources/Resources) for this API Version
	TerraformUri string `json:"terraformUri"`

	// Versions is a summary of the Versions available for this Service
	Versions map[string]ServiceVersion `json:"versions"`
}

type ServiceVersion struct {
	// Generate specifies whether this should be generated
	Generate bool `json:"generate"`

	// Preview specifies whether or not this is a Preview API
	Preview bool `json:"preview"`

	// Uri is a reference to more details about this Service Version
	Uri string `json:"uri"`
}
