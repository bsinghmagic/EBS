using System;
using System.IO;
using System.Reflection;
using log4net;
using LiteDB;
using System.Collections.Generic;

namespace ConnectorLib.API
{
    /// <summary>
    /// Local DB Interface wrapper
    /// Hides DB-dependent implementation
    /// </summary>
    public class LocalDbApi
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(LocalDbApi));

        private string DbPath
        {
            get
            {
                var assemblyFullPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                var serviceExecutionDirectory = new FileInfo(assemblyFullPath).Directory?.FullName;

                if (serviceExecutionDirectory == null)
                    throw new SystemException("Critical error. Can not get execution path.");

                var databaseDirectory = Path.Combine(serviceExecutionDirectory, "DB/EBS");

                Directory.CreateDirectory(databaseDirectory);

                return Path.Combine(databaseDirectory, "local.db");
            }
        }
    public void drop(string key)
    {
      using (var db = new LiteDatabase(DbPath))
      {
        db.DropCollection(key);
      }
    }

    public void Save<T>(string key, T data)
    {
      using (var db = new LiteDatabase(DbPath))
      {
     
      var mapping = db.GetCollection<T>(key); 
         mapping.Upsert(data);
      }
    }
    public IEnumerable<T> Get<T>(string key)
    {
      using (var db = new LiteDatabase(DbPath))
      {
        var mapping = db.GetCollection<T>(key);      
        return mapping.FindAll();
      }
    }

    /// <summary>
    /// Saves new id pair in LocalDB
    /// </summary>
    /// <param name="key"></param>
    /// <param name="EBSCustomerId"></param>
    public void StoreCustomerId(string key, string EBSCustomerId)
        {
            using (var db = new LiteDatabase(DbPath))
            {
                var customerIdsMapping = db.GetCollection<CustomerIdMapping>();

                customerIdsMapping.Insert(new CustomerIdMapping
                {
                    EBSConnectorKey = key,
                    EBSCustomerId = EBSCustomerId
                });

                customerIdsMapping.EnsureIndex(x => x.EBSCustomerId);
                customerIdsMapping.EnsureIndex(x => x.EBSConnectorKey);

                Log.Info($"LOCALDB: Stored for Key: '{key}' map to CustomerId: '{EBSCustomerId}'");
            }
        }

        /// <summary>
        /// Get EBS Customer Id by Key (cross-system)
        /// </summary>
        /// <param name="key">Composite unique key</param>
        /// <returns>EBS Customer Id or null if key is not found</returns>
        public string GetCustomerIdByKey(string key)
        {
            using (var db = new LiteDatabase(DbPath))
            {
                var customerIdsMapping = db.GetCollection<CustomerIdMapping>();
                var map = customerIdsMapping.FindOne(x => x.EBSConnectorKey.Equals(key));

                Log.Info($"LOCALDB: Found for key: '{key}' map to CustomerId: '{map?.EBSCustomerId ?? "null"}'");

                return map?.EBSCustomerId;
            }
        }

        /// <summary>
        /// Saves new id pair in LocalDB
        /// </summary>
        /// <param name="key"></param>
        /// <param name="EBSVendorId"></param>
        public void StoreVendorId(string key, string EBSVendorId)
        {
            using (var db = new LiteDatabase(DbPath))
            {
                var customerIdsMapping = db.GetCollection<VendorIdMapping>();

                customerIdsMapping.Insert(new VendorIdMapping
                {
                    EBSConnectorKey = key,
                    EBSVendorId = EBSVendorId
                });

                customerIdsMapping.EnsureIndex(x => x.EBSVendorId);
                customerIdsMapping.EnsureIndex(x => x.EBSConnectorKey);

                Log.Info($"LOCALDB: Stored for Key: '{key}' map to VendorId: '{EBSVendorId}'");
            }
        }

        /// <summary>
        /// Get EBS Vendor Id by Key (cross-system)
        /// </summary>
        /// <param name="key">Composite unique key</param>
        /// <returns>EBS Customer Id or null if key is not found</returns>
        public string GetVendorIdByKey(string key)
        {
            using (var db = new LiteDatabase(DbPath))
            {
                var customerIdsMapping = db.GetCollection<VendorIdMapping>();
                var map = customerIdsMapping.FindOne(x => x.EBSConnectorKey.Equals(key));

                Log.Info($"LOCALDB: Found for key: '{key}' map to VendorId: '{map?.EBSVendorId?? "null"}'");

                return map?.EBSVendorId;
            }
        }
        public string GetPurchaseOrderIdByKey(string key)
        {
            using (var db = new LiteDatabase(DbPath))
            {
                var purchaseOrderIdsMapping = db.GetCollection<PurchaseOrderIdMapping>();
                var map = purchaseOrderIdsMapping.FindOne(x => x.EBSConnectorKey.Equals(key));

                Log.Info($"LOCALDB: Found for key: '{key}' map to PurchaseOrderId: '{map?.PurchaseOrderId?? "null"}'");

                return map?.PurchaseOrderId;
            }
        }
        public void StorePurchaseOrderId(string key, string EBSPurchaseOrderId)
        {
            using (var db = new LiteDatabase(DbPath))
            {
                var customerIdsMapping = db.GetCollection<PurchaseOrderIdMapping>();

                customerIdsMapping.Insert(new PurchaseOrderIdMapping
                {
                    EBSConnectorKey = key,
                    PurchaseOrderId= EBSPurchaseOrderId
                });

                customerIdsMapping.EnsureIndex(x => x.PurchaseOrderId);
                customerIdsMapping.EnsureIndex(x => x.EBSConnectorKey);

                Log.Info($"LOCALDB: Stored for Key: '{key}' map to PurchaseOrderId: '{EBSPurchaseOrderId}'");
            }
        }
        private class CustomerIdMapping
        {
            public CustomerIdMapping()
            {
                Id = ObjectId.NewObjectId();
            }

            // ReSharper disable once UnusedAutoPropertyAccessor.Global
            // ReSharper disable once MemberCanBePrivate.Local
            // ReSharper disable once UnusedAutoPropertyAccessor.Local
            public ObjectId Id { get; }
            public string EBSConnectorKey { get; set; }
            public string EBSCustomerId { get; set; }
        }

        private class VendorIdMapping
        {
            public VendorIdMapping()
            {
                Id = ObjectId.NewObjectId();
            }
            
            public ObjectId Id { get; }
            public string EBSConnectorKey { get; set; }
            public string EBSVendorId { get; set; }
        }
        private class PurchaseOrderIdMapping
        {
            public PurchaseOrderIdMapping()
            {
                Id = ObjectId.NewObjectId();
            }
          
            public ObjectId Id { get; }
            public string EBSConnectorKey { get; set; }
            public string PurchaseOrderId { get; set; }
        }

    private class Mapping<T>
    {
      public string Key { get; set; }
      public T data { get; set; }
    }
  }
}
