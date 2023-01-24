package services

type Config struct {
	// Services is a slice of Services which should be imported
	Services []Service `hcl:"service,block"`
}

type Service struct {
	// Directory is the name of the Swagger directory for this Service (e.g. appconfiguration)
	Directory string `hcl:"directory,label"`

	// Name is the normalized (title-case, no spaces etc) name for this Service (e.g. AppConfiguration)
	Name string `hcl:"name"`

	// Available is a list of the Versions for this Service which should be imported
	Available []string `hcl:"available"`

	// Ignore is a list of Versions which should be Ignored for this Service
	// A version is automatically ignored if it's not defined in
	Ignore *[]string `hcl:"ignore"`

	// ResourceProvider is the name of the Resource Provider for this Service.
	// When specified, this is used to filter the Operations in the Service to only operations
	// targeting this Resource Provider.
	//
	// As a general rule - this should be left blank, at the time of writing this is only applicable
	// to the Network service, which includes operations from both the Compute and Networking Resource
	// Providers, which causes issues with ID parsing, hence this filter option to filter Compute operations.
	ResourceProvider *string `hcl:"resource_provider"`
}
