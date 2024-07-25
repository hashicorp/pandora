// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package generator

import (
	"testing"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func TestTemplateIdParserBasic(t *testing.T) {
	actual, err := resourceIdTemplater{
		name: "BasicTestId",
		resource: models.ResourceID{
			ExampleValue: "/subscriptions/{subscriptionId}",
			Segments: []models.ResourceIDSegment{
				models.NewStaticValueResourceIDSegment("staticSubscriptions", "subscriptions"),
				models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
			},
		},
	}.template(GeneratorData{
		resourceIds: map[string]models.ResourceID{
			"empty": {
				CommonIDAlias: stringPointer("basic"),
			},
		},
		packageName: "somepackage",
		source:      AccTestLicenceType,
	})
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := `package somepackage
import (
    "fmt"
    "regexp"
    "strconv"
    "strings"

    "github.com/hashicorp/go-azure-helpers/resourcemanager/recaser"
    "github.com/hashicorp/go-azure-helpers/resourcemanager/resourceids"
)

// acctests licence placeholder

func init() {
    recaser.RegisterResourceId(&BasicTestId{})
}

var _ resourceids.ResourceId = &BasicTestId{}

	// BasicTestId is a struct representing the Resource ID for a Basic Test
	type BasicTestId struct {
		SubscriptionId string
	}

	// NewBasicTestID returns a new BasicTestId struct
	func NewBasicTestID(subscriptionId string) BasicTestId {
		return BasicTestId{
			SubscriptionId: subscriptionId,
		}
	}

	// ParseBasicTestID parses 'input' into a BasicTestId
	func ParseBasicTestID(input string) (*BasicTestId, error) {
        parser := resourceids.NewParserFromResourceIdType(&BasicTestId{})
        parsed, err := parser.Parse(input, false)
        if err != nil {
	        return nil, fmt.Errorf("parsing %q: %+v", input, err)
        }

        id := BasicTestId{}
        if err := id.FromParseResult(*parsed); err != nil {
			return nil, err
		}

        return &id, nil
	}

	// ParseBasicTestIDInsensitively parses 'input' case-insensitively into a BasicTestId
	// note: this method should only be used for API response data and not user input
	func ParseBasicTestIDInsensitively(input string) (*BasicTestId, error) {
        parser := resourceids.NewParserFromResourceIdType(&BasicTestId{})
        parsed, err := parser.Parse(input, true)
        if err != nil {
	        return nil, fmt.Errorf("parsing %q: %+v", input, err)
        }

        id := BasicTestId{}
        if err := id.FromParseResult(*parsed); err != nil {
			return nil, err
		}

        return &id, nil
	}

	func (id *BasicTestId) FromParseResult(input resourceids.ParseResult) error {
		var ok bool

		if id.SubscriptionId, ok = input.Parsed["subscriptionId"]; !ok {
			return resourceids.NewSegmentNotSpecifiedError(id, "subscriptionId", input)
        }

		return nil
	}

	// ValidateBasicTestID checks that 'input' can be parsed as a Basic Test ID
	func ValidateBasicTestID(input interface{}, key string) (warnings []string, errors []error) {
        v, ok := input.(string)
        if !ok {
	        errors = append(errors, fmt.Errorf("expected %q to be a string", key))
			return
        }

        if _, err := ParseBasicTestID(v); err != nil {
	        errors = append(errors, err)
        }

		return
	}

	// ID returns the formatted Basic Test ID
	func (id BasicTestId) ID() string {
		fmtString := "/subscriptions/%s"
		return fmt.Sprintf(fmtString, id.SubscriptionId)
	}

	// Segments returns a slice of Resource ID Segments which comprise this Basic Test ID
	func (id BasicTestId) Segments() []resourceids.Segment {
		return []resourceids.Segment{
			resourceids.StaticSegment("staticSubscriptions", "subscriptions", "subscriptions"),
			resourceids.SubscriptionIdSegment("subscriptionId", "12345678-1234-9876-4563-123456789012"),
		}
	}

	// String returns a human-readable description of this Basic Test ID
	func (id BasicTestId) String() string {
		components := []string{
			fmt.Sprintf("Subscription: %q", id.SubscriptionId),
		}
		return fmt.Sprintf("Basic Test (%s)", strings.Join(components, "\n"))
	}
`
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestTemplateIdParserConstantsOnly(t *testing.T) {
	actual, err := resourceIdTemplater{
		name: "ConstantOnlyId",
		resource: models.ResourceID{
			ExampleValue: "/thing/{thingId}",
			ConstantNames: []string{
				"Thing",
			},
			Segments: []models.ResourceIDSegment{
				models.NewStaticValueResourceIDSegment("staticThing", "thing"),
				models.NewConstantResourceIDSegment("thingId", "Thing", "someThing"),
			},
		},
		constantDetails: map[string]models.SDKConstant{
			"Thing": {
				Type: models.StringSDKConstantType,
				Values: map[string]string{
					"Some":    "Some",
					"Another": "Another",
				},
			},
		},
	}.template(GeneratorData{
		resourceIds: map[string]models.ResourceID{
			"empty": {
				CommonIDAlias: stringPointer("thing"),
			},
		},
		packageName: "somepackage",
		source:      AccTestLicenceType,
	})
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := `package somepackage

import (
	"fmt"
	"regexp"
	"strconv"
	"strings"

    "github.com/hashicorp/go-azure-helpers/resourcemanager/recaser"
	"github.com/hashicorp/go-azure-helpers/resourcemanager/resourceids"
)

// acctests licence placeholder

func init() {
    recaser.RegisterResourceId(&ConstantOnlyId{})
}

var _ resourceids.ResourceId = &ConstantOnlyId{}

// ConstantOnlyId is a struct representing the Resource ID for a Constant Only
type ConstantOnlyId struct {
	ThingId Thing
}

// NewConstantOnlyID returns a new ConstantOnlyId struct
func NewConstantOnlyID(thingId Thing) ConstantOnlyId {
	return ConstantOnlyId{
		ThingId: thingId,
	}
}

// ParseConstantOnlyID parses 'input' into a ConstantOnlyId
func ParseConstantOnlyID(input string) (*ConstantOnlyId, error) {
	parser := resourceids.NewParserFromResourceIdType(&ConstantOnlyId{})
	parsed, err := parser.Parse(input, false)
	if err != nil {
		return nil, fmt.Errorf("parsing %q: %+v", input, err)
	}

	id := ConstantOnlyId{}
	if err := id.FromParseResult(*parsed); err != nil {
			return nil, err
	}

	return &id, nil
}

// ParseConstantOnlyIDInsensitively parses 'input' case-insensitively into a ConstantOnlyId
// note: this method should only be used for API response data and not user input
func ParseConstantOnlyIDInsensitively(input string) (*ConstantOnlyId, error) {
	parser := resourceids.NewParserFromResourceIdType(&ConstantOnlyId{})
	parsed, err := parser.Parse(input, true)
	if err != nil {
		return nil, fmt.Errorf("parsing %q: %+v", input, err)
	}

	id := ConstantOnlyId{}
	if err := id.FromParseResult(*parsed); err != nil {
			return nil, err
	}

	return &id, nil
}

func (id *ConstantOnlyId) FromParseResult(input resourceids.ParseResult) error {
	if v, ok := input.Parsed["thingId"]; true {
        if !ok {
        	return resourceids.NewSegmentNotSpecifiedError(id, "thingId", input)
        }
        thingId, err := parseThing(v)
        if err != nil {
        	return fmt.Errorf("parsing %q: %+v", v, err)
        }
        id.ThingId = *thingId
	}
	return nil
}

// ValidateConstantOnlyID checks that 'input' can be parsed as a Constant Only ID
func ValidateConstantOnlyID(input interface{}, key string) (warnings []string, errors []error) {
	v, ok := input.(string)
	if !ok {
		errors = append(errors, fmt.Errorf("expected %q to be a string", key))
		return
	}

	if _, err := ParseConstantOnlyID(v); err != nil {
		errors = append(errors, err)
	}

	return
}

// ID returns the formatted Constant Only ID
func (id ConstantOnlyId) ID() string {
	fmtString := "/thing/%s"
	return fmt.Sprintf(fmtString, string(id.ThingId))
}

// Segments returns a slice of Resource ID Segments which comprise this Constant Only ID
func (id ConstantOnlyId) Segments() []resourceids.Segment {
	return []resourceids.Segment{
		resourceids.StaticSegment("staticThing", "thing", "thing"),
		resourceids.ConstantSegment("thingId", PossibleValuesForThing(), "someThing"),
	}
}

// String returns a human-readable description of this Constant Only ID
func (id ConstantOnlyId) String() string {
	components := []string{
		fmt.Sprintf("Thing: %q", string(id.ThingId)),
	}
	return fmt.Sprintf("Constant Only (%s)", strings.Join(components, "\n"))
}
`
	assertTemplatedCodeMatches(t, expected, *actual)
}
