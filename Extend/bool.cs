﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Voodoo
{
    public static class @bool
    {
        #region 将布尔类型的状态转换为“是”、“否”的字符串
        /// <summary>
        /// 将布尔类型的状态转换为“是”、“否”的字符串
        /// </summary>
        /// <param name="b">true或者false</param>
        /// <example>
        /// bool IsGood=false;<br/>
        /// string str_Good=IsGood.ToChinese();//结果为“否”
        ///  </example>
        public static string ToChinese(this bool b)
        {
            if (b)
            {
                return "<span style='color:green'>是</span>";
            }
            return "<span style='color:red'>否</span>";
        }
        #endregion

        public static string ToS(this bool b)
        {
            return b ? "1" : "0";
        }

        /// <summary>
        /// BOOL类型转换为short
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public static short BoolToShort(this bool b)
        {
            if (b)
            {
                return 1;
            }
            return 0;
        }

        public static int ToInt32(this bool b)
        {
            return b ? 1 : 2;
        }
    }
}
