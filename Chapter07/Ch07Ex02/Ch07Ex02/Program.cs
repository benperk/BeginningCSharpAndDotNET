using System;

namespace Ch07Ex02
{
    class Program
    {
        static string[] eTypes = { "none", "simple", "index",
                                 "nested index", "filter" };
        static void Main(string[] args)
        {
            foreach (string eType in eTypes)
            {
                try
                {
                    Console.WriteLine("Main() try block reached.");        // Line 15
                    Console.WriteLine($"ThrowException(\"{eType}\") called.");
                    ThrowException(eType);
                    Console.WriteLine("Main() try block continues.");      // Line 18
                }
                catch (System.IndexOutOfRangeException e) when (eType == "filter")
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Main() FILTERED System.IndexOutOfRangeException" +
                                      $"catch block reached. Message:\n\"{e.Message}\"");
                    Console.ResetColor();
                }
                catch (System.IndexOutOfRangeException e)                 // Line 27
                {
                    Console.WriteLine("Main() System.IndexOutOfRangeException catch " +
                                      $"block reached. Message:\n\"{e.Message}\"");
                }
                catch                                                     // Line 32
                {
                    Console.WriteLine("Main() general catch block reached.");
                }
                finally
                {
                    Console.WriteLine("Main() finally block reached.");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
        static void ThrowException(string exceptionType)
        {
            Console.WriteLine($"ThrowException(\"{exceptionType}\") reached.");
            switch (exceptionType)
            {
                case "none":
                    Console.WriteLine("Not throwing an exception.");
                    break;                                               // Line 51
                case "simple":
                    Console.WriteLine("Throwing System.Exception.");
                    throw new System.Exception();                      // Line 54
                case "index":
                    Console.WriteLine("Throwing System.IndexOutOfRangeException.");
                    eTypes[5] = "error";                                 // Line 57
                    break;
                case "nested index":
                    try                                                  // Line 60
                    {
                        Console.WriteLine("ThrowException(\"nested index\") " +
                                          "try block reached.");
                        Console.WriteLine("ThrowException(\"index\") called.");
                        ThrowException("index");                          // Line 65
                    }
                    catch                                                // Line 67
                    {
                        Console.WriteLine("ThrowException(\"nested index\") general"
                                          + " catch block reached.");
                        throw;
                    }
                    finally
                    {
                        Console.WriteLine("ThrowException(\"nested index\") finally"
                                          + " block reached.");
                    }
                    break;
                case "filter":
                    try                                                  // Line 86
                    {
                        Console.WriteLine("ThrowException(\"filter\") " +
                                          "try block reached.");
                        Console.WriteLine("ThrowException(\"index\") called.");
                        ThrowException("index");                          // Line 91
                    }
                    catch                                                // Line 93
                    {
                        Console.WriteLine("ThrowException(\"filter\") general"
                                          + " catch block reached.");
                        throw;
                    }
                    break;
                }
            }
        }
    }
