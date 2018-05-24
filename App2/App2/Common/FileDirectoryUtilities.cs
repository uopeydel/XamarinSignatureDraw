using System;
using System.Collections.Generic;
using Android.Graphics;
using Java.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace App2.Common
{
    public class FileDirectoryUtilities
    {
        public struct WokringDir
        {
            public const string MyAppDir = "MyApp/";
            public const string TempCamera = "TempCamera/";
            public const string TempFileNameCamera = "tempCamera.jpg";
        }

        public static string CopyToWorkingDir(string localPath, string guid, string testDirXxDir)
        {
            File file = new File(localPath);
            FileOutputStream outStream = null;
            File folder = new File(GetDirectory(testDirXxDir));
            if (!folder.Exists())
            {
                folder.Mkdirs();
            }

            if (file.Exists())
            {
                byte[] byteFile = System.IO.File.ReadAllBytes(localPath);
                string Ext = GetFileExt(localPath);
                string newFile = string.Format("{0}/{1}{2}", folder, guid, Ext);
                if ((byteFile != null) && (byteFile.Length > 0) && (folder.Exists()) && (!string.IsNullOrEmpty(Ext)))
                {
                    outStream = new FileOutputStream(newFile);
                    outStream.Write(byteFile);
                    outStream.Close();
                }
                if (!string.IsNullOrEmpty(newFile))
                {
                    File nFile = new File(newFile);
                    if (nFile.Exists())
                    {
                        return newFile;
                    }
                }
            }

            return string.Empty;
        }

        public static void SaveByteFile(byte[] file, string path)
        {
            File folder = new File(GetDirectory(path));
            if (!folder.Exists())
            {
                folder.Mkdirs();
            }
            if ((file != null) && (file.Length > 0) && (folder.Exists()))
            {
                FileOutputStream outStream = null;
                outStream = new FileOutputStream(path);
                outStream.Write(file);
                outStream.Close();
            }
        }

        public static bool CheckFileExists(string path)
        {
            if (!string.IsNullOrEmpty(path))
            {
                File nFile = new File(path);
                if (nFile.Exists())
                {
                    return true;
                }
            }
            return false;
        }

        public static void MoveFile(string tempPath, string localPath)
        {
            if (System.IO.File.Exists(tempPath))
            {
                System.IO.File.Move(tempPath, localPath);
            }
        }

        public static void CoppyFile(string tempPath, string localPath)
        {
            if (System.IO.File.Exists(tempPath))
            {
                System.IO.File.Copy(tempPath, localPath);
            }
        }


        public static string GetDirectory(string testDirXxDir)
        {
            return Android.OS.Environment.ExternalStorageDirectory + File.Separator + testDirXxDir;
        }

        public static void DeleteFile(string localPath)
        {
            File file = new File(localPath);
            if (file.Exists())
            {
                file.Delete();
            }
        }

        public static string GetFileExt(string fileName)
        {
            if (fileName.LastIndexOf(".") >= 0)
            {
                return fileName.Substring(fileName.LastIndexOf("."));
            }
            return string.Empty;
        }
    }
}