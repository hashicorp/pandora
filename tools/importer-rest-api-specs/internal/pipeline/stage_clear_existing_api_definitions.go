// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package pipeline

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/data-api-repository/repository"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/logging"
)

func (p *Pipeline) clearExistingAPIDefinitions() error {
	// Common Types don't/shouldn't be needed for ARM, so this is mostly for sanity-checking purposes
	logging.Info("Removing any Common Types..")
	commonTypesOpts := repository.RemoveCommonTypesOptions{
		SourceDataOrigin: p.opts.SourceDataOrigin,
	}
	if err := p.repository.RemoveCommonTypes(commonTypesOpts); err != nil {
		return fmt.Errorf("purging any existing Common Types for for the Source Data Type %q / Source Data Origin %q: %+v", p.opts.SourceDataType, p.opts.SourceDataOrigin, err)
	}

	if len(p.opts.ServiceNamesToLimitTo) == 0 {
		logging.Infof("Purging all existing Source Data for Source Data Type %q / Source Data Origin %q..", p.opts.SourceDataType, p.opts.SourceDataOrigin)
		if err := p.repository.PurgeExistingData(p.opts.SourceDataOrigin); err != nil {
			return fmt.Errorf("purging the existing Source Data for the Source Data Type %q / Source Data Origin %q: %+v", p.opts.SourceDataType, p.opts.SourceDataOrigin, err)
		}
		return nil
	}

	logging.Infof("Purging the existing Source Data for the Services [%+v] for  for Source Data Type %q / Source Data Origin %q..", p.opts.ServiceNamesToLimitTo, p.opts.SourceDataType, p.opts.SourceDataOrigin)
	for _, serviceName := range p.opts.ServiceNamesToLimitTo {
		logging.Infof("Removing the existing Data for Service %q..", serviceName)
		opts := repository.RemoveServiceOptions{
			ServiceName:      serviceName,
			SourceDataOrigin: p.opts.SourceDataOrigin,
		}
		if err := p.repository.RemoveService(opts); err != nil {
			return fmt.Errorf("removing the existing Data for Service %q: %+v", serviceName, err)
		}
	}
	return nil
}
