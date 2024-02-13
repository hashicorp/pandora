package models

// SourceDataType defines a type of Source Data.
type SourceDataType string

const (
	// MicrosoftGraphSourceDataType defines that this Data is related to Microsoft Graph.
	MicrosoftGraphSourceDataType SourceDataType = "microsoft-graph"

	// ResourceManagerSourceDataType defines that this Data is related to Azure Resource Manager.
	ResourceManagerSourceDataType SourceDataType = "resource-manager"
)
