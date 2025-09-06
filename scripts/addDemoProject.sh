set -euo pipefail


# root/
# ├── <feature-flavor>/
# │   ├── <feature-name>/
#         ├── Demo.cs
#         ├── <created project files>...

# echo "namespace Cookbook.<FeatureFlavor>.<FeatureName>;" Demo.cs


# Parameters
FEATURE_FLAVOR=$1
FEATURE_NAME=$2
PROJECT_TYPE=$3

delimeter="-"
FEATURE=""
FEATURENAME=""
# best-practices\dep-inj\Demo.cs
FEATURE_DIR="$FEATURE_FLAVOR/$FEATURE_NAME"
#tests\DepInj.tests\DepInj.tests.csproj
TEST_DIR="tests/${FEATURE}.tests"

# Ensure base directories
mkdir -p "$FEATURE_DIR"
mkdir -p "$TEST_DIR"

# Create project and test project
dotnet new "$PROJECT_TYPE" -o "$FEATURE_DIR"
dotnet new xunit -o "$TEST_DIR"

# Add to solution
dotnet sln add "$FEATURE_DIR/$FEATURE_NAME.csproj"
dotnet sln add "$TEST_DIR/${FEATURE_NAME}.Tests.csproj"

# Add reference from Tests -> Project
dotnet add "$TEST_DIR/${FEATURE_NAME}.Tests.csproj" reference "$FEATURE_DIR/$FEATURE_NAME.csproj"

# Build solution
dotnet build