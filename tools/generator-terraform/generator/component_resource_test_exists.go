package generator

import "fmt"

func existsFuncForResourceTest(input ResourceInput) string {
	return fmt.Sprintf("type %sResource struct{}", input.ResourceTypeName)
}
