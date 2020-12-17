using System;
using System.Diagnostics;

namespace FileTools
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            FileTool fileTool = new FileTool();
            try
            {
                Operations(args, fileTool);
                Console.WriteLine("Operation has been completed successfully");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                stopwatch.Stop();
                Console.WriteLine($"Elapsed time: {stopwatch.Elapsed}");
            }

            static void Operations(string[] args, FileTool fileTool)
            {
                if (args.Length > 0)
                {
                    switch (args[0])
                    {
                        case "rf":
                        case nameof(fileTool.RenameFile):
                                fileTool.RenameFile(args[1], args[2]);
                            break;
                        case "ra":
                        case nameof(fileTool.RenameAll):
                                fileTool.RenameAll(args[1], args[2]);
                            break;
                        case "rg":
                        case nameof(fileTool.RenameAllWithGuid):
                                fileTool.RenameAllWithGuid(args[1], args[2]);
                            break;
                        case "e":
                        case nameof(fileTool.AreEquals):
                                Console.WriteLine(fileTool.AreEquals(args[1], args[2]));
                            break;
                        case "h":
                        case nameof(fileTool.GetFileHash):
                                Console.WriteLine(fileTool.GetFileHash(args[1]));
                            break;
                        case "mg":
                        case nameof(fileTool.MergeFolders):
                                fileTool.MergeFolders(args[1], args[2], args[3], args[4]);
                            break;
                        case "fd":
                        case nameof(fileTool.FindDuplicated):
                                fileTool.FindDuplicated(args[1]);
                            break;
                        default:
                            throw new ArgumentException($"'{args[0]}' was not recognized as a valid task");
                            break;
                    }
                }
            }
        }
    }
}
