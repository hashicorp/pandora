package generator

import (
	"fmt"
	"strings"
	"unicode"
)

var _ templater = idParserTemplater{}

type idParserTemplater struct {
	name   string
	format string
}

func (c idParserTemplater) template(data ServiceGeneratorData) (*string, error) {
	rid, err := newResourceID(c.name, data.packageName, c.format)
	if err != nil {
		return nil, fmt.Errorf("scaffolding ID Parser for %q (%q): %+v", c.name, c.format, err)
	}

	code := rid.code()
	return &code, nil
}

// pretty much lifted and shifted from terraform-provider-azurerm - this needs refactoring
type resourceIdSegment struct {
	// ArgumentName is the name which should be used when this segment is used in an Argument
	ArgumentName string

	// FieldName is the name which should be used for this segment when referenced in a Field
	FieldName string

	// SegmentKey is the Segment used for this in the Resource ID e.g. `resourceGroups`
	SegmentKey string

	// SegmentValue is the value for this segment used in the Resource ID
	SegmentValue string
}

type resourceIdParserData struct {
	TypeName string
	IDFmt    string
	IDRaw    string

	ServicePackageName string

	HasResourceGroup  bool
	HasSubscriptionId bool
	Segments          []resourceIdSegment // this has to be a slice not a map since we care about the order
}

func newResourceID(typeName, servicePackageName, resourceId string) (*resourceIdParserData, error) {
	// split the string, but remove the prefix of `/` since it's an empty segment
	split := strings.Split(strings.TrimPrefix(resourceId, "/"), "/")
	if len(split)%2 != 0 {
		return nil, fmt.Errorf("segments weren't divisible by 2: %q", resourceId)
	}

	segments := make([]resourceIdSegment, 0)
	for i := 0; i < len(split); i += 2 {
		key := split[i]
		value := split[i+1]

		// the RP shouldn't be transformed
		if key == "providers" {
			continue
		}

		var segmentBuilder = func(key, value string, hasSubscriptionId bool) resourceIdSegment {
			var toCamelCase = func(input string) string {
				// lazy but it works
				out := make([]rune, 0)
				for i, char := range strings.Title(input) {
					if i == 0 {
						out = append(out, unicode.ToLower(char))
						continue
					}

					out = append(out, char)
				}
				return string(out)
			}

			rewritten := fmt.Sprintf("%sName", key)
			segment := resourceIdSegment{
				FieldName:    strings.Title(rewritten),
				ArgumentName: toCamelCase(rewritten),
				SegmentKey:   key,
				SegmentValue: value,
			}

			if strings.EqualFold(key, "resourceGroups") {
				segment.FieldName = "ResourceGroup"
				segment.ArgumentName = "resourceGroup"
				return segment
			}

			if key == "subscriptions" && !hasSubscriptionId {
				segment.FieldName = "SubscriptionId"
				segment.ArgumentName = "subscriptionId"
				return segment
			}

			if strings.HasSuffix(key, "s") {
				// TODO: in time this could be worth a series of overrides

				// handles "GallerieName" and `DataFactoriesName`
				if strings.HasSuffix(key, "ies") {
					key = strings.TrimSuffix(key, "ies")
					key = fmt.Sprintf("%sy", key)
				}

				// handles `PublicIPAddressesName`
				if strings.HasSuffix(key, "sses") {
					key = strings.TrimSuffix(key, "sses")
					key = fmt.Sprintf("%sss", key)
				} else if strings.HasSuffix(key, "s") {
					key = strings.TrimSuffix(key, "s")
				}

				if strings.EqualFold(key, typeName) {
					segment.FieldName = "Name"
					segment.ArgumentName = "name"
				} else {
					// remove {Thing}s and make that {Thing}Name
					rewritten = fmt.Sprintf("%sName", key)
					segment.FieldName = strings.Title(rewritten)
					segment.ArgumentName = toCamelCase(rewritten)
				}
			}

			return segment
		}

		// handle multiple 'subscriptions' segments, ala ServiceBus Subscription
		hasSubscriptionId := false
		for _, v := range segments {
			if v.FieldName == "SubscriptionId" {
				hasSubscriptionId = true
				break
			}
		}

		segment := segmentBuilder(key, value, hasSubscriptionId)
		segments = append(segments, segment)
	}

	// finally build up the format string based on this information
	fmtString := resourceId
	hasResourceGroup := false
	hasSubscriptionId := false
	for _, segment := range segments {
		if strings.EqualFold(segment.SegmentKey, "subscriptions") {
			hasSubscriptionId = true
		}
		if strings.EqualFold(segment.SegmentKey, "resourceGroups") {
			hasResourceGroup = true
		}

		// has to be double-escaped since this is a fmtstring
		fmtString = strings.Replace(fmtString, segment.SegmentValue, "%s", 1)
	}

	return &resourceIdParserData{
		IDFmt:              fmtString,
		IDRaw:              resourceId,
		HasResourceGroup:   hasResourceGroup,
		HasSubscriptionId:  hasSubscriptionId,
		Segments:           segments,
		ServicePackageName: servicePackageName,
		TypeName:           typeName,
	}, nil
}

func (id resourceIdParserData) code() string {
	return fmt.Sprintf(`package %s

import (
	"fmt"
	"strings"

	"github.com/hashicorp/go-azure-helpers/resourcemanager/resourceids"
)

%s
%s
%s
%s
%s
%s
`, id.ServicePackageName, id.codeForType(), id.codeForConstructor(), id.codeForDescription(), id.codeForFormatter(), id.codeForParser(), id.codeForParserInsensitive())
}

func (id resourceIdParserData) codeForType() string {
	fields := make([]string, 0)
	for _, segment := range id.Segments {
		fields = append(fields, fmt.Sprintf("\t%s\tstring", segment.FieldName))
	}
	fieldStr := strings.Join(fields, "\n")
	return fmt.Sprintf(`
type %[1]sId struct {
%[2]s
}
`, id.TypeName, fieldStr)
}

func (id resourceIdParserData) codeForConstructor() string {
	arguments := make([]string, 0)
	assignments := make([]string, 0)

	for _, segment := range id.Segments {
		arguments = append(arguments, segment.ArgumentName)
		assignments = append(assignments, fmt.Sprintf("\t\t%s:\t%s,", segment.FieldName, segment.ArgumentName))
	}

	argumentsStr := strings.Join(arguments, ", ")
	assignmentsStr := strings.Join(assignments, "\n")
	return fmt.Sprintf(`
func New%[1]sID(%[2]s string) %[1]sId {
	return %[1]sId{
%[3]s
	}
}
`, id.TypeName, argumentsStr, assignmentsStr)
}

func (id resourceIdParserData) codeForDescription() string {
	var makeHumanReadable = func(input string) string {
		chars := make([]rune, 0)
		for _, c := range input {
			if unicode.IsUpper(c) {
				chars = append(chars, ' ')
			}

			chars = append(chars, c)
		}
		out := string(chars)
		return strings.TrimSpace(out)
	}

	formatKeys := make([]string, 0)
	for _, segment := range id.Segments {
		if segment.FieldName == "SubscriptionId" {
			continue
		}

		humanReadableKey := makeHumanReadable(segment.FieldName)
		formatKeys = append(formatKeys, fmt.Sprintf("\t\tfmt.Sprintf(\"%[1]s %%q\", id.%[2]s),", humanReadableKey, segment.FieldName))
	}

	reversedKeys := make([]string, 0)
	for i := len(formatKeys); i != 0; i-- {
		reversedKeys = append(reversedKeys, formatKeys[i-1])
	}

	formatKeysString := strings.Join(reversedKeys, "\n")
	return fmt.Sprintf(`
func (id %[1]sId) String() string {
	segments := []string{
%s
	}
	segmentsStr := strings.Join(segments, " / ")
	return fmt.Sprintf("%%s: (%%s)", %[3]q, segmentsStr)
}
`, id.TypeName, formatKeysString, makeHumanReadable(id.TypeName))
}

func (id resourceIdParserData) codeForFormatter() string {
	formatKeys := make([]string, 0)
	for _, segment := range id.Segments {
		formatKeys = append(formatKeys, fmt.Sprintf("id.%s", segment.FieldName))
	}
	formatKeysString := strings.Join(formatKeys, ", ")
	return fmt.Sprintf(`
func (id %[1]sId) ID() string {
	fmtString := %[2]q
	return fmt.Sprintf(fmtString, %[3]s)
}
`, id.TypeName, id.IDFmt, formatKeysString)
}

func (id resourceIdParserData) codeForParser() string {
	directAssignments := make([]string, 0)
	if id.HasSubscriptionId {
		directAssignments = append(directAssignments, "\t\tSubscriptionId: id.SubscriptionID,")
	}
	if id.HasResourceGroup {
		directAssignments = append(directAssignments, "\t\tResourceGroup: id.ResourceGroup,")
	}
	directAssignmentsStr := strings.Join(directAssignments, "\n")

	parserStatements := make([]string, 0)
	for _, segment := range id.Segments {
		isSubscription := strings.EqualFold(segment.FieldName, "SubscriptionId") && id.HasSubscriptionId
		isResourceGroup := strings.EqualFold(segment.FieldName, "ResourceGroup") && id.HasResourceGroup
		if isSubscription || isResourceGroup {
			parserStatements = append(parserStatements, fmt.Sprintf(`
	if resourceId.%[1]s == "" {
		return nil, fmt.Errorf("ID was missing the '%[2]s' element")
	}
`, segment.FieldName, segment.SegmentKey))
			continue
		}

		fmtString := "\tif resourceId.%[1]s, err = id.PopSegment(\"%[2]s\"); err != nil {\n\t\treturn nil, err\n\t}"
		parserStatements = append(parserStatements, fmt.Sprintf(fmtString, segment.FieldName, segment.SegmentKey))
	}
	parserStatementsStr := strings.Join(parserStatements, "\n")
	return fmt.Sprintf(`
// %[1]sID parses a %[1]s ID into an %[1]sId struct 
func %[1]sID(input string) (*%[1]sId, error) {
	id, err := resourceids.ParseAzureResourceID(input)
	if err != nil {
		return nil, err
	}

	resourceId := %[1]sId{
%[2]s
	}

%[3]s

	if err := id.ValidateNoEmptySegments(input); err != nil {
		return nil, err
	}

	return &resourceId, nil
}
`, id.TypeName, directAssignmentsStr, parserStatementsStr)
}

func (id resourceIdParserData) codeForParserInsensitive() string {
	directAssignments := make([]string, 0)
	if id.HasSubscriptionId {
		directAssignments = append(directAssignments, "\t\tSubscriptionId: id.SubscriptionID,")
	}
	if id.HasResourceGroup {
		directAssignments = append(directAssignments, "\t\tResourceGroup: id.ResourceGroup,")
	}
	directAssignmentsStr := strings.Join(directAssignments, "\n")

	parserStatements := make([]string, 0)
	for _, segment := range id.Segments {
		isSubscription := strings.EqualFold(segment.FieldName, "SubscriptionId") && id.HasSubscriptionId
		isResourceGroup := strings.EqualFold(segment.FieldName, "ResourceGroup") && id.HasResourceGroup
		if isSubscription || isResourceGroup {
			parserStatements = append(parserStatements, fmt.Sprintf(`
	if resourceId.%[1]s == "" {
		return nil, fmt.Errorf("ID was missing the '%[2]s' element")
	}
`, segment.FieldName, segment.SegmentKey))
			continue
		}

		// NOTE: This becomes dramatically simpler long-term - but for now has to be long-winded
		// to avoid subtle changes to resources until this is threaded through everywhere
		fmtString := `
  // find the correct casing for the '%[2]s' segment
  %[2]sKey := "%[2]s"
  for key := range id.Path {
  	if strings.EqualFold(key, %[2]sKey) {
  		%[2]sKey = key
  		break
  	}
  }
  if resourceId.%[1]s, err = id.PopSegment(%[2]sKey); err != nil {
    return nil, err
  }
`
		parserStatements = append(parserStatements, fmt.Sprintf(fmtString, segment.FieldName, segment.SegmentKey))
	}
	parserStatementsStr := strings.Join(parserStatements, "\n")
	return fmt.Sprintf(`
// %[1]sIDInsensitively parses an %[1]s ID into an %[1]sId struct, insensitively
// This should only be used to parse an ID for rewriting to a consistent casing,
// the %[1]sID method should be used instead for validation etc.
func %[1]sIDInsensitively(input string) (*%[1]sId, error) {
	id, err := resourceids.ParseAzureResourceID(input)
	if err != nil {
		return nil, err
	}

	resourceId := %[1]sId{
%[2]s
	}

%[3]s

	if err := id.ValidateNoEmptySegments(input); err != nil {
		return nil, err
	}

	return &resourceId, nil
}
`, id.TypeName, directAssignmentsStr, parserStatementsStr)
}
