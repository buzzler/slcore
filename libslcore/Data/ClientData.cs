namespace SLCore.Data
{
    public class ClientData
    {
        public PublicData PublicData { get; private set; }
        public PrivateData PrivateData { get; private set; }

        internal ClientData(PublicData pubdata, PrivateData pridata)
        {
            PublicData = pubdata;
            PrivateData = pridata;
        }
    }
}