// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package generator

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

type Settings struct {
	CanonicalApiVersions          map[string]string
	CommonTypesPackageName        string
	GenerateDescriptionsForModels bool
	RecurseParentModels           bool
	VersionsToGenerateCommonTypes map[string]models.SourceDataOrigin
	servicesUsingOldBaseLayer     map[string]struct{}
}

func (s *Settings) CanonicalApiVersion(version string) *string {
	if v, ok := s.CanonicalApiVersions[version]; ok {
		return &v
	}
	return nil
}

func (s *Settings) UseOldBaseLayerFor(serviceNames ...string) {
	if s.servicesUsingOldBaseLayer == nil {
		s.servicesUsingOldBaseLayer = map[string]struct{}{}
	}
	for _, name := range serviceNames {
		s.servicesUsingOldBaseLayer[name] = struct{}{}
	}
}

func (s *Settings) ShouldUseNewBaseLayer(serviceName, version string) bool {
	if _, ok := s.servicesUsingOldBaseLayer[serviceName]; ok {
		return false
	}
	if _, ok := s.servicesUsingOldBaseLayer[fmt.Sprintf("%s@%s", serviceName, version)]; ok {
		return false
	}
	return true
}
