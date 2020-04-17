using System;
using System.Threading.Tasks;
using Abp.Application.Services;

namespace WeiXinProject.WxSdk.Test
{
    public class TestService:ITestInterface,IApplicationService
    {
        public TestService()
        {
        }

        public Task SendMessage()
        {
            throw new NotImplementedException();
        }
    }
}
