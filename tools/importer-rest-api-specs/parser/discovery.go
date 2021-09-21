package parser

import (
	"io/ioutil"
	"log"
	"os"
	"path/filepath"
	"sort"
	"strings"
)

// TODO: move this into a `discovery` package, I guess?

type resourceManagerService struct {
	apiVersions      map[string]string
	resourceProvider string
}

func FindResourceManagerServices(directory string, justLatestVersion, debug bool) (*[]ResourceManagerService, error) {
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
			relativePath = strings.TrimPrefix(relativePath, "/")
			trimmed := strings.TrimPrefix(relativePath, directory)
			segments := strings.Split(trimmed, "/")
			if len(segments) != 5 {
				return nil
			}

			serviceName := segments[0]
			serviceType := segments[1]
			resourceProvider := segments[2]
			serviceReleaseState := segments[3]
			apiVersion := segments[4]

			if debug {
				log.Printf("Service %q / Type %q / RP %q / Status %q / Version %q", serviceName, serviceType, resourceProvider, serviceReleaseState, apiVersion)
				log.Printf("Path %q", fullPath)
			}

			if !strings.EqualFold(serviceType, "resource-manager") {
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
	out := make([]ResourceManagerService, 0)
	for _, serviceName := range serviceNames {
		paths := services[serviceName]

		sortedApiVersions := make([]string, 0)
		for k := range paths.apiVersions {
			sortedApiVersions = append(sortedApiVersions, k)
		}
		sort.Strings(sortedApiVersions)

		newestApiVersion := sortedApiVersions[len(sortedApiVersions)-1]

		service := ResourceManagerService{
			Name:             serviceName,
			ApiVersionPaths:  paths.apiVersions,
			ResourceProvider: paths.resourceProvider,
		}
		if justLatestVersion {
			service.ApiVersionPaths = map[string]string{
				newestApiVersion: paths.apiVersions[newestApiVersion],
			}
		}
		out = append(out, service)
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
	dirContents, err := ioutil.ReadDir(directory)
	if err != nil {
		return nil, err
	}

	for _, file := range dirContents {
		if file.IsDir() {
			continue
		}

		extension := filepath.Ext(file.Name())
		if strings.EqualFold(extension, ".json") {
			filePath := filepath.Join(directory, file.Name())
			swaggerFiles = append(swaggerFiles, filePath)
		}
	}

	return &swaggerFiles, nil
}
