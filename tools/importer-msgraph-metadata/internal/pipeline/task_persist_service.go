// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package pipeline

import (
	"fmt"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api-repository/repository"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/internal/logging"
)

func (p pipelineForService) persistApiDefinitions(sdkService sdkModels.Service, commonTypes map[string]sdkModels.CommonTypes) error {
	logging.Infof(fmt.Sprintf("Persisting API Definitions for Service %q..", sdkService.Name))

	opts := repository.SaveServiceOptions{
		CommonTypes:      commonTypes,
		Service:          sdkService,
		ServiceName:      sdkService.Name,
		SourceCommitSHA:  pointer.To(p.metadataGitSha),
		SourceDataOrigin: sdkModels.MicrosoftGraphMetaDataSourceDataOrigin,
	}

	if err := p.repo.SaveService(opts); err != nil {
		return fmt.Errorf("persisting Data API Definitions for Service %q: %+v", sdkService.Name, err)
	}

	return nil
}
