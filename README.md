# XirzoResult Library ✨

A lightweight library that provides a simple success/error result type, allowing you to handle outcomes in a clean and expressive way.


## Example Usage 🚀
Below is a quick demonstration of how you might use the Result type in your code (assuming you have the above library and the “Error” type set up):

```csharp
using XirzoResult;

class Program
{
static void Main()
{
        // Create a Result with a successful value
        Result<string> successfulResult = "Hello, Xirzo!";

        // Implicit cast to an error result
        Result<string> errorResult = new Error("Something went wrong.");

        // Use Match to handle the two cases
        successfulResult.Match(
            success => {
                Console.WriteLine($"✅ Success: {success}");
                return 0;
            },
            error => {
                Console.WriteLine($"❌ Error: {error.Message}");
                return -1;
            }
        );

        // Error example
        errorResult.Match(
            success => {
                Console.WriteLine($"✅ Success: {success}");
                return 0;
            },
            error => {
                Console.WriteLine($"❌ Error: {error.Message}");
                return -1;
            }
        );
    }
}
