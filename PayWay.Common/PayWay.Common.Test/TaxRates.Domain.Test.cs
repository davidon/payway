using System;
using Xunit;

namespace PayWay.Common.Test
{
	public class TaxRatesDomainTest
	{
		/// <summary>
		/// test first level tax rate
		/// annual salary: $0 - $18, tax rate: 200 Nil Nil
		/// </summary>
		public class FirstLevel
		{
			//Dependant instances are based on abstration, not concretion
			ITaxRatesDomain taxRates;

			/// <summary>
			/// Constructor
			/// </summary>
			public FirstLevel()
			{
				taxRates = new TaxRatesDomain();
			}

			[Fact]
			public void TaxRatesTest_FirstLevelBottom()
			{
				taxRates.AnnualSalary = 0;
				taxRates.FetchTaxRates();
				Assert.Equal(0, taxRates.RatePerDolloar);
				Assert.Equal(0, taxRates.TaxStartup);
			}

			[Fact]
			public void TaxRatesTest_FirstLevelTop()
			{
				taxRates.AnnualSalary = 18200;
				taxRates.FetchTaxRates();
				Assert.Equal(0, taxRates.RatePerDolloar);
				Assert.Equal(0, taxRates.TaxStartup);
			}

			[Fact]
			public void TaxRatesTest_FirstLevel()
			{
				taxRates.AnnualSalary = 999;
				taxRates.FetchTaxRates();
				Assert.Equal(0, taxRates.RatePerDolloar);
				Assert.Equal(0, taxRates.TaxStartup);
			}
		}

		/// <summary>
		/// test Second level tax rate
		/// annual salary: $18,201 - $37,000; tax rate: 19c for each $1 over $18,200
		/// </summary>
		public class SecondLevel
		{
			//Dependant instances are based on abstration, not concretion
			ITaxRatesDomain taxRates;

			/// <summary>
			/// Constructor
			/// </summary>
			public SecondLevel()
			{
				taxRates = new TaxRatesDomain();
			}

			[Fact]
			public void TaxRatesTest_SecondLevelBottom()
			{
				taxRates.AnnualSalary = 18201;
				taxRates.FetchTaxRates();
				Assert.Equal(19, taxRates.RatePerDolloar);
				Assert.Equal(0, taxRates.TaxStartup);
			}

			[Fact]
			public void TaxRatesTest_SecondLevelTop()
			{
				taxRates.AnnualSalary = 37000;
				taxRates.FetchTaxRates();
				Assert.Equal(19, taxRates.RatePerDolloar);
				Assert.Equal(0, taxRates.TaxStartup);
			}

			[Fact]
			public void TaxRatesTest_SecondLevel()
			{
				taxRates.AnnualSalary = 23999;
				taxRates.FetchTaxRates();
				Assert.Equal(19, taxRates.RatePerDolloar);
				Assert.Equal(0, taxRates.TaxStartup);
			}
		}

		/// <summary>
		/// test third level tax rate
		/// annual salary: $37,001 - $87,000; tax rate: $3,572 plus 32.5c for each $1 over $37,000
		/// </summary>
		public class ThirdLevel
		{
			//Dependant instances are based on abstration, not concretion
			ITaxRatesDomain taxRates;

			/// <summary>
			/// Constructor
			/// </summary>
			public ThirdLevel()
			{
				taxRates = new TaxRatesDomain();
			}

			[Fact]
			public void TaxRatesTest_ThirdLevelBottom()
			{
				taxRates.AnnualSalary = 37001;
				taxRates.FetchTaxRates();
				Assert.Equal(32.5m, taxRates.RatePerDolloar);
				Assert.Equal(3572, taxRates.TaxStartup);
			}

			[Fact]
			public void TaxRatesTest_ThirdLevelTop()
			{
				taxRates.AnnualSalary = 87000;
				taxRates.FetchTaxRates();
				Assert.Equal(32.5m, taxRates.RatePerDolloar);
				Assert.Equal(3572, taxRates.TaxStartup);
			}

			[Fact]
			public void TaxRatesTest_ThirdLevel()
			{
				taxRates.AnnualSalary = 56999;
				taxRates.FetchTaxRates();
				Assert.Equal(32.5m, taxRates.RatePerDolloar);
				Assert.Equal(3572, taxRates.TaxStartup);
			}
		}

		/// <summary>
		/// Test Forth level tax rate
		/// annual salary: $87,001 - $180,000; tax rate: $19,822 plus 37c for each $1 over $87,000
		/// </summary>
		public class ForthLevel
		{
			//Dependant instances are based on abstration, not concretion
			ITaxRatesDomain taxRates;

			/// <summary>
			/// Constructor
			/// </summary>
			public ForthLevel()
			{
				taxRates = new TaxRatesDomain();
			}

			[Fact]
			public void TaxRatesTest_ForthLevelBottom()
			{
				taxRates.AnnualSalary = 87001;
				taxRates.FetchTaxRates();
				Assert.Equal(37, taxRates.RatePerDolloar);
				Assert.Equal(19822, taxRates.TaxStartup);
			}

			[Fact]
			public void TaxRatesTest_ForthLevelTop()
			{
				taxRates.AnnualSalary = 180000;
				taxRates.FetchTaxRates();
				Assert.Equal(37, taxRates.RatePerDolloar);
				Assert.Equal(19822, taxRates.TaxStartup);
			}

			[Fact]
			public void TaxRatesTest_ForthLevel()
			{
				taxRates.AnnualSalary = 123999;
				taxRates.FetchTaxRates();
				Assert.Equal(37, taxRates.RatePerDolloar);
				Assert.Equal(19822, taxRates.TaxStartup);
			}
		}

		/// <summary>
		/// test fifth level tax rate
		/// annual salary $180,001 and over; tax rate: $54,232 plus 45c for each $1 over $180,000
		/// </summary>
		public class FifthLevel
		{
			//Dependant instances are based on abstration, not concretion
			ITaxRatesDomain taxRates;

			/// <summary>
			/// Constructor
			/// </summary>
			public FifthLevel()
			{
				taxRates = new TaxRatesDomain();
			}

			[Fact]
			public void TaxRatesTest_FifthLevelBottom()
			{
				taxRates.AnnualSalary = 180001;
				taxRates.FetchTaxRates();
				Assert.Equal(45, taxRates.RatePerDolloar);
				Assert.Equal(54232, taxRates.TaxStartup);
			}

			[Fact]
			public void TaxRatesTest_FifthLevelTop()
			{
				taxRates.AnnualSalary = 777888999;
				taxRates.FetchTaxRates();
				Assert.Equal(45, taxRates.RatePerDolloar);
				Assert.Equal(54232, taxRates.TaxStartup);
			}

			[Fact]
			public void TaxRatesTest_FifthLevel()
			{
				taxRates.AnnualSalary = 234567;
				taxRates.FetchTaxRates();
				Assert.Equal(45, taxRates.RatePerDolloar);
				Assert.Equal(54232, taxRates.TaxStartup);
			}
		}

	}
}
