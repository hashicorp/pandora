package repositories

import (
	"fmt"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
)

type ServicesRepository interface {
	GetByName(serviceName string, serviceType ServiceType) (*ServiceDetails, error)

	GetAll(serviceType ServiceType) (*[]ServiceDetails, error)
}

var _ ServicesRepository = &ServicesRepositoryImpl{}

type ServicesRepositoryImpl struct {
	// TODO:
	// directory string
}

func (s *ServicesRepositoryImpl) GetByName(serviceName string, serviceType ServiceType) (*ServiceDetails, error) {
	allServices, err := s.GetAll(serviceType)
	if err != nil {
		return nil, fmt.Errorf("parsing the list of services: %+v", err)
	}
	for _, service := range *allServices {
		if service.Name == serviceName {
			return &service, nil
		}
	}

	return nil, nil
}

func (s *ServicesRepositoryImpl) GetAll(serviceType ServiceType) (*[]ServiceDetails, error) {
	return &[]ServiceDetails{
		{
			Name:                 "Compute",
			ResourceProvider:     "Microsoft.Compute",
			TerraformPackageName: pointer.To("compute"),
			ApiVersions: map[string]*ServiceApiVersionDetails{
				"2020-01-01": {
					Name:     "2020-01-01",
					Generate: true,
					Resources: map[string]*ServiceApiVersionResourceDetails{
						"VirtualMachines": {},
						// TODO:
					},
					Source: HandWrittenApiDefinitionsSource,
				},
			},
			Generate: true,
		},
	}, nil
}
