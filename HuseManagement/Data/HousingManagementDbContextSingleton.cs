using System;

namespace HuseManagement.Data
{
    
    public static class HousingManagementDbContextSingleton
    {
        private static volatile HousingManagementDB instance;
        private static readonly object syncRoot = new object();

        
        public static HousingManagementDB Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new HousingManagementDB();
                        }
                    }
                }
                return instance;
            }
        }

        
        public static void DisposeInstance()
        {
            lock (syncRoot)
            {
                if (instance != null)
                {
                    instance.Dispose();
                    instance = null;
                }
            }
        }
    }
}
