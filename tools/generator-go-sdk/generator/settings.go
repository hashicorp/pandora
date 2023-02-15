package generator

type Settings struct {
	ServicesUsingNewBaseLayer map[string]struct{}
}

func (s *Settings) UseNewBaseLayerFor(serviceNames ...string) {
	if s.ServicesUsingNewBaseLayer == nil {
		s.ServicesUsingNewBaseLayer = map[string]struct{}{}
	}
	for _, name := range serviceNames {
		s.ServicesUsingNewBaseLayer[name] = struct{}{}
	}
}

func (s *Settings) ShouldUseNewBaseLayer(serviceName, version string) bool {
	if _, ok := s.ServicesUsingNewBaseLayer[serviceName]; ok {
		return true
	}
	if _, ok := s.ServicesUsingNewBaseLayer[serviceName+"@"+version]; ok {
		return true
	}
	return false
}
