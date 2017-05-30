SET PATH=%PATH%;c:\cygwin64\bin
rm -r -f docs
rm -r -f src
rm -r -f README.md

REM SET VER=chromasdk_CsharpDotNet2
SET VER=chromasdk_csharp
cp -f "C:\Public\tgraupmann-swagger-codegen\samples\chromasdk\%VER%\README.md" .
rm -r -f "docs"
cp -r -f "C:\Public\tgraupmann-swagger-codegen\samples\chromasdk\%VER%\docs" .
cp -r -f "C:\Public\tgraupmann-swagger-codegen\samples\chromasdk\%VER%\src" .
rm -r -f "src\ChromaSDK.Test"

SET VER=custom_chromasdk_csharp
rm -r -f "custom"
mkdir "custom"
cp -r -f "C:\Public\tgraupmann-swagger-codegen\samples\chromasdk\%VER%\src" .
cp -f "C:\Public\tgraupmann-swagger-codegen\samples\chromasdk\%VER%\README.md" "custom"
cp -r -f "C:\Public\tgraupmann-swagger-codegen\samples\chromasdk\%VER%\docs" "custom"
rm -r -f "src\CustomChromaSDK.Test"
rm -f "src\ChromaSDK\Properties\AssemblyInfo.cs"

PAUSE
