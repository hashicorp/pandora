package generator

import (
	"fmt"
)

func (s *ServiceGenerator) metaClient(data VersionInput, versionDirectory string) error {
	if len(data.Resources) == 0 {
		return nil
	}

	templater := metaClientTemplater{
		serviceName: data.ServiceName,
		apiVersion:  data.VersionName,
		resources:   data.Resources,
		source:      data.Source,
	}
	if err := s.writeToPathForVersion(versionDirectory, "client.go", templater); err != nil {
		return fmt.Errorf("templating meta client for API Version %q / Service %q: %+v", data.VersionName, data.ServiceName, err)
	}

	return nil
}
