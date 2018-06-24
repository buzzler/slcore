using System.Collections.Generic;

namespace SLCore.Data
{
    public class PublicData
    {
        public Dictionary<int, CardInfo> HostKnown { get; }
        public List<Dictionary<int, CardInfo>> ClientKnowns { get; }

        public PublicData()
        {
            HostKnown = new Dictionary<int, CardInfo>();
            ClientKnowns = new List<Dictionary<int, CardInfo>>();
        }
    }
}