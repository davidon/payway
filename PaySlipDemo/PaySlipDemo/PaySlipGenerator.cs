using System;
using System.Collections.Generic;
using PayWay.Common;

namespace PayWay.Display
{
	class PaySlipGenerator
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Start generating pay slips");
			//get input data from CSV file
			CsvSourceDoamin source = new CsvSourceDoamin();
			source.ReadSourceData();
			Console.WriteLine("Finished reading input CSV files");

			List<PaySlipDomain> paySlipRecords = new List<PaySlipDomain>();
			foreach (DataSourceDomain _sourceData in source.ListSourceData) {

				//get tax rates grid data
				TaxRatesDomain _taxRates = new TaxRatesDomain(_sourceData.AnnualSalary);
				_taxRates.FetchTaxRates();

				//get output fields' data
				paySlipRecords.Add(new PaySlipDomain(_taxRates, _sourceData));
				Console.WriteLine($"Payee {_sourceData.LastName} {_sourceData.FirstName} is ready");
			}

			//generate output payslip in CSV format
			CsvOutputController _csvOutput = new CsvOutputController(paySlipRecords);
			_csvOutput.WriteOutputData();
			//Fixture/payslip_output.csv
			Console.WriteLine($"All done! Payslips have been generated into {(new Settings()).CsvOutputPath}");
		}
	}
}
