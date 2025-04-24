using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace AXADIO.Interpreter
{
    public class InterpreterObject
    {
        public string Compile(string[] compileString)
        {
            Dictionary<string, string> variables = new Dictionary<string, string>();
            string finalString = "";

            foreach (string rawLine in compileString)
            {
                string line = rawLine.Trim();

                if (string.IsNullOrWhiteSpace(line))
                    continue;

                if (!line.EndsWith("."))
                {
                    finalString += $"Xatolik: Qator nuqta bilan tugashi kerak → \"{line}\"\n";
                    continue;
                }

                // Oxirgi nuqtani olib tashlab, analiz qilamiz
                line = line.Substring(0, line.Length - 1).Trim();

                if (line.StartsWith("son"))
                {
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
                        finalString += $"Xato sintaksis (son): {rawLine}\n";
                    }
                }
                else if (line.StartsWith("raqam"))
                {
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
                        finalString += $"Xato sintaksis (raqam): {rawLine}\n";
                    }
                }
                else if (line.StartsWith("belgi"))
                {
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
                        finalString += $"Xato sintaksis (belgi): {rawLine}\n";
                    }
                }
                else if (line.StartsWith("kasr"))
                {
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
                        finalString += $"Xato sintaksis (kasr): {rawLine}\n";
                    }
                }
                else
                {
                    finalString += $"Aniqlanmagan buyruq: {rawLine}\n";
                }
            }

            return finalString;
        }
    }

    public class ExpectingCode
    {
        public bool EveryThingIsClear { get; private set; }
        public List<string> Errors { get; private set; }

        public ExpectingCode()
        {
            Errors = new List<string>();
        }

        public void CheckCode(string[] lines)
        {
            EveryThingIsClear = true;
            Errors.Clear();

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i].Trim();

                if (string.IsNullOrWhiteSpace(line))
                    continue;

                if (!line.EndsWith("."))
                {
                    EveryThingIsClear = false;
                    Errors.Add($"Xatolik {i + 1}-qator: Nuqta bilan tugashi lozim → \"{line}\"");
                }
            }
        }

    }
}
