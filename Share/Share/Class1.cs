using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share
{
    public sealed class Class1
    {
        /// <summary> 
        /// Base64加密 
        /// </summary> 
        /// <param name="source">待加密的明文</param> 
        /// <returns></returns> 
        public static string EncodeBase64(string source)
        {
            byte[] bytes = System.Text.Encoding.Default.GetBytes(source);
            string encode;
            try
            {
                encode = Convert.ToBase64String(bytes);
            }
            catch
            {
                encode = source;
            }
            return encode;
        }

        /// <summary> 
        /// Base64解密 
        /// </summary> 
        /// <param name="result">待解密的密文</param> 
        /// <returns>解密后的字符串</returns> 
        public static string DecodeBase64(string result)
        {
            string decode = "";
            byte[] bytes = Convert.FromBase64String(result);
            try
            {
                decode = System.Text.Encoding.Default.GetString(bytes);
            }
            catch
            {
                decode = result;
            }
            return decode;
        }
    }
}
