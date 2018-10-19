using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.Sqlite;

namespace PayWay.Common
{
	/// <summary>
	/// Tax rate which is applicable to annual salary; that is, a row in tax rates table
	/// example: $37,001 - $87,000 $3,572 plus 32.5c for each $1 over $37,000
	/// (this class shoudl not contain input and output data)
	/// </summary>
	public class TaxRatesDomain : ITaxRatesDomain

	{
		/// <summary>
		/// SQLite DB file path of tax rates which is configurable
		/// </summary>
		private string TaxRatesDBPath => (new Settings()).TaxRatesDBPath;

		//The properties correspond to TABLE tax_rates:threshold_bottom,threshold_top number,tax_startup number,super_rate number

		/// <summary>
		/// annual salary
		/// </summary>
		public decimal AnnualSalary { get; set; }

		/// <summary>
		/// The bottom threshold of annual salary for a specific level tax rate
		/// </summary>
		public int ThresholdBottom { get; set; }

		/// <summary>
		/// The top threshold of annual salary for a specific level tax rate
		/// negative or null or 0 threshold top means unlimited
		/// </summary>
		public int? ThresholdTop { get; set; }

		/// <summary>
		/// The initial taxed amount for a specific level tax rate
		/// </summary>
		public int TaxStartup { get; set; }

		/// <summary>
		/// Tax Rate Per Dolloar (not including %)
		/// </summary>
		public decimal RatePerDolloar { get; set; }

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="_annualSalary">annual salary</param>
		public TaxRatesDomain(decimal _annualSalary) => AnnualSalary = _annualSalary;

		/// <summary>
		/// Default constructor
		/// </summary>
		public TaxRatesDomain()
		{
		}

		/// <summary>
		/// Get tax rate record based on a specific annual salary
		/// </summary>
		/// <returns></returns>
		public bool FetchTaxRates()
		{
			//Tax rates fixture is stored in Sqlite DB
			using (var db = new SqliteConnection(TaxRatesDBPath))
			{
				db.Open();

				var command = new SqliteCommand($"select * from tax_rates WHERE threshold_bottom <= {AnnualSalary} AND (threshold_top >= {AnnualSalary} OR threshold_top is NULL)", db);
				var reader = command.ExecuteReader();

				reader.Read();
				//DB table columns:   threshold_bottom, threshold_top, tax_startup, super_rate
				ThresholdBottom = reader.GetInt32(0);
				ThresholdTop = !reader.IsDBNull(1) ? reader.GetInt32(1) : -1;	//negative threshold top means unlimited
				TaxStartup = reader.GetInt32(2);
				RatePerDolloar = reader.GetDecimal(3);
			}
			return true;
		}
	}
}
