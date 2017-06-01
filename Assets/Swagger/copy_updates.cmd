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

SET VER=razer_csharp
rm -r -f "razer"
mkdir "razer"
cp -r -f "C:\Public\tgraupmann-swagger-codegen\samples\chromasdk\%VER%\src" .
cp -f "C:\Public\tgraupmann-swagger-codegen\samples\chromasdk\%VER%\README.md" "razer"
cp -r -f "C:\Public\tgraupmann-swagger-codegen\samples\chromasdk\%VER%\docs" "razer"
rm -r -f "src\RazerSDK.Test"
rm -f "src\RazerSDK\Properties\AssemblyInfo.cs"


SET VER=razer_delete_csharp
rm -r -f "razer_delete"
mkdir "razer_delete"
cp -r -f "C:\Public\tgraupmann-swagger-codegen\samples\chromasdk\%VER%\src" .
cp -f "C:\Public\tgraupmann-swagger-codegen\samples\chromasdk\%VER%\README.md" "razer_delete"
cp -r -f "C:\Public\tgraupmann-swagger-codegen\samples\chromasdk\%VER%\docs" "razer_delete"
rm -r -f "src\RazerSDKDelete.Test"
rm -f "src\RazerSDKDelete\Properties\AssemblyInfo.cs"


PAUSE
