namespace TestConsole.Experiments;

public class ValidParentheses
{
    // Given a string containing only ()[]{}, determine if it’s valid (properly opened/closed and nested).
    // Return true/false.

    // Examples: "()[]{}" → true, "(]" → false, "{[]}" → true.

    public bool Implementation(string s)
    {
        if (string.IsNullOrEmpty(s) || (s.Length % 2) != 0)
        {
            return false;
        }
        
        var validSet = new HashSet<char> { '(', ')', '[', ']', '{', '}' };
        var stack = new Stack<char>();

        foreach (var c in s)
        {
            if (!validSet.Contains(c))
            {
                return false;
            }

            switch (c)
            {
                // Push the expected closing bracket for each opener.
                case '(':
                    stack.Push(')');
                    break;
                case '[':
                    stack.Push(']');
                    break;
                case '{':
                    stack.Push('}');
                    break;
                default:
                {
                    // c is a closing bracket here.
                    if (stack.Count == 0 || stack.Pop() != c)
                    {
                        return false;
                    }

                    break;
                }
            }
        }

        return stack.Count == 0;
    }
}