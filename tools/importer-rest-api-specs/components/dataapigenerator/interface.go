package dataapigenerator

import (
	"github.com/hashicorp/go-hclog"
)

type Generator struct {
	apiVersionPackageName         string
	logger                        hclog.Logger
	namespaceForService           string
	namespaceForApiVersion        string
	namespaceForTerraform         string
	outputDirectory               string
	resourceProvider              *string
	rootNamespace                 string
	serviceName                   string
	swaggerGitSha                 string
	terraformPackageName          *string
	workingDirectoryForService    string
	workingDirectoryForApiVersion string
	workingDirectoryForTerraform  string
}
