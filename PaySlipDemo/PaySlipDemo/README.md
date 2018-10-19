# Introduction 
This is startup or sprint 1 of a comprehensive payment system, currently it is to generate payslips, however the architecture solution is for continuous improvement and big ideas.

# Installation process
1. Extract the MYOB.zip into a folder, e.g. `c:\MYOB`
2. Open Console (CLI), go to the folder, e.g. `c:\MYOB\App\bin`, run command:    
`cd c:\MYOB\App\bin`
3. Run command:  
`dotnet PaySlipDemo.dll`

# Continuous development in Visual Studio
* Open solution file `c:\MYOB\PaySlipDemo\PaySlipDemo.sln`
* Use Nuget package manager to install dependencies
* Rebuild and Run from Debug menu, and view the generated payslip file: `C:\MYOB\PaySlipDemo\PaySlipDemo\bin\Debug\netcoreapp2.1\Fixture\payslip_output.csv`
* You can also run unit test from Test Explorer in VS

# Resources & References:
First of all, you don't need to do anything with the input CSV file and tax rates classification data, they are all self-contained into the project.

However, if you want to change the input CSV data, or apply a new policy of tax rates, this is where they are: 
* Input CSV file is together with project PayWay.Common: `C:\MYOB\PayWay.Common\PayWay.Common\Fixture\payway_source.csv`  
(please be mindful to change CSV format as not every scenario is tested; super rate no need to enter percentage sign % for simplicity)

* The SQLite DB file which contains Tax rates is: `C:\MYOB\PayWay.Common\PayWay.Common\Fixture\tax_rates.sqlite3`

* The DB script is: `C:\MYOB\PayWay.Common\PayWay.Common\Scripts\pay_way.sql`, 
You can use it to modify tax ratesimprovement 

# Solutions and specifications:
* Use latest .NET Core 2.1 technology, platform independent
* Settings, for example, input & output CSV file or path, and the SQLite DB file path ( of tax rates classification data ) can be easily changed even without looking into code. 
* Software development S.O.L.I.D principles and design pattern are adopted for software development and design
* Modular, functional and microservice methodology for flexible plug in new feautres
* DI (Dependency Injection)
* Use unit test to adopt TDD (Test Driven Development) for important modules. Testing logic is based on abstraction rather than concretion.  The testing cases are from question sheet, criteria is set at beginning and it's against interface without concrete implementation to ensure business requirements are fully addressed.  
  The unit test structure and solution (using latest XUnit) is flexible for a thorough coverage in future sprint.
* compatible with different input and output formats, such as CSV, JSON, XML, DB etc.
* Compatible with further applications development, for example, WEB API, ASP.Net web interfaces.
* This project is self-contained, users don't need to manually put input data in place.
* Simpler operations for end-user is under consideration for user friendly design

# Minds & Ideas:
* Why Tax rates is stored into DB?
  - It's more secure than text file. Tax rates are generally immutable but text file is more easily to be tampered.
  - It's efficient
  - Even end users without technical skills can change tax rates using application DB Browser for SQLite ( http://sqlitebrowser.org/).



