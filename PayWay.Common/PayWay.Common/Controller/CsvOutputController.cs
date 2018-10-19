using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using CsvHelper;

namespace PayWay.Common
{
	public class CsvOutputController : DataOutputController, IFileOutputController
	{
		/// <summary>
		/// list of payslips records which are ready for output/display
		/// </summary>
		private List<PaySlipDomain> paySlipRecords;

		/// <summary>
		/// CSV output file path
		/// </summary>
		public string FileOutputPath => (new Settings()).CsvOutputPath;

		/// <summary>
		/// Generate CSV output files
		/// </summary>
		/// <param name="_paySlipRecords"></param>
		public CsvOutputController(List<PaySlipDomain> _paySlipRecords)
		{
			paySlipRecords = _paySlipRecords;
		}

		/// <summary>
		///Output format: name, pay period, gross income, income tax, net income, super
		///example: David Rudd,01 March – 31 March,5004,922,4082,450
		/// </summary>
		/// <returns></returns>
		public override bool WriteOutputData()
		{
			using (TextWriter writer = File.CreateText(FileOutputPath))
			{
				CsvWriter csv = new CsvWriter(writer);
				foreach (PaySlipDomain _paySlipData in paySlipRecords)
				{
					var record = new
					{
						_paySlipData.PayeeName,
						_paySlipData.PayPeriod,
						_paySlipData.GrossIncome,
						_paySlipData.IncomeTax,
						_paySlipData.NetIncome,
						_paySlipData.Super
					};
					csv.WriteRecord(record);
					csv.NextRecord();
				}

			}

			return true;
		}
	}
}
