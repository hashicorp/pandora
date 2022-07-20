package dataapigenerator

import "github.com/hashicorp/pandora/tools/importer-rest-api-specs/parser"

type Service struct {
	data                 parser.ParsedData
	debugLog             bool
	outputDirectory      string
	resourceProvider     *string
	rootNamespace        string
	swaggerGitSha        string
	terraformPackageName *string

	ServiceName           string
	ApiVersion            string
	ApiVersionPackageName string

	NamespaceForService    string
	NamespaceForApiVersion string
	NamespaceForTerraform  string

	WorkingDirectoryForService    string
	WorkingDirectoryForApiVersion string
	WorkingDirectoryForTerraform  string
	ResourceProvider              *string
	TerraformPackageName          *string
}
