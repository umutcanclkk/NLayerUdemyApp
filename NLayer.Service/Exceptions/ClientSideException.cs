namespace NLayer.Service.Exceptions
{
    public class ClientSideException:Exception
    {
        public ClientSideException(string message) : base(message)
        {
        }

        public ClientSideException(string message, object not) :base(message)
        { 
        
        
        }

    }
}
