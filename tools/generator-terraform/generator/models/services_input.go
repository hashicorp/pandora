package models

type ServicesInput struct {
	// RootDirectory is the path to the directory where generated files should be output.
	RootDirectory string

	// Services is a map of key (ServiceName) to value (ApiVersion) of the Services which
	// should be generated.
	Services map[string]ServiceInput
}
