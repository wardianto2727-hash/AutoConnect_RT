using System;
using System.Collections.Generic;
using System.Management;

public class GClass1
{

	public string String_0
	{
		get
		{
			return this.string_0;
		}
	}

	public string String_1
	{
		get
		{
			return this.string_1;
		}
	}

	public string String_2
	{
		get
		{
			return this.string_0;
		}
		set
		{
			this.string_0 = value;
		}
	}
	public string String_3
	{
		get
		{
			return this.string_1;
		}
		set
		{
			this.string_1 = value;
		}
	}

	public GClass1(string sDeviceManagerName, string sComPort)
	{
		this.string_0 = sDeviceManagerName;
		this.string_1 = sComPort;
	}

	public static List<GClass1> alexdev_0()
	{
		List<GClass1> list = new List<GClass1>();
		foreach (ManagementBaseObject managementBaseObject in new ManagementObjectSearcher("root\\cimv2", "SELECT * FROM Win32_PnPEntity WHERE Name LIKE '%(COM[0-9]%'").Get())
		{
			ManagementObject managementObject = (ManagementObject)managementBaseObject;
			string text = managementObject["Name"].ToString().Trim();
			string text2 = GClass1.alexdev_1(text);
			text.Replace("(" + text2 + ")", "").Trim();
			string sComPort = managementObject["PNPDeviceID"].ToString().Trim();
			list.Add(new GClass1(text2, sComPort));
		}
		return list;
	}
	private static string alexdev_1(string string_2)
	{
		bool flag = !string.IsNullOrEmpty(string_2);
		string result;
		if (flag)
		{
			int num = string_2.IndexOf("(");
			int num2 = string_2.IndexOf(")");
			result = ((num <= -1 || num2 <= -1) ? "" : checked(string_2.Substring(num + 1, num2 - num - 1)));
		}
		else
		{
			result = "";
		}
		return result;
	}
	private string string_0;
	private string string_1;
}
