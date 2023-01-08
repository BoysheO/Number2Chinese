namespace Number2ChineseTest;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    [TestCase(1,ExpectedResult = "一")]
    [TestCase(12,ExpectedResult = "十二")]
    [TestCase(23,ExpectedResult = "二十三")]
    [TestCase(123,ExpectedResult = "一百二十三")]
    public string TestIntToLowercaseString(int number)
    {
        return Number2Chinese.Number2Chinese.ToLowercaseString(number);
    }
}