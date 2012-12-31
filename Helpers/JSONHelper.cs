using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Json;

namespace SFWinformsClient
{
	public static class JSONHelper
	{
		public static string ToJson(object payload)
		{
			DataContractJsonSerializer ser = new DataContractJsonSerializer(payload.GetType());
			using (MemoryStream ms = new MemoryStream())
			{
				ser.WriteObject(ms, payload);
				byte[] data = ms.ToArray();
				return Encoding.UTF8.GetString(data, 0, data.Length);
			}
		}

		public static byte[] GetEncodedJsonPayload(object payload)
		{
			byte[] data;
			DataContractJsonSerializer ser = new DataContractJsonSerializer(payload.GetType());
			using (MemoryStream ms = new MemoryStream())
			{
				ser.WriteObject(ms, payload);
				data = ms.ToArray();
			}
			return data;
		}
	}
}
