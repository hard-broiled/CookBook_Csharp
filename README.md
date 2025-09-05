
Target Framework: net8.0



Contribution Guide:
- directory structure guidance
    - feature flavor (best practice vs language feature etc.)
    - feature name (records vs structs etc)
    - mkdir <feature-flavor>/<feature-name>
- Make the new dotnet project for this feature/topic
    - cd feature-flavor/feature-name
    - dotnet new <project-type> "FeatureName" -o .
- Make related test project
    - cd ../.. (root)
    - mkdir -p tests/<feature-name>.tests
    - cd tests/<feature-name>.tests
    - dotnet new xunit -n <FeatureName>.tests -o .
    - cd ../.. (back to root)
- Add new project to the sln 
    - dotnet sln add <feature-flavor>/<feature-name>/<Feature>.csproj
- Link new tests to new project
    - dotnet add tests/<Feature>.tests/<Feature>.Tests.csproj reference <feature-flavor>/<feature-name>/<Feature>.csproj
- Test build & run for new project
    - cd <feature-flavor>/<feature-name>
    - dotnet run --project <feature-flavor>/<feature-name>/<Feature>.csproj


- Insert script guidance for the above process Create script to scaffold new feature-flavor/feature-name project directory path, create relevant project type at that path, create related test project, add new proj to the sln, link new tests to new proj, then fire a test build and run of the hello world new project