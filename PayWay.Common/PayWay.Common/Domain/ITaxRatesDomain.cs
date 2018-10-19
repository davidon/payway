namespace PayWay.Common
{
	/// <summary>
	/// Interface for Tax rate which is applicable to annual salary; that is, a row in tax rates table
	/// example: $37,001 - $87,000 $3,572 plus 32.5c for each $1 over $37,000
	/// (this class shoudl not contain input and output data)
	/// </summary>
	public interface ITaxRatesDomain
	{
		/// <summary>
		/// annual salary
		/// </summary>
		decimal AnnualSalary { get; set; }

		/// <summary>
		/// The bottom threshold of annual salary for a specific level tax rate
		/// </summary>
		int ThresholdBottom { get; set; }

		/// <summary>
		/// The top threshold of annual salary for a specific level tax rate
		/// negative or null or 0 threshold top means unlimited
		/// </summary>
		int? ThresholdTop { get; set; }

		/// <summary>
		/// The initial taxed amount for a specific level tax rate
		/// </summary>
		int TaxStartup { get; set; }

		/// <summary>
		/// Tax Rate Per Dolloar (not including %)
		/// </summary>
		decimal RatePerDolloar { get; set; }

		/// <summary>
		/// Get tax rate record based on a specific annual salary
		/// </summary>
		/// <returns></returns>
		bool FetchTaxRates();
	}
}
