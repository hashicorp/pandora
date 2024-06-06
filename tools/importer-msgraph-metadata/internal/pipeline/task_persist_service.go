package pipeline

import (
	"fmt"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api-repository/repository"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func (p pipelineForService) persistApiDefinitions(sdkServices map[string]sdkModels.Service, commonTypes map[string]sdkModels.CommonTypes) error {
	for serviceName, service := range sdkServices {
		p.logger.Info(fmt.Sprintf("persisting API Definitions for Service %q..", serviceName))

		opts := repository.SaveServiceOptions{
			CommonTypes:      commonTypes,
			Service:          service,
			ServiceName:      serviceName,
			SourceCommitSHA:  pointer.To(p.metadataGitSha),
			SourceDataOrigin: sdkModels.MicrosoftGraphMetaDataSourceDataOrigin,
			SourceDataType:   sdkModels.MicrosoftGraphSourceDataType,
		}

		if err := p.repo.SaveService(opts); err != nil {
			return fmt.Errorf("persisting Data API Definitions for Service %q: %+v", serviceName, err)
		}
	}

	return nil
}
