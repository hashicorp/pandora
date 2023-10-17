package dataapigeneratorjson

import (
	"github.com/hashicorp/go-hclog"
)

type Generator struct {
	apiVersionPackageName         string
	logger                        hclog.Logger
	outputDirectory               string
	resourceProvider              *string
	serviceName                   string
	swaggerGitSha                 string
	terraformPackageName          *string
	workingDirectoryForService    string
	workingDirectoryForApiVersion string
	workingDirectoryForTerraform  string
}
