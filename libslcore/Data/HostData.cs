using System;
using System.Collections.Generic;

namespace SLCore.Data
{
    public class HostData
    {
        public int Leader { get; private set; }
        public int Turn { get; private set; }
        public int TurnCount { get; private set; }
        public int TotalTurnCount { get; private set; }
        public PublicData PublicData { get; }
        public PrivateData PrivateData { get; }
        public List<PrivateData> ClientsDatas { get; }

        internal HostData(PublicData publicData, PrivateData privateData, List<PrivateData> clientsDatas)
        {
            Leader = -1;
            Turn = -1;
            TurnCount = 0;
            TotalTurnCount = 0;
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
        
        internal void SetLeader(int id)
        {
            Leader = id;
        }

        internal void SetTurn(int id)
        {
            Turn = id;
        }

        internal void SetTurnCount(int value)
        {
            TurnCount = value;
        }

        internal void SetTotalTurnCount(int value)
        {
            TotalTurnCount = value;
        }
    }
}