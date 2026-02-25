Collection of algorithms divided by patterns with tests.

Each algorithm should contain reasoning why it is written in a certain way.

Repo for learning.

---

# How algorithms grow
Big-O describes how an algorithm’s time or memory usage grows as input size grows.

| Big-O          | Name         | Typical Meaning                    |
| -------------- | ------------ | ---------------------------------- |
| **O(1)**       | Constant     | Same time regardless of input size |
| **O(log n)**   | Logarithmic  | Grows very slowly                  |
| **O(n)**       | Linear       | Grows proportional to input        |
| **O(n log n)** | Linearithmic | Common in efficient sorts          |
| **O(n²)**      | Quadratic    | Nested loops                       |
| **O(2ⁿ)**      | Exponential  | Very slow (brute force)            |

Additional notations:

| Notation          | Question it answers                          |
| ----------------- | -------------------------------------------- |
| **Big-O**         | “How slow can this algorithm be _at worst_?” |
| **Big-Ω (Omega)** | “How fast can this algorithm be _at best_?”  |
| **Big-Θ (Theta)** | “What is the _tight, exact_ growth rate?”    |
Big-O ignores constants and lower-order terms.
In real code, constants, memory allocations, and early exits can still matter.

## Complexity
- Time: How long does it take to run
- Space: How much extra memory does it use
### ⏱️ Time Complexity
**Time complexity** describes how the **running time grows** as the input size grows.
> “If the input gets bigger, how many more operations does my algorithm perform?”

 Example intuition
- Checking every pair in a list → slow growth
- Scanning once through a list → fast growth
#### 💾 Space Complexity
**Space complexity** describes how much **additional memory** your algorithm uses **beyond the input itself**.
> “As the input grows, how much extra memory does my algorithm need?”

Important:
- Input itself **does not count**
- Only **extra allocations** count
---

## Big-O Notations/Complexity Classes
###  O(1) — Constant Time
Time does not depend on input size.

Example: Array index access
```csharp
int GetFirst(int[] numbers)
{
    return numbers[0];
}
```

Whether the array has 10 or 10 million elements → same time
Dictionary lookup is average O(1)

Dictionary example
```csharp
var dict = new Dictionary<int, string>();
dict[42] = "Answer";
string value = dict[42]; // O(1) average
```

### O(log n) — Logarithmic Time
Each step cuts the problem in half.

Example: Binary search
```csharp
int BinarySearch(int[] sorted, int target)
{
    int left = 0;
    int right = sorted.Length - 1;

    while (left <= right)
    {
        int mid = (left + right) / 2;

        if (sorted[mid] == target)
            return mid;

        if (sorted[mid] < target)
            left = mid + 1;
        else
            right = mid - 1;
    }
    return -1;
}
```

Input size:
1,000 → ~10 steps
1,000,000 → ~20 steps
That’s why logarithmic algorithms scale extremely well.

### O(n) — Linear Time
Time grows directly with input size.

Example: Loop through a list
```csharp
int Sum(int[] numbers)
{
    int total = 0;
    foreach (var n in numbers)
    {
        total += n;
    }
    return total;
}
```

If the array doubles → work doubles.

### O(n log n) — Linearithmic Time
Very common in efficient sorting algorithms.

Example: Sorting
```csharp
var list = new List<int> { 5, 3, 8, 1 };
list.Sort(); // O(n log n)
```

Why?
List.Sort uses introspective sort
Combines quicksort, heapsort, insertion sort

Rule of thumb:
If an algorithm processes every element and does a logarithmic operation per element → O(n log n)

### O(n²) — Quadratic Time
Usually caused by nested loops.

Example: Comparing every pair
```csharp
void PrintAllPairs(int[] numbers)
{
    for (int i = 0; i < numbers.Length; i++)
    {
        for (int j = 0; j < numbers.Length; j++)
        {
            Console.WriteLine($"{numbers[i]}, {numbers[j]}");
        }
    }
}
```

If n = 1,000:
1,000,000 iterations 
Quadratic algorithms become slow very quickly.

### O(2ⁿ) — Exponential Time
Each input element doubles the work.

Example: Recursive Fibonacci (naive)
```csharp
int Fib(int n)
{
    if (n <= 1) return n;
    return Fib(n - 1) + Fib(n - 2);
}
```

Fib(40) already takes noticeable time

This is why memoization or DP is critical

---

## Big-O of Common C# Collections

| Collection                | Operation            | Big-O      |
| ------------------------- | -------------------- | ---------- |
| `List<T>`                 | Index access         | O(1)       |
| `List<T>`                 | Insert/remove middle | O(n)       |
| `Dictionary<TKey,TValue>` | Lookup               | O(1) avg   |
| `HashSet<T>`              | Contains             | O(1) avg   |
| `Queue<T>`                | Enqueue/Dequeue      | O(1)       |
| `Array.Sort`              | Sort                 | O(n log n) |

---

## Visual graphs for Big-O notation

<p>
  <img src="Images/Pasted%20image%2020251227195701.png" width="400" />
</p>
<p>
  <img src="Images/Pasted%20image%2020251227195720.png" width="400" />
</p>
<p>
  <img src="Images/Pasted%20image%2020251227195733.png" width="400" />
</p>
<p>
  <img src="Images/Pasted%20image%2020251227195741.png" width="400" />
</p>
<p>
  <img src="Images/Pasted%20image%2020251227195801.png" width="400" />
</p>
<p>
  <img src="Images/Pasted%20image%2020251227195806.png" width="400" />
</p>
