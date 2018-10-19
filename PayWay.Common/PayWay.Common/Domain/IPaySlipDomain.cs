namespace PayWay.Common
{
	/// <summary>
	/// This interface is to generate output fields for payslip file
	/// This interface is not dependant on specific input source; so CSV specific members, as an example, should not be used here
	/// </summary>
	public interface IPaySlipDomain
	{
		/// <summary>
		/// Payee's name on payslip
		/// </summary>
		string PayeeName { get; }

		/// <summary>
		/// Payment period on payslip
		/// </summary>
		string PayPeriod { get; }

		/// <summary>
		/// Payee's taxed amount on payslip
		/// </summary>
		decimal IncomeTax { get; }

		/// <summary>
		/// Payee's gorss monthly salary on payslip
		/// </summary>
		decimal GrossIncome { get; }

		/// <summary>
		/// Payee's net monthly salary on payslip
		/// </summary>
		decimal NetIncome { get; }

		/// <summary>
		/// Payee's monthly super on payslip
		/// </summary>
		decimal Super { get; }

		/// <summary>
		/// use property of firstName & lastName
		/// </summary>
		/// <returns></returns>
		string GenerateName();

		/// <summary>
		/// overloading for middle name
		/// </summary>
		/// <param name="firstName"></param>
		/// <param name="lastName"></param>
		/// <param name="middleName">middleName is optinal</param>
		/// <returns></returns>
		string GenerateName(string firstName, string lastName, string middleName);

		/// <summary>
		/// This is to get payment period using numeric month in order to simplify parameter passing
		/// </summary>
		/// <param name="month">numeric month: 1 for Jan, 2 for Feb...</param>
		/// <returns></returns>
		string GeneratePayPeriod(int month);
		/// <summary>
		/// only one param of string, including start date and end date, e.g. 01 March – 31 March
		/// </summary>
		/// <param name="month"></param>
		/// <returns></returns>
		string GeneratePayPeriod(string month);
		decimal CalculateGrossIncome();
		decimal CalculateIncomeTax();
		decimal CalculateNetIncome();

		/// <summary>
		/// Calculate Super
		/// </summary>
		/// <returns></returns>
		decimal CalculateSuper();

		/// <summary>
		/// round amount to nearest whole dollar, 50 cents round up
		/// </summary>
		/// <param name="amount"></param>
		/// <returns></returns>
		decimal Round(decimal amount);
	}
}
