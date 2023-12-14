package repositories

import (
	"encoding/json"
	"errors"
	"fmt"
	"os"
	"path"

	"github.com/hashicorp/pandora/tools/sdk/dataapimodels"
)

func (s *ServicesRepositoryImpl) discoverServiceTypeDirectories() (*[]string, error) {
	// discoverServiceTypeDirectories finds all directories under the root directory that contain api definitions for a given
	// service type by checking for a metadata.json and comparing the Data Source value defined within it to the Data Source
	// value we're expecting for the Services Repository
	dirs, err := listSubDirectories(s.rootDirectory)
	if err != nil {
		return nil, fmt.Errorf("listing directories under %q: %+v", s.rootDirectory, err)
	}

	serviceTypeDirectories := make([]string, 0)

	for _, d := range *dirs {
		serviceTypeDir := path.Join(s.rootDirectory, d)

		// check whether directory contains a metadata.json
		var metadata dataapimodels.MetaData
		contents, err := loadJson(path.Join(serviceTypeDir, "metadata.json"))
		if err != nil {
			var pathError *os.PathError
			if errors.As(err, &pathError) {
				// this folder has no metadata.json, so we skip it
				continue
			}
			return nil, fmt.Errorf("loading metadata.json: %+v", err)
		}

		if err := json.Unmarshal(*contents, &metadata); err != nil {
			return nil, fmt.Errorf("unmarshaling metadata.json: %+v", err)
		}

		if metadata.DataSource != s.expectedDataSource {
			// this folder contains definitions not belonging to this service type, so we skip it
			continue
		}
		serviceTypeDirectories = append(serviceTypeDirectories, serviceTypeDir)
	}

	return &serviceTypeDirectories, nil
}

func (s *ServicesRepositoryImpl) discoverSubsetOfServices() error {
	// discoverSubsetOfServices populates the serviceNamesToDirectory attribute of the ServicesRepositoryImpl.
	// This function is called if we're spinning up the data API for a subset of services and avoids iterating over
	// all available services.
	dirs, err := s.discoverServiceTypeDirectories()
	if err != nil {
		return fmt.Errorf("discovering service type directories for service type %q: %+v", s.serviceType, err)
	}

	services := make(map[string]string, 0)
	for _, d := range *dirs {
		for _, service := range *s.serviceNames {
			serviceDir := path.Join(d, service)
			if _, err := os.Stat(serviceDir); os.IsNotExist(err) {
				// we continue here since the service we're looking for could exist in another source directory e.g. under handwritten definitions
				continue
			}
			if _, ok := services[service]; ok {
				return fmt.Errorf("duplicate definitions for service %q", service)
			}
			services[service] = serviceDir
		}
	}

	// this checks if all services have been found if we're running the data API for a subset
	for _, service := range *s.serviceNames {
		if _, ok := services[service]; !ok {
			return fmt.Errorf("service %q was not found", service)
		}
	}

	s.serviceNamesToDirectory = &services

	return nil
}

func (s *ServicesRepositoryImpl) discoverAllServices() error {
	// discoverAllServices populates the serviceNamesToDirectory attribute of the ServicesRepositoryImpl.
	// It iterates through all available services to build a complete list of available services for a given
	// service type and checks if there are duplicate definitions for a service.
	dirs, err := s.discoverServiceTypeDirectories()
	if err != nil {
		return fmt.Errorf("discovering service type directories for service type %q: %+v", s.serviceType, err)
	}

	allServices := make(map[string]string, 0)
	for _, d := range *dirs {
		files, err := os.ReadDir(d)
		if err != nil {
			return fmt.Errorf("getting all services: %+v", err)
		}

		for _, f := range files {
			if f.IsDir() {
				if _, ok := allServices[f.Name()]; ok {
					return fmt.Errorf("duplicate definitions for service %q", f.Name())
				}
				allServices[f.Name()] = path.Join(d, f.Name())
			}
		}
	}

	s.serviceNamesToDirectory = &allServices

	return nil
}
