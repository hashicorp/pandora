package main

import (
	"fmt"
	"os"
	"sort"
	"strings"
	"time"

	"github.com/hashicorp/hcl/v2/gohcl"
	"github.com/hashicorp/hcl/v2/hclwrite"
	"github.com/hashicorp/pandora/tools/sdk/config/services"
)

func writeToFile(config services.Config, filePath string) error {
	config.Services = sortServices(config.Services)

	newFile := hclwrite.NewEmptyFile()
	gohcl.EncodeIntoBody(&config, newFile.Body())
	bytes := hclwrite.Format(newFile.Bytes())
	os.Remove(filePath)
	file, err := os.Create(filePath)
	if err != nil {
		return fmt.Errorf("opening %q for writing: %+v", filePath, err)
	}
	defer file.Close()
	file.Write(bytes)
	return nil
}

func sortServices(input []services.Service) []services.Service {
	names := make([]string, 0)
	parsed := make(map[string]services.Service, 0)
	for _, service := range input {
		names = append(names, service.Directory)
		parsed[service.Directory] = service
	}

	sort.Strings(names)

	output := make([]services.Service, 0)
	for _, name := range names {
		service := parsed[name]
		sort.Strings(service.Available)
		if service.Ignore != nil {
			sort.Strings(*service.Ignore)
		}
		output = append(output, service)
	}
	return output
}

func reconcileWithAvailableServices(input services.Config, availableServices []AvailableService) (*services.Config, error) {
	result := make(map[string]services.Service, 0)
	// first add the existing services we know about
	for _, service := range input.Services {
		result[strings.ToLower(service.Directory)] = service
	}

	// first add the existing services we know about
	for _, availableService := range availableServices {
		key := strings.ToLower(availableService.Directory)
		existing, hasExisting := result[key]
		if !hasExisting {
			// temporary feature-flag to ensure we only update the versions for previously-imported services
			// this is useful until we import everything - otherwise for now this'll be a large-diff
			if onlyUpdateExistingServices {
				continue
			}

			versions := filterToStableVersions(availableService.Version)
			if len(versions) == 0 {
				// since this is a new service, if only a preview version is available let's use that
				versions = availableService.Version
			}
			latestVersion := latestVersionFrom(versions)

			result[key] = services.Service{
				Directory: availableService.Directory,
				Name:      strings.Title(availableService.Directory),
				Available: []string{
					latestVersion,
				},
				Ignore: nil,
			}
			continue
		}

		// determine if there's any new versions which should be added
		versionsToAdd := make([]string, 0)
		for _, version := range availableService.Version {
			existsInExistingList := false
			versionIsOlderThanExistingVersion := false

			for _, existingVersion := range existing.Available {
				if strings.EqualFold(version, existingVersion) {
					existsInExistingList = true
				}

				isOlder, err := isVersionIsOlderThanExistingVersion(version, existingVersion)
				if err != nil {
					return nil, err
				}
				if *isOlder {
					versionIsOlderThanExistingVersion = true
				}
			}

			existsInIgnoreList := false
			if existing.Ignore != nil {
				for _, other := range *existing.Ignore {
					if strings.EqualFold(version, other) {
						existsInIgnoreList = true
						break
					}
				}
			}

			if existsInExistingList || existsInIgnoreList || versionIsOlderThanExistingVersion {
				continue
			}

			// for now we don't want to auto-import Preview versions, only Stable releases
			if isPreviewVersion(version) {
				continue
			}

			versionsToAdd = append(versionsToAdd, version)
		}

		// we're only interested when this is a non-preview version
		stableVersionsToAdd := filterToStableVersions(versionsToAdd)
		if len(stableVersionsToAdd) == 0 {
			continue
		}

		latestVersion := latestVersionFrom(stableVersionsToAdd)
		existing.Available = append(existing.Available, latestVersion)
		result[key] = existing
	}

	output := make([]services.Service, 0)
	for _, service := range result {
		output = append(output, service)
	}
	input.Services = output
	return &input, nil
}

func latestVersionFrom(input []string) string {
	sort.Strings(input)
	newestApiVersion := input[len(input)-1]
	return newestApiVersion
}

func isVersionIsOlderThanExistingVersion(new string, existing string) (*bool, error) {
	normalizedNew := normalizeDateString(new)
	normalizedOld := normalizeDateString(existing)
	if normalizedNew == normalizedOld {
		v := true
		// if we're using an older preview (e.g. 2020-01-01-preview) but
		// a GA version gets published, we should import the new version
		if isPreviewVersion(existing) {
			v = false
		}
		return &v, nil
	}

	yyyymmddFormat := "2006-01-02"
	newDate, err := time.Parse(yyyymmddFormat, normalizedNew)
	if err != nil {
		return nil, fmt.Errorf("parsing %q as %q: %+v", new, yyyymmddFormat, err)
	}
	existingDate, err := time.Parse(yyyymmddFormat, normalizedOld)
	if err != nil {
		return nil, fmt.Errorf("parsing %q as %q: %+v", existing, yyyymmddFormat, err)
	}

	// this can happen in Preview API's once the values are normalized
	// e.g. 2017-08-01 and 2017-08-01-beta
	newIsOlderThanExisting := newDate.Before(existingDate) && !existingDate.Equal(newDate)
	return &newIsOlderThanExisting, nil
}

func normalizeDateString(input string) string {
	output := strings.ToLower(input)
	output = strings.TrimSuffix(output, "-privatepreview")
	output = strings.TrimSuffix(output, "-publicpreview")
	output = strings.TrimSuffix(output, "-preview")
	output = strings.TrimSuffix(output, "-beta")
	return output
}

func filterToStableVersions(input []string) []string {
	output := make([]string, 0)
	for _, v := range input {
		if isPreviewVersion(v) {
			continue
		}

		output = append(output, v)
	}

	sort.Strings(output)
	return output
}

func isPreviewVersion(version string) bool {
	val := strings.ToLower(version)
	knownBetaSegments := []string{
		"beta",
		// privatepreview and publicpreview are implied
		"preview",
	}
	for _, v := range knownBetaSegments {
		if strings.Contains(val, v) {
			return true
		}
	}

	return false
}
