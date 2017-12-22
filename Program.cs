using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleApplication1
{
	class Program
	{
		static void Main(string[] args)
		{
			var t = new Top();
			t.First = "This is a string";
			t.Second = 25;
			t.Middle = new Middle();
			t.Middle.FirstMiddle = 1;
			t.Middle.SecondMiddle = "string";
			t.Third = "another string";
			//t.MiddleEmpty = null;
			//t.MiddleEmpty = new Middle();
			//t.MiddleEmpty.FirstMiddle = 1;

			string x = SerializeMessage(t);
			Console.WriteLine(x);

			Top z = DeserializeMessage<Top>(x);
			int m = 1;
		}


		/// <summary>
		/// Serializes an envoy message into a json string
		/// </summary>
		internal static string SerializeMessage(object message)
		{
			//var serializedMsg = JsonConvert.SerializeObject(message, Formatting.Indented);
			var serializedMsg = JsonConvert.SerializeObject(message, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
			return serializedMsg;
		}

		/// <summary>
		/// Deserializes a json string into an envoy message
		/// </summary>
		private static T DeserializeMessage<T>(string messageData)
		{
			//return JsonConvert.DeserializeObject<T>(messageData);
			return JsonConvert.DeserializeObject<T>(messageData, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
		}

	}


	class Top
	{
		public string First { get; set; }
		public int Second { get; set; }
		public Middle Middle { get; set; }
		public Middle MiddleEmpty { get; set; }
		public string Third { get; set; }
		
		public Top()
		{
//			Middle = new Middle();
//			MiddleEmpty = new Middle();
		}
	}

	class Middle
	{
		public int FirstMiddle { get; set; }
		public string SecondMiddle { get; set; }
	}
}
