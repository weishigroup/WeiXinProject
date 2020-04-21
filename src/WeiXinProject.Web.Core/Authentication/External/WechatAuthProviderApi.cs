using System;
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


        ///  第三方登录名称需要与前端配置的一致        public const string ProviderName = "EnterpriseWechat";        private readonly UserManager _userManager;


        ///  本地微信用户的服务。 这个需要自己添加。用于判断当前微信用户是否有权限        private readonly WXUserManager _wXUserManager;        private readonly LogInManager _logInManager;        private readonly TokenAuthConfiguration _configuration;        private readonly IExternalAuthConfiguration _externalAuthConfiguration;        public WechatAuthProviderApi(            UserManager _userManager,            WXUserManager _wXUserManager,            LogInManager _logInManager,            TokenAuthConfiguration _configuration,            IExternalAuthConfiguration _externalAuthConfiguration)
        {            this._userManager = _userManager;            this._wXUserManager = _wXUserManager;            this._logInManager = _logInManager;            this._configuration = _configuration;            this._externalAuthConfiguration = _externalAuthConfiguration;        }        public override async Task<ExternalAuthUserInfo> GetUserInfo(string Code)        {
            // 1. 获取企业微信ToKen
            WeChatToken weChatToken = await this.GetWechatToKen();
            // 2. 获取用户信息
            WeChatUserInfo weChatUserInfo = await this.GetWechatUserId(Code, weChatToken.access_token);
            // 3. 通过获取的的微信用户UserId并判断是否存在自己的服务器中。
            WXUser wXUser = await _wXUserManager.FindByUserId(weChatUserInfo.UserId);            var t = wXUser == null ? new ExternalAuthUserInfo() : new ExternalAuthUserInfo            {                EmailAddress = wXUser.Email,
                Surname = wXUser.AbpUser.Surname,                ProviderKey = weChatUserInfo.UserId,                Provider = ProviderName,                Name = wXUser.AbpUser.Name            };            return t;        }        public async Task<WeChatToken> GetWechatToKen()
        {
            var Provider = _externalAuthConfiguration.Providers.FirstOrDefault(P => P.Name == ProviderName);            var appid = Provider.ClientId;            var secret = Provider.ClientSecret;            try            {                var httpClient = new HttpClient();                httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1)");                httpClient.Timeout = TimeSpan.FromMinutes(3);
                var urlToken = $"https://qyapi.weixin.qq.com/cgi-bin/gettoken?corpid={appid}&corpsecret={secret}";                string ResultToken = await httpClient.GetStringAsync(urlToken);                WeChatToken wX_Token = JsonConvert.DeserializeObject<WeChatToken>(ResultToken);                return wX_Token;            }            catch (Exception ex)            {                throw new UserFriendlyException("获取微信access_token失败" + ex.Message);            }        }        public async Task<WeChatUserInfo> GetWechatUserId(string code, string token)
        {            try            {                var httpClient = new HttpClient();                httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1)");                httpClient.Timeout = TimeSpan.FromMinutes(3);                var urlGetUserInfo = $"https://qyapi.weixin.qq.com/cgi-bin/user/getuserinfo?access_token={token}&code={code}";                var ResultUserInfo = await httpClient.GetStringAsync(urlGetUserInfo);                WeChatUserInfo wXUserInfo = JsonConvert.DeserializeObject<WeChatUserInfo>(ResultUserInfo);                return wXUserInfo;            }            catch (Exception ex)            {                throw new UserFriendlyException("获取微信UserInfo失败" + ex.Message);
            }
        }
    }
}
