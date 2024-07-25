// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package generator

import (
	"fmt"
)

type Settings struct {
	CommonTypesPackageName    string
	servicesUsingOldBaseLayer map[string]struct{}
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
