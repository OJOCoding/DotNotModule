﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

using Lib.Data.Attribs;

namespace Lib.Data.DB
{
    public class CDBRecord
    {
        public const bool IS_DEBUGGING_FLAGS = true;

        // ....................................................................
        private bool __isNew = false;
        [ColumnWidth(30)]
        [Browsable(IS_DEBUGGING_FLAGS)]
        public bool IsNew { get { return __isNew; } set { __isNew = value; } }
        // ....................................................................
        private bool __isUpdated = false;
        [ColumnWidth(30)]
        [Browsable(IS_DEBUGGING_FLAGS)]
        public bool IsUpdated
        {
            get { return __isUpdated; }
            set
            {
                if (!__isNew)
                    __isUpdated = value;
            }
        }
        // ....................................................................
        private bool __isDeleted = false;
        [ColumnWidth(30)]
        [Browsable(IS_DEBUGGING_FLAGS)]
        public bool IsDeleted
        {
            get { return __isDeleted; }

            set
            {
                __isDeleted = value;
                if (__isUpdated)
                    __isUpdated = false;

                // In case a new record has been deleted before saving it will be disregarded
                if (__isNew && __isDeleted)
                {
                    __isNew = false;
                    __isDeleted = false;
                }
            }
        }
        // ....................................................................
        [ColumnWidth(30)]
        [Browsable(false)]
        public string PrimaryKeyName
        {
            get
            {
                string sResult = string.Empty;
                Type tObjectType = GetType();
                foreach (var oProperty in tObjectType.GetProperties())
                {
                    var oKeyAttrib = oProperty.GetCustomAttribute<KeyAttribute>();
                    if (oKeyAttrib != null)
                    {
                        sResult = oProperty.Name;
                        break;
                    }
                }
                return sResult;
            }
        }
        // ....................................................................

        public int PrimaryKeyValue
        {
            get
            {
                Type tObjectType = GetType();

                PropertyInfo? oInfo = tObjectType.GetProperty(this.PrimaryKeyName);
                if (oInfo != null)
                    return (int)(oInfo.GetValue(this)??-1);
                else
                    return -1;
            }
            set
                { 
                    Type tObjectType = GetType();

                    PropertyInfo? oInfo = tObjectType.GetProperty(this.PrimaryKeyName);
                    if (oInfo != null)
                        oInfo.SetValue(this, value);
            }
        }
        // ....................................................................
    }
}
