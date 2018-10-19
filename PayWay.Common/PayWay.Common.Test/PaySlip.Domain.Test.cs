using Xunit;

namespace PayWay.Common.Test
{
	public class PaySlipDomainTest
	{
		PaySlipDomain paySlip;

		//Dependant instances are based on abstration, not concretion
		ITaxRatesDomain taxRates;
		IDataSourceDomain dataSource;

		/// <summary>
		/// Constructor
		/// </summary>
		public PaySlipDomainTest()
		{
			//Dependant instances are instantiated without passing object parameters so that dependancies are isolated from each testing unit
			taxRates = new TaxRatesDomain();
			dataSource = new DataSourceDomain();

			//The testing data is from the example of business requirements
			dataSource.AnnualSalary = 60050;
			dataSource.SuperRate = 9; //in percent

			taxRates.TaxStartup = 3572;
			taxRates.ThresholdBottom = 37000;
			taxRates.RatePerDolloar = 32.5m; //in cents			

			paySlip = new PaySlipDomain(taxRates, dataSource);
		}

		/// <summary>
		/// Test rounding, 50 cents should be rounded up
		/// </summary>
		[Fact]
		public void RoundTest()
		{
			Assert.Equal(5004, paySlip.Round((decimal)5004.16666667));
			Assert.Equal(922, paySlip.Round((decimal)921.9375));
			Assert.Equal(450, paySlip.Round((decimal)450.36));
			Assert.Equal(1, paySlip.Round((decimal)1.001));
			Assert.Equal(2, paySlip.Round((decimal)1.5001));
			Assert.Equal(1, paySlip.Round((decimal)1.4999));
			Assert.Equal(0, paySlip.Round((decimal)0.001));
			Assert.Equal(1, paySlip.Round((decimal)0.5001));
			Assert.Equal(0, paySlip.Round((decimal)0.4999));
		}

		/// <summary>
		/// Test monthly gross income
		/// </summary>
		[Fact]
		public void GrossIncomeTest()
		{
			//5004 is from the example of business requirements
			Assert.Equal(5004, paySlip.GrossIncome);
		}

		/// <summary>
		/// Test income tax
		/// </summary>
		[Fact]
		public void IncomeTaxTest()
		{
			//922 is from the example of business requirements
			Assert.Equal(922, paySlip.IncomeTax);
		}

		/// <summary>
		/// Test net income
		/// </summary>
		[Fact]
		public void NetIncomeTest()
		{
			//4082 is from the example of business requirements
			Assert.Equal(4082, paySlip.NetIncome);

		}
		/// <summary>
		/// Test super
		/// </summary>
		[Fact]
		public void SuperTest()
		{
			//450 is from the example of business requirements
			Assert.Equal(450, paySlip.Super);

		}
	}
}
