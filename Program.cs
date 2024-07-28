namespace VMDL
{
    public static class Program
    {
        public static void Main()
        {
            System.Console.WriteLine("VMDL Version 1.1");
            System.Console.WriteLine("Searching for packets...");

            while (true)
            {
                try
                {
                    System.Collections.Generic.List<string> SearchDirectoryPaths = new System.Collections.Generic.List<string>();
                    System.Collections.Generic.List<string> SearchFilePaths = new System.Collections.Generic.List<string>();
                    int SearchInterval = 1000;

                    try
                    {
                        Microsoft.Win32.RegistryKey HKCU = Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, Microsoft.Win32.RegistryView.Registry64);
                        Microsoft.Win32.RegistryKey HKCUVMDL = HKCU.OpenSubKey("SOFTWARE\\VMDL");
                        try
                        {
                            SearchDirectoryPaths.AddRange((string[])HKCUVMDL.GetValue("SearchDirectoryPaths", new string[0]));
                        }
                        catch
                        {

                        }
                        try
                        {
                            SearchFilePaths.AddRange((string[])HKCUVMDL.GetValue("SearchFilePaths", new string[0]));
                        }
                        catch
                        {

                        }
                        try
                        {
                            SearchInterval = (int)HKCUVMDL.GetValue("SearchInterval", null);
                        }
                        catch
                        {

                        }
                        HKCUVMDL.Close();
                        HKCU.Close();
                    }
                    catch
                    {

                    }

                    try
                    {
                        Microsoft.Win32.RegistryKey HKCU = Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, Microsoft.Win32.RegistryView.Registry64);
                        Microsoft.Win32.RegistryKey HKCUVMDL = HKCU.OpenSubKey("SOFTWARE\\VMDL");
                        try
                        {
                            SearchDirectoryPaths.AddRange((string[])HKCUVMDL.GetValue("SearchDirectoryPaths", new string[0]));
                        }
                        catch
                        {

                        }
                        try
                        {
                            SearchFilePaths.AddRange((string[])HKCUVMDL.GetValue("SearchFilePaths", new string[0]));
                        }
                        catch
                        {

                        }
                        try
                        {
                            SearchInterval = (int)HKCUVMDL.GetValue("SearchInterval", null);
                        }
                        catch
                        {

                        }
                        HKCUVMDL.Close();
                        HKCU.Close();
                    }
                    catch
                    {

                    }

                    try
                    {
                        Microsoft.Win32.RegistryKey HKLM = Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, Microsoft.Win32.RegistryView.Registry64);
                        Microsoft.Win32.RegistryKey HKLMVMDL = HKLM.OpenSubKey("SOFTWARE\\VMDL");
                        try
                        {
                            SearchDirectoryPaths.AddRange((string[])HKLMVMDL.GetValue("SearchDirectoryPaths", new string[0]));
                        }
                        catch
                        {

                        }
                        try
                        {
                            SearchFilePaths.AddRange((string[])HKLMVMDL.GetValue("SearchFilePaths", new string[0]));
                        }
                        catch
                        {

                        }
                        try
                        {
                            SearchInterval = (int)HKLMVMDL.GetValue("SearchInterval", null);
                        }
                        catch
                        {

                        }
                        HKLMVMDL.Close();
                        HKLM.Close();
                    }
                    catch
                    {

                    }

                    try
                    {
                        Microsoft.Win32.RegistryKey HKLM = Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, Microsoft.Win32.RegistryView.Registry32);
                        Microsoft.Win32.RegistryKey HKLMVMDL = HKLM.OpenSubKey("SOFTWARE\\VMDL");
                        try
                        {
                            SearchDirectoryPaths.AddRange((string[])HKLMVMDL.GetValue("SearchDirectoryPaths", new string[0]));
                        }
                        catch
                        {

                        }
                        try
                        {
                            SearchFilePaths.AddRange((string[])HKLMVMDL.GetValue("SearchFilePaths", new string[0]));
                        }
                        catch
                        {

                        }
                        try
                        {
                            SearchInterval = (int)HKLMVMDL.GetValue("SearchInterval", null);
                        }
                        catch
                        {

                        }
                        HKLMVMDL.Close();
                        HKLM.Close();
                    }
                    catch
                    {

                    }

                    foreach (string SearchDirectoryPath in SearchDirectoryPaths)
                    {
                        try
                        {
                            SearchFilePaths.AddRange(System.IO.Directory.GetFiles(SearchDirectoryPath, "*.VMDL", System.IO.SearchOption.AllDirectories));
                        }
                        catch
                        {

                        }
                    }

                    foreach (string SearchFilePath in SearchFilePaths)
                    {
                        try
                        {
                            string PacketContents = System.IO.File.ReadAllText(SearchFilePath);

                            System.Diagnostics.Process.Start(PacketContents);

                            System.IO.File.Delete(SearchFilePath);

                            System.Console.WriteLine($"Found packet at \"{SearchFilePath}\" and started executable at \"{PacketContents}\".");

                            /* string PacketContentsTrimmed = "";

                             for (int i = 0; i < PacketContents.Length; i++)
                             {
                                 if (!(PacketContents[i] is ' ' || PacketContents[i] is '\r' || PacketContents[i] is '\n' || PacketContents[i] is '\t'))
                                 {
                                     PacketContentsTrimmed += PacketContents[i];
                                 }
                             }

                             System.Collections.Generic.List<string> PacketStatements = new System.Collections.Generic.List<string>();
                             string CurrentStatement = "";

                             for (int i = 0; i < PacketContents.Length; i++)
                             {
                                 if (PacketContents[i] is ';')
                                 {
                                     if (!(CurrentStatement is ""))
                                     {
                                         PacketStatements.Add(CurrentStatement);
                                         CurrentStatement = "";
                                     }
                                 }
                                 else
                                 {
                                     CurrentStatement += PacketContents[i];
                                 }
                             }

                             string Arguments = null;
                             string ExecutablePath = null;
                             string LauncherMode = null;
                             string Username = null;
                             string Password = null;

                             foreach (string Statement in PacketStatements)
                             {

                             }

                             if (LauncherMode is null || LauncherMode is "asinvoker")
                             {
                                 System.Diagnostics.ProcessStartInfo processStartInfo = new System.Diagnostics.ProcessStartInfo();
                                 if (Arguments is null)
                                 {
                                     processStartInfo.Arguments = "";
                                 }
                                 else
                                 {
                                     processStartInfo.Arguments = Arguments;
                                 }
                                 processStartInfo.FileName = ExecutablePath;
                                 processStartInfo.
                                 System.Diagnostics.Process.Start(processStartInfo);
                             }
                             else if (LauncherMode is "elevate")
                             {
                                 System.Diagnostics.ProcessStartInfo processStartInfo = new System.Diagnostics.ProcessStartInfo();
                                 System.Diagnostics.Process.Start(processStartInfo);
                             }
                             else if (LauncherMode is "runas")
                             {
                                 System.Diagnostics.ProcessStartInfo processStartInfo = new System.Diagnostics.ProcessStartInfo();
                                 System.Diagnostics.Process.Start(processStartInfo);
                             }*/
                        }
                        catch
                        {

                        }
                    }
                    System.Threading.Thread.Sleep(SearchInterval);
                }
                catch
                {

                }
            }
        }
    }
}