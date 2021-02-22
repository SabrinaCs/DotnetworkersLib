// ---------------------------------------------------------------
// DATI FILE EncDec.cs
// ---------------------------------------------------------------
// Soluzione...............: DnwLibraries
// Progetto................: DnwCrypto
// File....................: EncDec.cs
// Namespace...............: Dnw.Crypto
// Classi..................: public static EncDec
// Interfacce..............:
// Enumerazioni............:
// Linee di codice.........: 174
// Dimensione..............: 4,94 Kb
// Data Creazione..........: 13/05/2013 15:45:38
// Data ultima Modifica....: 10/06/2013 17:37:41
// ---------------------------------------------------------------

using Dnw.Base;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Dnw.Crypto
{

	/// <summary>
	/// The encriptor decriptor helper
	/// </summary>
	public static class EncDec
	{
		private readonly static byte[] mBytes = new byte[] { 0x44, 0x6f, 0x74, 0x4e, 0x65, 0x74, 0x57, 
						0x6f, 0x72, 0x6b, 0x65, 0x72, 0x73, 0x2e, 0x47, 0x6f, 
						0x74, 0x74, 0x61 };

		/// <summary>
		/// Decrypts the specified data.
		/// </summary>
		/// <param name="encryptedData">The encrypted data.</param>
		/// <param name="outerKey">The outer key.</param>
		/// <param name="IV">The IV.</param>
		/// <returns></returns>
		private static byte[] Decrypt(byte[] encryptedData, byte[] outerKey, byte[] IV)
		{
			try
			{

				using (MemoryStream memoryStream = new MemoryStream())
				{
					Rijndael key = Rijndael.Create();
					key.Key = outerKey;
					key.IV = IV;
					using (CryptoStream cryptoStream =
						new CryptoStream(memoryStream, key.CreateDecryptor(),
							CryptoStreamMode.Write))
					{
						cryptoStream.Write(encryptedData, 0, (int)encryptedData.Length);
						cryptoStream.Close();
					}
					byte[] array = memoryStream.ToArray();
					return array;
				}
			}
			catch (Exception ex)
			{
				EventLogger.SendMsg(ex);
				throw;
			}
		}

		/// <summary>
		/// Decrypts the specified text.
		/// </summary>
		/// <param name="encryptedTextOrFileName">Name of the encrypted text or file.</param>
		/// <param name="isFileName">if set to <c>true</c> the data is a file name to read</param>
		/// <returns></returns>
		public static string Decrypt(string encryptedTextOrFileName, bool isFileName = false)
		{
			try
			{
				byte[] dataArray = null;
				if (!isFileName)
				{
					dataArray = Convert.FromBase64String(encryptedTextOrFileName);
				}
				else
				{
					dataArray = Convert.FromBase64String(File.ReadAllText(encryptedTextOrFileName));
				}
				PasswordDeriveBytes passwordDeriveByte =
					new PasswordDeriveBytes(EncDecRx.CryptoData, mBytes	);
				byte[] hiddenArray = EncDec.Decrypt(dataArray,
					passwordDeriveByte.GetBytes(32), passwordDeriveByte.GetBytes(16));
				return Encoding.Unicode.GetString(hiddenArray);

			}
			catch (Exception ex)
			{
				EventLogger.SendMsg(ex);
				throw;
			}
		}




		/// <summary>
		/// Encrypts the specified data.
		/// </summary>
		/// <param name="data">The data.</param>
		/// <param name="outerKey">The outer key.</param>
		/// <param name="IV">The IV.</param>
		/// <returns></returns>
		private static byte[] Encrypt(byte[] data, byte[] outerKey, byte[] IV)
		{
			try
			{

				using (MemoryStream memoryStream = new MemoryStream())
				{
					Rijndael key = Rijndael.Create();
					key.Key = outerKey;
					key.IV = IV;

					using (CryptoStream cryptoStream =
						new CryptoStream(memoryStream, key.CreateEncryptor(),
							CryptoStreamMode.Write))
					{
						cryptoStream.Write(data, 0, (int)data.Length);
						cryptoStream.Close();
					}
					byte[] array = memoryStream.ToArray();
					return array;
				}
			}
			catch (Exception ex)
			{
				EventLogger.SendMsg(ex);
				throw;
			}
		}

		/// <summary>
		/// Encrypts the specified text.
		/// </summary>
		/// <param name="text">The text.</param>
		/// <returns></returns>
		public static string Encrypt(string text)
		{
			try
			{

				byte[] bytes = Encoding.Unicode.GetBytes(text);
				PasswordDeriveBytes passwordDeriveByte =
					new PasswordDeriveBytes(EncDecRx.CryptoData, mBytes);
				byte[] encryptedArray = EncDec.Encrypt(bytes,
					passwordDeriveByte.GetBytes(32), passwordDeriveByte.GetBytes(16));
				return Convert.ToBase64String(encryptedArray);
			}
			catch (Exception ex)
			{
				EventLogger.SendMsg(ex);
				throw;
			}

		}

		/// <summary>
		/// Encrypts the specified text in the specified file
		/// </summary>
		/// <param name="text">The text.</param>
		/// <param name="fileName">Name of the file.</param>
		public static void Encrypt(string text, string fileName)
		{
			try
			{

				string encryptedData = Encrypt(text);
				File.WriteAllText(fileName, encryptedData);
			}
			catch (Exception ex)
			{
				EventLogger.SendMsg(ex);
				throw;
			}
		}


	}
}