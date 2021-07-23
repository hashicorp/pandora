package generator

import (
	"fmt"
	"os"
	"path/filepath"
)

type CustomTypeGenerator struct{}

func NewCustomTypeGenerator() CustomTypeGenerator {
	return CustomTypeGenerator{}
}

type CustomTypeGeneratorInput struct {
	OutputDirectory string
}

type customTypeFile struct {
	filename string
	content  []byte
}

func (g *CustomTypeGenerator) Generate(input CustomTypeGeneratorInput) error {
	outputPath := filepath.Join(input.OutputDirectory, "customtype")

	if err := cleanAndRecreateWorkingDirectory(outputPath); err != nil {
		return fmt.Errorf("cleaning/recreating working directory %q: %+v", outputPath, err)
	}

	files := []customTypeFile{
		{
			filename: "identity_system_assigned.go",
			content: []byte(fmt.Sprintf(`
package customtype

type SystemAssignedIdentity struct {
	Type *string %[1]sjson:"type,omitempty"%[1]s
	TenantID *string %[1]sjson:"tenantId,omitempty"%[1]s
	PrincipalID *string %[1]sjson:"principalId,omitempty"%[1]s
}

`, "`")),
		},
		{
			filename: "identity_user_assigned_identity.go",
			content: []byte(fmt.Sprintf(`
package customtype

type UserAssignedIdentity struct {
	ResourceId *string %[1]sjson:"resourceId,omitempty"%[1]s
	UserAssignedIdentityInfo
}

type UserAssignedIdentityInfo struct {
	ClientId *string %[1]sjson:"clientId,omitempty"%[1]s
	PrincipalId *string %[1]sjson:"principalId,omitempty"%[1]s
}
`, "`")),
		},
		{
			filename: "identity_user_assigned_list.go",
			content: []byte(fmt.Sprintf(`
package customtype

type UserAssignedIdentityList struct {
	Type *string %[1]sjson:"type,omitempty"%[1]s
	UserAssignedIdentities  []*UserAssignedIdentity %[1]sjson:"userAssignedIdentities,omitempty"%[1]s
}
`, "`")),
		},
		{
			filename: "identity_user_assigned_map.go",
			content: []byte(fmt.Sprintf(`
package customtype

type UserAssignedIdentityMap struct {
	Type *string %[1]sjson:"type,omitempty"%[1]s
	UserAssignedIdentities  map[string]*UserAssignedIdentityInfo %[1]sjson:"userAssignedIdentities,omitempty"%[1]s
}
`, "`")),
		},
		{
			filename: "identity_system_user_assigned_list.go",
			content: []byte(fmt.Sprintf(`
package customtype

type SystemUserAssignedIdentityList struct {
	Type *string %[1]sjson:"type,omitempty"%[1]s
	TenantId *string %[1]sjson:"tenantId,omitempty"%[1]s
	PrincipalId *string %[1]sjson:"principalId,omitempty"%[1]s
	UserAssignedIdentities  []*UserAssignedIdentity %[1]sjson:"userAssignedIdentities,omitempty"%[1]s
}
`, "`")),
		},
		{
			filename: "identity_system_user_assigned_map.go",
			content: []byte(fmt.Sprintf(`
package customtype

type SystemUserAssignedIdentityMap struct {
	Type *string %[1]sjson:"type,omitempty"%[1]s
	TenantId *string %[1]sjson:"tenantId,omitempty"%[1]s
	PrincipalId *string %[1]sjson:"principalId,omitempty"%[1]s
	UserAssignedIdentities  map[string]*UserAssignedIdentityInfo %[1]sjson:"userAssignedIdentities,omitempty"%[1]s
}
`, "`")),
		},
	}

	for _, f := range files {
		fullFilePath := filepath.Join(outputPath, f.filename)
		_ = os.Remove(fullFilePath)
		file, err := os.Create(fullFilePath)
		defer file.Close()
		if err != nil {
			return fmt.Errorf("opening %q: %+v", fullFilePath, err)
		}

		if _, err := file.Write(f.content); err != nil {
			return fmt.Errorf("writing %q: %+v", fullFilePath, err)
		}
	}

	runGoFmt(outputPath)
	runGoImports(outputPath)

	return nil
}
