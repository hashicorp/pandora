// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package pipeline

import (
	"fmt"
	"os"
	"sort"

	"github.com/hashicorp/pandora/tools/data-api-repository/repository"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/logging"
)

func RunValidate(opts Options) error {
	logging.Info("Validating Data..")

	logging.Debug("Building the repository..")
	repo, err := repository.NewRepository(opts.RestAPISpecsDirectory, opts.SourceDataType, &opts.ServiceNamesToLimitTo, logging.Log)
	if err != nil {
		return fmt.Errorf("building repository: %+v", err)
	}
	logging.Debug("Completed - Building the repository.")

	p := &Pipeline{
		opts:       opts,
		repository: repo,
	}

	logging.Info("Loading the Configuration Files..")
	if err := p.loadConfigurationFiles(); err != nil {
		return fmt.Errorf("loading the Configuration Files: %+v", err)
	}

	serviceNamesToResults := make(map[string]validationResult)
	for _, service := range p.servicesFromConfigurationFiles {
		logging.Infof("Parsing the Data for Service %q..", service.Name)
		data, err := p.parseDataForService(service)
		if err != nil {
			serviceNamesToResults[service.Name] = validationResult{
				succeeded: false,
				error:     err.Error(),
			}
			continue
		}

		serviceNamesToResults[service.Name] = validationResult{
			succeeded: true,
			summary:   fmt.Sprintf("%d API Versions", len(data.APIVersions)),
		}
	}
	serviceNames := make([]string, 0)
	succeeded := true
	for serviceName, service := range serviceNamesToResults {
		serviceNames = append(serviceNames, serviceName)

		if !service.succeeded {
			succeeded = false
		}
	}
	sort.Strings(serviceNames)

	logging.Info("Validation Results:")
	for _, serviceName := range serviceNames {
		result := serviceNamesToResults[serviceName]
		if result.succeeded {
			logging.Infof("✅ Service %q - %s", serviceName, result.summary)
		} else {
			logging.Infof("❌ Service %q - %s", serviceName, result.error)
		}
	}

	if !succeeded {
		os.Exit(1)
	}
	return nil
}

type validationResult struct {
	succeeded bool
	error     string
	summary   string
}
