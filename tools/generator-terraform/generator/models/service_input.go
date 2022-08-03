package models

type ServiceInput struct {
	// ApiVersion is the API Version used for this Service
	ApiVersion string

	// CategoryNames is a slice of Category Names the Data Sources and Resources contain.
	CategoryNames []string

	// DataSourceNames is a slice of the names of the Data Sources which should be output.
	DataSourceNames []string

	// ProviderPrefix is the prefix used for the Resources within this Terraform Provider.
	ProviderPrefix string

	// RootDirectory is the path to the directory where generated files should be output.
	RootDirectory string

	// ResourceNames is a slice of the names of the Resources which should be output.
	ResourceNames []string

	// SdkServiceName is the name of this Service within the Go-SDK.
	SdkServiceName string

	// ServiceDisplayName is the human/friendly name of this Service.
	ServiceDisplayName string

	// ServicePackageName is the name of the Service Package for this Service.
	ServicePackageName string
}
