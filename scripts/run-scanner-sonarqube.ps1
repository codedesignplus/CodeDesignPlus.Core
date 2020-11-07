dotnet test .\tests\CodeDesignPlus.Core.Test\CodeDesignPlus.Core.Test.csproj /p:CollectCoverage=true /p:CoverletOutputFormat=opencover

dotnet sonarscanner begin /k:"CodeDesignPlus.Core" /d:sonar.host.url=http://localhost:9000 /d:sonar.cs.opencover.reportsPaths="tests\CodeDesignPlus.Core.Test\coverage.opencover.xml" /d:sonar.coverage.exclusions="**Tests*.cs"

dotnet build

dotnet sonarscanner end
