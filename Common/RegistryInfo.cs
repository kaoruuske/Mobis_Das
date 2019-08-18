using System;
using Microsoft.Win32;

namespace MOBISDAS.Common
{
	public class RegistryInfo
	{
		#region [Method] RegistryRead : Registry Key Read
		/// <summary>
		/// Registry Key를 레지스트리 정보에서 읽어온다.
		/// </summary>
		/// <param name="RegHive">Registry의 Directory 설정 (ex : Registry.LocalMachine)</param>
		/// <param name="RegPath">Registry Path 설정 (ex:"Software\\AutoWare\\TEST\\")</param>
		/// <param name="KeyName">Registry Key Name 설정 </param>
		/// <param name="DefaultValue">Registry Key Value가 Null인 경우 return되는 Default Value 설정</param>
		/// <returns>Registry Key 정보</returns>
		public static string RegistryRead(RegistryKey RegHive, string RegPath, string KeyName, string DefaultValue)
		{
			string strResult = ""; 
			string[] regStrings = RegPath.Split('\\');;
			
			//First item of array will be the base key, so be carefull iterating below
			RegistryKey[] RegKey = new RegistryKey[regStrings.Length + 1]; 
			RegKey[0] = RegHive; 
			
			try
			{
				for (int i = 0; i < regStrings.Length; i++)
				{
					RegKey[i + 1] = RegKey[i].OpenSubKey(regStrings[i]);

					// OpenSubKey가 없는 경우 DefaultValue return
					if (RegKey[i + 1] == null)			return DefaultValue;
					if (i == regStrings.Length - 1)		strResult = (string) RegKey[i + 1].GetValue(KeyName, DefaultValue); 
				} 
				return strResult; 
			}
			catch
			{
				return "";
			}
		}  
		#endregion

		#region [Method] RegistryWrite : Registry Key Write
		/// <summary>
		/// Registry Key를 레지스트리 정보에 설정한다.
		/// </summary>
		/// <param name="RegHive">Registry의 Directory 설정 (ex : Registry.LocalMachine)</param>
		/// <param name="RegPath">Registry Path 설정 (ex:"Software\\AutoWare\\TEST\\")</param>
		/// <param name="KeyName">Registry Key Name 설정 </param>
		/// <param name="KeyValue">Registry Key Value</param>
		public static void RegistryWrite(RegistryKey RegHive, string RegPath, string KeyName, string KeyValue)
		{
			// Split the registry path
			string[] regStrings = RegPath.Split('\\');

			// First item of array will be the base key, so be carefull iterating below
			RegistryKey[] RegKey = new RegistryKey[regStrings.Length + 1]; 
			RegKey[0] = RegHive; 
  
			for (int i = 0; i < regStrings.Length; i++)
			{
				RegKey[i + 1] = RegKey[i].OpenSubKey(regStrings[i], true);
				if (RegKey[i + 1] == null)	RegKey[i + 1] = RegKey[i].CreateSubKey(regStrings[i]);
			} 
			
			// Write the value to the registry
			try
			{
				RegKey[regStrings.Length].SetValue(KeyName, KeyValue);
			}
			catch (System.NullReferenceException)
			{
				// throw(new Exception("Null Reference"));
			}
			catch (System.UnauthorizedAccessException)
			{
				// throw(new Exception("Unauthorized Access"));
			}
		}
		#endregion
	}
}