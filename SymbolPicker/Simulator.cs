using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Simulator
{
    public static class KeyboardSimulator
    {
        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);
        /// <summary>
        /// Simulate keyborad actions.
        /// </summary>
        /// <param name="keyboardCode">ASCII. Ex: A - 0x41</param>
        /// <param name="KeyEventFlags">the key event</param>
        /// <param name="wScanCode">If dwFlags specifies KEYEVENTF_UNICODE, wScan specifies a Unicode character which is to be sent to the foreground application.</param>
        /// <param name="iswScanCode">Determine if the input this a wScan(unicode): if it's unicode, the program will use wScanCode instead of keyboardCode</param>
        ///<remarks>https://stackoverflow.com/questions/60063914/how-does-dword-time-in-tagkeybdinput-work-and-when-to-use-it</remarks>
        /// <param name="additionalInfo">Addtional info</param>
        /// <returns>The function returns the number of events successfully inserted into the keyboard or mouse input stream. If the function returns zero, it means the input has been blocked by another thread. (Success return 1, fail return 0)</returns>

        public static uint SimulateKeyboard(ushort keyboardCode, KeyEventFlags KeyEventFlags, ushort wScanCode = 0, bool iswScanCode = false, uint recordTime = 0, IntPtr additionalInfo = default(IntPtr))
        {
            KEYBDINPUT keyboardInput = new KEYBDINPUT();
            keyboardInput.dwFlags = (uint)KeyEventFlags;
            if (iswScanCode)
            {
                keyboardInput.wScan = wScanCode;
            }
            else
            {
                keyboardInput.wVk = keyboardCode;
            }
            keyboardInput.time = recordTime;
            keyboardInput.dwExtraInfo = additionalInfo;

            InputUnion union = new InputUnion();
            union.ki = keyboardInput;

            INPUT[] input = new INPUT[1];
            input[0].type = (uint)InputTypes.KEYBOARD;
            input[0].U = union;
            return SendInput(1, input, Marshal.SizeOf(typeof(INPUT)));


        }
    }



    // --------------------------- ---------------------------



    public enum InputTypes : uint
    {
        // INPUT_MOUSE表示鼠标事件
        MOUSE = 0,
        // INPUT_KEYBOARD表示键盘事件
        KEYBOARD = 1,
        // INPUT_HARDWARE表示硬件事件
        HARDWARE = 2
    }
    public enum KeyEventFlags : ushort
    {
        KEYDOWN = 0x0000,
        EXTENDEDKEY = 0x0001, // 键盘扩展键被按下
        KEYUP = 0x0002, // 键盘按键释放
        UNICODE = 0x0004, // 键盘按键产生Unicode字符
        SCANCODE = 0x0008 // 键盘按键使用扫描码
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct INPUT
    {
        public uint type;
        public InputUnion U;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct InputUnion
    {
        [FieldOffset(0)]
        public MOUSEINPUT mi;
        [FieldOffset(0)]
        public KEYBDINPUT ki;
        [FieldOffset(0)]
        public HARDWAREINPUT hi;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MOUSEINPUT
    {
        public int dx;
        public int dy;
        public uint mouseData;
        public uint dwFlags;
        public uint time;
        public IntPtr dwExtraInfo;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct KEYBDINPUT
    {
        public ushort wVk;
        public ushort wScan;
        public uint dwFlags;
        public uint time;
        public IntPtr dwExtraInfo;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct HARDWAREINPUT
    {
        public uint uMsg;
        public ushort wParamL;
        public ushort wParamH;
    }

}
