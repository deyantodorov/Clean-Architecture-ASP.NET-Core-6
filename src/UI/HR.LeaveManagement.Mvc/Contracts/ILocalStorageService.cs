using System;
using System.Collections.Generic;

namespace HR.LeaveManagement.Mvc.Contracts
{
    public interface ILocalStorageService
    {
        void ClearStorage(List<string> keys);

        bool Exists(string key);

        T GetStorageValue<T>(string key);

        void SetStorageValue<T>(string key, T value);
    }
}

