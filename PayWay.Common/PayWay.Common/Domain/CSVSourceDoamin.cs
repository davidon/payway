using System;
using System.Collections.Generic;
using System.IO;
using CsvHelper;

namespace PayWay.Common
{
	/// <summary>
	/// This class is to read and parse of input CSV file
	/// </summary>
	public class CsvSourceDoamin : DataSourceDomain, IFileSourceDoamin
	{
		/// <summary>
		/// CSV input file path
		/// </summary>
		public string FileSourcePath => (new Settings()).CsvSourcePath; 

		/// <summary>
		/// List of input CSV source records
		/// </summary>
		public List<DataSourceDomain> ListSourceData {get; set;}

		/// <summary>
		/// Constructor
		/// (using expression body for simplicity)
		/// </summary>
		public CsvSourceDoamin() => ListSourceData = new List<DataSourceDomain>();

		/// <summary>
		/// CsvHelper Config for reading
		/// </summary>
		/// <param name="csv"></param>
		private void CsvHelperConfig(CsvReader csv)
		{
			//By default assuming there is a header record
			csv.Configuration.HasHeaderRecord = true;
			//Prepares the header field for matching against a member name
			// Trim
			csv.Configuration.PrepareHeaderForMatch = header => header?.Trim();

			// Remove whitespace
			csv.Configuration.PrepareHeaderForMatch = header => header.Replace(" ", string.Empty);

			// Remove underscores
			csv.Configuration.PrepareHeaderForMatch = header => header.Replace("_", string.Empty);

			// Ignore case
			csv.Configuration.PrepareHeaderForMatch = header => header.ToLower();

			//The delimiter used to separate fields. Default.
			csv.Configuration.Delimiter = ",";

			//The quote used to escape fields. Default.
			csv.Configuration.Quote = '"';

			//The character used to denote a line that is commented out. Default.
			csv.Configuration.Comment = '#';

			//If a different column count is detected on rows a BadDataException is thrown
			csv.Configuration.DetectColumnCountChanges = true;

			//Quotes no fields when writing
			//not existing??csv.Configuration.QuoteNoFields = true;
		}
		/// <summary>
		/// Read input CSV source file
		/// </summary>
		/// <returns></returns>
		public override bool ReadSourceData()
		{
			using (TextReader reader = File.OpenText(FileSourcePath))
			{
				CsvReader csv = new CsvReader(reader);
				this.CsvHelperConfig(csv);

				csv.Read();
				csv.ReadHeader();
				while (csv.Read())
				{
					//must use DataSourceDomain as generic type, as record's fields are declared there
					ListSourceData.Add(csv.GetRecord<DataSourceDomain>());
				}
			}

			return true;
		}
	}
}
