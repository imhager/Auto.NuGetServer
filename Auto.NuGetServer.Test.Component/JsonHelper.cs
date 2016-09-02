/*********************************************************
 * Copyright(c) 2012-2016
 * Author:wangzhonghai
 * clrversion:4.0.30319.42000
 * description：
 *       1、
 * history：
 *       1、wangzhonghai - 2016/9/2 13:06:41 - Add 
 * *******************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Auto.NuGetServer.Test.Component
{
    /// <summary>
    /// json序列化、反序列化帮助类，dependency newtonsoft
    /// </summary>
    public static class JsonHelper
    {
        /// <summary>
        /// entity 2 json
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static string ToJson<T>(T model)
        {
            return JsonConvert.SerializeObject(model);
        }

        /// <summary>
        /// json 2 Entity
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T FromJson<T>(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch
            {
                throw new ArgumentException(string.Format("json转化到 {0} 实体出错，json值详细：{1}", typeof(T).Name, json));
            }
        }

        /// <summary>
        /// Json 2 Entity with anonymousType
        /// </summary>
        /// <param name="value"></param>
        /// <param name="anonymousTypeObject"></param>
        /// <returns></returns>
        public static T FromJson<T>(string value, T anonymousTypeObject)
        {
            return JsonConvert.DeserializeAnonymousType<T>(value, anonymousTypeObject);
        }

        #region JSON 格式扩展

        /// <summary>
        /// JsonEncode
        /// </summary>
        /// <param name="value">字符替换对象</param>
        /// <returns>返回替换后的字符串</returns>
        public static string JsonEncode(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return value;
            }

            value = value.Replace("\\", "\\\\");
            value = value.Replace("\"", "\\\"");
            value = value.Replace("/", "\\/");
            value = value.Replace("\b", "\\b");
            value = value.Replace("\f", "\\f");
            value = value.Replace("\n", "\\n");
            value = value.Replace("\r", "\\r");
            value = value.Replace("\t", "\\t");

            return value;
        }

        #endregion
    }
}
