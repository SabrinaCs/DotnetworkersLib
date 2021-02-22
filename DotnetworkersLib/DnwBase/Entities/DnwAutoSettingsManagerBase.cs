// ---------------------------------------------------------------
// DATI FILE DnwAutoSettingsManagerBase.cs
// ---------------------------------------------------------------
// Soluzione...............: DnwLibraries
// Progetto................: DnwBase
// File....................: DnwAutoSettingsManagerBase.cs
// Namespace...............: Dnw.Base.Entities
// Classi..................: public abstract DnwAutoSettingsManagerBase
// Interfacce..............:
// Enumerazioni............:
// Linee di codice.........: 110
// Dimensione..............: 2,92 Kb
// Data Creazione..........: 13/06/2013 11:14:04
// Data ultima Modifica....: 13/06/2013 12:52:17
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;
using Dnw.Base.Collections;
using System.IO;



namespace Dnw.Base.Entities
{
	///<summary>
	/// Descrizione della classe: 
	///</summary>
	public abstract class DnwAutoSettingsManagerBase
	{

		/// <summary>
		/// The FMP sttfilename
		/// </summary>
		protected const string FMP_STTFILENAME = "DotNetwork\\AutomaticSettings\\AS_{0}.nscfg";

		/// <summary>
		/// Setting automatici x salvataggio dimensioni e control t delle form
		/// </summary>
		///<remarks>
		///</remarks>
		private DnwSettingsCollection mAutoSettings;

		/// <summary>
		/// Get - string User file name
		/// </summary>
		///<remarks>
		///</remarks>
		public abstract string AutoConfigName { get; }

		/// <summary>
		/// Get or set - Setting automatici x salvataggio dimensioni e control t delle form
		/// </summary>
		///<remarks>
		///</remarks>
		public DnwSettingsCollection AutoSettings
		{
			get
			{
				if (mAutoSettings == null)
				{
					if (File.Exists(AutoConfigName))
					{
						try
						{
							mAutoSettings = DnwSettingsCollection.ReadXml(AutoConfigName, false);
						}
						catch (Exception ex)
						{
							EventLogger.SendMsg(ex);
							mAutoSettings = new DnwSettingsCollection();
						}
					}
					else
					{
						mAutoSettings = new DnwSettingsCollection();
					}
				}
				return mAutoSettings;
			}
		}

		/// <summary>
		/// Aggiunge un setting.
		/// Se esiste rimpiazza il valore
		/// </summary>
		/// <param name="pNewSetting">Nuovo setting da aggiungere</param>
		public void AddOrReplace(DnwSetting pNewSetting)
		{
			try
			{
				DnwSetting esistente = AutoSettings.FirstOrDefault(s => s.ID.ToLower() == pNewSetting.ID.ToLower());
				if (esistente != null)
				{
					esistente.Value = pNewSetting.Value;
				}
				else
				{
					AutoSettings.Add(pNewSetting);
				}
			}
			catch (Exception ex)
			{
				EventLogger.SendMsg(ex);
				throw;
			}
		}

		/// <summary>
		/// Aggiunge un setting.
		/// Se esiste rimpiazza il valore
		/// </summary>
		/// <param name="pNewSettingName">Nome del nuovo setting.</param>
		/// <param name="pNewSettingValue">Valore del nuovo setting</param>
		public void AddOrReplace(string pNewSettingName, string pNewSettingValue)
		{
			try
			{
				DnwSetting esistente = AutoSettings.FirstOrDefault(s => s.ID.ToLower() == pNewSettingName.ToLower());
				if (esistente != null)
				{
					esistente.Value = pNewSettingValue;
				}
				else
				{
					AutoSettings.Add(new DnwSetting() { ID = pNewSettingName, Value = pNewSettingValue });
				}
			}
			catch (Exception ex)
			{
				EventLogger.SendMsg(ex);
				throw;
			}
		}

		/// <summary>
		/// Torna il valore del setting, Se il setting non esiste torna il valore passato
		/// </summary>
		/// <param name="pSettingName">Nome del setting</param>
		/// <param name="pSettingValueIfNotExists">Stringa di ritorno se non esiste</param>
		/// <returns></returns>
		public string GetSettingValue(string pSettingName, string pSettingValueIfNotExists)
		{
			string rito = pSettingValueIfNotExists;
			try
			{
				DnwSetting esistente = AutoSettings.FirstOrDefault(s => s.ID.ToLower() == pSettingName.ToLower());
				if (esistente != null)
				{
					rito = esistente.Value;
				}
			}
			catch (Exception ex)
			{
				EventLogger.SendMsg(ex);
				throw;
			}
			return (rito);
		}

		/// <summary>
		/// Saves the settings.
		/// </summary>
		public void SaveSettings()
		{
			AutoSettings.WriteXml(AutoConfigName);
		}



	}
}