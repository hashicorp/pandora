package generator

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/generator-go-sdk/featureflags"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

// TODO: add unit tests covering this

var _ templater = resourceIdTemplater{}

type resourceIdTemplater struct {
	name            string
	resource        resourcemanager.ResourceIdDefinition
	constantDetails map[string]resourcemanager.ConstantDetails
}

func (r resourceIdTemplater) template(data ServiceGeneratorData) (*string, error) {
	structBody, err := r.structBody()
	if err != nil {
		return nil, fmt.Errorf("generating struct body: %+v", err)
	}
	methods, err := r.methods(data)
	if err != nil {
		return nil, fmt.Errorf("generating methods: %+v", err)
	}

	out := fmt.Sprintf(`package %[1]s
import (
    "fmt"
    "regexp"	
    "strconv"
    "strings"

    "github.com/hashicorp/go-azure-helpers/resourcemanager/resourceids"
)

%[2]s
%[3]s
`, data.packageName, *structBody, *methods)
	return &out, nil
}

func (r resourceIdTemplater) structBody() (*string, error) {
	lines := make([]string, 0)

	for _, segment := range r.resource.Segments {
		segmentType := string(resourcemanager.StringConstant)
		switch segment.Type {
		case resourcemanager.StaticSegment:
			continue
		case resourcemanager.ResourceProviderSegment:
			continue
		case resourcemanager.ConstantSegment:
			if segment.ConstantReference == nil {
				return nil, fmt.Errorf("segment %q is a constant with no reference", segment.Name)
			}

			segmentType = *segment.ConstantReference
		}

		lines = append(lines, fmt.Sprintf("%s %s", strings.Title(segment.Name), segmentType))
	}

	wordifiedName := wordifyString(r.name)
	out := fmt.Sprintf(`
var _ resourceids.ResourceId = %[1]s{}

// %[1]s is a struct representing the Resource ID for a %[3]s
type %[1]s struct {
%[2]s
}
`, r.name, strings.Join(lines, "\n"), wordifiedName)
	return &out, nil
}

func (r resourceIdTemplater) methods(data ServiceGeneratorData) (*string, error) {
	nameWithoutSuffix := strings.TrimSuffix(r.name, "Id")

	// NOTE: ordering is useful here for skimming the code, we do Public -> Private
	//	e.g. Struct -> NewStruct -> Parse -> Validate -> other Methods

	methods := make([]string, 0)

	// New{ID} function
	functionBody, err := r.newFunction(nameWithoutSuffix)
	if err != nil {
		return nil, fmt.Errorf("generating the New function: %+v", err)
	}
	methods = append(methods, *functionBody)

	// case-sensitive parse function
	functionBody, err = r.parseFunction(nameWithoutSuffix, true)
	if err != nil {
		return nil, fmt.Errorf("generating the case-sensitive function: %+v", err)
	}
	methods = append(methods, *functionBody)

	if featureflags.GenerateCaseInsensitiveFunctions {
		// case-insensitive parse function
		functionBody, err := r.parseFunction(nameWithoutSuffix, false)
		if err != nil {
			return nil, fmt.Errorf("generating the case-insensitive function: %+v", err)
		}

		methods = append(methods, *functionBody)
	}

	// Validate function
	methods = append(methods, r.validateFunction(nameWithoutSuffix))

	// Id function
	functionBody, err = r.idFunction(data)
	if err != nil {
		return nil, fmt.Errorf("generating ID function: %+v", err)
	}
	methods = append(methods, *functionBody)

	// Segments function
	functionBody, err = r.segmentsFunction()
	if err != nil {
		return nil, fmt.Errorf("generating Segments function: %+v", err)
	}
	methods = append(methods, *functionBody)

	// String function
	functionBody, err = r.stringFunction(data)
	if err != nil {
		return nil, fmt.Errorf("generating String function: %+v", err)
	}
	methods = append(methods, *functionBody)

	out := strings.Join(methods, "\n\n")
	return &out, nil
}

func (r resourceIdTemplater) idFunction(data ServiceGeneratorData) (*string, error) {
	fmtSegments := make([]string, 0)      // %s
	segmentArguments := make([]string, 0) // id.Foo
	for _, segment := range r.resource.Segments {
		switch segment.Type {
		case resourcemanager.ResourceProviderSegment, resourcemanager.StaticSegment:
			{
				if segment.FixedValue == nil {
					return nil, fmt.Errorf("segment %q should have a static value but didn't get one", segment.Name)
				}
				fmtSegments = append(fmtSegments, *segment.FixedValue)
				continue
			}

		case resourcemanager.ConstantSegment:
			{
				if segment.ConstantReference == nil {
					return nil, fmt.Errorf("the constant segment %q has no reference", segment.Name)
				}

				// get the segment and determine the type
				constant, ok := data.constants[*segment.ConstantReference]
				if !ok {
					return nil, fmt.Errorf("the constant %q was not found in the data for segment %q", *segment.ConstantReference, segment.Name)
				}

				fmtVals := map[resourcemanager.ConstantType]string{
					resourcemanager.IntegerConstant: "%d",
					resourcemanager.FloatConstant:   "%f",
					resourcemanager.StringConstant:  "%s",
				}
				fmtVal, ok := fmtVals[constant.Type]
				if !ok {
					return nil, fmt.Errorf("constant type %q has no fmtVals mapping", string(constant.Type))
				}
				fmtSegments = append(fmtSegments, fmtVal)

				segmentType, err := golangTypeNameForConstantType(constant.Type)
				if err != nil {
					return nil, fmt.Errorf("for constant %q: %+v", err, err)
				}
				segmentArguments = append(segmentArguments, fmt.Sprintf("%s(id.%s)", *segmentType, strings.Title(segment.Name)))
			}

		case resourcemanager.ScopeSegment:
			{
				fmtSegments = append(fmtSegments, "%s")
				segmentArguments = append(segmentArguments, fmt.Sprintf("strings.TrimPrefix(id.%s, \"/\")", strings.Title(segment.Name)))
			}

		default:
			{
				fmtSegments = append(fmtSegments, "%s")
				segmentArguments = append(segmentArguments, fmt.Sprintf("id.%s", strings.Title(segment.Name)))
			}
		}
	}

	// intentionally doing this and not using strings.Join to handle Scopes which are full Resource ID's
	fmtString := urlFromSegments(fmtSegments)
	segmentsString := strings.Join(segmentArguments, ", ")
	wordifiedName := wordifyString(r.name)

	out := fmt.Sprintf(`
// ID returns the formatted %[4]s ID
func (id %[1]s) ID() string {
	fmtString := %[2]q
	return fmt.Sprintf(fmtString, %[3]s)
}
`, r.name, fmtString, segmentsString, wordifiedName)
	return &out, nil
}

func (r resourceIdTemplater) newFunction(nameWithoutSuffix string) (*string, error) {
	arguments := make([]string, 0)
	lines := make([]string, 0)

	for _, segment := range r.resource.Segments {
		switch segment.Type {
		case resourcemanager.StaticSegment:
			fallthrough
		case resourcemanager.ResourceProviderSegment:
			continue

		case resourcemanager.ConstantSegment:
			{
				if segment.ConstantReference == nil {
					return nil, fmt.Errorf("segment %q is a constant without a reference", segment.Name)
				}

				arguments = append(arguments, fmt.Sprintf("%s %s", segment.Name, *segment.ConstantReference))
				lines = append(lines, fmt.Sprintf("%s: %s,", strings.Title(segment.Name), segment.Name))
			}

		case resourcemanager.ResourceGroupSegment, resourcemanager.ScopeSegment, resourcemanager.SubscriptionIdSegment, resourcemanager.UserSpecifiedSegment:
			{
				arguments = append(arguments, fmt.Sprintf("%s string", segment.Name))
				lines = append(lines, fmt.Sprintf("%s: %s,", strings.Title(segment.Name), segment.Name))
			}

		default:
			return nil, fmt.Errorf("unsupported segment type %q", string(segment.Type))
		}
	}

	out := fmt.Sprintf(`
// New%[1]sID returns a new %[2]s struct 
func New%[1]sID(%[3]s) %[2]s {
	return %[1]sId{
		%[4]s
	}
}`, nameWithoutSuffix, r.name, strings.Join(arguments, ", "), strings.Join(lines, "\n"))
	return &out, nil
}

func (r resourceIdTemplater) parseFunction(nameWithoutSuffix string, caseSensitive bool) (*string, error) {
	functionName := fmt.Sprintf("Parse%[1]sID", nameWithoutSuffix)
	if !caseSensitive {
		functionName += "Insensitively"
	}

	lines := make([]string, 0)
	for _, segment := range r.resource.Segments {
		switch segment.Type {
		case resourcemanager.ConstantSegment:
			{
				if segment.ConstantReference == nil {
					return nil, fmt.Errorf("constant segment %q has no reference", segment.Name)
				}

				lines = append(lines, fmt.Sprintf(`
	
	var v string
	if v, ok = parsed.Parsed[%[1]q]; true {
		if !ok {
			return nil, fmt.Errorf("the segment '%[1]s' was not found in the resource id %%q", input)
		}

		%[1]s, err := parse%[3]s(v)
		if err != nil {
			return nil, fmt.Errorf("parsing %%q: %%+v", v, err)
		}
		id.%[2]s = *%[1]s
	}
`, segment.Name, strings.Title(segment.Name), *segment.ConstantReference))
				continue
			}

		case resourcemanager.ResourceGroupSegment, resourcemanager.ScopeSegment, resourcemanager.SubscriptionIdSegment, resourcemanager.UserSpecifiedSegment:
			{
				lines = append(lines, fmt.Sprintf(`
	if id.%[2]s, ok = parsed.Parsed[%[1]q]; !ok {
		return nil, fmt.Errorf("the segment '%[1]s' was not found in the resource id %%q", input)
	}
`, segment.Name, strings.Title(segment.Name)))
				continue
			}

		default:
			continue
		}
	}

	description := fmt.Sprintf("// %[1]s parses 'input' into a %[2]s", functionName, r.name)
	if !caseSensitive {
		description = fmt.Sprintf(`
// %[1]s parses 'input' case-insensitively into a %[2]s
// note: this method should only be used for API response data and not user input`, functionName, r.name)
	}

	out := fmt.Sprintf(`%[5]s
func %[1]s(input string) (*%[2]s, error) {
	parser := resourceids.NewParserFromResourceIdType(%[2]s{})
	parsed, err := parser.Parse(input, %[3]t)
	if err != nil {
		return nil, fmt.Errorf("parsing %%q: %%+v", input, err)
	}

	var ok bool
	id := %[2]s{}

	%[4]s

	return &id, nil
}`, functionName, r.name, !caseSensitive, strings.Join(lines, "\n"), description)
	return &out, nil
}

func (r resourceIdTemplater) segmentsFunction() (*string, error) {
	lines := make([]string, 0)

	for _, segment := range r.resource.Segments {
		switch segment.Type {
		case resourcemanager.ConstantSegment:
			{
				if segment.ConstantReference == nil {
					return nil, fmt.Errorf("constant segment %q had no reference", segment.Name)
				}
				lines = append(lines, fmt.Sprintf("resourceids.ConstantSegment(%q, PossibleValuesFor%[2]s(), %q),", segment.Name, *segment.ConstantReference, segment.ExampleValue))
				continue
			}
		case resourcemanager.ResourceGroupSegment:
			{
				lines = append(lines, fmt.Sprintf("resourceids.ResourceGroupSegment(%q, %q),", segment.Name, segment.ExampleValue))
				continue
			}
		case resourcemanager.ResourceProviderSegment:
			{
				if segment.FixedValue == nil {
					return nil, fmt.Errorf("resource provider segment %q had no value", segment.Name)
				}

				lines = append(lines, fmt.Sprintf("resourceids.ResourceProviderSegment(%q, %q, %q),", segment.Name, *segment.FixedValue, segment.ExampleValue))
				continue
			}
		case resourcemanager.ScopeSegment:
			{
				lines = append(lines, fmt.Sprintf("resourceids.ScopeSegment(%q, %q),", segment.Name, segment.ExampleValue))
				continue
			}
		case resourcemanager.StaticSegment:
			{
				if segment.FixedValue == nil {
					return nil, fmt.Errorf("static segment %q had no value", segment.Name)
				}

				lines = append(lines, fmt.Sprintf("resourceids.StaticSegment(%q, %q, %q),", segment.Name, *segment.FixedValue, segment.ExampleValue))
				continue
			}
		case resourcemanager.SubscriptionIdSegment:
			{
				lines = append(lines, fmt.Sprintf("resourceids.SubscriptionIdSegment(%q, %q),", segment.Name, segment.ExampleValue))
				continue
			}
		case resourcemanager.UserSpecifiedSegment:
			{
				lines = append(lines, fmt.Sprintf("resourceids.UserSpecifiedSegment(%q, %q),", segment.Name, segment.ExampleValue))
				continue
			}

		default:
			return nil, fmt.Errorf("unimplemented segment type %q", string(segment.Type))
		}
	}

	wordifiedName := wordifyString(r.name)
	out := fmt.Sprintf(`
// Segments returns a slice of Resource ID Segments which comprise this %[3]s ID
func (id %[1]s) Segments() []resourceids.Segment {
	return []resourceids.Segment{
		%[2]s
	}
}
`, r.name, strings.Join(lines, "\n"), wordifiedName)
	return &out, nil
}

func (r resourceIdTemplater) stringFunction(data ServiceGeneratorData) (*string, error) {
	componentsLines := make([]string, 0)
	for _, segment := range r.resource.Segments {
		switch segment.Type {
		case resourcemanager.ResourceProviderSegment, resourcemanager.StaticSegment:
			continue

		case resourcemanager.ConstantSegment:
			if segment.ConstantReference == nil {
				return nil, fmt.Errorf("segment %q is a constant without a reference", segment.Name)
			}
			constant, ok := data.constants[*segment.ConstantReference]
			if !ok {
				return nil, fmt.Errorf("the constant %q for segment %q was not found in the data", *segment.ConstantReference, segment.Name)
			}

			typeName, err := golangTypeNameForConstantType(constant.Type)
			if err != nil {
				return nil, fmt.Errorf("for constant %q: %+v", segment.Name, err)
			}
			// e.g.
			// components = append(components, fmt.Sprintf("SomeVal: string(%s)", id.SomeVal)
			componentsLines = append(componentsLines, fmt.Sprintf(`fmt.Sprintf("%[1]s: %%q", %[2]s(id.%[3]s)),`, wordifyString(segment.Name), *typeName, strings.Title(segment.Name)))

		default:
			// e.g.
			// components = append(components, fmt.Sprintf("SomeVal: %q", id.SomeVal)
			componentsLines = append(componentsLines, fmt.Sprintf(`fmt.Sprintf("%[1]s: %%q", id.%[2]s),`, wordifyString(segment.Name), strings.Title(segment.Name)))
		}
	}

	wordifiedName := wordifyString(r.name)
	out := fmt.Sprintf(`
// String returns a human-readable description of this %[3]s ID
func (id %[1]s) String() string {
	components := []string{
		%[2]s
	}
	return fmt.Sprintf("%[3]s (%%s)", strings.Join(components, "\n"))  
}`, r.name, strings.Join(componentsLines, "\n"), wordifiedName)
	return &out, nil
}

func (r resourceIdTemplater) validateFunction(nameWithoutSuffix string) string {
	wordifiedName := wordifyString(r.name)
	return fmt.Sprintf(`
// Validate%[1]sID checks that 'input' can be parsed as a %[2]s ID
func Validate%[1]sID(input interface{}, key string) (warnings []string, errors []error) {
	v, ok := input.(string)
	if !ok {
		errors = append(errors, fmt.Errorf("expected %%q to be a string", key))
		return
	}

	if _, err := Parse%[1]sID(v); err != nil {
		errors = append(errors, err)
	}

	return
}
`, nameWithoutSuffix, wordifiedName)
}
