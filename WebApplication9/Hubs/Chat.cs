using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication9.Interface;
using WebApplication9.Models;
using WebApplication9.ViewModel;

namespace WebApplication9.Hubs
{
    public class Chat : Hub
    {
        public static ConcurrentDictionary<string, string> dicUserInformation = new ConcurrentDictionary<string, string>();
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMessage _iMessage;
        public Chat(UserManager<ApplicationUser> userManager, IMessage iMessage)
        {
            _userManager = userManager;
            _iMessage = iMessage;
        }

        public async Task<string> SendIndividualMessage(string fromUser, string toUser, string message)
        {
            try
            {
                if (fromUser == "")
                    return "Error";

                //var MsgUniqueID = DateTime.UtcNow.Month + DateTime.UtcNow.Second + (DateTime.UtcNow.Year + 4) + DateTime.UtcNow.Millisecond + DateTime.UtcNow.Hour + DateTime.UtcNow.Day + DateTime.UtcNow.Minute + DateTime.UtcNow.Millisecond;

                Message objMessageModel = new Message()
                {
                    ToUserID = toUser,
                    MessageText = message,
                };
                string uId = GetUserId();
                if (!string.IsNullOrEmpty(uId))
                {
                    objMessageModel.UserID = uId;
                    objMessageModel.FromUserID = uId;
                }
                var toUserData = await _userManager.FindByIdAsync(toUser);
                await Clients.Caller.SendAsync("broadcastIndividualMessage", $"me To {toUserData.Email} : <b> {message} </b>");
                if (dicUserInformation.ContainsKey(toUser))
                {
                    var userEmail = "";
                    if (!string.IsNullOrEmpty(uId))
                    {
                        var fromUserData = await _userManager.FindByIdAsync(uId);
                        userEmail = fromUserData.Email;
                    }
                    await Clients.Client(dicUserInformation[toUser]).SendAsync("broadcastIndividualMessage", $"{userEmail} To me : <b> {message} </b>");
                }
                else
                {
                    //await Clients.Caller.SendAsync("offlineUserMessage", $"{toUserData.Email} is currently Offline.");
                }
                #region insert message in table 
                var MessageID = await _iMessage.InsertMessage(objMessageModel);
                #endregion

                return "SUCCESS";
            }
            catch (Exception ex)
            {
                _ = string.Format("Error \n Error : {0} ", ex.ToString());
                return "CatchError";
            }
        }

        private async void Notify(string UserID, string ConnectionID)
        {
            string msg = "";
            try
            {
                if (UserID == "")
                {
                    msg = string.Format("Call user online and automatic online (Chat:Hub - Notify) \n Message : 1.1 [UserID IS NULL ...]");
                }
                else
                {
                    var Result = dicUserInformation.FirstOrDefault(x => (x.Key == UserID) && x.Value == ConnectionID);
                    if (string.IsNullOrEmpty(Result.Key))
                    {
                        if (dicUserInformation.ContainsKey(UserID))
                        {
                            dicUserInformation.TryRemove(UserID, out string value);
                        }
                        dicUserInformation.TryAdd(UserID, ConnectionID);
                        //var messages = await _iMessage.GetMessagesById(Guid.Parse(UserID));
                        await Clients.All.SendAsync("UserConnected", ConnectionID);
                    }
                    else
                    {
                        msg = string.Format("Caller alredy exists (Chat:Hub - Notify) \n Message : 1.6 [Connection already exists - {0} ...]", UserID);
                    }
                }
            }
            catch (Exception ex)
            {
                msg = string.Format("Error while notify signalR client when connected or disconnected (Chat:Hub - Notify) \n Error : {0} ", ex.ToString());
            }
        }

        public override async Task OnConnectedAsync()
        {
            string uId = GetUserId();
            if (!string.IsNullOrEmpty(uId))
            {
                Notify(uId, Context.ConnectionId);
            }

            //await Clients.All.SendAsync("UserConnected", Context.ConnectionId);
            await base.OnConnectedAsync();
        }

        public string GetUserId()
        {
            var query = Context.GetHttpContext().Request.Query;
            if (query.Count > 0)
            {
                string uId = DecodeString(query["userId"].First());
                return uId;
            }
            return "";
        }
        private async void ClientDisconnect(string ConnectionID)
        {
            try
            {
                var Result = dicUserInformation.FirstOrDefault(x => x.Value == ConnectionID);
                dicUserInformation.TryRemove(Result.Key, out string value);
                await Clients.All.SendAsync("UserDisconnected", ConnectionID);
            }
            catch (Exception ex)
            {
                _ = string.Format("Error \n Error : {0} ", ex.ToString());
                //throw;
            }
        }

        public override async Task OnDisconnectedAsync(Exception ex)
        {
            ClientDisconnect(Context.ConnectionId.ToString());
            await base.OnDisconnectedAsync(ex);
        }
        public static string EncodeString(string strData) // EncodeString
        {
            try
            {
                byte[] encyrptedData = new byte[strData.Length];
                encyrptedData = Encoding.UTF8.GetBytes(strData);
                string encodeddata = Convert.ToBase64String(encyrptedData);
                return encodeddata;
            }
            catch (Exception ex)
            {
                _ = string.Format("Error \n Error : {0} ", ex.ToString());
                return strData;
            }
        }

        public static string DecodeString(string strData) //DecodeString
        {
            try
            {
                UTF8Encoding encoder = new UTF8Encoding();
                Decoder decode = encoder.GetDecoder();
                byte[] bytes = Convert.FromBase64String(strData);
                int count = decode.GetCharCount(bytes, 0, bytes.Length);
                char[] decodechar = new char[count];
                decode.GetChars(bytes, 0, bytes.Length, decodechar, 0);
                string result = new string(decodechar);
                return result;
            }
            catch (Exception ex)
            {
                _ = string.Format("Error \n Error : {0} ", ex.ToString());
                return strData;
            }
        }
    }

}
