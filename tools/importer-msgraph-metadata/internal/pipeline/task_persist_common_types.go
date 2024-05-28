package pipeline

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/data-api-repository/repository"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func (p pipeline) PersistCommonTypesDefinitions() error {
	p.logger.Debug(fmt.Sprintf("removing any existing Common Types Definitions with Version %q", p.apiVersion))

	removeCommonTypesOpts := repository.RemoveCommonTypesOptions{
		SourceDataOrigin: sdkModels.MicrosoftGraphMetaDataSourceDataOrigin,
		SourceDataType:   sdkModels.MicrosoftGraphSourceDataType,
		Version:          p.apiVersion,
	}

	if err := p.repo.RemoveCommonTypes(removeCommonTypesOpts); err != nil {
		return fmt.Errorf("removing existing Common Types Definitions with Version %q: %+v", p.apiVersion, err)
	}

	p.logger.Info("persisting Common Types Definitions..")

	commonTypes := map[string]sdkModels.CommonTypes{
		p.apiVersion: p.commonTypesForVersion,
	}

	opts := repository.SaveCommonTypesOptions{
		SourceCommitSHA:  pointerTo(p.metadataGitSha),
		CommonTypes:      commonTypes,
		SourceDataOrigin: sdkModels.MicrosoftGraphMetaDataSourceDataOrigin,
		SourceDataType:   sdkModels.MicrosoftGraphSourceDataType,
	}

	if err := p.repo.SaveCommonTypes(opts); err != nil {
		return fmt.Errorf("persisting Data API Definitions for Common Types: %+v", err)
	}

	return nil
}
