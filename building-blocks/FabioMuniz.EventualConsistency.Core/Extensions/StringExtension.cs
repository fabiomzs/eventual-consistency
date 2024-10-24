using System.Text;
using System.Text.RegularExpressions;

namespace FabioMuniz.EventualConsistency.Core.Extensions;

public static class StringExtension
{
	public static string ToKebab(this string value)
	{
		if (string.IsNullOrEmpty(value))
			return value;

		var builder = new StringBuilder();
		for (int i = 0; i < value.Length; i++)
		{
			char currentChar = value[i];

			if (char.IsUpper(currentChar))
			{
				if (i > 0)
					builder.Append('-');

				builder.Append(char.ToLower(currentChar));
			}
			else
			{
				builder.Append(currentChar);
			}
		}

		return builder.ToString();
	}
}
