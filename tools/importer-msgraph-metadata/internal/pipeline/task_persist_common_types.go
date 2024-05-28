package pipeline

import (
	"fmt"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	dataapisdk "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/dataapigeneratorjson"
)

func (p pipeline) PersistCommonTypesDefinitions() error {
	p.logger.Debug(fmt.Sprintf("removing any existing Common Types Definitions with Version %q", p.apiVersion))

	removeCommonTypesOpts := dataapigeneratorjson.RemoveCommonTypesOptions{
		SourceDataOrigin: dataapisdk.MicrosoftGraphMetaDataSourceDataOrigin,
		SourceDataType:   dataapisdk.MicrosoftGraphSourceDataType,
		Version:          p.apiVersion,
	}

	if err := p.repo.RemoveCommonTypes(removeCommonTypesOpts); err != nil {
		return fmt.Errorf("removing existing Common Types Definitions with Version %q: %+v", p.apiVersion, err)
	}

	p.logger.Info("persisting Common Types Definitions..")

	commonTypes := map[string]sdkModels.CommonTypes{
		p.apiVersion: p.commonTypesForVersion,
	}

	opts := dataapigeneratorjson.SaveCommonTypesOptions{
		AzureRestAPISpecsGitSHA: pointer.To(p.metadataGitSha),
		CommonTypes:             commonTypes,
		SourceDataOrigin:        dataapisdk.MicrosoftGraphMetaDataSourceDataOrigin,
		SourceDataType:          dataapisdk.MicrosoftGraphSourceDataType,
	}

	if err := p.repo.SaveCommonTypes(opts); err != nil {
		return fmt.Errorf("persisting Data API Definitions for Common Types: %+v", err)
	}

	return nil
}
