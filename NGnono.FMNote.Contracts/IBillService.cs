using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NGnono.FMNote.Contracts
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBillService
    {
        /// <summary>
        ///  添加
        /// </summary>
        /// <param name="model">Bill model</param>
        /// <returns></returns>
        dynamic Insert(dynamic model);
    }
}
