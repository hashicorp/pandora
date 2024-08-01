// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package pipeline

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/data-api-repository/repository"
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
