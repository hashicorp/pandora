#!/bin/bash

set -e

DIR="$(cd "$(dirname "$0")" && pwd)/.."

function buildAndInstallDependencies {
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
  local dataApiAssemblyPath=$1
  local outputDirectory=$2

  echo "Running Wrapper.."
  cd "${DIR}/tools/wrapper-automation"
  ./wrapper-automation terraform \
    -data-api-assembly-path="../../$dataApiAssemblyPath"\
    -output-dir="../../$outputDirectory"

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
  local sdkRepo=$2

  echo "Removing any existing working directory.."
  cd "${DIR}"
  rm -rf "$workingDirectory"

  echo "Cloning SDK Repository into $workingDirectory.."
  git clone "$sdkRepo" "$workingDirectory"

  echo "Preparing the repository for generation"
  cd "${DIR}"
  cd "${workingDirectory}"
  make prepare # TODO: add this to the private repo

  cd "${DIR}"
}

function runFmtImportsAndGenerate {
  local workingDirectory=$1

  echo "Running 'make fmt'.."
  cd "${workingDirectory}"
  make fmt

  echo "Running 'make goimports'.."
  make goimports

  echo "Running 'make generate'.."
  make fmt

  cd "${DIR}"
}

function cleanup {
  local outputDirectory=$1

  cd "${DIR}"
  echo "Removing temporary working directory $outputDirectory.."
  rm -rf "$outputDirectory"
}

function main {
  local dataApiAssemblyPath="data/Pandora.Api/bin/Debug/net6.0/Pandora.Api.dll"
  local outputDirectory="tmp/provider-azurerm"
  local sdkRepo="git@github.com:hashicorp/terraform-provider-azurerm-private.git"

  buildAndInstallDependencies
  prepareTerraformProvider "$outputDirectory" "$sdkRepo"
  runWrapper "$dataApiAssemblyPath" "$outputDirectory"
  runFmtImportsAndGenerate "$outputDirectory"
  runTerraformProviderUnitTests "$outputDirectory"
  cleanup "$outputDirectory"
}

main
