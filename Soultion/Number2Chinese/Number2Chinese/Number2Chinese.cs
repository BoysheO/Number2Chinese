using System;
using System.Buffers;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using BoysheO.Extensions;

namespace Number2Chinese
{
    /// <summary>
    /// 最大单位支持到亿，因为人民生活习惯的计数单位到亿为止,例如会人们通常使用八十万亿而不是八十兆。
    /// </summary>
    public static class Number2Chinese
    {
        public static readonly string LowercaseLetters = "零一二三四五六七八九";

        public static readonly string[] LowercaseUnitLetters =
        {
            "十",
            "百",
            "千",
            "万",
            "十万",
            "百万",
            "千万",
            "亿",
        };

        // public static ReadOnlySpan<char> GetLowercaseUnit(int unitOrder)
        // {
        //     if(unitOrder==0)return Span<char>.Empty;
        //     if (unitOrder < LowercaseUnitLetters.Length) return LowercaseUnitLetters[unitOrder].AsSpan();
        //     
        // }

        // public static readonly string UppercaseLetters = "零壹贰叁肆伍陆柒捌玖";

        public static string ToLowercaseString(int number)
        {
            bool isLessThan0 = number < 0;
            if (isLessThan0)
            {
                number = -number;
            }

            Span<char> chars = stackalloc char[10];
            var charCount = 0;
            while (number > 0)
            {
                var div = Math.DivRem(number, 10, out var mode);
                chars[charCount] = LowercaseLetters[mode];
                charCount++;
                number = div;
            }
            //运行至此，chars里面按逆序放置着数字对应汉字
            
            // Span<char> chars2 = stackalloc char[20];
            // var chars2Count = 0;
            // for (int i = 0; i < charCount; i++)
            // {
            //     var c = chars[i];
            //     chars2[chars2Count] = c;
            //     chars2Count++;
            //     var unit = LowercaseUnitLetters[i].AsSpan();
            //     for (int j = unit.Length; j >= 0; j++)
            //     {
            //         chars2[chars2Count] = unit[j];
            //         chars2Count++;
            //     }
            // }

            unsafe
            {
                fixed (char* c = chars)
                {
                    return new string(c);
                }
            }
        }
    }
}