// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

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
					Name:      normalizeServiceName(serviceName),
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

	servicesToSkip := map[string]struct{}{
		// These services are Removed and should be excluded
		"blockchain":        {},
		"devspaces":         {},
		"servicefabricmesh": {},
		"vmwarecloudsimple": {},

		// These services are Deprecated and should be excluded
		"servicemap": {},

		// NOTE: we believe these services are deprecated?
		"adhybridhealthservice": {},
		"customerlockbox":       {},
		"dynamicstelemetry":     {},
		"iotspaces":             {},
	}
	output := make([]AvailableService, 0)
	for _, service := range services {
		if _, shouldSkip := servicesToSkip[strings.ToLower(service.Name)]; shouldSkip {
			continue
		}

		output = append(output, service)
	}

	return &output, nil
}

func normalizeServiceName(input string) string {
	output := input
	output = strings.Title(output)
	output = strings.ReplaceAll(output, ".", "")
	output = strings.ReplaceAll(output, "-", "")
	return output
}
