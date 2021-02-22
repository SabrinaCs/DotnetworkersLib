// ---------------------------------------------------------------
// DATI FILE SqlConnectionInfoModel.cs
// ---------------------------------------------------------------
// Soluzione...............: DnwLibraries
// Progetto................: DnwUISqlServer
// File....................: SqlConnectionInfoModel.cs
// Namespace...............: Dnw.UI.SqlServer.Models
// Classi..................: public SqlConnectionInfoModel : INotifyPropertyChanged
// Interfacce..............:
// Enumerazioni............:
// Linee di codice.........: 861
// Dimensione..............: 21,16 Kb
// Data Creazione..........: 13/05/2013 15:45:40
// Data ultima Modifica....: 16/05/2013 16:07:21
// ---------------------------------------------------------------

using Dnw.Base;
using Dnw.Base.Data.SqlServer.Collections;
using Dnw.Base.Data.SqlServer.Entities;
using Dnw.Crypto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Dnw.UI.SqlServer.Models
{
	///<summary>
	/// Descrizione della classe: 
	///</summary>
	public class SqlConnectionInfoModel : INotifyPropertyChanged
	{

		#region Constants

		/// <summary>
		/// Connection Types
		/// N/A
		/// </summary>
		public const string FLD_ConnectionTypes = "ConnectionTypes";

		/// <summary>
		/// Contains the currently active element in the connection
		/// N/A
		/// </summary>
		public const string FLD_CurrentConnection = "CurrentConnection";

		/// <summary>
		/// Editing Image
		/// N/A
		/// </summary>
		public const string FLD_EditImage = "EditImage";

		/// <summary>
		/// File Name
		/// N/A
		/// </summary>
		public const string FLD_FileName = "FileName";

		/// <summary>
		/// Indicates wether the collection of connection informations has been changed during this session
		/// N/A
		/// </summary>
		public const string FLD_IsChanged = "IsChanged";

		/// <summary>
		/// Indicates wether the control is in edit mode so that the Textboxes can be modified
		/// N/A
		/// </summary>
		public const string FLD_IsInEditMode = "IsInEditMode";

		/// <summary>
		/// Indicates wether the collection of connection informations has not been changed during this session
		/// N/A
		/// </summary>
		public const string FLD_IsNotChanged = "IsNotChanged";

		/// <summary>
		/// Opposite of the IsInEditMode generated because needed to bind the enabled property
		/// of the menu options of the control.
		/// </summary>
		public const string FLD_IsNotInEditMode = "IsNotInEditMode";

		/// <summary>
		/// Indicates wether the Username and password can be edited
		/// DbField
		/// </summary>
		public const string FLD_SqlConnectionIsInEditMode = "SqlConnectionIsInEditMode";

		/// <summary>
		/// Collection of the Connection Items managed by the user control
		/// N/A
		/// </summary>
		public const string FLD_SqlConnections = "SqlConnections";

		/// <summary>
		/// Untrusted enables or disables the username and password for the connection in editing mode if the trusted flag is false
		/// N/A
		/// </summary>
		public const string FLD_Untrusted = "Untrusted";

		/// <summary>
		/// Image Path
		/// </summary>
		private const string IMG_Editing = "pack://application:,,,/Dnw.UI.SqlServer.v4.0;component/Images/btn_032_113.png";

		/// <summary>
		/// Image Path
		/// </summary>
		private const string IMG_View = "pack://application:,,,/Dnw.UI.SqlServer.v4.0;component/Images/btn_032_159.png";

		/// <summary>
		/// Image Path
		/// </summary>
		private const string IMG_TestConn = "pack://application:,,,/Dnw.UI.SqlServer.v4.0;component/Images/btn_032_151.png";

		/// <summary>
		/// Image Path
		/// </summary>
		private const string IMG_TestConnOk = "pack://application:,,,/Dnw.UI.SqlServer.v4.0;component/Images/btn_032_166.png";

		/// <summary>
		/// Image Path
		/// </summary>
		private const string IMG_TestConnKo = "pack://application:,,,/Dnw.UI.SqlServer.v4.0;component/Images/btn_032_232.png";

		#endregion

		#region Fields

		/// <summary>
		/// Connection Types
		/// N/A
		/// </summary>
		private List<Tuple<string, string>> mConnectionTypes;

		/// <summary>
		/// Contains the currently active element in the connection
		/// N/A
		/// </summary>
		private SqlConnectionInfo mCurrentConnection;

		/// <summary>
		/// Editing Image
		/// N/A
		/// </summary>
		private BitmapImage mEditImage;

		/// <summary>
		/// Name of the file where to put the connections or from which to retrieve them
		/// </summary>
		private string mFileName;

		/// <summary>
		/// Indicates wether the collection of connection informations has been changed during this session
		/// N/A
		/// </summary>
		private bool mIsChanged;

		/// <summary>
		/// Indicates wether the control is in edit mode so that the Textboxes can be modified
		/// N/A
		/// </summary>
		private bool mIsInEditMode;

		/// <summary>
		/// Not Editing Image
		/// N/A
		/// </summary>
		private BitmapImage mNotEditImage;

		/// <summary>
		/// Connection Test
		/// </summary>
		private BitmapImage mConnTest;

		/// <summary>
		/// Connection OK
		/// </summary>
		private BitmapImage mConnOk;

		/// <summary>
		/// Connection KO
		/// </summary>
		private BitmapImage mConnKo;

		/// <summary>
		/// Collection of the Connection Items managed by the user control
		/// N/A
		/// </summary>
		private SqlConnectionInfosCollection mSqlConnections;

		/// <summary>
		/// Collection reserved for the Undo
		/// </summary>
		private SqlConnectionInfosCollection mUndoSqlConnections;

		#endregion

		#region Public Methods

		/// <summary>
		/// Adds a new element to the connections collection and 
		/// activates editing on it.
		/// </summary>
		public void AddNew()
		{
			IsInEditMode = true;
			SqlConnectionInfo newItem = new SqlConnectionInfo();
			SqlConnections.Add(newItem);
			CurrentConnection = newItem;
			IsChanged = true;

		}

		/// <summary>
		/// Clears this instance.
		/// </summary>
		public void Clear()
		{
			this.SqlConnections = null;
			this.SqlConnections = new SqlConnectionInfosCollection();
			this.IsInEditMode = false;
			this.IsChanged = false;
		}

		/// <summary>
		/// Clones the current connection in a new one
		/// </summary>
		public void Clone()
		{
			if (CurrentConnection != null)
			{
				SqlConnectionInfo newItem = CurrentConnection.Clone();
				newItem.ConnectionID += "(Copy)";
				SqlConnections.Add(newItem);
				CurrentConnection = newItem;
				IsInEditMode = true;
				IsChanged = true;
			}
		}

		/// <summary>
		/// Deletes the currently selected connection
		/// </summary>
		public void Delete()
		{
			int ndx = SqlConnections.IndexOf(CurrentConnection);

			if (MessageBox.Show(SqlConnectionInfoModelRx.warSCIMConfirmDeletion, SqlConnectionInfoModelRx.warTitle, MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
			{
				SqlConnections.Remove(CurrentConnection);
				if (SqlConnections.Count > ndx)
				{
					CurrentConnection = SqlConnections[ndx];
				}
				else
				{
					if (SqlConnections.Count > 0)
					{
						CurrentConnection = SqlConnections[SqlConnections.Count - 1];
					}
					else
					{
						CurrentConnection = null;
					}
				}
				IsChanged = true;
			}
		}

		/// <summary>
		/// Edits the current connection
		/// </summary>
		public void Edit()
		{
			if (SqlConnections.Count == 0)
			{
				AddNew();
			}
			else
			{
				if (this.CurrentConnection == null)
				{
					if (MessageBox.Show(SqlConnectionInfoModelRx.txtSCIMAskToCreateNewConnection, SqlConnectionInfoModelRx.txtSCIMNewConnection, MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
					{
						AddNew();
					}
				}
				else
				{
					this.IsInEditMode = true;
				}
			}
		}

		/// <summary>
		/// Exports the content of the collection in a file selected by the user
		/// </summary>
		public void Export(ImportExportData data)
		{
			try
			{
				if (!data.Encrypt)
				{
					this.SqlConnections.Serialize(data.FileName);
				}
				else
				{
					EncDec.Encrypt(this.mSqlConnections.Serialize(), data.FileName);
				}
			}
			catch (Exception ex)
			{
				EventLogger.SendMsg(ex);
				throw;
			}
		}

		/// <summary>
		/// Imports the content of a connections file and adds them to the current collection
		/// </summary>
		public void Import(ImportExportData data)
		{
			try
			{

				string content = null;
				if (data.Encrypt)
				{
					content = EncDec.Decrypt(data.FileName, true);
				}
				else
				{
					content = File.ReadAllText(data.FileName);
				}
				SqlConnectionInfosCollection imported = SqlConnectionInfosCollection.Deserialize(content, false);
				if (imported.Count > 0)
				{
					foreach (SqlConnectionInfo item in imported)
					{
						SqlConnections.Add(item);
					}
				}

				IsChanged = true;
			}
			catch (Exception ex)
			{
				EventLogger.SendMsg(ex);
				throw;
			}
		}

		/// <summary>
		/// Loads the file set for this session in encrypted or decrypted mode.
		/// </summary>
		/// <param name="encrypted">if set to <c>true</c> the file is [encrypted].</param>
		public void Load(bool encrypted = false)
		{
			if (encrypted)
			{
				LoadEncrypted(FileName);
			}
			else
			{
				Load(FileName);
			}
		}


		/// <summary>
		/// Loads the encrypted file into the collection.
		/// </summary>
		/// <param name="fileName">Name of the file.</param>
		/// <exception cref="NoConnectionDataFileException"></exception>
		private void LoadEncrypted(string fileName)
		{
			if (!fileName.XDwIsNullOrTrimEmpty())
			{
				string jSonData = EncDec.Decrypt(fileName, true);

				this.SqlConnections = null;
				this.SqlConnections = SqlConnectionInfosCollection.Deserialize(jSonData, false);
				if (this.SqlConnections == null)
				{
					this.SqlConnections = new SqlConnectionInfosCollection();
				}
				this.IsInEditMode = false;
				this.IsChanged = false;
			}
			else
			{
				throw new NoConnectionDataFileException(SqlConnectionInfoModelRx.excSCIMNoFileToLoad);
			}

		}


		/// <summary>
		/// Loads the data from the file given
		/// </summary>
		/// <exception cref="Dnw.UI.SqlServer.Models.NoConnectionDataFileException"></exception>
		/// <exception cref="System.ApplicationException">TODO: load from file</exception>
		private void Load(string fileName)
		{
			if (!fileName.XDwIsNullOrTrimEmpty())
			{
				this.SqlConnections = null;
				this.SqlConnections = SqlConnectionInfosCollection.Deserialize(fileName);
				if (this.SqlConnections == null)
				{
					this.SqlConnections = new SqlConnectionInfosCollection();
				}
				this.IsInEditMode = false;
				this.IsChanged = false;
			}
			else
			{
				throw new NoConnectionDataFileException(SqlConnectionInfoModelRx.excSCIMNoFileToLoad);
			}
		}

		/// <summary>
		/// Saves the specified data in clear or encrypted way.
		/// </summary>
		/// <param name="encrypted">if set to <c>true</c> encrypts the data</param>
		public void Save(bool encrypted = false)
		{
			if (!FileName.XDwIsNullOrTrimEmpty())
			{
				if (encrypted)
				{
					SaveEncrypted(FileName);
				}
				else
				{
					Save(FileName);
				}

				mUndoSqlConnections.Clear();
				mUndoSqlConnections = null;

				this.IsInEditMode = false;
				this.IsChanged = false;
			}
			else
			{
				throw new NoConnectionDataFileException(SqlConnectionInfoModelRx.excSCIMNoFileToSave);
			}
		}

		/// <summary>
		/// Saves the data on the file given
		/// </summary>
		/// <exception cref="NoConnectionDataFileException"></exception>
		/// <exception cref="System.ApplicationException">TODO: save to file</exception>
		private void Save(string fileName)
		{
			this.SqlConnections.Serialize(fileName);
		}

		/// <summary>
		/// Saves the data encrypting them in the specified file.
		/// </summary>
		/// <param name="fileName">Name of the file.</param>
		/// <exception cref="NoConnectionDataFileException"></exception>
		private void SaveEncrypted(string fileName)
		{
			string jSonData = this.SqlConnections.Serialize();
			EncDec.Encrypt(jSonData, fileName);

		}

		/// <summary>
		/// Undoes all changes and reload original values from file
		/// or clears the data.
		/// </summary>
		public void Undo()
		{
			this.SqlConnections = null;
			this.SqlConnections = mUndoSqlConnections;
		}

		/// <summary>
		/// returns the content of this control as json data.
		/// </summary>
		/// <returns></returns>
		public string GetJsonData()
		{
			return (SqlConnections.Serialize());
		}

		/// <summary>
		/// returns the content of this control as a collection.
		/// </summary>
		/// <returns></returns>
		public SqlConnectionInfosCollection GetData()
		{
			return (SqlConnections);
		}

		/// <summary>
		/// Returns an encrypted string containing the data of this control.
		/// </summary>
		/// <returns></returns>
		public string GetEncryptedData()
		{
			string jSonData = this.SqlConnections.Serialize();
			return EncDec.Encrypt(jSonData);
		}

		/// <summary>
		/// Sets the data in the control from an external collection
		/// </summary>
		/// <param name="data">The data.</param>
		public void Load(SqlConnectionInfosCollection data)
		{
			SqlConnections = null;
			SqlConnections = data;
			if (this.SqlConnections == null)
			{
				this.SqlConnections = new SqlConnectionInfosCollection();
			}
			this.IsInEditMode = false;
			this.IsChanged = false;
		}

		/// <summary>
		/// Loads the data in the control from a Json string
		/// </summary>
		/// <param name="jsonData">The json data.</param>
		public void LoadJsonData(string jsonData)
		{
			SqlConnections = null;
			SqlConnections = SqlConnectionInfosCollection.Deserialize(jsonData, false);
			if (this.SqlConnections == null)
			{
				this.SqlConnections = new SqlConnectionInfosCollection();
			}
			this.IsInEditMode = false;
			this.IsChanged = false;
		}

		/// <summary>
		/// Loads the encrypted data.
		/// </summary>
		/// <param name="encryptedData">The encrypted data.</param>
		public void LoadEncryptedData(string encryptedData)
		{
			string jsonData = EncDec.Decrypt(encryptedData);
			SqlConnections = null;
			SqlConnections = SqlConnectionInfosCollection.Deserialize(jsonData, false);
			if (this.SqlConnections == null)
			{
				this.SqlConnections = new SqlConnectionInfosCollection();
			}
			this.IsInEditMode = false;
			this.IsChanged = false;
		}



		/// <summary>
		/// Initializes a new instance of the <see cref="SqlConnectionInfoModel"/> class.
		/// </summary>
		public SqlConnectionInfoModel()
		{
			mEditImage = new BitmapImage(new Uri(IMG_Editing));
			mNotEditImage = new BitmapImage(new Uri(IMG_View));
			mConnTest = new BitmapImage(new Uri(IMG_TestConn));
			mConnOk = new BitmapImage(new Uri(IMG_TestConnOk));
			mConnKo = new BitmapImage(new Uri(IMG_TestConnKo));
		}

		/// <summary>
		/// Tests the connection.
		/// </summary>
		public void TestConnection()
		{
			using (SqlConnection cn = new SqlConnection(CurrentConnection.ConnectionString))
			{
				try
				{
					cn.Open();
					cn.Close();
					this.CurrentConnectionTest = mConnOk;
				}
				catch (Exception)
				{
					this.CurrentConnectionTest = mConnKo;
				}
			}

		}

		#endregion

		#region Protected Methods

		/// <summary>
		/// Evento generato alla modifica di una property.
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

		///<summary>
		/// Evento che viene generato alla modifica di una property
		///</summary>
		/// <param name="pPropertyName">nome della property</param>
		protected virtual void OnPropertyChanged(string pPropertyName)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(pPropertyName));
		}

		#endregion

		#region Private Methods

		/// <summary>
		/// Handles the PropertyChanged event of the CurrentConnection control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="PropertyChangedEventArgs"/> instance containing the event data.</param>
		/// <exception cref="System.Exception">The method or operation is not implemented.</exception>
		void CurrentConnection_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (this.IsInEditMode)
			{
				this.IsChanged = true;
			}
			switch (e.PropertyName)
			{
				case SqlConnectionInfo.FLD_Trusted:
					OnPropertyChanged(FLD_SqlConnectionIsInEditMode);
					break;
			}
		}

		#endregion



		/// <summary>
		/// Collection of the Connection Items managed by the user control
		/// N/A
		/// </summary>
		public SqlConnectionInfosCollection SqlConnections
		{
			get
			{
				return mSqlConnections;
			}
			set
			{
				mSqlConnections = value;
				OnPropertyChanged(FLD_SqlConnections);
			}
		}

		/// <summary>
		/// Connection Types
		/// N/A
		/// </summary>
		public List<Tuple<string, string>> ConnectionTypes
		{
			get
			{
				if (mConnectionTypes == null)
				{
					mConnectionTypes = new List<Tuple<string, string>>();
					mConnectionTypes.Add(new Tuple<string, string>("ADM", "Administrative"));
					mConnectionTypes.Add(new Tuple<string, string>("LOG", "Login"));
					mConnectionTypes.Add(new Tuple<string, string>("OPE", "Operational"));

				}
				return mConnectionTypes;
			}
		}

		/// <summary>
		/// Name of the file where to put the connections or from which to retrieve them
		/// </summary>
		///<remarks>
		///</remarks>
		public string FileName
		{
			get
			{
				return mFileName;
			}
			set
			{
				mFileName = value;
				OnPropertyChanged(FLD_FileName);
			}
		}

		/// <summary>
		/// Indicates wether the collection of connection informations has been changed during this session
		/// N/A
		/// </summary>
		public bool IsChanged
		{
			get
			{
				return mIsChanged;
			}
			set
			{
				mIsChanged = value;
				OnPropertyChanged(FLD_IsChanged);
				OnPropertyChanged(FLD_IsNotChanged);
			}
		}

		/// <summary>
		///  Indicates the opposite of the IsChanged property due to Binding needs
		/// </summary>
		public bool IsNotChanged
		{
			get
			{
				return !IsChanged;
			}
		}

		/// <summary>
		/// Indicates wether the control is in edit mode so that the Textboxes can be modified
		/// N/A
		/// </summary>
		public bool IsInEditMode
		{
			get
			{
				return mIsInEditMode;
			}
			set
			{
				if (!mIsInEditMode && value)
				{
					if (SqlConnections != null)
					{
						mUndoSqlConnections = SqlConnections.Clone();
					}
					else
					{
						mUndoSqlConnections = null;
					}
				}
				mIsInEditMode = value;

				OnPropertyChanged(FLD_IsInEditMode);
				OnPropertyChanged(FLD_IsNotInEditMode);
				OnPropertyChanged(FLD_SqlConnectionIsInEditMode);
				OnPropertyChanged(FLD_EditImage);
			}
		}


		/// <summary>
		/// Gets a value indicating whether this instance is not in edit mode.
		/// </summary>
		/// <value>
		/// <c>true</c> if this instance is not in edit mode; otherwise, <c>false</c>.
		/// </value>
		public bool IsNotInEditMode
		{
			get
			{
				return (!IsInEditMode);
			}
		}

		/// <summary>
		/// Indicates wether the Username and password can be edited
		/// DbField
		/// </summary>
		public bool SqlConnectionIsInEditMode
		{
			get
			{
				bool isTheCurrentConnectionTrusted = false;
				if (CurrentConnection != null)
				{
					isTheCurrentConnectionTrusted = CurrentConnection.Trusted;
				}
				return this.IsInEditMode && !isTheCurrentConnectionTrusted;
			}
		}

		/// <summary>
		/// Contains the currently active element in the connection
		/// N/A
		/// </summary>
		public SqlConnectionInfo CurrentConnection
		{
			get
			{
				return mCurrentConnection;
			}
			set
			{
				if (mCurrentConnection != null)
				{
					mCurrentConnection.PropertyChanged += CurrentConnection_PropertyChanged;
				}
				mCurrentConnection = value;
				if (mCurrentConnection != null)
				{
					mCurrentConnection.PropertyChanged += CurrentConnection_PropertyChanged;
				}
				CurrentConnectionTest = mConnTest;
				OnPropertyChanged(FLD_CurrentConnection);
				OnPropertyChanged(FLD_SqlConnectionIsInEditMode);
				OnPropertyChanged(FLD_IsInEditMode);

			}
		}

		/// <summary>
		/// Editing Image
		/// N/A
		/// </summary>
		public BitmapImage EditImage
		{
			get
			{
				if (IsInEditMode)
				{
					return (mEditImage);
				}
				else
				{
					return (mNotEditImage);
				}
			}
		}


		/// <summary>
		/// Test connection image
		/// N/A
		/// </summary>
		public const string FLD_CurrentConnectionTest = "CurrentConnectionTest";

		/// <summary>
		/// Test connection image
		/// N/A
		/// </summary>
		private BitmapImage mCurrentConnectionTest;

		/// <summary>
		/// Test connection image
		/// N/A
		/// </summary>
		public BitmapImage CurrentConnectionTest
		{
			get
			{
				return mCurrentConnectionTest;
			}
			set
			{
				mCurrentConnectionTest = value;
				OnPropertyChanged(FLD_CurrentConnectionTest);
			}
		}

	

	}
}