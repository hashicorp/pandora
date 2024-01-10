#!/bin/bash

set -e

DIR="$(cd "$(dirname "$0")" && pwd)/.."

function buildAndInstallDependencies {
  echo "Outputting Go Version.."
  go version

  echo "Installing the Data API V2 onto the GOBIN.."
  cd "${DIR}/tools/data-api"
  go install .
  cd "${DIR}"

  echo "Installing the Terraform Generator into the GOBIN.."
  cd "${DIR}/tools/generator-terraform"
  go install .
  cd "${DIR}"

  echo "Building Wrapper.."
  cd "${DIR}/tools/wrapper-automation"
  go build -o wrapper-automation
  cd "${DIR}"
}

function runWrapper {
  local apiDefinitionsDirectory=$1
  local outputDirectory=$2

  echo "Running Wrapper.."
  cd "${DIR}/tools/wrapper-automation"
  ./wrapper-automation terraform \
    --api-definitions-dir="../../$apiDefinitionsDirectory"\
    --output-dir="../../$outputDirectory"

  cd "${DIR}"

  echo "Running 'make tools' within the Terraform Provider codebase.."
  cd "${outputDirectory}"
  make tools

  echo "Running 'make fmt' on the generated code.."
  make fmt

  cd "${DIR}"
}

function runTerraformProviderUnitTests {
  local outputDirectory=$1

  cd "${DIR}"

  echo "Running 'make test' within the Terraform Provider codebase.."
  cd "${outputDirectory}"
  make test
}

function prepareTerraformProvider {
  local workingDirectory=$1
  local providerRepo=$2

  echo "Removing any existing working directory.."
  cd "${DIR}"
  rm -rf "$workingDirectory"

  echo "Cloning Terraform Provider $providerRepo into $workingDirectory.."
  git clone "$providerRepo" "$workingDirectory"

  echo "Preparing the repository for generation"
  cd "${DIR}"
  cd "${workingDirectory}"
  make prepare

  cd "${DIR}"
}

function runFmtImportsAndGenerate {
  local workingDirectory=$1

  cd "${workingDirectory}"

  echo "Running 'go mod vendor'.."
  go mod vendor

  echo "Running 'make tools'.."
  make tools

  echo "Running 'make fmt'.."
  make fmt

  echo "Running 'make goimports'.."
  make goimports

  echo "Running 'make generate'.."
  make generate

  echo "Running 'make terrafmt'.."
  make terrafmt

  cd "${DIR}"
}

function cleanup {
  local outputDirectory=$1

  cd "${DIR}"
  echo "Removing temporary working directory $outputDirectory.."
  rm -rf "$outputDirectory"
}

function main {
  local apiDefinitionsDirectory="./api-definitions"
  local outputDirectory="tmp/provider-azurerm"
  local providerRepo="git@github.com:hashicorp/terraform-provider-azurerm.git"

  buildAndInstallDependencies
  prepareTerraformProvider "$outputDirectory" "$providerRepo"
  runWrapper "$apiDefinitionsDirectory" "$outputDirectory"
  runFmtImportsAndGenerate "$outputDirectory"
  runTerraformProviderUnitTests "$outputDirectory"
  cleanup "$outputDirectory"
}

main
