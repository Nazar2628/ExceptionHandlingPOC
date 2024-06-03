using System;
using System.IO;

namespace ExceptionHandlingPOC
{
    // Custom exception
    public class CustomException : Exception
    {
        public CustomException(string message) : base(message) { }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Demonstrating different types of exception handling
            HandleDivideByZeroException();
            HandleNullReferenceException();
            HandleIndexOutOfRangeException();
            HandleFormatException();
            HandleCustomException();
            HandleMultipleExceptions();
            HandleFileNotFoundException();
            HandleInvalidOperationException();
            HandleOutOfMemoryException();
            HandleArgumentException();
            HandleArgumentNullException();
            HandleArgumentOutOfRangeException();
            HandleIOException();
            HandleUnauthorizedAccessException();

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        static void HandleDivideByZeroException()
        {
            try
            {
                int numerator = 10;
                int denominator = 0;
                int result = numerator / denominator;
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Caught a DivideByZeroException: {ex.Message}");
            }
        }

        static void HandleNullReferenceException()
        {
            string str = null;
            try
            {  
                int length = str.Length;
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine($"Caught a NullReferenceException: {ex.Message}");
            }
        }

        static void HandleIndexOutOfRangeException()
        {
            try
            {
                int[] numbers = { 1, 2, 3 };
                int number = numbers[5];
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"Caught an IndexOutOfRangeException: {ex.Message}");
            }
        }

        static void HandleFormatException()
        {
            try
            {
                string input = "abc";
                int number = int.Parse(input);
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Caught a FormatException: {ex.Message}");
            }
        }

        static void HandleCustomException()
        {
            try
            {
                throw new CustomException("This is a custom exception.");
            }
            catch (CustomException ex)
            {
                Console.WriteLine($"Caught a CustomException: {ex.Message}");
            }
        }

        static void HandleMultipleExceptions()
        {
            try
            {
                string input = null;
                int number = int.Parse(input); // This will throw a FormatException
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Caught a FormatException in multiple catch blocks: {ex.Message}");
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine($"Caught a NullReferenceException in multiple catch blocks: {ex.Message}");
            }
            catch (Exception ex) // General exception catch block
            {
                Console.WriteLine($"Caught a general Exception: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Finally block executed.");
            }
        }

        static void HandleFileNotFoundException()
        {
            try
            {
                string path = "nonexistentfile.txt";
                string content = File.ReadAllText(path);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Caught a FileNotFoundException: {ex.Message}");
            }
        }

        static void HandleInvalidOperationException()
        {
            try
            {
                var queue = new System.Collections.Queue();
                queue.Dequeue(); // This will throw InvalidOperationException because the queue is empty
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Caught an InvalidOperationException: {ex.Message}");
            }
        }

        static void HandleOutOfMemoryException()
        {
            try
            {
                // Deliberately causing an OutOfMemoryException is risky and impractical,
                // so this is a theoretical example.
                throw new OutOfMemoryException("Simulated OutOfMemoryException");
            }
            catch (OutOfMemoryException ex)
            {
                Console.WriteLine($"Caught an OutOfMemoryException: {ex.Message}");
            }
        }

        static void HandleArgumentException()
        {
            try
            {
                string invalidPath = "<invalid_path>";
                File.Open(invalidPath, FileMode.Open); // This will throw ArgumentException
            }
            catch (System.IO.IOException ex)
            {
                Console.WriteLine($"Caught an FileNotFoundException: {ex.Message}");
            }
        }

        static void HandleArgumentNullException()
        {
            try
            {
                string str = null;
                if (str == null)
                    throw new ArgumentNullException(nameof(str), "Argument cannot be null");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Caught an ArgumentNullException: {ex.Message}");
            }
        }

        static void HandleArgumentOutOfRangeException()
        {
            try
            {
                int[] array = new int[5];
                array[-1] = 10; // This will throw ArgumentOutOfRangeException
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"Caught an ArgumentOutOfRangeException: {ex.Message}");
            }
        }

        static void HandleIOException()
        {
            try
            {
                using (var stream = new FileStream("nonexistentfile.txt", FileMode.Open))
                {
                    // Attempt to read from a nonexistent file, will throw IOException
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Caught an IOException: {ex.Message}");
            }
        }

        static void HandleUnauthorizedAccessException()
        {
            try
            {
                string path = "/root/secretfile.txt";
                File.ReadAllText(path); // This will throw UnauthorizedAccessException on most systems
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine($"Caught an UnauthorizedAccessException: {ex.Message}");
            }
        }
    }
}
