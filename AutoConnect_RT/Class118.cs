using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

[StandardModule] 
internal sealed class Class118
{
	public static string alexdev_0(string string_1)
	{
		StringBuilder stringBuilder = new StringBuilder();
		checked
		{
			for (int i = 0; i < string_1.Length; i++)
			{
				stringBuilder.Append(((int)string_1[i]).ToString("x").ToUpper());
			}
			return stringBuilder.ToString();
		}
	}

	[MethodImpl(MethodImplOptions.NoOptimization)]
	public static object alexdev_1(ref string string_1, ref int int_0, ref short short_0)
	{
		FileSystem.FileOpen(1, string_1, OpenMode.Binary, OpenAccess.Read, OpenShare.Default, -1);
		FileSystem.FileGet(1, ref int_0, (long)short_0);
		FileSystem.FileClose(Array.Empty<int>());
		return int_0;
	}

	[MethodImpl(MethodImplOptions.NoOptimization)]
	public static void alexdev_2(ref string string_1, ref int int_0, ref short short_0)
	{
		FileSystem.FileOpen(2, string_1, OpenMode.Binary, OpenAccess.Write, OpenShare.Default, -1);
		FileSystem.FilePut(2, int_0, (long)short_0);
		FileSystem.FileClose(Array.Empty<int>());
	}

	public static string alexdev_3(ref string string_1)
	{
		string text = "";
		while (string_1.Length > 0)
		{
			string str = Conversion.Hex(Strings.Asc(string_1.Substring(0, 1).ToString()));
			string_1 = string_1.Substring(1, checked(string_1.Length - 1));
			text += str;
		}
		return text;
	}

	public static void alexdev_4(string string_1)
	{
		string text = "";
		int num = Strings.Len(string_1);
		checked
		{
			for (int i = 1; i <= num; i++)
			{
				string str = Strings.Mid(string_1, i, 8);
				int num2 = 128;
				int num3 = 0;
				int num4 = 1;
				do
				{
					bool flag = Operators.CompareString(Strings.Mid(str, num4, 1), "3", false) == 0;
					if (flag)
					{
						num3 += num2;
						num2 = (int)Math.Round((double)num2 / 2.0);
					}
					else
					{
						num2 = (int)Math.Round((double)num2 / 2.0);
					}
					num4++;
				}
				while (num4 <= 8);
				text += Conversions.ToString(Strings.Chr(num3));
				i += 7;
			}
			string_1 = text;
		}
	}

	public static string alexdev_5(string string_1)
	{
		string[] array = new string[8];
		string text = "";
		string text2 = "";
		int num = Strings.Len(string_1);
		checked
		{
			for (int i = 1; i <= num; i++)
			{
				int num2 = Strings.Asc(Strings.Mid(string_1, i, 1));
				array[7] = Conversions.ToString(num2 % 2);
				num2 = (int)Math.Round((double)num2 / 2.0);
				array[6] = Conversions.ToString(num2 % 2);
				num2 = (int)Math.Round((double)num2 / 2.0);
				array[5] = Conversions.ToString(num2 % 2);
				num2 = (int)Math.Round((double)num2 / 2.0);
				array[4] = Conversions.ToString(num2 % 2);
				num2 = (int)Math.Round((double)num2 / 2.0);
				array[3] = Conversions.ToString(num2 % 2);
				num2 = (int)Math.Round((double)num2 / 2.0);
				array[2] = Conversions.ToString(num2 % 2);
				num2 = (int)Math.Round((double)num2 / 2.0);
				array[1] = Conversions.ToString(num2 % 2);
				num2 = (int)Math.Round((double)num2 / 2.0);
				array[0] = Conversions.ToString(num2 % 2);
				int num3 = Information.UBound(array, 1);
				for (int j = 0; j <= num3; j++)
				{
					text += array[j];
				}
				text2 += text;
				text = "";
			}
			string_1 = text2;
			return string_1;
		}
	}

	public static string alexdev_6(string string_1, int int_0)
	{
		checked
		{
			string result;
			using (StreamReader streamReader = new StreamReader(string_1))
			{
				int num = int_0 - 1;
				for (int i = 1; i <= num; i++)
				{
					streamReader.ReadLine();
				}
				result = streamReader.ReadLine();
			}
			return result;
		}
	}

	public static string alexdev_7(string string_1)
	{
		string text = Conversions.ToString(0);
		try
		{
			bool flag = File.Exists(string_1);
			if (flag)
			{
				StreamReader streamReader = new StreamReader(string_1);
				while (Operators.CompareString(streamReader.ReadLine(), "", false) != 0)
				{
					text = Conversions.ToString(Conversions.ToDouble(text) + 1.0);
				}
				streamReader.Close();
			}
			else
			{
				Interaction.MsgBox(" Error: Setting file not found", MsgBoxStyle.OkOnly, null);
			}
		}
		catch (Exception)
		{
		}
		return text;
	}

	internal static void alexdev_8(string string_1, string string_2)
	{
		try
		{
			using (StreamWriter streamWriter = File.AppendText(string_1))
			{
				streamWriter.WriteLine(string_2);
				streamWriter.Close();
			}
		}
		catch (Exception)
		{
		}
	}

	internal static void alexdev_9(string string_1)
	{
		try
		{
			bool flag = File.Exists(string_1);
			if (flag)
			{
				StreamWriter streamWriter = new StreamWriter(string_1);
				streamWriter.Write("");
				streamWriter.Close();
			}
		}
		catch (Exception)
		{
		}
	}
}
