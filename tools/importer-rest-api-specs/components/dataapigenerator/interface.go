package dataapigenerator

import (
	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

type Service struct {
	apiVersionPackageName         string
	data                          models.AzureApiDefinition
	logger                        hclog.Logger
	namespaceForService           string
	namespaceForApiVersion        string
	namespaceForTerraform         string
	outputDirectory               string
	resourceProvider              *string
	rootNamespace                 string
	swaggerGitSha                 string
	terraformPackageName          *string
	workingDirectoryForService    string
	workingDirectoryForApiVersion string
	workingDirectoryForTerraform  string
}
