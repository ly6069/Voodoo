﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
namespace Voodoo
{
    public static class myRegex
    {
        #region 在字符串中查找匹配的字符串
        /// <summary>
        /// 在字符串中查找匹配的字符串，如在“<div id="wea">北京:晴转多云 1-17℃</div>”中查找"晴转多云 1-17℃".
        /// </summary>
        /// <param name="str">要查找的字符串，如：“<div id="wea">北京:晴转多云 1-17℃</div>”</param>
        /// <param name="startString">要查找数据之前的字符串，如：（<div id="wea">北京:）</param>
        /// <param name="endString">要查找数据之后的字符串，如：（</div>）</param>
        /// <returns></returns>
        public static string FindText(this string str, string startString, string endString)
        {
            string regex = startString + "(?<key>.*?)" + endString;
            Regex r = new Regex(regex, RegexOptions.Singleline);
            Match mc = r.Match(str);
            return mc.Groups["key"].Value;
        }
        #endregion
    }
}