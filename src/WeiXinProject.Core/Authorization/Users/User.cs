using System;
using System.Collections.Generic;
using Abp.Authorization.Users;
using Abp.Extensions;

namespace WeiXinProject.Authorization.Users
{
    public class User : AbpUser<User>
    {
        public const string DefaultPassword = "123qwe";

        public static string CreateRandomPassword()
        {
            return Guid.NewGuid().ToString("N").Truncate(16);
        }

        public static User CreateTenantAdminUser(int tenantId, string emailAddress)
        {
            var user = new User
            {
                TenantId = tenantId,
                UserName = AdminUserName,
                Name = AdminUserName,
                Surname = AdminUserName,
                EmailAddress = emailAddress,
                Roles = new List<UserRole>()
            };

            user.SetNormalizedNames();

            return user;
        }
        ///<Summary>
        /// GroupID 分组：机构型,客户型
        ///</Summary>
        [Display(Name = "分组：机构型,客户型")]
        public int GroupID { get; set; }

        ///<Summary>
        /// Avatar 头像
        ///</Summary>
        [Display(Name = "头像")]
        public string Avatar { get; set; }

        ///<Summary>
        /// Sex 性别
        ///</Summary>
        [Display(Name = "性别")]
        public int Sex { get; set; }

        ///<Summary>
        /// Birthday 生日
        ///</Summary>
        [Display(Name = "生日")]
        public DateTime Birthday { get; set; }

        ///<Summary>
        /// Province 省
        ///</Summary>
        [Display(Name = "省")]
        public string Province { get; set; }

        ///<Summary>
        /// City 市
        ///</Summary>
        [Display(Name = "市")]
        public string City { get; set; }

        ///<Summary>
        /// County 县
        ///</Summary>
        [Display(Name = "县")]
        public string County { get; set; }

        ///<Summary>
        /// Address 联系地址
        ///</Summary>
        [Display(Name = "联系地址")]
        public string Address { get; set; }

        ///<Summary>
        /// QQ QQ
        ///</Summary>
        [Display(Name = "QQ")]
        public string QQ { get; set; }

        ///<Summary>
        /// WeChat 微信
        ///</Summary>
        [Display(Name = "微信")]
        public string WeChat { get; set; }

        ///<Summary>
        /// DingTalk 钉钉
        ///</Summary>
        [Display(Name = "钉钉")]
        public string DingTalk { get; set; }

        ///<Summary>
        /// Skype Skype
        ///</Summary>
        [Display(Name = "Skype")]
        public string Skype { get; set; }

        ///<Summary>
        /// WhatsApp WhatsApp
        ///</Summary>
        [Display(Name = "WhatsApp")]
        public string WhatsApp { get; set; }

        ///<Summary>
        /// Memo Memo
        ///</Summary>
        [Display(Name = "Memo")]
        public string Memo { get; set; }
    }
}
}
