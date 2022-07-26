package generator

import "fmt"

func testResourceStruct(input ResourceInput) string {
	return fmt.Sprintf("type %sResource struct{}", input.ResourceTypeName)
}
