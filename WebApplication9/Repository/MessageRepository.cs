using System;
using System.Threading.Tasks;
using WebApplication9.Interface;
using WebApplication9.ViewModel;

namespace WebApplication9.Repository
{
    public class MessageRepository : IMessage
    {
        private readonly Data.ApplicationDbContext _db;
        public MessageRepository(Data.ApplicationDbContext db)
        {
            this._db = db;
        }
        public async Task<Guid> InsertMessage(Message message)
        {
            try
            {
                var messageDto = Mapping.Mapper.Map<Data.MessageDto>(message);
                _db.Messages.Add(messageDto);
                await _db.SaveChangesAsync();
                var messageID = messageDto.MessageID;
                return messageID;
            }
            catch (Exception ex)
            {
                //WriteLog(string.Format("Error while insert message in message table (MessageRepository(InsertMessage)) \n Error : {0} ", ex.ToString()));
                throw;
            }
        }
    }
}
