using DataReader;
using DataReader.data.Records;
using Lib.Data.DB;
using Lib.Data.Attribs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ItemPackagingLogic.Entities
{
   
    public class CEntity<T> : IEntity where T : CDBRecord, new()
    {
        public const bool IS_DEBUGGING_FLAGS = true;


        // ....................................................................
        internal T __record;
        [Browsable(false)]
        public T Record { get { return __record; } }
        // ....................................................................

        // --------------------------------------------------------------------------------------
        public CEntity()
        {
            __record = new T();
        }
        // --------------------------------------------------------------------------------------
        //Advanced C#/.NET: This in an example of reflection. 
        protected int? getPrimaryKeyValue()
        {
            int? nResult = null;

            string sResult = string.Empty;
            Type tObjectType = GetType();
            foreach (var oProperty in tObjectType.GetProperties())
            {
                var oKeyAttrib = oProperty.GetCustomAttribute<KeyAttribute>();
                if (oKeyAttrib != null)
                {
                    string sPrimaryKeyFieldName = oProperty.Name;
                    nResult = (int?)oProperty.GetValue(this);
                    break;
                }
            }
            return nResult;
        }
        // --------------------------------------------------------------------------------------

        #region // IEntity \\
        // --------------------------------------------------------------------------------------
        [Browsable(IS_DEBUGGING_FLAGS)]
        public EntryChangeType Change
        {
            //PATTERNS: Adapter: The UX view this object as an IEntity that has a single property called Change
            //          Abstraction is suitable, because the UX does not anything more than setting change type to an entity.
            //          Each entity has a __record where there is no EntryChangeType but the boolean property IsDeleted, IsCreated, IsUpdated
            //          This object is the adapter, that performs the adaptation, and the __record is the adaptee.
            get
            {
                if (__record.IsDeleted)
                    return EntryChangeType.DELETED;
                else if (__record.IsNew)
                    return EntryChangeType.CREATED;
                else if (__record.IsUpdated)
                    return EntryChangeType.UPDATED;
                else
                    return EntryChangeType.NONE;
            }
            set
            {
                switch (value)
                {
                    case EntryChangeType.CREATED:
                        {
                            int? nKeyValue = getPrimaryKeyValue();
                            if (nKeyValue != null)
                                __record.IsNew = nKeyValue == 0;
                            else
                                __record.IsNew = true;
                            break;
                        }
                    case EntryChangeType.UPDATED:
                        {
                            __record.IsUpdated = true;
                            break;
                        }
                    case EntryChangeType.DELETED:
                        {
                            __record.IsDeleted = true;
                            break;
                        }

                }
            }
        }
        // --------------------------------------------------------------------------------------
        #endregion
    }
}
