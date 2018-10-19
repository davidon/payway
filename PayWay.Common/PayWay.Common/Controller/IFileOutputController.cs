using System;
using System.Collections.Generic;
using System.Text;

namespace PayWay.Common
{
	interface IFileOutputController : IDataOutputController
	{
		/// <summary>
		/// all kinds of file for writing have a path to it
		/// </summary>
		string FileOutputPath { get; }
	}
}
