using System;

internal class AllStringFunctions
{
    internal string userInput = "";
    internal AllStringFunctions()
    {
        Console.Write("Enter any string: ");

    userInputCheck:
        userInput = Console.ReadLine();

        if (userInput.Length == 0)
        {
            Console.Write("\n\nInvalid String value..!  Enter any string: ");
            goto userInputCheck;
        }
        // Convert to upperString and lowerString case
        string upperString = userInput.ToUpper();
        string lowerString = userInput.ToLower();

        Console.WriteLine("Original string: {0}", userInput);
        Console.WriteLine("Uppercase: {0}", upperString);
        Console.WriteLine("Lowercase: {0}", lowerString);

        // Remove whitespace and non-alphanumeric characters
        string cleaned = userInput.Replace(" ", "").Replace(".", "").Replace(",", "");
        Console.WriteLine("Cleaned string: {0}", cleaned);

        // Find index of a substring
        int index = userInput.IndexOf("desai");
        Console.WriteLine("Index of 'desai': {0}", index);

        //Concatination of a String 
        string concatingString = string.Concat("India");
        Console.WriteLine("userInput Concatinated with 'India' : {0}", userInput);

        // Check if string contains a substring
        bool contains = userInput.Contains("anand");
        Console.WriteLine("userInput Contains 'anand': {0}", contains);

        // Get substring
        string subString = userInput.Substring(0, 5);
        Console.WriteLine("userInput Substring (0, 5): {0}", subString);

        // Split into words
        string[] words = userInput.Split(' ');
        Console.WriteLine("userInput Split & Join Words: {0}", string.Join(", ", words));

        // Check string starting value
        Console.WriteLine("userInput StartsWith 'a': {0}", userInput.StartsWith("a"));

        // Check string ending value
        Console.WriteLine("userInput EndsWith 'a': {0}", userInput.EndsWith("a"));

        // Reverse the string
        char[] chars = userInput.ToCharArray();
        Array.Reverse(chars);
        string reversed = new string(chars);
        Console.WriteLine(" userInput Reversed: {0}", reversed);

        // Convert to char array and back to string
        char[] charArray = userInput.ToCharArray();
        string fromCharArray = new string(charArray);
        Console.WriteLine("From char array: {0}", fromCharArray);

        // Trim whitespace in string value
        string trimmedString = userInput.Trim();
        Console.WriteLine("Trimmed: {0}", trimmedString);

        // Pad left and right with spaces
        string leftPaddedString = userInput.PadLeft(20);
        Console.WriteLine("Left padded: '{0}'", leftPaddedString);
        string rightPaddedString = userInput.PadRight(20);
        Console.WriteLine("Right padded: '{0}'", rightPaddedString);

        // Replace a substring
        string replacedSubString = userInput.Replace(userInput[0],'O');
        Console.WriteLine("Replaced Sub String: {0}", replacedSubString);

        Console.ReadLine();
    }
}
