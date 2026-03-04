using TestConsole.Experiments;

namespace AlgorithmsTests.Experiments;

public class ValidParenthesesTests
{
    public static TheoryData<string, bool> TestCases =>
        new()
        {
            // Valid
            { "()", true },
            { "[]", true },
            { "{}", true },
            { "()[]{}", true },
            { "{[]}", true },
            { "([{}])", true },
            { "((()))", true },
            { "([]{})", true },
            { "{[()()]}", true },
            { "{[()()]}[]", true },
            { "(([]){})", true },

            // Invalid
            { "", false },
            { "(]", false },
            { "([)]", false },
            { "(", false },
            { ")", false },
            { "[", false },
            { "]", false },
            { "{", false },
            { "}", false },
            { "(()", false },
            { "(((", false },
            { "())", false },
            { ")))", false },
            { "][", false },
            { "}{", false },
            { ")(", false },
            { "[(])", false },
            { "{[(])}", false },
            { "{[]}}", false },
            { "(([]){)}", false },
            { "((", false },
            { "([]", false },
        };

    [Theory]
    [MemberData(nameof(TestCases))]
    public void Implementation_ReturnsExpectedMaxRunLength(string s, bool expected)
    {
        // Arrange
        var sut = new ValidParentheses();

        // Act
        var result = sut.Implementation(s);

        // Assert
        Assert.Equal(expected, result);
    }
}