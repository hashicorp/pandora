package pipeline

import (
	"fmt"
	"log"
	"sort"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/discovery"
	"github.com/hashicorp/pandora/tools/sdk/config/definitions"
)

func parseAndOutputSegments(input RunInput) error {
	terraformDefinitions := definitions.Config{
		Services: map[string]definitions.ServiceDefinition{},
	}
	data, err := discovery.FindServices(input, terraformDefinitions)
	if err != nil {
		return fmt.Errorf("retrieving data: %+v", err)
	}

	fixedSegmentValues := make(map[string]struct{}, 0)
	for _, service := range *data {
		input.Logger.Trace(fmt.Sprintf("Parsing Swagger files within API Version %q for Service %q..", service.ApiVersion, service.ServiceName))
		data, err := parseSwaggerFiles(service, input.Logger)
		if err != nil {
			log.Printf("❌ Service %q - Api Version %q", service.ServiceName, service.ApiVersion)
			log.Printf("     💥 Error: parsing Swagger files: %+v", err)
			return err
		}
		if data == nil {
			log.Printf("😵 Service %q / Api Version %q contains no resources, skipping.", service.ServiceName, service.ApiVersion)
			continue
		}

		for _, resource := range data.Resources {
			for _, id := range resource.ResourceIds {
				for _, segment := range id.Segments {
					if segment.FixedValue == nil {
						continue
					}

					input.Logger.Trace(fmt.Sprintf("Found Resource ID Segment %q..", *segment.FixedValue))
					fixedSegmentValues[*segment.FixedValue] = struct{}{}
				}
			}
		}
	}

	segments := make([]string, 0)
	for k := range fixedSegmentValues {
		segments = append(segments, k)
	}
	sort.Strings(segments)

	fmt.Println("[DEBUG] ---------------------------------------------")
	fmt.Println("[DEBUG] ---------------------------------------------")

	for _, v := range segments {
		fmt.Println(v)
	}

	fmt.Println("[DEBUG] ---------------------------------------------")
	fmt.Println("[DEBUG] ---------------------------------------------")

	return nil
}
