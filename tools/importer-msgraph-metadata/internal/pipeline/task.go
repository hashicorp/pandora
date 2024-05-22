// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package pipeline

import (
	"fmt"
	"github.com/davecgh/go-spew/spew"
	"github.com/getkin/kin-openapi/openapi3"
	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/go-hclog"
	dataapisdk "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/dataapigeneratorjson"
)

type pipelineTask struct {
	apiVersion      string
	repo            dataapigeneratorjson.Repository
	logger          hclog.Logger
	metadataGitSha  string
	outputDirectory string
	service         string
	spec            *openapi3.T
}

func (p pipelineTask) runImportForService(serviceTags []string, models Models) error {
	p.logger.Info(fmt.Sprintf("Parsing resource IDs for %q", p.service))
	resourceIds, err := p.parseResourceIDsForService()
	if err != nil {
		return err
	}

	p.logger.Info(fmt.Sprintf("Parsing resources for %q", p.service))
	resources, err := p.parseResourcesForService(resourceIds, models)
	if err != nil {
		return err
	}
	if len(resources) == 0 {
		return nil
	}

	// Consistency checks for discovered resources
	for resourceName, resource := range resources {
		if resource == nil {
			return fmt.Errorf("nil resource named %q was encountered for %q", resourceName, p.service)
		}
		if resource.Category == "" {
			path := "(no path)"
			if len(resource.Paths) > 0 {
				path = resource.Paths[0].ID()
			}
			p.logger.Warn(spew.Sprintf("Resource with no category was encountered for %q at %q: %#v", p.service, path, *resource))
		}
	}

	sdkServices, err := p.translateServiceToDataApiSdkTypes(models, resources)
	if err != nil {
		return err
	}

	for serviceName, service := range *sdkServices {
		for version := range service.APIVersions {
			p.logger.Debug(fmt.Sprintf("Removing any existing API Definitions for the Service %q with Version %q", serviceName, version))
			removeServiceOpts := dataapigeneratorjson.RemoveServiceOptions{
				ServiceName:      serviceName,
				SourceDataOrigin: dataapisdk.MicrosoftGraphMetaDataSourceDataOrigin,
				SourceDataType:   dataapisdk.MicrosoftGraphSourceDataType,
				Version:          version,
			}
			if err = p.repo.RemoveService(removeServiceOpts); err != nil {
				return fmt.Errorf("removing existing API Definitions for Service %q with Version %q: %+v", serviceName, version, err)
			}
		}

		p.logger.Info(fmt.Sprintf("Persisting API Definitions for Service %q..", serviceName))

		opts := dataapigeneratorjson.SaveServiceOptions{
			AzureRestAPISpecsGitSHA: pointer.To(p.metadataGitSha),
			ResourceProvider:        nil,
			Service:                 service,
			ServiceName:             serviceName,
			SourceDataOrigin:        dataapisdk.MicrosoftGraphMetaDataSourceDataOrigin,
			SourceDataType:          dataapisdk.MicrosoftGraphSourceDataType,
		}

		if err = p.repo.SaveService(opts); err != nil {
			//p.logger.Info("FIXME: skipping failure: %v", err)
			return fmt.Errorf("persisting Data API Definitions for Service %q: %+v", serviceName, err)
		}
	}

	return nil
}
