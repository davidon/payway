using System;
using System.Collections.Generic;
using PayWay.Common;
using Serilog;

namespace PayWay.Display
{
	class PaySlipGenerator
	{
		static void Main(string[] args)
		{
			var log = new LoggerConfiguration()
				.WriteTo.Console()
				.WriteTo.File("payslip_demo.txt", rollingInterval: RollingInterval.Day)
				.CreateLogger();

			log.Information("Start generating pay slips");
			//get input data from CSV file
			CsvSourceDoamin source = new CsvSourceDoamin();
			source.ReadSourceData();
			log.Information("Finished reading input CSV files");

			List <PaySlipDomain> paySlipRecords = new List<PaySlipDomain>();
			foreach (DataSourceDomain _sourceData in source.ListSourceData) {

				//get tax rates grid data
				TaxRatesDomain _taxRates = new TaxRatesDomain(_sourceData.AnnualSalary);
				_taxRates.FetchTaxRates();

				//get output fields' data
				paySlipRecords.Add(new PaySlipDomain(_taxRates, _sourceData));
				log.Information($"Payee {_sourceData.LastName} {_sourceData.FirstName} is ready");
			}

			//generate output payslip in CSV format
			CsvOutputController _csvOutput = new CsvOutputController(paySlipRecords);
			_csvOutput.WriteOutputData();
			//Fixture/payslip_output.csv
			log.Information(($"All done! Payslips have been generated into {(new Settings()).CsvOutputPath}"));
		}
	}
}
