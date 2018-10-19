using System;

namespace PayWay.Common
{
	/// <summary>
	/// This class is to generate output fields for payslip file
	/// This class is not dependant on specific input source; so CSV specific members, as an example, should not be used here
	/// </summary>
	public class PaySlipDomain : IPaySlipDomain
	{
		/// <summary>
		/// instance holding tax rates classified records 
		/// </summary>
		public TaxRatesDomain taxRates;

		/// <summary>
		/// instance holding input source records
		/// </summary>
		public DataSourceDomain dataSource;

		/// <summary>
		/// Default constructor
		/// </summary>
		public PaySlipDomain() {}

		/// <summary>
		/// constructor
		/// (Passing parameters for DI)
		/// </summary>
		/// <param name="_taxRates"></param>
		/// <param name="_dataSource"></param>
		//Dependancies are based on abstration, not concretion
		public PaySlipDomain(ITaxRatesDomain _taxRates, IDataSourceDomain _dataSource)
		{
			taxRates = (TaxRatesDomain)_taxRates;
			dataSource = (DataSourceDomain)_dataSource;
		}

		/// <summary>
		/// Payee's name on payslip
		/// (readonly property as expression body)
		/// </summary>
		public string PayeeName => GenerateName();

		/// <summary>
		/// Payment period on payslip
		/// </summary>
		public string PayPeriod => GeneratePayPeriod(dataSource.PaymentStartDate, dataSource.PaymentEndDate);

		/// <summary>
		/// Payee's taxed amount on payslip
		/// </summary>
		public decimal IncomeTax => CalculateIncomeTax();

		/// <summary>
		/// Payee's gorss monthly salary on payslip
		/// </summary>
		public decimal GrossIncome => CalculateGrossIncome();

		/// <summary>
		/// Payee's net monthly salary on payslip
		/// </summary>
		public decimal NetIncome => CalculateNetIncome();

		/// <summary>
		/// Payee's monthly super on payslip
		/// </summary>
		public decimal Super => CalculateSuper();
		
		/// <summary>
		/// Example: income tax = (3,572 + (60,050 - 37,000) x 0.325) / 12 = 921.9375 (round up) = 922
		/// </summary>
		/// <returns></returns>
		public decimal CalculateIncomeTax()
		{
			return Round((taxRates.TaxStartup + (dataSource.AnnualSalary - taxRates.ThresholdBottom) * (taxRates.RatePerDolloar / 100)) / 12);
		}

		/// <summary>
		/// gross income = annual salary / 12 months
		/// </summary>
		/// <returns></returns>
		public decimal CalculateGrossIncome()
		{
			return Round(dataSource.AnnualSalary / 12);
		}

		/// <summary>
		/// Calculate Monthly Net Income
		/// </summary>
		/// <returns></returns>
		public decimal CalculateNetIncome()
		{
			return GrossIncome - IncomeTax; 
		}

		/// <summary>
		/// super = gross income x super rate
		/// </summary>
		/// <returns></returns>
		public decimal CalculateSuper()
		{
			return Round(GrossIncome * (dataSource.SuperRate / 100));
		}

		/// <summary>
		/// Generate Name
		/// </summary>
		/// <returns></returns>
		public string GenerateName()
		{
			return $"{dataSource.FirstName} {dataSource.LastName}";
		}

		/// <summary>
		/// Generate Name
		/// overloading for three parts of name
		/// </summary>
		/// <param name="firstName"></param>
		/// <param name="lastName"></param>
		/// <param name="middleName"></param>
		/// <returns></returns>
		public string GenerateName(string firstName, string lastName, string middleName = "")
		{
			string _middle = !String.IsNullOrEmpty(middleName) ? $"{middleName} " : "";
			return $"{firstName} {_middle}{lastName}";
		}

		/// <summary>
		/// Generate payment period
		/// overload for beginning and end parameter of text
		/// </summary>
		/// <param name="periodStart">e.g. 01 March</param>
		/// <param name="periodEnd">e.g. 31 March</param>
		/// <returns></returns>
		public string GeneratePayPeriod(string periodStart, string periodEnd)
		{
			return $"{periodStart} - {periodEnd}";
		}

		/// <summary>
		/// Generate payment period
		/// Overload for all-in-one parameter
		/// </summary>
		/// <param name="month">e.g. 01 March – 31 March</param>
		/// <returns></returns>
		public string GeneratePayPeriod(string wholePeriod)
		{
			//the simplest case as requirement: output is same as input
			return wholePeriod;
		}

		/// <summary>
		/// This is to get payment period using numeric month in order to simplify parameter passing
		/// overload for numeric parameter
		/// </summary>
		/// <param name="month">numeric month: 1 for Jan, 2 for Feb...</param>
		/// <returns></returns>
		public string GeneratePayPeriod(int month)
		{
			throw new NotImplementedException("Place holder for future feature. Please use string parameter instead");
		}

		/// <summary>
		/// round amount to nearest whole dollar, 50 cents round up
		/// </summary>
		/// <param name="amount"></param>
		/// <returns></returns>
		public decimal Round(decimal amount)
		{
			return Math.Round(amount, MidpointRounding.AwayFromZero);
		}
	}
}
