package main

import (
	"fmt"
	"os"
	"sort"
	"strings"
	"time"

	"github.com/hashicorp/hcl/v2/gohcl"
	"github.com/hashicorp/hcl/v2/hclwrite"
)

type Config struct {
	// Services is a slice of Services which should be imported
	Services []Service `hcl:"service,block"`
}

type Service struct {
	// Directory is the name of the Swagger directory for this Service (e.g. appconfiguration)
	Directory string `hcl:"directory,label"`

	// Name is the normalized (title-case, no spaces etc) name for this Service (e.g. AppConfiguration)
	Name string `hcl:"name"`

	// Available is a list of the Versions for this Service which should be imported
	Available []string `hcl:"available"`

	// Ignore is a list of Versions which should be Ignored for this Service
	// A version is automatically ignored if it's not defined in
	Ignore *[]string `hcl:"ignore"`
}

func (c *Config) WriteToFile(filePath string) error {
	c.sortServices()

	newFile := hclwrite.NewEmptyFile()
	gohcl.EncodeIntoBody(c, newFile.Body())
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

func (c *Config) sortServices() {
	names := make([]string, 0)
	services := make(map[string]Service, 0)
	for _, service := range c.Services {
		names = append(names, service.Directory)
		services[service.Directory] = service
	}

	sort.Strings(names)

	output := make([]Service, 0)
	for _, name := range names {
		service := services[name]
		sort.Strings(service.Available)
		if service.Ignore != nil {
			sort.Strings(*service.Ignore)
		}
		output = append(output, service)
	}
	c.Services = output
}

func (c *Config) ReconcileWithAvailableServices(availableServices []AvailableService) error {
	services := make(map[string]Service, 0)
	// first add the existing services we know about
	for _, service := range c.Services {
		services[strings.ToLower(service.Directory)] = service
	}

	// first add the existing services we know about
	for _, availableService := range availableServices {
		key := strings.ToLower(availableService.Directory)
		existing, hasExisting := services[key]
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

			services[key] = Service{
				Directory: availableService.Directory,
				Name:      strings.Title(availableService.Directory),
				Available: []string{
					latestVersion,
				},
				Ignore:    nil,
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
					return err
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
		services[key] = existing
	}

	output := make([]Service, 0)
	for _, service := range services {
		output = append(output, service)
	}
	c.Services = output
	return nil
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
