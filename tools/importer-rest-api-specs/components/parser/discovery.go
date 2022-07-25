package parser

import (
	"fmt"
	"io/fs"
	"os"
	"path/filepath"
	"sort"
	"strings"

	"github.com/hashicorp/go-hclog"
)

// TODO: move this into a `discovery` package, I guess?

type resourceManagerService struct {
	apiVersions      map[string]string
	resourceProvider string
}

func FindResourceManagerServices(directory string, logger hclog.Logger) (*map[string]ResourceManagerService, error) {
	services := make(map[string]resourceManagerService, 0)
	err := filepath.Walk(directory,
		func(fullPath string, info os.FileInfo, err error) error {
			if err != nil {
				return err
			}
			if !info.IsDir() {
				return nil
			}

			// appconfiguration/data-plane/Microsoft.AppConfiguration/stable/1.0
			// vmware/resource-manager/Microsoft.AVS/{preview|stable}/{version}
			relativePath := strings.TrimPrefix(fullPath, directory)
			relativePath = strings.TrimPrefix(relativePath, string(os.PathSeparator))
			trimmed := strings.TrimPrefix(relativePath, directory)
			segments := strings.Split(trimmed, string(os.PathSeparator))
			if len(segments) != 5 {
				return nil
			}

			serviceName := segments[0]
			serviceType := segments[1]
			resourceProvider := segments[2]
			serviceReleaseState := segments[3]
			apiVersion := segments[4]

			logger.Debug(fmt.Sprintf("Service %q / Type %q / RP %q / Status %q / Version %q", serviceName, serviceType, resourceProvider, serviceReleaseState, apiVersion))
			logger.Debug(fmt.Sprintf("Path %q", fullPath))

			if !strings.EqualFold(serviceType, "resource-manager") {
				return nil
			}
			// ignore 'common' e.g. ./specification/streamanalytics/resource-manager/Microsoft.StreamAnalytics/common/v1/definitions.json
			if !strings.EqualFold(serviceReleaseState, "stable") && !strings.EqualFold(serviceReleaseState, "preview") {
				return nil
			}

			existingPaths, ok := services[serviceName]
			if !ok {
				existingPaths = resourceManagerService{
					resourceProvider: resourceProvider,
					apiVersions:      map[string]string{},
				}
			}
			existingPaths.apiVersions[apiVersion] = fullPath
			services[serviceName] = existingPaths

			return nil
		})
	if err != nil {
		return nil, err
	}

	serviceNames := make([]string, 0)
	for serviceName := range services {
		serviceNames = append(serviceNames, serviceName)
	}
	sort.Strings(serviceNames)
	out := make(map[string]ResourceManagerService, 0)
	for _, serviceName := range serviceNames {
		paths := services[serviceName]

		sortedApiVersions := make([]string, 0)
		for k := range paths.apiVersions {
			sortedApiVersions = append(sortedApiVersions, k)
		}
		sort.Strings(sortedApiVersions)

		out[serviceName] = ResourceManagerService{
			Name:             serviceName,
			ApiVersionPaths:  paths.apiVersions,
			ResourceProvider: paths.resourceProvider,
		}
	}
	return &out, nil
}

type ResourceManagerService struct {
	Name             string
	ApiVersionPaths  map[string]string
	ResourceProvider string
}

func SwaggerFilesInDirectory(directory string) (*[]string, error) {
	swaggerFiles := make([]string, 0)
	if err := filepath.WalkDir(directory, func(path string, d fs.DirEntry, err error) error {
		if err != nil {
			return err
		}
		name := filepath.Base(path)
		if strings.EqualFold(name, "examples") {
			return fs.SkipDir
		}

		extension := filepath.Ext(name)
		if strings.EqualFold(extension, ".json") {
			swaggerFiles = append(swaggerFiles, path)
		}
		return nil
	}); err != nil {
		return nil, err
	}
	return &swaggerFiles, nil
}
