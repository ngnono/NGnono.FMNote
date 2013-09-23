using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NGnono.FMNote.Models.Enums
{
    public enum DataStatus
    {
        None = 0,
        /// <summary>
        /// 正常
        /// </summary>
        Normal = 1,


    }

    public enum BusinessStatus
    {
        None = 0
    }

    public enum ExtendedContentType
    {
        /// <summary>
        /// ,
        /// </summary>
        Default = 0,

        /// <summary>
        /// json
        /// </summary>
        Json = 1,

        /// <summary>
        /// xml
        /// </summary>
        Xml = 2,


    }

    public enum UserLevel
    {
        /// <summary>
        /// 未设定
        /// </summary>
        None = 0,

        /// <summary>
        /// 普通用户
        /// </summary>
        User = 1,

        /// <summary>
        /// 达人
        /// </summary>
        Daren = 2,
    }
}
