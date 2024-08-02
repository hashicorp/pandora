// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package pipeline

import (
	"github.com/getkin/kin-openapi/openapi3"
	"github.com/hashicorp/pandora/tools/data-api-repository/repository"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/parser"
)

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
