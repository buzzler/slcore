namespace SLCore.Data
{
    public class ObserverData
    {
        public PublicData PublicData { get; private set; }

        internal ObserverData(PublicData publicData)
        {
            PublicData = publicData;
        }
    }
}