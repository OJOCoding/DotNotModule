using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataReader
{
    public interface IDataModule
    {
        public Object Model { get; }
        public bool LoadLookups();
        public bool LoadBrowser(Dictionary<string, Object> p_oCriteria);
        public bool LoadBrowserFirstPage(Dictionary<string, Object> p_oCriteria);
        public bool LoadBrowserNextPage();
        public bool LoadBrowserPrevPage();
        public bool Load();
        public bool LoadMaster(int p_nKeyValue);
        public bool Save();
        public bool New();
        public bool Delete();
        public bool IsLoaded { get; set; }
        public String LastError { get; set; }
    }
}