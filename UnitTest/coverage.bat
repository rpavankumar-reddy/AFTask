﻿..\..\packages\OpenCover.4.6.519\tools\OpenCover.Console.exe -register:user -target:".\packages\NUnit.ConsoleRunner.3.6.1\tools\nunit3-console.exe" -targetargs:".\UnitTest\bin\Debug\UnitTest.dll" -excludebyattribute:*.ExcludeFromCodeCoverage* -excludebyfile:*\*Designer.cs -hideskipped:All -output:.\Coverage\Codecoverage.xml