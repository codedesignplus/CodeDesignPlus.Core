cd ..

# Vars
$path = "tests\CodeDesignPlus.Core.Test"
$project = "$path\CodeDesignPlus.Core.Test.csproj"
$report = "$path\coverage.opencover.xml"


# Run Sonnar Scanner
dotnet test $project /p:CollectCoverage=true /p:CoverletOutputFormat=opencover

dotnet sonarscanner begin /k:"CodeDesignPlus.Core" /d:sonar.host.url=http://localhost:9000 /d:sonar.cs.opencover.reportsPaths="$report" /d:sonar.coverage.exclusions="**Test*.cs"

dotnet build

dotnet sonarscanner end