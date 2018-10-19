namespace PayWay.Common
{

	/// <summary>
	/// Interface for different File formats of input sources, e.g. ipuit source from CSV, JSON, XML etc.
	/// </summary>
	public interface IFileSourceDoamin : IDataSourceDomain

	{
		/// <summary>
		/// all kinds of file source have a path to it
		/// </summary>
		string FileSourcePath { get; }
	}
}
