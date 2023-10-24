package dataapigeneratorjson

import (
	"github.com/hashicorp/go-hclog"
)

type Generator struct {
	apiVersionPackageName         string
	outputDirectory               string
	resourceProvider              *string
	serviceName                   string
	swaggerGitSha                 string
	terraformPackageName          *string
	workingDirectoryForService    string
	workingDirectoryForApiVersion string
	workingDirectoryForTerraform  string

	// TODO: pass this into methods as needed, so that we can ensure the logger is always named as required?
	logger hclog.Logger
}
