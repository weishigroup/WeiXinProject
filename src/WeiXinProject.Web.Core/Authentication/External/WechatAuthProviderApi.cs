﻿using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Abp.UI;
using Newtonsoft.Json;
using WeiXinProject.Authentication.JwtBearer;
using WeiXinProject.Authorization;
using WeiXinProject.Authorization.Users;
using WeiXinProject.Models.WeChat;

namespace WeiXinProject.Authentication.External
{
    public class WechatAuthProviderApi:ExternalAuthProviderApiBase
    {


        ///  第三方登录名称需要与前端配置的一致


        ///  本地微信用户的服务。 这个需要自己添加。用于判断当前微信用户是否有权限
        {
            // 1. 获取企业微信ToKen
            WeChatToken weChatToken = await this.GetWechatToKen();
            // 2. 获取用户信息
            WeChatUserInfo weChatUserInfo = await this.GetWechatUserId(Code, weChatToken.access_token);
            // 3. 通过获取的的微信用户UserId并判断是否存在自己的服务器中。
            WXUser wXUser = await _wXUserManager.FindByUserId(weChatUserInfo.UserId);
                Surname = wXUser.AbpUser.Surname,
        {
            var Provider = _externalAuthConfiguration.Providers.FirstOrDefault(P => P.Name == ProviderName);
                var urlToken = $"https://qyapi.weixin.qq.com/cgi-bin/gettoken?corpid={appid}&corpsecret={secret}";
        {
            }
        }
    }
}