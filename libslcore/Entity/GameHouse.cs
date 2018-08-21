using System.Collections.Generic;
using SLCore.Data;
using SLCore.Event;

namespace SLCore.Entity
{
    public class GameHouse
    {
        private GameHost Host { get; }
        private PublicData HostPublicData { get; }
        private PrivateData HostPrivateData { get; }
        private Dispatcher HostDispatcher { get; }
        private List<GameClient> Clients { get; }
        private List<PrivateData> ClientDatas { get; }
        private List<Dispatcher> ClientDispatchers { get; }
        private List<GameObserver> Observers { get; }

        public GameHouse()
        {
            HostPublicData = new PublicData();
            HostPrivateData = new PrivateData();
            HostDispatcher = new Dispatcher();
            ClientDatas = new List<PrivateData>(2);
            ClientDispatchers = new List<Dispatcher>(2);
            Host = new GameHost(new HostData(HostPublicData, HostPrivateData, ClientDatas),
                new HostDispatcher(HostDispatcher, ClientDispatchers));
            Clients = new List<GameClient>(2);
            Observers = new List<GameObserver>();
        }

        public void AddClient()
        {
            HostPublicData.ClientKnowns.Add(new Dictionary<int, CardInfo>());

            var data = new PrivateData();
            ClientDatas.Add(data);

            var dispatcher = new Dispatcher();
            ClientDispatchers.Add(dispatcher);

            var id = Clients.Count;
            Clients.Add(new GameClient(id, new ClientData(HostPublicData, data),
                new ClientDispatcher(HostDispatcher, dispatcher)));

            for (var i = 0; i < Clients.Count; i++)
                Clients[i].Id = i;
        }

        public void AddObserver()
        {
            var id = Observers.Count;
            Observers.Add(new GameObserver(id, HostDispatcher, new ObserverData(HostPublicData)));
        }

        public void Start()
        {
            Host.Start();
        }

        public void Loop()
        {
            Host.LoopState();
            foreach (var gameClient in Clients)
                gameClient.LoopState();
            foreach (var gameObserver in Observers)
                gameObserver.LoopState();
        }
    }
}