// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package pipeline

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/data-api-repository/repository"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/terraform"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/logging"
)

func RunImporter(opts Options) error {
	logging.Infof("Importing Data..")

	logging.Debugf("Building the repository..")
	repo, err := repository.NewRepository(opts.APIDefinitionsDirectory, opts.SourceDataType, &opts.ServiceNamesToLimitTo, logging.Log)
	if err != nil {
		return fmt.Errorf("building repository: %+v", err)
	}
	logging.Debugf("Completed - Building the repository.")

	loadingMessage()

	p := &Pipeline{
		opts:       opts,
		repository: repo,
	}

	logging.Debugf("Determining the Git Commit SHA from %q..", p.opts.RestAPISpecsDirectory)
	restAPISpecsCommitSHA, err := p.determineGitCommitSHA()
	if err != nil {
		return fmt.Errorf("determining the Git Commit SHA from %q: %+v", p.opts.RestAPISpecsDirectory, err)
	}
	logging.Debugf("Completed - Determining the Git Commit SHA from %q.", p.opts.RestAPISpecsDirectory)

	logging.Infof("Loading the Configuration Files..")
	if err := p.loadConfigurationFiles(); err != nil {
		return fmt.Errorf("loading the Configuration Files: %+v", err)
	}

	logging.Debugf("Clearing any existing API Definitions..")
	if err := p.clearExistingAPIDefinitions(); err != nil {
		return fmt.Errorf("clearing the existing API Definitions within %q: %+v", opts.APIDefinitionsDirectory, err)
	}
	logging.Debugf("Completed - Clearing any existing API Definitions.")

	logging.Infof("Processing the %d Services..", len(p.servicesFromConfigurationFiles))
	for _, service := range p.servicesFromConfigurationFiles {
		if len(opts.ServiceNamesToLimitTo) > 0 {
			processThisService := false
			for _, serviceNameToLimitTo := range opts.ServiceNamesToLimitTo {
				if service.Name == serviceNameToLimitTo {
					processThisService = true
					break
				}
			}
			if !processThisService {
				logging.Infof("Skipping the Service %q..", service.Name)
				continue
			}
		}

		logging.Infof("Discovering the Data for Service %q..", service.Name)
		data, err := p.parseDataForService(service)
		if err != nil {
			return fmt.Errorf("parsing Data for the Service %q: %+v", service.Name, err)
		}
		logging.Debugf("Completed - Discovering the Data for Service %q.", service.Name)

		terraformDetails, ok := p.servicesToTerraformDetails[service.Name]
		if ok {
			logging.Infof("Building the Terraform Data for the Service %q..", service.Name)
			data, err = terraform.BuildForService(*data, terraformDetails.resourceLabelToResourceDefinitions, p.opts.ProviderPrefix, terraformDetails.terraformPackageName)
			if err != nil {
				return fmt.Errorf("building the Terraform Data for Service %q: %+v", service.Name, err)
			}
			logging.Debugf("Completed - Building the Terraform Data for the Service %q.", service.Name)
		} else {
			logging.Debugf("Skipping - no Terraform Definitions for the Service %q..", service.Name)
		}

		logging.Infof("Writing Data for Service %q..", service.Name)
		saveServiceOpts := repository.SaveServiceOptions{
			ResourceProvider: service.ResourceProvider,
			Service:          *data,
			ServiceName:      service.Name,
			SourceCommitSHA:  restAPISpecsCommitSHA,
			SourceDataOrigin: p.opts.SourceDataOrigin,
		}
		if err := p.repository.SaveService(saveServiceOpts); err != nil {
			return fmt.Errorf("saving the Service %q: %+v", service.Name, err)
		}
		logging.Debugf("Completed - writing Data for Service %q.", service.Name)
	}

	logging.Infof("Completed - Importing Data.")
	return nil
}
