using System;
using System.Buffers;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using BoysheO.Extensions;

namespace Number2Chinese
{
    /// <summary>
    /// 最大单位支持到极；目前只做了小写中文读数逻辑
    /// </summary>
    public static class Number2Chinese
    {
        // public static readonly string UppercaseLetters = "零壹贰叁肆伍陆柒捌玖";

        public static readonly string LowercaseLetters = "零一二三四五六七八九";

        public static readonly char[] LowercaseLittleUnitLetters =
        {
            '个',
            '十',
            '百',
            '千',
        };

        public static readonly string[] LowercaseBigUnitLetters =
        {
            "个",
            "万",
            "亿",
            "兆",
            "京",
            "垓",
            "秭",
            "穰",
            "沟",
            "涧",
            "正",
            "载",
            "极"
        };

        /// <summary>
        /// 按万进中国习惯，按需读零输出读数。
        /// </summary>
        public static string ToLowercaseReadingString(ulong number)
        {
            Span<char> buffer = stackalloc char[59];
            var bufferCount = ToLowercaseReadingStringAsBuff(number, buffer);
            unsafe
            {
                fixed (char* c = buffer.Slice(0, bufferCount))
                {
                    return new string(c);
                }
            }
        }

        /// <summary>
        /// 按万进中国习惯，按需读零输出读数。
        /// </summary>
        public static string ToLowercaseReadingString(long number)
        {
            bool isLess0 = number < 0;
            int buffCount;
            if (isLess0)
            {
                number = -number;
                buffCount = 60;
            }
            else
            {
                buffCount = 59;
            }

            Span<char> buffer = stackalloc char[buffCount];
            if (isLess0)
            {
                buffer[0] = '负';
            }

            var subBuffer = isLess0 ? buffer.Slice(1, 59) : buffer;
            var subBufferCount = ToLowercaseReadingStringAsBuff(unchecked((ulong)number), subBuffer);
            unsafe
            {
                fixed (char* c = buffer.Slice(0, subBufferCount + (isLess0 ? 1 : 0)))
                {
                    return new string(c);
                }
            }
        }

        /// <summary>
        /// 按万进中国习惯，按需读零输出读数。
        /// </summary>
        public static string ToLowercaseReadingString(int number)
        {
            return ToLowercaseReadingString((long)number);
        }

        /// <summary>
        /// 按万进中国习惯，按需读零输出读数。
        /// </summary>
        public static string ToLowercaseReadingString(uint number)
        {
            return ToLowercaseReadingString((ulong)number);
        }

        /// <summary>
        /// 按万进中国习惯，按需读零输出读数。
        /// </summary>
        private static int ToLowercaseReadingStringAsBuff(ulong number, Span<char> resultBuffer)
        {
            if (resultBuffer.Length != 59)
                throw new ArgumentOutOfRangeException(nameof(resultBuffer), "it's len must be 59");
            if (number < 10)
            {
                resultBuffer[0] = LowercaseLetters[(int)number];
                return 1;
            }

            #region 拆解数位

            Span<byte> digits = stackalloc byte[20]; //ulong型最大这么多位
            var digitsCount = 0;
            while (number > 0)
            {
                var div = number / 10;
                var mod = number - div * 10;
                digits[digitsCount] = unchecked((byte)mod);
                digitsCount++;
                number = div;
            }

            digits.Slice(0, digitsCount).Reverse();

            #endregion

            Span<char> chars = resultBuffer; //ulong型最多使用这么多字
            var charsCount = 0;
            var p = 0;
            bool is0LastDigit = false;
            while (p < digitsCount)
            {
                var unitOrder = digitsCount - p - 1;
                var digit = digits[p];

                //位数上是0时不读
                if (digit == 0)
                {
                    p++;
                    is0LastDigit = true;
                    continue;
                }

                if (is0LastDigit)
                {
                    chars[charsCount] = LowercaseLetters[0];
                    charsCount++;
                    is0LastDigit = false;
                }

                var littleUnitOrder = unitOrder % 4;
                //如果首位是一十则缩略成十
                if (p == 0 && digit == 1 && littleUnitOrder == 1)
                {
                }
                else
                {
                    var digitChar = LowercaseLetters[digit];
                    chars[charsCount] = digitChar;
                    charsCount++;
                }

                if (littleUnitOrder > 0)
                {
                    var unit = LowercaseLittleUnitLetters[littleUnitOrder];
                    chars[charsCount] = unit;
                    charsCount++;
                }

                //逢四得到一个大位
                if (unitOrder % 4 == 0)
                {
                    var order = unitOrder / 4;
                    //忽略个位
                    if (order > 0)
                    {
                        var bigUnit = LowercaseBigUnitLetters[order].AsSpan();
                        for (int i = 0, len = bigUnit.Length; i < len; i++)
                        {
                            chars[charsCount] = bigUnit[i];
                            charsCount++;
                        }
                    }
                }

                p++;
            }

            return charsCount;
        }
    }
}