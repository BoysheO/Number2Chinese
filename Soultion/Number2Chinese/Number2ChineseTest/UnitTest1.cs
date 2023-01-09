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
    public string TestIntToLowercaseString(ulong number)
    {
        return Number2Chinese.Number2Chinese.ToLowercaseReadingStringInChinese(number);
    }
}