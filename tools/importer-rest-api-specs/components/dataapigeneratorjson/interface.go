package dataapigeneratorjson

import (
	"github.com/hashicorp/go-hclog"
)

type Generator struct {
	outputDirectory                   string
	resourceProvider                  *string
	serviceName                       string
	terraformPackageName              *string
	workingDirectoryForService        string
	workingDirectoryForApiVersion     string
	workingDirectoryForTerraform      string
	workingDirectoryForTerraformTests string

	// TODO: pass this into methods as needed, so that we can ensure the logger is always named as required?
	logger hclog.Logger
}
