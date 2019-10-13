using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obscuris
{
	public	class b64
	{
		public static string Base64Encode(string filename)
		{
			string plainText = System.IO.File.ReadAllText(filename);
			var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
			return System.Convert.ToBase64String(plainTextBytes);
		}
		public static string Base64Decode(string filename)
		{
			string base64EncodedData = System.IO.File.ReadAllText(filename);
			var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
			return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
		}
	}
}
