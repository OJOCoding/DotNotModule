using System;
using System.Text.Json;
using System.Text.Json.Serialization;



namespace DataReader
{
    // =============================================================================================================
    public class CAppSettings
    {
        // ........................................................................
        // If the application is using the new Material UX
        public bool IsNewUX { get; set; }
        // ........................................................................
        // Name of the LocalDB instance
        public string InstanceName { get; set; }
        // ........................................................................
        // Name of the database file without its extension
        public string DatabaseName { get ;set; }
        // ........................................................................
        // The folllowing is a C# attribute. With this attribute you ignore this property from JSON serialization/deserialization
        [JsonIgnore]
        public string FileName { get; set; }
        // ........................................................................
        [JsonIgnore]
        public string DatabasePath { get; set; }
        // ........................................................................



        // --------------------------------------------------------------------------------------
        public CAppSettings()
        {
            // Assign the default values for the settings
            this.IsNewUX = false;
            this.InstanceName = "MyInstance";
            this.DatabaseName = "ItemPackages";

            // The .exe file resides under a sub-folder /bin/Debug/net6.0-windows. 
            // To locate other files/folders we should go some folders back.
            // This is the count specified at the parameter.
            this.FileName = Path.Combine(this.getParentPath(4), "settings.json");

            this.DatabasePath = this.getParentPath(4);
        }
        // --------------------------------------------------------------------------------------
        private string getParentPath(int p_nFoldersBeforeCount)
        {
            // Go back some folders from the path from which the executable runs, e.g. for p_nFoldersBeforeCount=4 it is ..\..\..\.. 
            string sDBPath = Environment.CurrentDirectory; ;
            for (int nPreviousFolder = 1; nPreviousFolder <= p_nFoldersBeforeCount; nPreviousFolder++)
            {
                var oConfigFolder = Directory.GetParent(sDBPath);
                if (oConfigFolder != null)
                    sDBPath = oConfigFolder.FullName;
            }
            return sDBPath;
        }
        // ------------------------------------------------------------------------------------------------
        public void Assign(CAppSettings p_oSettings)
        {
            this.IsNewUX = p_oSettings.IsNewUX;
            this.InstanceName = p_oSettings.InstanceName;
            this.DatabaseName = p_oSettings.DatabaseName;
        }
        // ------------------------------------------------------------------------------------------------
        public CAppSettings? LoadJSON()
        {
            CAppSettings? oResult;

            if (File.Exists(FileName))
            { 
                // This is an example of deserializing a C# object from a JSON String
                string sJSON = File.ReadAllText(this.FileName);
                oResult = (CAppSettings?)JsonSerializer.Deserialize(sJSON, GetType());
            }
            else
                oResult = null;

            
            return oResult;
        }
        // ------------------------------------------------------------------------------------------------
        public void SaveJSON(object p_oSourceObject)
        {
            // This is an example of serializing an object into a JSON string
            JsonSerializerOptions oOptions = new JsonSerializerOptions();
            oOptions.WriteIndented = true;

            string sJSON = JsonSerializer.Serialize(p_oSourceObject, oOptions);
            File.WriteAllText(this.FileName, sJSON);
        }
        // --------------------------------------------------------------------------------------
        public void Save()
        { 
            this.SaveJSON(this);
        }
        // --------------------------------------------------------------------------------------
        public void Load()
        {
            if (!File.Exists(FileName))
            {
                // Lazy initialization of settings:
                // If the settings file does not exist, the first run will create the settings file.
                SaveJSON(this);
            }
            else
            {
                // If the file is successfully loaded, it will assign the values of loaded settings
                CAppSettings? oLoadedSettings = LoadJSON();
                if (oLoadedSettings != null)
                    Assign(oLoadedSettings);
            }
        }
        // --------------------------------------------------------------------------------------



        // ....................................................................
        //PATTERN: Singleton. There can be only one instance of the class CApp
        private static CAppSettings? __instance = null;
        public static CAppSettings Instance
        {
            get
            {
                //PATTERN: Lazy initialization. The only instance is created at the first time that is needed.
                if (__instance == null)
                { 
                    __instance = new CAppSettings();
                    __instance.Load();
                }
                return __instance;
            }
        }
        // ....................................................................
    }

}
