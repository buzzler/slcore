using System;
using System.Collections.Generic;

namespace SLCore.Data
{
    public class HostData
    {
        public int Leader { get; set; }
        public int Turn { get; set; }
        public PublicData PublicData { get; }
        public PrivateData PrivateData { get; }
        public List<PrivateData> ClientsDatas { get; }

        internal HostData(PublicData publicData, PrivateData privateData, List<PrivateData> clientsDatas)
        {
            Leader = -1;
            Turn = -1;
            PublicData = publicData;
            PrivateData = privateData;
            ClientsDatas = clientsDatas;
        }

        internal PrivateData GetClientData(int id)
        {
            if (ClientsDatas.Count <= id)
                throw new ArgumentException($"wrong id({id})");

            return ClientsDatas[id];
        }

        internal int GetClientCount()
        {
            return ClientsDatas.Count;
        }
    }
}