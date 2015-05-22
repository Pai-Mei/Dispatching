using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GMap.NET;
using GMap.NET.MapProviders;

namespace Dispatching
{
	public class Settings
	{
		private static string m_FilePath = Environment.CurrentDirectory + "\\settings.xml";

		public Int32 MinZoom { get; set; }
		public Int32 MaxZoom { get; set; }

		public static Settings LoadSettings()
		{
			Settings sets = null;
			try
			{
				sets = Xml.Xml.Load(m_FilePath, typeof(Settings)) as Settings;
			}
			catch {
				throw new Exception("Файл с настройками отсутствует или поврежден!\nЗагружены настройки по-умолчанию.");
			}
			return sets;
		}

		public void SaveSettings()
		{
			try
			{
				Xml.Xml.Save(m_FilePath, this, typeof(Settings));
			}
			catch
			{
				throw new Exception("Файл с настройками не был создан из-за ошибки!");
			}
		}
	}
}
