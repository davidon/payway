using System;
using System.Collections.Generic;
using System.Text;

namespace PayWay.Common
{
	/// <summary>
	/// base class for different output format
	/// </summary>
	public class DataOutputController : IDataOutputController
	{
		/// <summary>
		/// Generic/base method to output/display generated records
		/// </summary>
		/// <returns>boolean; indicating sucess/failure status</returns>
		public virtual bool WriteOutputData()
		{
			//Future enhancement: check output format, and call corresponding child class
			return true;
		}
	}
}
