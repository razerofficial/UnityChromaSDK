SET PATH=%PATH%;c:\cygwin64\bin
rm -r -f docs
rm -r -f src
rm -r -f README.md

REM SET VER=chromasdk_CsharpDotNet2
SET VER=chromasdk_csharp
cp -r -f "C:\Public\tgraupmann-swagger-codegen\samples\chromasdk\%VER%\README.md" .
cp -r -f "C:\Public\tgraupmann-swagger-codegen\samples\chromasdk\%VER%\docs" .
cp -r -f "C:\Public\tgraupmann-swagger-codegen\samples\chromasdk\%VER%\src" .

rm -r -f "src\IO.Swagger.Test"

PAUSE
