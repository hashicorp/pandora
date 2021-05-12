package generator

import "fmt"

func golangConstantForStatusCode(statusCode int) string {
	codes := map[int]string{
		200: "http.StatusOK",
		201: "http.StatusCreated",
		202: "http.StatusAccepted",
		204: "http.StatusNoContent",
		301: "http.StatusMovedPermanently",
		302: "http.StatusFound",
		307: "http.StatusTemporaryRedirect",
		308: "http.StatusPermanentRedirect",
		400: "http.StatusBadRequest",
		401: "http.StatusUnauthorized",
		403: "http.StatusForbidden",
		404: "http.StatusNotFound",
		405: "http.StatusMethodNotAllowed",
		406: "http.StatusNotAcceptable",
		407: "http.StatusProxyAuthRequired",
		408: "http.StatusRequestTimeout",
		409: "http.StatusConflict",
		410: "http.StatusGone",
		429: "http.StatusTooManyRequests",
		500: "http.StatusInternalServerError",
		501: "http.StatusNotImplemented",
		502: "http.StatusBadGateway",
		503: "http.StatusServiceUnavailable",
		504: "http.StatusGatewayTimeout",
	}
	v, ok := codes[statusCode]
	if ok {
		return v
	}

	return fmt.Sprintf("%d // TODO: document me", statusCode)
}
