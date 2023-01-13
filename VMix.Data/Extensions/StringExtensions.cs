namespace VMix.Data.Extensions
{
	public static class StringExtensions
	{
		//JWT TOKEN için SHA256'ya göre HASH üretme algoritması
		public static string CreateHash(this string text)
		{
			using (var sha256Hash = SHA256.Create())
			{
				byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(text));
				var builder = new StringBuilder();
				for (int i = 0; i < bytes.Length; i++)
				{
					builder.Append(bytes[i].ToString("x2"));
				}
				return builder.ToString();
			}
		}
	}
}
