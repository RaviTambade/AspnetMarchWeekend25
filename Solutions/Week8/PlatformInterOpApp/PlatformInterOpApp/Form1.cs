using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;



namespace PlatformInterOpApp
{
    public partial class Form1 : Form
    {
        //Importing the user32.dll library to use the MessageBox function
       /* [DllImport("user32.dll", CharSet = CharSet.Ansi)]
        public static extern int MessageBox(IntPtr hWnd, string lpText, string lpCaption, uint uType);
       */


        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern SafeFileHandle CreateFile(
       string lpFileName,
       uint dwDesiredAccess,
       uint dwShareMode,
       IntPtr lpSecurityAttributes,
       uint dwCreationDisposition,
       uint dwFlagsAndAttributes,
       IntPtr hTemplateFile);


        const uint MB_OK = 0x00000000;
        const uint MB_ICONINFORMATION = 0x00000040;

        // Constants for desired access
        private const uint GENERIC_READ = 0x80000000;

        // Share mode
        private const uint FILE_SHARE_READ = 0x00000001;
        private const uint FILE_SHARE_WRITE = 0x00000002;

        // Creation disposition
        private const uint OPEN_EXISTING = 3;

        // Flags and attributes
        private const uint FILE_ATTRIBUTE_NORMAL = 0x80;

        // Invalid handle
        private static readonly IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);



        public Form1()
        {
            InitializeComponent();
        }



        public static bool IsFileLocked(string filePath)
        {
            SafeFileHandle handle = CreateFile(
                filePath,
                GENERIC_READ,
                0, // No sharing
                IntPtr.Zero,
                OPEN_EXISTING,
                FILE_ATTRIBUTE_NORMAL,
                IntPtr.Zero);

            if (handle.IsInvalid)
            {
                int error = Marshal.GetLastWin32Error();

                // ERROR_SHARING_VIOLATION = 32 means file is opened by another process
                return error == 32;
            }

            handle.Dispose(); // Clean up if opened successfully
            return false;
        }
        private void OnFileSelect(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "All files (*.*)|*.*";
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the path of specified file
                    string filePath = openFileDialog.FileName;
                    this.textBox1.Text = filePath;

                    //.net code
                    // IL Code (CLR Targetted Code)     and  Windows Code (Win32 code) (OS targetted Code)
                    // Class library Code  and Native DLL Code
                    // Runtime Code and  Native code
                    // Managed Code (.NET Compliant Code)  and UnManaged Code (Non .NET Compliant Code)

                    //MessageBox.Show("Selected file: " + filePath);

                    //Native windows dynamic link library (user32.dll)
                    //Win32 API
                    //invoke native code of showing message box


                    //Unmanaged code
                    //Win32 API
                    //Meaning that the code is not managed by the CLR
                    // Native code 

                    // MessageBox(IntPtr.Zero, filePath, "Win32 MessageBox", MB_OK | MB_ICONINFORMATION);

                    if (IsFileLocked(filePath))
                    {
                        MessageBox.Show("File is currently in use (locked by another process).");
                    }
                    else
                    {
                        MessageBox.Show("File is not locked. You can access it.");
                    }



                }
            }


        }
    }
}
