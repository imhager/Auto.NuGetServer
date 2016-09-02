/*********************************************************
 * Copyright(c) 2012-2016
 * Author:wangzhonghai
 * clrversion:4.0.30319.42000
 * description：
 *       1、
 * history：
 *       1、wangzhonghai - 2016/9/2 13:07:37 - Add 
 * *******************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Auto.NuGetServer.Test.Component
{
    public static class IpHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetIP()
        {
            //如果客户端使用了代理服务器，则利用X_FORWARDED_FOR找到客户端IP地址
            string userHostAddress = "";
            if (HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null)
            {
                //client,proxy1,proxy2...
                userHostAddress = HttpContext.Current.Request.Headers["X-Forwarded-For"];
                if (!string.IsNullOrWhiteSpace(userHostAddress))
                {
                    userHostAddress = userHostAddress.Split(',')[0].Trim();
                }
            }

            //否则直接读取REMOTE_ADDR获取客户端IP地址
            if (string.IsNullOrEmpty(userHostAddress))
            {
                userHostAddress = HttpContext.Current.Request.Headers["X-Real-IP"];//等同于 REMOTE_ADDR

                //userHostAddress += HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            //前两者均失败，则利用Request.UserHostAddress属性获取IP地址，但此时无法确定该IP是客户端IP还是代理IP
            if (string.IsNullOrEmpty(userHostAddress))
            {
                userHostAddress = HttpContext.Current.Request.UserHostAddress;
            }

            //判定是否是有效IP，防止客户端恶意攻击
            if (!string.IsNullOrEmpty(userHostAddress) && IsValideIp(userHostAddress))
            {
                return userHostAddress;
            }

            return "0.0.0.1";
        }

        /// <summary>
        /// 检查IP地址格式
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsValideIp(string ip)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }
    }
}
