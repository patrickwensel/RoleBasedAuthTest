using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication9.Data;
using WebApplication9.Interface;
using WebApplication9.Models;
using WebApplication9.ViewModel;

namespace WebApplication9.Repository
{
    public class MessageRepository : IMessage
    {
        private readonly Data.ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        public MessageRepository(Data.ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            this._db = db;
            _userManager = userManager;
        }
        public async Task<Guid> InsertMessage(Message message)
        {
            try
            {
                var messageDto = Mapping.Mapper.Map<MessageDto>(message);
                _db.Messages.Add(messageDto);
                await _db.SaveChangesAsync();
                var messageID = messageDto.MessageID;
                return messageID;
            }
            catch (Exception ex)
            {
                _ = string.Format("Error \n Error : {0} ", ex.ToString());
                //WriteLog(string.Format("Error while insert message in message table (MessageRepository(InsertMessage)) \n Error : {0} ", ex.ToString()));
                throw;
            }
        }
        public async Task<IList<Message>> GetMessagesByUserId(string id)
        {
            try
            {

                var messageList = new List<MessageDto>();
                messageList = await _db.Messages.AsNoTracking().Where(x => x.FromUserID == id || x.ToUserID == id).OrderByDescending(p => p.MessageDateTime).Select(p => new MessageDto
                {
                    MessageID = p.MessageID,
                    UserID = p.UserID,
                    FromUserID = p.FromUserID,
                    ToUserID = p.ToUserID,
                    MessageText = p.MessageText,
                    MessageDateTime = p.MessageDateTime,
                }).ToListAsync();

                var messages = Mapping.Mapper.Map<IList<Message>>(messageList);
                var userList = (_userManager.Users).ToList();
                if (userList.Count > 0)
                {
                    foreach (var item in messages)
                    {
                        var fromUser = userList.Where(x => x.Id == item.FromUserID).FirstOrDefault();
                        if (fromUser != null)
                        {
                            item.FromUserEmail = fromUser.Email;
                        }
                        var toUser = userList.Where(x => x.Id == item.ToUserID).FirstOrDefault();
                        if (toUser != null)
                        {
                            item.ToUserEmail = toUser.Email;
                        }
                    }
                }
                return messages;
            }
            catch (Exception ex)
            {
                _ = string.Format("Error \n Error : {0} ", ex.ToString());
                //WriteLog(string.Format("Error while get message from message table (MessageRepository(GetMessagesById)) \n Error : {0} ", ex.ToString()));
                throw;
            }
        }
    }
}
