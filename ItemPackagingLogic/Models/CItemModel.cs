﻿
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataReader;
using DataReader.data.Records;
using DataReader.data.Tables;
using DataReader.data;
using ItemPackagingLogic.Entities;
using ItemPackagingData.Records;

namespace ItemPackagingLogic.Models
{
    public class CItemModel
    {
        #region // Data Tier Objects \\
        public table_Item browser = new table_Item();
        public table_Item master = new table_Item();
        public table_Item_PKG detail = new table_Item_PKG();
        #endregion

        public List<CItem> ItemList = new List<CItem>();
        public CItem Item;
        public List<CItem_PKG> Item_Package = new List<CItem_PKG>();

        // --------------------------------------------------------------------------------------
        public CItemModel()
        {
        }
        // --------------------------------------------------------------------------------------
        public void Clear()
        {
            this.master.Records.Clear();
            this.detail.Records.Clear();

            this.Item = new CItem();
            this.Item_Package.Clear();
        }
        // --------------------------------------------------------------------------------------
        public void SaveMasterDetail()
        {
            this.__addDetailRecords();
            using (IDbTransaction iTransaction = CData.Instance.DB.BeginTransaction())
            {
                try
                {
                    this.master.Transaction = iTransaction;
                    this.detail.Transaction = iTransaction;

                    this.master.SaveTable();                
                    this.__updateMasterKeyOnDetails();      
                    this.detail.SaveDetails();  
                    iTransaction.Commit();
                }
                catch
                {
                    iTransaction.Rollback();
                    throw;
                }
            }
        }
        // --------------------------------------------------------------------------------------
        public void DeleteMasterDetail()
        {
            this.Item.Change = EntryChangeType.DELETED;
            this.__flagDetailsAsDeleted();

            using (IDbTransaction iTransaction = CData.Instance.DB.BeginTransaction())
            {
                try
                {
                    this.master.Transaction = iTransaction;
                    this.detail.Transaction = iTransaction;
                    this.detail.SaveDetails();  
                    this.master.SaveTable();
                    iTransaction.Commit();
                }
                catch
                {
                    iTransaction.Rollback();
                    throw;
                }
            }
        }
        // --------------------------------------------------------------------------------------
        public void CreateMasterDetailEntity()
        {
            this.Item = new CItem() { __record = this.master.Records[0] };
            this.Item_Package.Clear();

            foreach (Item_PKG oRecord in this.detail.Records)
            {
                CItem_PKG oDetail = new CItem_PKG() { __record = oRecord };
                this.Item_Package.Add(oDetail);
            }
        }
        // --------------------------------------------------------------------------------------
        public void CreateBrowserEntries()
        {
            this.ItemList.Clear();
            foreach (Item oRecord in this.browser.Records)
            {
                CItem oEntry = new CItem();
                oEntry.__record = oRecord;
                this.ItemList.Add(oEntry);
            }
        }

        private void __addDetailRecords()
        {
            if (this.Item.Change == EntryChangeType.CREATED)
                if (this.master.Records.IndexOf(this.Item.Record) == -1)
                    this.master.Records.Add(this.Item.Record);

            foreach (CItem_PKG oDetail in this.Item_Package)
            {
                if (oDetail.Change == EntryChangeType.CREATED)
                {
                    if (this.detail.Records.IndexOf(oDetail.Record) == -1)
                        this.detail.Records.Add(oDetail.Record);
                }
            }
        }
        // --------------------------------------------------------------------------------------
        private void __updateMasterKeyOnDetails()
        {
            int nMasterKey = this.master.Records[0].ID;
            foreach (var oDetail in this.detail.Records)
                oDetail.Item_ID = nMasterKey;
        }
        // --------------------------------------------------------------------------------------
        private void __flagDetailsAsDeleted()
        {
            foreach (var oDetail in this.Item_Package)
                oDetail.Change = EntryChangeType.DELETED;
        }
    }
}