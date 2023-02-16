package generator

import (
	"fmt"
)

type Settings struct {
	servicesUsingNewBaseLayer map[string]struct{}
}

func (s *Settings) UseNewBaseLayerFor(serviceNames ...string) {
	if s.servicesUsingNewBaseLayer == nil {
		s.servicesUsingNewBaseLayer = map[string]struct{}{}
	}
	for _, name := range serviceNames {
		s.servicesUsingNewBaseLayer[name] = struct{}{}
	}
}

func (s *Settings) ShouldUseNewBaseLayer(serviceName, version string) bool {
	if _, ok := s.servicesUsingNewBaseLayer[serviceName]; ok {
		return true
	}
	if _, ok := s.servicesUsingNewBaseLayer[fmt.Sprintf("%s@%s", serviceName, version)]; ok {
		return true
	}
	return false
}
