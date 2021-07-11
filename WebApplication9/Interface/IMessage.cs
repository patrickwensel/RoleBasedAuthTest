using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication9.ViewModel;

namespace WebApplication9.Interface
{
    public interface IMessage
    {
        Task<Guid> InsertMessage(Message message);
        Task<IList<Message>> GetMessagesByUserId(string id);
    }
}
