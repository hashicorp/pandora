package pipeline

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/data-api-repository/repository"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func (p pipelineForService) persistApiDefinitions(sdkServices map[string]sdkModels.Service, commonTypes map[string]sdkModels.CommonTypes) error {
	for serviceName, service := range sdkServices {
		for version := range service.APIVersions {
			p.logger.Debug(fmt.Sprintf("removing any existing API Definitions for the Service %q with Version %q", serviceName, version))

			removeServiceOpts := repository.RemoveServiceOptions{
				ServiceName:      serviceName,
				SourceDataOrigin: sdkModels.MicrosoftGraphMetaDataSourceDataOrigin,
				SourceDataType:   sdkModels.MicrosoftGraphSourceDataType,
				Version:          version,
			}

			if err := p.repo.RemoveService(removeServiceOpts); err != nil {
				return fmt.Errorf("removing existing API Definitions for Service %q with Version %q: %+v", serviceName, version, err)
			}
		}

		p.logger.Info(fmt.Sprintf("persisting API Definitions for Service %q..", serviceName))

		opts := repository.SaveServiceOptions{
			CommonTypes:      commonTypes,
			Service:          service,
			ServiceName:      serviceName,
			SourceCommitSHA:  pointerTo(p.metadataGitSha),
			SourceDataOrigin: sdkModels.MicrosoftGraphMetaDataSourceDataOrigin,
			SourceDataType:   sdkModels.MicrosoftGraphSourceDataType,
		}

		if err := p.repo.SaveService(opts); err != nil {
			return fmt.Errorf("persisting Data API Definitions for Service %q: %+v", serviceName, err)
		}
	}

	return nil
}
