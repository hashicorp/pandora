// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package pipeline

import (
	"fmt"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/data-api-repository/repository"
)

type RunInput struct {
	ProviderPrefix string

	Logger hclog.Logger

	CommonTypesDirectoryName string
	ConfigFilePath           string
	MetadataDirectory        string
	OpenApiFilePattern       string
	OutputDirectory          string
	Repo                     repository.Repository
	Services                 []string
}

func Run(input RunInput) error {
	logger := input.Logger

	metadataGitSha, err := determineGitSha(input.MetadataDirectory, logger)
	if err != nil {
		return fmt.Errorf("determining Git SHA at %q: %+v", input.MetadataDirectory, err)
	}

	return runImporter(input, *metadataGitSha)
}
