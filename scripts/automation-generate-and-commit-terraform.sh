#!/bin/bash

set -e

DIR="$(cd "$(dirname "$0")" && pwd)/.."

function buildAndInstallDependencies {
    echo "Installing the Terraform Generator into the GOBIN.."
    cd "${DIR}/tools/generator-terraform"
    go install .
    cd "${DIR}"

    echo "Building Wrapper.."
    cd "${DIR}/tools/wrapper-terraform-generator"
    go build -o wrapper-terraform-generator
    cd "${DIR}"
}

function runWrapper {
  local dataApiAssemblyPath=$1
  local outputDirectory=$2

  echo "Running Wrapper.."
  cd "${DIR}/tools/wrapper-terraform-generator"
  ./wrapper-terraform-generator \
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

function conditionallyCommitAndPushGoSdk {
  local workingDirectory=$1
  local sha=$2
  local branch="auto-pr/$sha"

  cd "${DIR}"
  cd "$workingDirectory"
  if [[ $(git status --porcelain | wc -l) -gt 0 ]]; then
    echo "Committing and Pushing the changes"

    # commit the generated changes
    git checkout -b "$branch"
    git config user.name "hc-github-team-tf-azure"
    git config user.email "<>"
    git add --all
    git commit -m "Updating based on $sha"

    # then update the dependencies
    go mod tidy
    if [[ $(git status --porcelain | wc -l) -gt 0 ]]; then
      git add --all
      git commit -m "Updating dependencies based on $sha"
    fi

    # NOTE: we're intentionally force-pushing here in-case this PR is
    # open and other changes (e.g. to the generator) get included
    git push origin "$branch" -f
  else
    echo "No changes detected - skipping commit/push"
  fi
}

function getSwaggerSubmoduleSha {
  local submodulePath=$1

  cd "${DIR}"
  cd "$submodulePath"
  git rev-parse --short HEAD
}

function cleanup {
  local outputDirectory=$1

  cd "${DIR}"
  echo "Removing temporary working directory $outputDirectory.."
  rm -rf "$outputDirectory"
}

function main {
  local dataApiAssemblyPath="data/Pandora.Api/bin/Debug/net6.0/Pandora.Api.dll"
  local swaggerSubmodule="./swagger"
  local outputDirectory="tmp/go-azure-sdk"
  local sdkRepo="git@github.com:hashicorp/terraform-provider-azurerm-private.git"
  local sha

  buildAndInstallDependencies
  sha=$(getSwaggerSubmoduleSha "$swaggerSubmodule")
  prepareTerraformProvider "$outputDirectory" "$sdkRepo"
  runWrapper "$dataApiAssemblyPath" "$outputDirectory" "$sha"
  runTerraformProviderUnitTests "$outputDirectory" "$sha"
  cleanup "$outputDirectory"
}

main