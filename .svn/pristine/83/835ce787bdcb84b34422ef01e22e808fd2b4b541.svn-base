using System;
using System.Collections.Generic;
using System.Text;

using DataReader;

namespace ItemPackagingLogic

{
    public class CDataModuleObserver: List<IDataModule>
    {
        // --------------------------------------------------------------------------------
        public CDataModuleObserver()
        {
        }
        // --------------------------------------------------------------------------------
        public void Subscribe(IDataModule p_iModule)
        {
            // Add it only once.
            if (this.IndexOf(p_iModule) == -1) 
                this.Add(p_iModule);
        }
        // --------------------------------------------------------------------------------
        public void UnSubscribe(IDataModule p_iModule)
        {
            // Remove it if it is subscribed.
            if (this.IndexOf(p_iModule) != -1)
                this.Remove(p_iModule);
        }
        // --------------------------------------------------------------------------------
        public void NotifyAllToReloadLookups()
        {
            foreach (IDataModule iModule in this)
                iModule.LoadLookups();
        }
        // --------------------------------------------------------------------------------
        
        
    }
}
