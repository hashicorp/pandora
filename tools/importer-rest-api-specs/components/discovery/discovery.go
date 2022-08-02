package discovery

import (
	"fmt"
	"io/fs"
	"os"
	"path/filepath"
	"sort"
	"strings"

	"github.com/hashicorp/go-hclog"
)

type resourceManagerService struct {
	apiVersions      map[string]string
	resourceProvider string
}

type swaggerDirectoryMetaData struct {
	serviceName         string
	serviceType         string
	resourceProvider    string
	serviceReleaseState string
	apiVersion          string
}

func getMetaDataForSwaggerDirectory(input []string) *swaggerDirectoryMetaData {
	// appconfiguration/data-plane/Microsoft.AppConfiguration/stable/1.0
	// vmware/resource-manager/Microsoft.AVS/{preview|stable}/{version}
	if len(input) != 5 {
		return nil
	}
	serviceName := input[0]
	serviceType := input[1]
	resourceProvider := input[2]
	serviceReleaseState := input[3]
	apiVersion := input[4]

	if !strings.EqualFold(serviceType, "resource-manager") {
		return nil
	}
	// ignore 'common' e.g. ./specification/streamanalytics/resource-manager/Microsoft.StreamAnalytics/common/v1/definitions.json
	if !strings.EqualFold(serviceReleaseState, "stable") && !strings.EqualFold(serviceReleaseState, "preview") {
		return nil
	}

	return &swaggerDirectoryMetaData{
		serviceName:         serviceName,
		serviceType:         serviceType,
		resourceProvider:    resourceProvider,
		serviceReleaseState: serviceReleaseState,
		apiVersion:          apiVersion,
	}
}

func (d swaggerDirectoryMetaData) String() string {
	return strings.Join([]string{
		fmt.Sprintf("Service %q", d.serviceName),
		fmt.Sprintf("Type %q", d.serviceType),
		fmt.Sprintf("RP %q", d.resourceProvider),
		fmt.Sprintf("Status %q", d.serviceReleaseState),
		fmt.Sprintf("Version %q", d.apiVersion),
	}, " / ")
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

			relativePath := strings.TrimPrefix(fullPath, directory)
			relativePath = strings.TrimPrefix(relativePath, string(os.PathSeparator))
			trimmed := strings.TrimPrefix(relativePath, directory)
			segments := strings.Split(trimmed, string(os.PathSeparator))

			metadata := getMetaDataForSwaggerDirectory(segments)
			if metadata == nil {
				return nil
			}

			logger.Debug(metadata.String())
			logger.Debug(fmt.Sprintf("Path %q", fullPath))

			existingPaths, ok := services[metadata.serviceName]
			if !ok {
				existingPaths = resourceManagerService{
					resourceProvider: metadata.resourceProvider,
					apiVersions:      map[string]string{},
				}
			}
			existingPaths.apiVersions[metadata.apiVersion] = fullPath
			services[metadata.serviceName] = existingPaths

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
