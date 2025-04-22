using System;
using System.Collections.Generic;

namespace AXADIO.Interpreter
{
    internal class StringParser
    {
        public string Compile(string[] compileString)
        {
            Dictionary<string, string> variables = new Dictionary<string, string>();
            string finalString = "";

            foreach (string i in compileString)
            {
                string line = i.Trim();

                if (line.StartsWith("son"))
                {
                    // Masalan: son x = 5
                    string[] parts = line.Split(new[] { ' ', '=' }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length == 3)
                    {
                        string variableName = parts[1];
                        string value = parts[2];
                        variables[variableName] = value;
                        finalString += $"Son o'zgaruvchi: {variableName} = {value}\n";
                    }
                    else
                    {
                        finalString += $"Xato sintaksis: {line}\n";
                    }
                }
                else if (line.StartsWith("raqam"))
                {
                    // Masalan: raqam x = 5
                    string[] parts = line.Split(new[] { ' ', '=' }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length == 3)
                    {
                        string variableName = parts[1];
                        string value = parts[2];
                        variables[variableName] = value;
                        finalString += $"Raqam o'zgaruvchi: {variableName} = {value}\n";
                    }
                    else
                    {
                        finalString += $"Xato sintaksis: {line}\n";
                    }
                }
                else if (line.StartsWith("belgi"))
                {
                    // Masalan: belgi x = 'A'
                    string[] parts = line.Split(new[] { ' ', '=' }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length == 3)
                    {
                        string variableName = parts[1];
                        string value = parts[2].Trim('\''); // Belgilarni qavslaridan olib tashlash
                        variables[variableName] = value;
                        finalString += $"Belgi o'zgaruvchi: {variableName} = {value}\n";
                    }
                    else
                    {
                        finalString += $"Xato sintaksis: {line}\n";
                    }
                }
                else if (line.StartsWith("kasr"))
                {
                    // Masalan: kasr x = 5.25
                    string[] parts = line.Split(new[] { ' ', '=' }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length == 3)
                    {
                        string variableName = parts[1];
                        string value = parts[2];
                        variables[variableName] = value;
                        finalString += $"Kasr o'zgaruvchi: {variableName} = {value}\n";
                    }
                    else
                    {
                        finalString += $"Xato sintaksis: {line}\n";
                    }
                }
                else
                {
                    finalString += $"Aniqlanmagan buyruq: {line}\n";
                }
            }

            return finalString;
        }
    }
}
