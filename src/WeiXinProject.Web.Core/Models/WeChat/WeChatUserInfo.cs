using System;
namespace WeiXinProject.Models.WeChat
{
    public class WeChatUserInfo
    {
        public int errcode { set; get; }
        public string errmsg { set; get; }
        public string UserId { set; get; }
        public string OpenId { set; get; }
        public string DeviceId { set; get; }
        
    }
}
