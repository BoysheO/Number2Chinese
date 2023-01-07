using System;
using System.Numerics;

namespace Number2Chinese
{
    /// <summary>
    /// 最大单位支持到亿，因为人民生活习惯的计数单位到亿为止,例如会人们通常使用八十万亿而不是八十兆。
    /// </summary>
    public static class Number2Chinese
    {
        public readonly static string LowercaseLetters = "零一二三四五六七八九";
        public readonly static string[] LowercaseUnitLetters = new string[]{
            "十",
            "百",
            "千",
            "万",
            "十万",
            "百万",
            "千万",
            "亿",
        };
        public readonly static string UppercaseLetters = "零壹贰叁肆伍陆柒捌玖";

        public string ToUppercaseString(long number)
        {

        }

        public string ToLowercaseString(long number)
        {

        }

        public string ToUppercaseString(int number)
        {

        }

        public string ToLowercaseString(int number)
        {

        }

        public string To(BigInteger bigInteger)
        {

        }

    }
}
