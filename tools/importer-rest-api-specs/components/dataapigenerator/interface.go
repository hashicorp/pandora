package dataapigenerator

import "github.com/hashicorp/pandora/tools/importer-rest-api-specs/parser"

type Service struct {
	apiVersionPackageName         string
	data                          parser.ParsedData
	debugLog                      bool
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
