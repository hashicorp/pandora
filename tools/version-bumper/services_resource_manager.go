package main

import (
	"os"
	"path/filepath"
	"strings"
)

var _ ServiceLocator = ResourceManagerService{}

type ResourceManagerService struct {
	swaggerDirectory string
}

func (s ResourceManagerService) AvailableServices() (*[]AvailableService, error) {
	specsDirectory := filepath.Join(s.swaggerDirectory, "specification")
	services := make(map[string]AvailableService, 0)

	err := filepath.Walk(specsDirectory,
		func(fullPath string, info os.FileInfo, err error) error {
			if err != nil {
				return err
			}
			if !info.IsDir() {
				return nil
			}

			// appconfiguration/data-plane/Microsoft.AppConfiguration/stable/1.0
			// vmware/resource-manager/Microsoft.AVS/{preview|stable}/{version}
			relativePath := strings.TrimPrefix(fullPath, specsDirectory)
			relativePath = strings.TrimPrefix(relativePath, "/")
			trimmed := strings.TrimPrefix(relativePath, specsDirectory)
			segments := strings.Split(trimmed, "/")
			if len(segments) != 5 {
				return nil
			}

			serviceName := segments[0]
			serviceType := segments[1]
			serviceReleaseState := segments[3]
			apiVersion := segments[4]

			if !strings.EqualFold(serviceType, "resource-manager") {
				return nil
			}
			// ignore 'common' e.g. ./specification/streamanalytics/resource-manager/Microsoft.StreamAnalytics/common/v1/definitions.json
			if !strings.EqualFold(serviceReleaseState, "stable") && !strings.EqualFold(serviceReleaseState, "preview") {
				return nil
			}

			existingPaths, ok := services[serviceName]
			if !ok {
				existingPaths = AvailableService{
					Name:      strings.Title(serviceName),
					Directory: serviceName,
					Version:   []string{},
				}
			}
			existingPaths.Version = append(existingPaths.Version, apiVersion)
			services[serviceName] = existingPaths

			return nil
		})
	if err != nil {
		return nil, err
	}

	output := make([]AvailableService, 0)
	for _, service := range services {
		output = append(output, service)
	}

	return &output, nil
}

