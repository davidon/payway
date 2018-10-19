using System;

namespace PayWay.Common
{
	/// <summary>
	/// This interface is to provide more generaic types for different input data sources, e.g. ipuit source from CSV, DB, JSON etc.
	/// Specific input source related types should not come here!
	/// </summary>
	public class DataSourceDomain : IDataSourceDomain
	{
		//class property names (see IDataSourceDomain) need to match the CSV file header names!!!
		
		/// <summary>
		/// Payee's first name
		/// </summary>
		public String FirstName { get; set; }
		
		/// <summary>
		/// Payee's last name
		/// </summary>
		public String LastName { get; set; }
		
		/// <summary>
		/// Payee's annual salary
		/// </summary>
		public decimal AnnualSalary { get; set; }

		/// <summary>
		/// Super rate based on annual salary
		/// decimal for the case like 9.5
		/// </summary>
		public decimal SuperRate { get; set; }

		/// <summary>
		/// Payee's payment start date
		/// </summary>
		public String PaymentStartDate { get; set; }

		/// <summary>
		/// Payee's payment end date
		/// </summary>
		public String PaymentEndDate { get; set; }

		/// <summary>
		/// Generic method for reading different input source data
		/// </summary>
		/// <returns></returns>
		public virtual bool ReadSourceData()
		{
			//Place holder: check output format, and call corresponding child class
			return true;
		}
	}
}
