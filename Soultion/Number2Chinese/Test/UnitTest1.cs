namespace Number2ChineseTest;

public class Tests
{
    [Test]
    [TestCase((ulong)0, ExpectedResult = "零")]
    [TestCase((ulong)1, ExpectedResult = "一")]
    [TestCase((ulong)10, ExpectedResult = "十")]
    [TestCase((ulong)12, ExpectedResult = "十二")]
    [TestCase((ulong)23, ExpectedResult = "二十三")]
    [TestCase((ulong)1230000, ExpectedResult = "一百二十三万")]
    [TestCase((ulong)1230001, ExpectedResult = "一百二十三万零一")]
    [TestCase((ulong)1230012, ExpectedResult = "一百二十三万零一十二")]
    [TestCase((ulong)1002_3001_0012, ExpectedResult = "一千零二亿三千零一万零一十二")]
    [TestCase(ulong.MaxValue, ExpectedResult = "一千八百四十四京六千七百四十四兆零七百三十七亿零九百五十五万一千六百一十五")]
    [TestCase(9999999999999999999, ExpectedResult = "九百九十九京九千九百九十九兆九千九百九十九亿九千九百九十九万九千九百九十九")]
    public string TestIntToLowercaseStringULong(ulong number)
    {
        return Number2Chinese.Number2Chinese.ToLowercaseReadingString(number);
    }
    
    [Test]
    [TestCase(0, ExpectedResult = "零")]
    [TestCase(1, ExpectedResult = "一")]
    [TestCase(10, ExpectedResult = "十")]
    [TestCase(12, ExpectedResult = "十二")]
    [TestCase(23, ExpectedResult = "二十三")]
    [TestCase(1230000, ExpectedResult = "一百二十三万")]
    [TestCase(1230001, ExpectedResult = "一百二十三万零一")]
    [TestCase(1230012, ExpectedResult = "一百二十三万零一十二")]
    [TestCase(1002_3001_0012, ExpectedResult = "一千零二亿三千零一万零一十二")]
    [TestCase(-1002_3001_0012, ExpectedResult = "负一千零二亿三千零一万零一十二")]
    [TestCase(long.MaxValue, ExpectedResult = "九百二十二京三千三百七十二兆零三百六十八亿五千四百七十七万五千八百零七")]
    [TestCase(long.MinValue, ExpectedResult = "负九百二十二京三千三百七十二兆零三百六十八亿五千四百七十七万五千八百零八")]
    public string TestIntToLowercaseStringLong(long number)
    {
        return Number2Chinese.Number2Chinese.ToLowercaseReadingString(number);
    }
}