using System.Security.Cryptography;
using System.Text;

namespace EFCoreDemo1.Infrastructure.Commons.Utils
{
	public static class MD5Encode
	{
		public static string ToMd5(this string str)
		{
			MD5 md5 = MD5.Create();
			byte[] output = md5.ComputeHash(Encoding.Default.GetBytes(str));
			//string result = BitConverter.ToString(output);
			return BitConverter.ToString(output).Replace("-", "");
		}
	}
}
