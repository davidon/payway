using System;
using System.Collections.Generic;
using System.Text;

namespace PayWay.Common
{
	/// <summary>
	/// Interface for different output format
	/// </summary>
	public interface IDataOutputController
	{
		/// <summary>
		/// Generic/base method to output/display generated records
		/// </summary>
		/// <returns>boolean; indicating sucess/failure status</returns>
		bool WriteOutputData();
	}
}
