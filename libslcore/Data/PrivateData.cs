using System.Collections.Generic;

namespace SLCore.Data
{
    public class PrivateData
    {
        public Dictionary<int, CardInfo> Unknown { get; }

        public PrivateData()
        {
            Unknown = new Dictionary<int, CardInfo>();
        }
    }
}