using River.BackgroundServices.Interfaces;
using System.IO;

namespace River.Infrastructure.FileSystem
{
    public class FileChangeListener : IFileChangeListener
    {
        private FileSystemWatcher _fileSystemWatcher;
        public FileChangeListener(FileSystemWatcher fileSystemWatcher)
        {
            _fileSystemWatcher = fileSystemWatcher;
            _fileSystemWatcher.NotifyFilter = NotifyFilters.Attributes
                | NotifyFilters.CreationTime
                | NotifyFilters.DirectoryName
                | NotifyFilters.FileName
                | NotifyFilters.LastAccess
                | NotifyFilters.LastWrite
                | NotifyFilters.Security
                | NotifyFilters.Size;

            _fileSystemWatcher.Changed += OnChanged;
            _fileSystemWatcher.Created += OnCreated;
            _fileSystemWatcher.Deleted += OnDeleted;
            _fileSystemWatcher.Renamed += OnRenamed;
            _fileSystemWatcher.Error += OnError;
        }

        private static void OnChanged(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType != WatcherChangeTypes.Changed)
            {
                return;
            }
        }

        private static void OnCreated(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType != WatcherChangeTypes.Created)
            {
                return;
            }
        }

        private static void OnDeleted(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType != WatcherChangeTypes.Deleted)
            {
                return;
            }
        }

        private static void OnRenamed(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType != WatcherChangeTypes.Renamed)
            {
                return;
            }
        }

        private static void OnError(object sender, ErrorEventArgs e)
        {
        }
    }
}
