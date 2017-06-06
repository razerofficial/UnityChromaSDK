SET PATH=%PATH%;c:\cygwin64\bin
rm -r -f docs
rm -r -f src
rm -r -f README.md

REM SET VER=chromasdk_CsharpDotNet2
SET VER=chromasdk_csharp
cp -f "C:\Public\tgraupmann-swagger-codegen\samples\chromasdk\%VER%\README.md" .
rm -r -f "docs"
IF EXIST "docs" PAUSE
cp -r -f "C:\Public\tgraupmann-swagger-codegen\samples\chromasdk\%VER%\docs" .
rm -r -f "src"
IF EXIST "src" PAUSE
cp -r -f "C:\Public\tgraupmann-swagger-codegen\samples\chromasdk\%VER%\src" .

REM SET VER=custom_chromasdk_csharp
rm -r -f "custom"
IF EXIST "custom" PAUSE
REM mkdir "custom"
REM cp -r -f "C:\Public\tgraupmann-swagger-codegen\samples\chromasdk\%VER%\src" "custom"
REM cp -f "C:\Public\tgraupmann-swagger-codegen\samples\chromasdk\%VER%\README.md" "custom"
REM cp -r -f "C:\Public\tgraupmann-swagger-codegen\samples\chromasdk\%VER%\docs" "custom"

SET VER=razer_csharp
rm -r -f "razer"
IF EXIST "razer" PAUSE
mkdir "razer"
cp -r -f "C:\Public\tgraupmann-swagger-codegen\samples\chromasdk\%VER%\src" "razer"
cp -f "C:\Public\tgraupmann-swagger-codegen\samples\chromasdk\%VER%\README.md" "razer"
cp -r -f "C:\Public\tgraupmann-swagger-codegen\samples\chromasdk\%VER%\docs" "razer"


SET VER=razer_delete_csharp
rm -r -f "razer_delete"
IF EXIST "razer_delete" PAUSE
mkdir "razer_delete"
cp -r -f "C:\Public\tgraupmann-swagger-codegen\samples\chromasdk\%VER%\src" "razer_delete"
cp -f "C:\Public\tgraupmann-swagger-codegen\samples\chromasdk\%VER%\README.md" "razer_delete"
cp -r -f "C:\Public\tgraupmann-swagger-codegen\samples\chromasdk\%VER%\docs" "razer_delete"


PAUSE
