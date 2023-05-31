package testing

import "fmt"

type testDependencies struct {
	needsResourceGroup bool
}

func (tb TestBuilder) generateBasicTest(dependencies *testDependencies) (*string, error) {
	return nil, fmt.Errorf("not implemented")
}
