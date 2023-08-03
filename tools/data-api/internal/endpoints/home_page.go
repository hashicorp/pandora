package endpoints

import (
	"html/template"
	"log"
	"net/http"
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
		<li>
			<a href="/v1/resource-manager/commonTypes">
				<strong>GET</strong>
				<code>/v1/resource-manager/commonTypes</code>
			</a>
		</li>
		<li>
			<a href="/v1/resource-manager/services">
				<strong>GET</strong>
				<code>/v1/resource-manager/services</code>
			</a>
		</li>
		<li>
			<strong>GET</strong>
			<code>/v1/resource-manager/services/{serviceName}</code>
		</li>
		<li>
			<strong>GET</strong>
			<code>/v1/resource-manager/services/{serviceName}/{serviceApiVersion}</code>
		</li>
		<li>
			<strong>GET</strong>
			<code>/v1/resource-manager/services/{serviceName}/{serviceApiVersion}</code>
		</li>
		<li>
			<strong>GET</strong>
			<code>/v1/resource-manager/services/{serviceName}/terraform</code>
		</li>
		<li>
			<strong>GET</strong>
			<code>/v1/resource-manager/services/{serviceName}/{resourceName}/operations</code>
		</li>
		<li>
			<strong>GET</strong>
			<code>/v1/resource-manager/services/{serviceName}/{resourceName}/schema</code>
		</li>
	</ul>
</body>
</html>
`

func HomePage(w http.ResponseWriter, r *http.Request) {
	templ, err := template.New("home-page").Parse(homePageTemplate)
	if err != nil {
		log.Printf("[ERROR] Serving Home Page: %+v", err)
		w.WriteHeader(http.StatusInternalServerError)
	}
	templ.Execute(w, nil)
}
