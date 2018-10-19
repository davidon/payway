using System;

namespace PayWay.Common
{
	/// <summary>
	/// Interface for different formats of input sources, e.g. ipuit source from CSV, DB, JSON, XML etc.
	/// </summary>
	public interface IDataSourceDomain
	{
		/// <summary>
		/// Payee's first name
		/// </summary>
		String FirstName { get; set; }

		/// <summary>
		/// Payee's last name
		/// </summary>
		String LastName { get; set; }

		/// <summary>
		/// Payee's annual salary
		/// </summary>
		decimal AnnualSalary { get; set; }

		/// <summary>
		/// Super rate based on annual salary
		/// decimal for the case like 9.5
		/// </summary>
		decimal SuperRate { get; set; }

		/// <summary>
		/// Payee's payment start date
		/// </summary>
		String PaymentStartDate { get; set; }

		/// <summary>
		/// Payee's payment end date
		/// </summary>
		String PaymentEndDate { get; set; }

		/// <summary>
		/// Generic method for reading different input source data
		/// </summary>
		/// <returns></returns>
		bool ReadSourceData();
	}
}
