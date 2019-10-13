using System;
using System.Collections.Generic;
using System.Linq;
using CommandLine;
using System.Text;
using System.Threading.Tasks;
using static Obscuris.b64;
using static Obscuris.aes;


namespace Obscuris
{
	class crypto
	{

		class Options
		{
			[Option('i', "input-file", Required = true,
			HelpText = "Input file to be processed.")]
			public string InputFile { get; set; }

			[Option('e', "obscuring method", Default= true,
			  HelpText = "how the file will be processed")]
			public string obscure { get; set; }
			
		}

		static int Main(string[] args)
		{
			if (args.Length == 0)
			{
				System.Console.WriteLine("Please provide file to encrypt.");
				return 1;
			}
			else
			{
				var opts = new Options();

				Parser.Default.ParseArguments<Options>(args).WithParsed(parsed => opts = parsed);
				string filename = opts.InputFile;
				string obscure = opts.obscure;
				string result = input(obscure, filename);
				System.Console.WriteLine(result);
				return 0;
			}
		}

		public static string input(string obscure, string filename)
		{
			switch (obscure)
			{
				case "b64":

				string	val = Base64Encode(filename); 
					return val;

				case "d64":
				 val = Base64Decode(filename);
					return val;

					
				case "encrypt":
					var instance = new aes();
					Console.Write("Enter a string - ");
					string password = Console.ReadLine();
					string encryptedText = instance.Encrypt(password, filename);
					return encryptedText;

				case "decrypt":
					instance = new aes();
					Console.Write("Enter password - ");
					password = Console.ReadLine();
					string decryptedText = instance.Decrypt(password, filename);
					return decryptedText;

				default:
					System.Console.WriteLine("invalid obsuring argument provided");
					val = null;
					return val;
	

			}
		}

	}
	}

