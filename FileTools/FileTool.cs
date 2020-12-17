using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace FileTools
{
    public class FileTool
    {
        private MD5 _MD5;

        public FileTool()
        {
            _MD5 = MD5.Create();
        }

        public string GetFileHash(string path)
        {
            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {                
                return BytesToString(_MD5.ComputeHash(Encoding.ASCII.GetBytes($"{BytesToString(_MD5.ComputeHash(stream))}_{Path.GetExtension(path).ToLower()}")));
            }
        }

        public bool AreEquals(string path1, string path2)
        {
            return (GetFileHash(path1) == GetFileHash(path2));
        }

        public void RenameFile(string path, string newName)
        {
            if (newName == null)
            {
                throw new ArgumentNullException("The argument newName can not be null");
            }

            File.Move(path, $"{Path.GetDirectoryName(path)}\\{newName}{Path.GetExtension(path)}");
        }

        public void RenameAllWithGuid(string path, string prefix)
        {
            if (prefix == null)
            {
                prefix = string.Empty;
            }

            var files = Directory.GetFiles(path);
            int i = 0;
            foreach (var file in files)
            {
                if (i % 10 == 0)
                {
                    Console.WriteLine($"{i} from {files.Length}");
                }
                ++i;
                File.Move(file, $"{path}\\{prefix}{Guid.NewGuid()}{Path.GetExtension(file)}");
            }
            Console.WriteLine($"{i} from {files.Length}");
        }

        public void RenameAll(string path, string prefix)
        {
            if (prefix == null)
            {
                prefix = string.Empty;
            }

            var files = Directory.GetFiles(path);

            if (files.Length > int.MaxValue)
            {
                throw new IndexOutOfRangeException($"This method suports only {int.MaxValue} files.");
            }

            int length = int.MaxValue.ToString().Length;
            int i = 0;

            foreach (var file in files)
            {
                if (i % 10 == 0)
                {
                    Console.WriteLine($"{i} from {files.Length}");
                }

                File.Move(file, $"{path}\\{prefix}{(++i).ToString().PadLeft(length, '0')}{Path.GetExtension(file)}");
            }
            Console.WriteLine($"{i} from {files.Length}");
        }

        public void MergeFolders(string folder1, string folder2, string destiny, string prefix)
        {

            var files1 = Directory.GetFiles(folder1);
            var files2 = Directory.GetFiles(folder2);
            Dictionary<string, string> dicFiles1 = new Dictionary<string, string>();
            Dictionary<string, string> dicFiles2 = new Dictionary<string, string>();
            int r = 0;
            Console.WriteLine($"Reading from {folder1}");
            foreach (string file in files1)
            {
                if (r % 10 == 0)
                {
                    Console.WriteLine($"{r} from {files1.Length}");
                }
                ++r;
                var hash = GetFileHash(file);
                if (!dicFiles1.ContainsKey(hash))
                {
                    dicFiles1.Add(hash, file);
                }
            }
            Console.WriteLine($"{r} from {files1.Length}");

            r = 0;
            Console.WriteLine($"Reading from {folder2}");
            foreach (string file in files2)
            {
                if (r % 10 == 0)
                {
                    Console.WriteLine($"{r} from {files2.Length}");
                }
                ++r;
                var hash = GetFileHash(file);
                if (!dicFiles2.ContainsKey(hash) && !dicFiles1.ContainsKey(hash))
                {
                    dicFiles2.Add(hash, file);
                }
            }
            Console.WriteLine($"{r} from {files2.Length}");

            var merged = MergeDictionary<string, string>(dicFiles1, dicFiles2);

            Directory.CreateDirectory(destiny);
            int length = int.MaxValue.ToString().Length;

            Console.WriteLine($"Copying to {destiny}");
            int i = 1;
            foreach (var item in merged)
            {
                if (i % 10 == 0)
                {
                    Console.WriteLine($"{i} from {merged.Count}");
                }
                File.Copy(item.Value, $"{destiny}\\{prefix}{i++.ToString().PadLeft(length, '0')}{Path.GetExtension(item.Value)}", true);
            }
            Console.WriteLine($"{i} from {merged.Count}");
        }

        public string[] FindDuplicated(string path)
        {
            List<string> result = new List<string>();
            var files1 = Directory.GetFiles(path);
            Dictionary<string, List<string>> dicFiles1 = new Dictionary<string, List<string>>();
            Console.WriteLine($"Reading from {path}");
            HashSet<string> duplicated = new HashSet<string>();
            foreach (string file in files1)
            {
                
                var hash = GetFileHash(file);
                if (!dicFiles1.ContainsKey(hash))
                {
                    dicFiles1.Add(hash, new List<string>() { file });
                }
                else
                {
                    if (!duplicated.Contains(hash))
                    {
                        duplicated.Add(hash);
                    }
                    dicFiles1[hash].Add(file);
                }
            }
            foreach (string hash in duplicated)
            {
                result.AddRange(dicFiles1[hash]);
            }
            if (result.Count > 0)
            {

                Console.WriteLine("Duplicated files");
                foreach (string r in result)
                {
                    Console.WriteLine(r);
                }
            }
            else
            {
                Console.WriteLine("Duplicated files not found");
            }

            return result.ToArray();
        }

        internal Dictionary<TKey,TValue> MergeDictionary<TKey, TValue>(Dictionary<TKey, TValue> dictionary1, Dictionary<TKey, TValue> dictionary2){
            Dictionary<TKey, TValue> result = null;
            if (dictionary1.Count > dictionary2.Count)
            {
                result = dictionary1;
                foreach (var item in dictionary2)
                {
                    if (!result.ContainsKey(item.Key))
                    {
                        result.Add(item.Key, item.Value);
                    }
                }
            }
            else
            {
                result = dictionary2;
                foreach (var item in dictionary1)
                {
                    if (!result.ContainsKey(item.Key))
                    {
                        result.Add(item.Key, item.Value);
                    }
                }
            }
            return result;
        }

        internal string BytesToString(byte[] bytes)
        {
            string result = string.Empty;
            foreach (byte b in bytes)
            {
                result += b.ToString("x2");
            }
            return result;
        }
    }
}
