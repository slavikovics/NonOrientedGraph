# NonOrientedGraph

### 1. Go to NonOrientedGraphTests:
```bash
cd NonOrientedGraphTests
```

### 2. Build project with test flags:
```bash
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=lcov /p:CoverletOutput=./lcov.info
```

### 3. Generate HTML with code coverage report:
```bash
dotnet reportgenerator -reports:./lcov.info -targetdir:.coverage
```

### 4. Open index.html in .coverage folder