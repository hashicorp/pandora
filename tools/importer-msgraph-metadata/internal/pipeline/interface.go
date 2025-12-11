// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package pipeline

import (
	"fmt"

	"github.com/getkin/kin-openapi/openapi3"
	"github.com/hashicorp/pandora/tools/data-api-repository/repository"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/parser"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/internal/logging"
)

type RunInput struct {
	ProviderPrefix string

	CommonTypesDirectoryName string
	ConfigFilePath           string
	MetadataDirectory        string
	OpenApiFilePattern       string
	OutputDirectory          string
	Repo                     repository.Repository
	Services                 []string
}

func Run(input RunInput) error {
	metadataGitSha, err := determineGitSha(input.MetadataDirectory, logging.Log)
	if err != nil {
		return fmt.Errorf("determining Git SHA at %q: %+v", input.MetadataDirectory, err)
	}

	return runImporter(input, *metadataGitSha)
}

type pipeline struct {
	apiVersion      string
	constants       parser.Constants
	repo            repository.Repository
	metadataGitSha  string
	models          parser.Models
	outputDirectory string
	resources       map[string]parser.Resources
	resourceIds     parser.ResourceIds
	spec            *openapi3.T
}

type pipelineForService struct {
	pipeline
	service string
}

func (p pipeline) ForService(serviceName string) pipelineForService {
	return pipelineForService{
		pipeline: p,
		service:  serviceName,
	}
}
