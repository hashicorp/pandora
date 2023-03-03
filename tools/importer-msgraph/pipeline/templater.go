package pipeline

import (
	"fmt"
	"strings"
)

func templateFile(pkg string, tmpl []string) string {
	return fmt.Sprintf(`package %[1]s

	import (
		"context"
		"fmt"
		"net/http"
		"time"

		"github.com/hashicorp/go-azure-sdk/microsoft-graph/models"
		"github.com/hashicorp/go-azure-sdk/sdk/client"
		"github.com/hashicorp/go-azure-sdk/sdk/client/msgraph"
		"github.com/hashicorp/go-azure-sdk/sdk/environments"
		"github.com/hashicorp/go-azure-sdk/sdk/odata"
	)

	%[2]s`, pkg, strings.Join(tmpl, "\n\n"))
}
