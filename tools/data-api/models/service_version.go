package models

type ServiceVersionDetails struct {
	// Resources is a key (Resource Name) value (ResourceSummary) pair of Resource
	// supported by this Service Version
	Resources map[string]ResourceSummary `json:"resources"`

	// Source specifies the original source used for these API Definitions
	Source ApiDefinitionsSource `json:"source"`
}

type ResourceSummary struct {
	// OperationsUri is an endpoint which contains information about the Operations
	// supported by this Resource
	OperationsUri string `json:"operationsUri"`

	// SchemaUri is an endpoint which contains information about the Schema for
	// this Resource
	SchemaUri string `json:"schemaUri"`
}

// ApiDefinitionsSource is used to indicate the original source for these API Definitions.
type ApiDefinitionsSource string

const (
	// ApiDefinitionsSourceHandWritten is used to signify that this set
	// of API Definitions was created by hand.
	ApiDefinitionsSourceHandWritten ApiDefinitionsSource = "HandWritten"

	// ApiDefinitionsSourceResourceManagerRestApiSpecs is used to signify
	// that this set of API Definitions is based on data within the Azure
	// Rest API Specs repository.
	ApiDefinitionsSourceResourceManagerRestApiSpecs ApiDefinitionsSource = "ResourceManagerRestApiSpecs"
)
