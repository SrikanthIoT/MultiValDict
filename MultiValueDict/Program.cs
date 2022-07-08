using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        Dictionary<string, List<string>> data = new Dictionary<string, List<string>>();
        while (true)
        {
            Console.Write(">");
            string input = Console.ReadLine();
            string[] commands = input.Split(" ");
            if(commands?.Any()??false)
            {
                switch(commands[0].ToLower())
                {
                    case "add":
                        if(commands.Length>=3 && !string.IsNullOrWhiteSpace(commands[1]) && !string.IsNullOrWhiteSpace(commands[2]))
                        {
                            if (data.ContainsKey(commands[1]))
                            {
                                if (data[commands[1]].Contains(commands[2]))
                                {
                                    Console.WriteLine(") ERROR, member already exists for key");
                                }
                                else
                                {
                                    data[commands[1]].Add(commands[2]);
                                    Console.WriteLine(") Added");
                                }
                            }
                            else
                            {
                                data.Add(commands[1], new List<string> { commands[2] });
                                Console.WriteLine(") Added");
                            }
                           
                        }
                        else
                        {
                            Console.WriteLine(") ERROR, key is required.");
                        }
                        break;
                    case "keys":
                        if(data.Keys?.Any()??false)
                        {
                            int i = 0;
                            data.Keys.ToList().ForEach(k =>
                            {
                                i++;
                                Console.WriteLine($"{i}) {k}");
                            });
                        }
                        else
                        {
                            Console.WriteLine(") (empty set).");
                        }
                        break;
                    case "members":
                        if (commands.Length>=2 && !string.IsNullOrWhiteSpace(commands[1]))
                        {
                            if (data.ContainsKey(commands[1]))
                            {
                                if(data[commands[1]]?.Any()??false)
                                {
                                    int i = 0;
                                    data[commands[1]]?.ForEach(d =>
                                    {
                                        i++;
                                        Console.WriteLine($"{i}) {d}");
                                    });
                                }
                                else
                                {
                                    Console.WriteLine(") (empty set).");
                                }
                               
                            }
                            else
                            {
                                Console.WriteLine(") ERROR, key does not exist.");
                            }
                        }
                        else
                        {
                            Console.WriteLine(") ERROR. Key is required.");
                        }
                        break;
                    case "remove":
                        if (commands.Length >= 3 && !string.IsNullOrWhiteSpace(commands[1]) && !string.IsNullOrWhiteSpace(commands[2]))
                        {
                            if (data.ContainsKey(commands[1]))
                            {
                                if (data[commands[1]]?.Any(x => x == commands[2]) ?? false)
                                {
                                    data[commands[1]].Remove(commands[2]);
                                    if (data[commands[1]]==null ||  data[commands[1]].Any()==false)
                                    {
                                        data.Remove(commands[1]);
                                    }
                                    Console.WriteLine(") Removed");
                                }
                                else
                                {
                                    Console.WriteLine(") ERROR, member does not exist");
                                }

                            }
                            else
                            {
                                Console.WriteLine(") ERROR, key does not exist.");
                            }
                        }
                        else
                        {
                            Console.WriteLine(") ERROR. Key and member are required.");
                        }
                        break;
                    case "removeall":
                        if (commands.Length >= 2 && !string.IsNullOrWhiteSpace(commands[1]))
                        {
                            if (data.ContainsKey(commands[1]))
                            {
                                data.Remove(commands[1]);
                                Console.WriteLine(") Removed");                               
                            }
                            else
                            {
                                Console.WriteLine(") ERROR, key does not exist.");
                            }
                        }
                        else
                        {
                            Console.WriteLine(") ERROR. Key is required.");
                        }
                        break;
                    case "clear":
                        data.Clear();
                        Console.WriteLine(") Cleared");
                        break;
                    case "keyexists":
                        if (commands.Length >= 2 && !string.IsNullOrWhiteSpace(commands[1]))
                        {
                            Console.WriteLine($") {data?.ContainsKey(commands[1]) ?? false}");
                        }
                        else
                        {
                            Console.WriteLine(") ERROR. Key is required.");
                        }
                        break;
                    case "memberexists":
                        if (commands.Length >= 3 && !string.IsNullOrWhiteSpace(commands[1]) && !string.IsNullOrWhiteSpace(commands[2]))
                        {
                            bool isExist = false;
                            if (data.ContainsKey(commands[1]))
                            {
                                if (data[commands[1]]?.Any(x => x == commands[2]) ?? false)
                                {
                                    isExist = true;
                                }
                            }
                            Console.WriteLine($") {isExist}.");
                        }
                        else
                        {
                            Console.WriteLine(") ERROR. Key and member both are required.");
                        }
                        break;
                    case "allmembers":
                        if(data?.Any()??false)
                        {
                            int i = 0;
                            foreach(var kv in data)
                            {
                                if(kv.Value?.Any()??false)
                                {
                                    kv.Value.ForEach(v =>
                                    {
                                        i++;
                                        Console.WriteLine($"{i}) {v}");
                                    });
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine(") (empty set).");
                        }
                        break;
                    case "items":
                        if (data?.Any() ?? false)
                        {
                            int i = 0;
                            foreach (var kv in data)
                            {
                                if (kv.Value?.Any() ?? false)
                                {
                                    kv.Value.ForEach(v =>
                                    {
                                        i++;
                                        Console.WriteLine($"{i}) {kv.Key}: {v}");
                                    });
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine(") (empty set).");
                        }
                        break;
                }
            }
            else
            {
                Console.WriteLine(") Invalid command");
            }
           
        }
    }
}