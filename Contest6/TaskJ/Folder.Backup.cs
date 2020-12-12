using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

partial class Folder
{
    internal class Backup
    {
        private List<File> files;

        public Backup(Folder folder)
        {
            files = folder.files.ToList();
        }

        public static void Restore(Folder folder, Backup backup)
        {
            folder.files = backup.files.ToList();
        }
    }

    public void AddFile(string name, int size)
    {
        files.Add(new File(name, size));
    }

    public void RemoveFile(File file)
    {
        files.Remove(file);
    }

    public File this[int i] =>
        i >= 0 && i < files.Count
            ? files[i]
            : throw new IndexOutOfRangeException("Not enough files or index less zero");

    public File this[string filename] => files.SingleOrDefault(f => f.Name == filename)
                                         ?? throw new ArgumentException("File not found");

    public override string ToString()
    {
        var result = new StringBuilder("Files in folder:");
        foreach (var file in files)
        {
            result.AppendLine().Append(file);
        }

        return result.ToString();
    }
}