// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package endpoints

import (
	"fmt"
	"html/template"
	"net/http"
	"sort"
	"strings"

	"github.com/go-chi/chi/v5"
	"github.com/hashicorp/pandora/tools/data-api/internal/logging"
)

const homePageTemplate = `
<html>
	<header>
		<title>Pandora Data API</title>
	</header>
<body>
	<h1>Pandora Data API</h1>
	<h3>Routes</h3>
	<ul>
		{{range . }}
			{{if .Linkable }}
				<li>
					<a href="{{.Uri}}">
						<code>{{.Uri}}</code>
					</a>
				</li>
			{{ else }}
				<li>
					<code>{{.Uri}}</code>
				</li>
			{{end}}
		{{end}}
	</ul>
</body>
</html>
`

func HomePage(router chi.Router) func(w http.ResponseWriter, r *http.Request) {
	return func(w http.ResponseWriter, r *http.Request) {
		routes := routerToListOfRoutes(router.Routes())
		links := homePageLinksFromRoutes(routes)

		templ, err := template.New("home-page").Parse(homePageTemplate)
		if err != nil {
			logging.Errorf("Serving Home Page: %+v", err)
			w.WriteHeader(http.StatusInternalServerError)
		}
		templ.Execute(w, links)
	}
}

type homePageLink struct {
	Uri      string
	Linkable bool
}

func homePageLinksFromRoutes(input []string) []homePageLink {
	// ensure the ordering is consistent
	sort.Strings(input)

	output := make([]homePageLink, 0)

	for _, item := range input {
		containsTemplatedParameter := false
		if strings.Contains(item, "{") {
			containsTemplatedParameter = true
		}
		if !containsTemplatedParameter && strings.Contains(item, "}") {
			containsTemplatedParameter = true
		}
		output = append(output, homePageLink{
			Uri:      item,
			Linkable: !containsTemplatedParameter,
		})
	}

	return output
}

func routerToListOfRoutes(input []chi.Route) []string {
	output := make([]string, 0)

	for _, route := range input {
		if route.SubRoutes != nil && len(route.SubRoutes.Routes()) > 0 {
			prefix := strings.TrimSuffix(route.Pattern, "/*")
			subRoutes := routerToListOfRoutes(route.SubRoutes.Routes())
			for _, subRoute := range subRoutes {
				output = append(output, fmt.Sprintf("%s%s", prefix, subRoute))
			}
			continue
		}

		output = append(output, strings.TrimSuffix(route.Pattern, "/"))
	}

	return output
}
