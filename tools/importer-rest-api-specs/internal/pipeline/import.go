// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package pipeline

import (
	"context"
	"fmt"
	"runtime"

	"github.com/hashicorp/pandora/tools/data-api-repository/repository"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/terraform"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/logging"
	"golang.org/x/sync/errgroup"
)

func RunImporter(opts Options) error {
	logging.Info("Importing Data..")

	logging.Debug("Building the repository..")
	repo, err := repository.NewRepository(opts.APIDefinitionsDirectory, opts.SourceDataType, &opts.ServiceNamesToLimitTo, logging.Log)
	if err != nil {
		return fmt.Errorf("building repository: %+v", err)
	}
	logging.Debug("Completed - Building the repository.")

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

	logging.Info("Loading the Configuration Files..")
	if err := p.loadConfigurationFiles(); err != nil {
		return fmt.Errorf("loading the Configuration Files: %+v", err)
	}

	logging.Debug("Clearing any existing API Definitions..")
	if err := p.clearExistingAPIDefinitions(); err != nil {
		return fmt.Errorf("clearing the existing API Definitions within %q: %+v", opts.APIDefinitionsDirectory, err)
	}
	logging.Debug("Completed - Clearing any existing API Definitions.")

	logging.Infof("Processing %d Services..", len(p.servicesFromConfigurationFiles))

	g, ctx := errgroup.WithContext(context.Background())
	semaphore := make(chan struct{}, runtime.NumCPU())

	for threadId, service := range p.servicesFromConfigurationFiles {
		service := service

		if len(opts.ServiceNamesToLimitTo) > 0 {
			processThisService := false
			for _, serviceNameToLimitTo := range opts.ServiceNamesToLimitTo {
				if service.Name == serviceNameToLimitTo {
					processThisService = true
					break
				}
			}
			if !processThisService {
				logging.Infof("ThreadID: %d - Skipping the Service %q..", threadId, service.Name)
				continue
			}
		}

		g.Go(func() error {
			select {
			case semaphore <- struct{}{}:
			case <-ctx.Done():
				return ctx.Err()
			}
			defer func() { <-semaphore }()

			logging.Infof("ThreadID: %d - Discovering the Data for Service %q..", threadId, service.Name)
			data, err := p.parseDataForService(service, threadId)
			if err != nil {
				return fmt.Errorf("parsing Data for the Service %q: %+v", service.Name, err)
			}
			logging.Debugf("ThreadID: %d - Completed - Discovering the Data for Service %q.", threadId, service.Name)

			terraformDetails, ok := p.servicesToTerraformDetails[service.Name]
			if ok {
				logging.Infof("ThreadID: %d - Building the Terraform Data for the Service %q..", threadId, service.Name)
				data, err = terraform.BuildForService(*data, terraformDetails.resourceLabelToResourceDefinitions, p.opts.ProviderPrefix, terraformDetails.terraformPackageName)
				if err != nil {
					return fmt.Errorf("building the Terraform Data for Service %q: %+v", service.Name, err)
				}
				logging.Debugf("ThreadID: %d - Completed - Building the Terraform Data for the Service %q.", threadId, service.Name)
			} else {
				logging.Debugf("ThreadID: %d - Skipping - no Terraform Definitions for the Service %q..", threadId, service.Name)
			}

			logging.Infof("ThreadID: %d - Writing Data for Service %q..", threadId, service.Name)
			saveServiceOpts := repository.SaveServiceOptions{
				ResourceProvider: service.ResourceProvider,
				Service:          *data,
				ServiceName:      service.Name,
				SourceCommitSHA:  restAPISpecsCommitSHA,
				SourceDataOrigin: p.opts.SourceDataOrigin,
			}
			if err := p.repository.SaveService(saveServiceOpts, threadId); err != nil {
				return fmt.Errorf("saving the Service %q: %+v", service.Name, err)
			}
			logging.Debugf("ThreadID: %d - Completed - writing Data for Service %q.", threadId, service.Name)

			return nil
		})
	}

	if err := g.Wait(); err != nil {
		return err
	}

	logging.Info("Completed - Importing Data.")
	return nil
}
