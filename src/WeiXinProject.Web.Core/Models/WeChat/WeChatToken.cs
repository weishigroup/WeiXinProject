using System;
namespace WeiXinProject.Models.WeChat
{
    public class WeChatToken
    {
        public int errcode { set; get; }
        public string errmsg { set; get; }
        public string access_token { set; get; }
        public int expires_in { set; get; }

    }
}
