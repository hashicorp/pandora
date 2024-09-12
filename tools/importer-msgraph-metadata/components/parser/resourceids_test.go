package parser

import (
	"reflect"
	"testing"

	"github.com/davecgh/go-spew/spew"
	"github.com/hashicorp/go-azure-helpers/lang/pointer"
)

func TestNewResourceID(t *testing.T) {
	testCases := []struct {
		input    string
		tags     []string
		expected ResourceId
	}{
		{
			input: "/applications",
			tags:  []string{"applications.application"},
			expected: ResourceId{
				Segments: []ResourceIdSegment{
					{
						Type:   SegmentLabel,
						Value:  "applications",
						plural: true,
					},
				},
			},
		},
		{
			input: "/applications/{application-id}",
			tags:  []string{"applications.application"},
			expected: ResourceId{
				Segments: []ResourceIdSegment{
					{
						Type:   SegmentLabel,
						Value:  "applications",
						plural: true,
					},
					{
						Type:  SegmentUserValue,
						Value: "{applicationId}",
						field: pointer.To("ApplicationId"),
					},
				},
			},
		},
		{
			input: "/groups/{group-id}/owners",
			tags:  []string{"groups.directoryObject"},
			expected: ResourceId{
				Segments: []ResourceIdSegment{
					{
						Type:   SegmentLabel,
						Value:  "groups",
						plural: true,
					},
					{
						Type:  SegmentUserValue,
						Value: "{groupId}",
						field: pointer.To("GroupId"),
					},
					{
						Type:   SegmentLabel,
						Value:  "owners",
						plural: true,
					},
				},
			},
		},
		{
			input: "/groups/{group-id}/owners/$count",
			tags:  []string{"groups.directoryObject"},
			expected: ResourceId{
				Segments: []ResourceIdSegment{
					{
						Type:   SegmentLabel,
						Value:  "groups",
						plural: true,
					},
					{
						Type:  SegmentUserValue,
						Value: "{groupId}",
						field: pointer.To("GroupId"),
					},
					{
						Type:   SegmentLabel,
						Value:  "owners",
						plural: true,
					},
					{
						Type:  SegmentODataReference,
						Value: "$count",
					},
				},
			},
		},
		{
			input: "/groups/{group-id}/owners/$ref",
			tags:  []string{"groups.directoryObject"},
			expected: ResourceId{
				Segments: []ResourceIdSegment{
					{
						Type:   SegmentLabel,
						Value:  "groups",
						plural: true,
					},
					{
						Type:  SegmentUserValue,
						Value: "{groupId}",
						field: pointer.To("GroupId"),
					},
					{
						Type:   SegmentLabel,
						Value:  "owners",
						plural: true,
					},
					{
						Type:  SegmentODataReference,
						Value: "$ref",
					},
				},
			},
		},
		{
			input: "/applications/{application-id}/microsoft.graph.setVerifiedPublisher",
			tags:  []string{"applications.Actions"},
			expected: ResourceId{
				Segments: []ResourceIdSegment{
					{
						Type:   SegmentLabel,
						Value:  "applications",
						plural: true,
					},
					{
						Type:  SegmentUserValue,
						Value: "{applicationId}",
						field: pointer.To("ApplicationId"),
					},
					{
						Type:  SegmentAction,
						Value: "setVerifiedPublisher",
					},
				},
			},
		},
		{
			input: "/groups/microsoft.graph.delta()",
			tags:  []string{"groups.Functions"},
			expected: ResourceId{
				Segments: []ResourceIdSegment{
					{
						Type:   SegmentLabel,
						Value:  "groups",
						plural: true,
					},
					{
						Type:  SegmentFunction,
						Value: "microsoft.graph.delta()",
					},
				},
			},
		},
		{
			input: "/directory/administrativeUnits/{administrativeUnit-id}/members/{directoryObject-id}/microsoft.graph.servicePrincipal",
			tags:  []string{"directory.administrativeUnit"},
			expected: ResourceId{
				Segments: []ResourceIdSegment{
					{
						Type:  SegmentLabel,
						Value: "directory",
					},
					{
						Type:   SegmentLabel,
						Value:  "administrativeUnits",
						plural: true,
					},
					{
						Type:  SegmentUserValue,
						Value: "{administrativeUnitId}",
						field: pointer.To("AdministrativeUnitId"),
					},
					{
						Type:   SegmentLabel,
						Value:  "members",
						plural: true,
					},
					{
						Type:  SegmentUserValue,
						Value: "{directoryObjectId}",
						field: pointer.To("DirectoryObjectId"),
					},
					{
						Type:  SegmentCast,
						Value: "microsoft.graph.servicePrincipal",
					},
				},
			},
		},
		{
			input: "/security/threatIntelligence/vulnerabilities/{vulnerability-id}/components/$count",
			tags:  []string{"security.threatIntelligence"},
			expected: ResourceId{
				Segments: []ResourceIdSegment{
					{
						Type:  SegmentLabel,
						Value: "security",
					},
					{
						Type:  SegmentLabel,
						Value: "threatIntelligence",
					},
					{
						Type:   SegmentLabel,
						Value:  "vulnerabilities",
						plural: true,
					},
					{
						Type:  SegmentUserValue,
						Value: "{vulnerabilityId}",
						field: pointer.To("VulnerabilityId"),
					},
					{
						Type:   SegmentLabel,
						Value:  "components",
						plural: true,
					},
					{
						Type:  SegmentODataReference,
						Value: "$count",
					},
				},
			},
		},
	}

	for _, c := range testCases {
		id := NewResourceId(c.input, c.tags)
		if !reflect.DeepEqual(id, c.expected) {
			t.Errorf(`expected:
%s

received:
%s`, spew.Sdump(c.expected), spew.Sdump(id))
		}
	}
}

func TestTruncateToLastSegmentOfTypeBeforeSegment(t *testing.T) {
	testCases := []struct {
		input        string
		tags         []string
		segmentTypes []ResourceIdSegmentType
		index        int
		expected     string
	}{
		{
			input:        "/applications/{application-id}/owners",
			tags:         []string{"applications.DirectoryObject"},
			segmentTypes: []ResourceIdSegmentType{SegmentUserValue},
			index:        -1,
			expected:     "/applications/{applicationId}",
		},
		{
			input:        "/directory/administrativeUnits/{administrativeUnit-id}/members/{directoryObject-id}/microsoft.graph.servicePrincipal",
			tags:         []string{"directory.administrativeUnit"},
			segmentTypes: []ResourceIdSegmentType{SegmentUserValue},
			index:        4,
			expected:     "/directory/administrativeUnits/{administrativeUnit-id}",
		},
		{
			input:        "/security/threatIntelligence/vulnerabilities/{vulnerability-id}/components/$count",
			tags:         []string{"security.threatIntelligence"},
			segmentTypes: []ResourceIdSegmentType{SegmentLabel},
			index:        4,
			expected:     "/security/threatIntelligence/vulnerabilities",
		},
	}

	for _, c := range testCases {
		original := NewResourceId(c.input, c.tags)
		output := original.TruncateToLastSegmentOfTypeBeforeSegment(c.segmentTypes, c.index)

		if output == nil {
			t.Error("received nil ResourceId")
		}

		expected := NewResourceId(c.expected, c.tags)

		if !reflect.DeepEqual(*output, expected) {
			t.Errorf(`expected:
%s

received:
%s`, spew.Sdump(expected), spew.Sdump(output))
		}
	}
}
