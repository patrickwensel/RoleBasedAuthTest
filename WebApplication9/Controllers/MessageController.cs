using System.Web.Http;
using WebApplication9.Interface;

namespace WebApplication9.Controllers
{
    public class MessageController : ApiController
    {
        private readonly IMessage _message;
        public MessageController(IMessage message)
        {
            _message = message;
        }
    }
}
