SET PATH=%PATH%;c:\cygwin64\bin

CD "Assets\ChromaSDK\SDK\Swagger"

SET VER=chromasdk_csharp
rm -r -f "chroma"
IF EXIST "chroma" PAUSE
mkdir "chroma"
cp -f "C:\Public\tgraupmann-swagger-codegen\samples\chromasdk\%VER%\README.md" "chroma"
cp -r -f "C:\Public\tgraupmann-swagger-codegen\samples\chromasdk\%VER%\docs" "chroma"
cp -r -f "C:\Public\tgraupmann-swagger-codegen\samples\chromasdk\%VER%\src" "chroma"

SET VER=razer_csharp
rm -r -f "razer"
IF EXIST "razer" PAUSE
mkdir "razer"
cp -r -f "C:\Public\tgraupmann-swagger-codegen\samples\chromasdk\%VER%\src" "razer"
cp -f "C:\Public\tgraupmann-swagger-codegen\samples\chromasdk\%VER%\README.md" "razer"
cp -r -f "C:\Public\tgraupmann-swagger-codegen\samples\chromasdk\%VER%\docs" "razer"


PAUSE
