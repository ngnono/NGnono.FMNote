using System;

namespace NGnono.FMNote.WebSupport.Models
{
    /// <summary>
    /// 网站用户
    /// </summary>
    [Serializable]
    public class WebSiteUser
    {
        public WebSiteUser()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WebSiteUser"/> class.
        /// </summary>
        /// <param name="loginName">
        /// The login name.
        /// </param>
        /// <param name="customerId">
        /// The customer id.
        /// </param>
        /// <param name="nickName">昵称</param>
        public WebSiteUser(string loginName, int customerId, string nickName)
        {
            this.LoginName = loginName;
            this.CustomerId = customerId;
            this.NickName = nickName;
        }

        /// <summary>
        /// Gets LoginName.
        /// </summary>
        public string LoginName { get; set; }

        /// <summary>
        /// Gets CustomerId.
        /// </summary>
        public int CustomerId { get; set; }

        public string NickName { get; set; }

        public string ShowName
        {
            get
            {
                return String.IsNullOrWhiteSpace(NickName) ? LoginName : NickName;
            }
            set { }
        }
    }
}
