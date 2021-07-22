package parser

import (
	"fmt"
	"io/ioutil"
	"log"
	"os"
	"path/filepath"
	"sort"
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/cleanup"

	"github.com/go-openapi/spec"
)

type operationUri struct {
	segments []string
}

func newOperationUri(input string) operationUri {
	segments := strings.Split(strings.TrimPrefix(input, "/"), "/")
	for i, v := range segments {
		segment := cleanup.NormalizeSegment(v, true)
		if v != segment {
			segments[i] = segment
		}
	}
	return operationUri{
		segments: segments,
	}
}

func (u operationUri) normalizedUri() string {
	return fmt.Sprintf("/%s", strings.Join(u.segments, "/"))
}

func (u operationUri) isArmResourceId() bool {
	if len(u.segments)%2 != 0 {
		return false
	}

	for _, segment := range u.segments {
		if segment == "resourceGroups" {
			return true
		}
	}

	return false
}

func (u operationUri) findTopLevelArmResourceId() *string {
	for i := len(u.segments) - 1; i > 0; i-- {
		segment := u.segments[i]
		if segmentIsUserSpecifiable(segment) {
			val := fmt.Sprintf("/%s", strings.Join(u.segments[0:i+1], "/"))
			return &val
		}
	}

	return nil
}

func (u operationUri) userSpecifiableSegmentName() *string {
	for i := len(u.segments) - 1; i > 0; i-- {
		segment := u.segments[i]
		if segmentIsUserSpecifiable(segment) {
			// if it's the first segment (e.g. `{thing}/something`) we'll have to take that
			if i == 0 {
				segment = strings.TrimPrefix(segment, "{")
				segment = strings.TrimSuffix(segment, "}")
				return &segment
			}

			// else we want the item before it e.g. /.../virtualMachines/{name}
			parentSegment := u.segments[i-1]
			if segmentIsUserSpecifiable(parentSegment) {
				// it's possible that this can be `../{thing}/{thing}`
				continue
			}
			return &parentSegment
		}
	}

	return nil
}

func (u operationUri) userSpecifiableSegments() (*[]string, error) {
	//if !u.isArmResourceId() {
	//	return nil, fmt.Errorf("non-arm uri's are unimplemented")
	//}

	segments := make([]string, 0)

	for _, segment := range u.segments {
		if !segmentIsUserSpecifiable(segment) {
			segments = append(segments, segment)
		}
	}

	return &segments, nil
}

func (u operationUri) suffix() *string {
	// an ARM ID should be Key-Value Pairs, however there's 'suffixes' to this e.g. {id}/restart
	if len(u.segments)%2 != 0 {
		val := u.segments[len(u.segments)-1]
		return &val
	}

	return nil
}

func (u operationUri) isTopLevelArmResource() bool {
	lastSegment := u.segments[len(u.segments)-1]
	return segmentIsUserSpecifiable(lastSegment)
}

func (u operationUri) shouldBeIgnored() bool {
	uri := u.normalizedUri()

	// we're not concerned with exposing the "operations" API's at this time - e.g.
	// /providers/Microsoft.EnterpriseKnowledgeGraph/services
	if strings.HasPrefix(strings.ToLower(uri), "/providers/") {
		return true
	}
	// or /subscriptions/{subscriptionId}/providers/Microsoft.EnterpriseKnowledgeGraph/services
	if v := strings.TrimPrefix(strings.ToLower(uri), "/subscriptions/{subscriptionid}"); strings.HasPrefix(v, "/providers/") {
		return true
	}
	// LRO's shouldn't be directly exposed, ignore bad data
	if strings.Contains(strings.ToLower(uri), "/operationresults/{operationid}") {
		return true
	}

	return false
}

func segmentIsUserSpecifiable(input string) bool {
	return strings.HasPrefix(input, "{") && strings.HasSuffix(input, "}")
}

func fragmentNameFromReference(input spec.Ref) *string {
	fragmentName := input.String()
	return fragmentNameFromString(fragmentName)
}

func fragmentNameFromString(fragmentName string) *string {
	if fragmentName != "" {
		fragments := strings.Split(fragmentName, "/") // format #/definitions/ConfigurationStoreListResult
		referenceName := fragments[len(fragments)-1]
		return &referenceName
	}

	return nil
}

func normalizeModelName(input string) string {
	out := input
	out = cleanup.NormalizeSegment(out, false)
	out = strings.Title(out)
	return out
}

func normalizeOperationName(operationId string, tag *string) string {
	operationName := operationId
	if tag != nil {
		operationName = strings.TrimPrefix(operationName, *tag)
	}
	operationName = strings.TrimPrefix(operationName, "Operations") // sanity checking
	operationName = strings.TrimPrefix(operationName, "s")          // plurals
	operationName = strings.TrimPrefix(operationName, "_")
	operationName = cleanup.NormalizeSegment(operationName, false)
	return operationName
}

func operationMatchesTag(operation *spec.Operation, tag *string) bool {
	// if there's no tags defined, we should capture it when the tag matched
	if tag == nil {
		return len(operation.Tags) == 0
	}

	for _, thisTag := range operation.Tags {
		if thisTag == *tag {
			return true
		}
	}

	return false
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

func FindResourceManagerServices(directory string) (*[]ResourceManagerService, error) {
	services := make(map[string]map[string]string, 0)
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
			log.Printf("Service %q / Type %q / RP %q / Status %q / Version %q", serviceName, serviceType, resourceProvider, serviceReleaseState, apiVersion)
			log.Printf("Path %q", fullPath)

			existingPaths, ok := services[serviceName]
			if !ok {
				existingPaths = make(map[string]string, 0)
			}
			existingPaths[apiVersion] = fullPath
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
		out = append(out, ResourceManagerService{
			Name:            serviceName,
			ApiVersionPaths: paths,
		})
	}
	return &out, nil
}

type ResourceManagerService struct {
	Name            string
	ApiVersionPaths map[string]string
}
