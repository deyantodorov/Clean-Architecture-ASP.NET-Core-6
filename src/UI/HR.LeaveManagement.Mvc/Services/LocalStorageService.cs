using System.Collections.Generic;

using Hanssens.Net;

using HR.LeaveManagement.Mvc.Contracts;

namespace HR.LeaveManagement.Mvc.Services
{
    public class LocalStorageService : ILocalStorageService
    {
        private LocalStorage _storage;

        public LocalStorageService()
        {
            var config = new LocalStorageConfiguration
            {
                AutoLoad = true,
                AutoSave = true,
                Filename = "HR.LEAVEMGMT"
            };

            _storage = new LocalStorage(config);
        }

        public void ClearStorage(List<string> keys)
        {
            foreach (var key in keys)
            {
                _storage.Remove(key);
            }
        }

        public bool Exists(string key) => _storage.Exists(key);

        public T GetStorageValue<T>(string key) => _storage.Get<T>(key);

        public void SetStorageValue<T>(string key, T value)
        {
            _storage.Store(key, value);
            _storage.Persist();
        }
    }
}

