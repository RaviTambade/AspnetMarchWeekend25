using System;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;


namespace PlatformINterOpApp;
public class Helper
{
    private const uint GENERIC_READ = 0x80000000;
    private const uint FILE_SHARE_READ = 0x00000001;
    private const uint OPEN_EXISTING = 3;
    private const uint FILE_ATTRIBUTE_NORMAL = 0x00000080;
    private const uint LOCKFILE_EXCLUSIVE_LOCK = 0x00000002;
    private static readonly IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);

    // Import CreateFileW
    [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
    private static extern unsafe SafeFileHandle CreateFileW(
        char* lpFileName,
        uint dwDesiredAccess,
        uint dwShareMode,
        IntPtr lpSecurityAttributes,
        uint dwCreationDisposition,
        uint dwFlagsAndAttributes,
        IntPtr hTemplateFile);

    // Import LockFileEx
    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern unsafe bool LockFileEx(
        SafeFileHandle hFile,
        uint dwFlags,
        uint dwReserved,
        uint nNumberOfBytesToLockLow,
        uint nNumberOfBytesToLockHigh,
        NativeOverlapped* lpOverlapped);

    // Import GetLastError
    [DllImport("kernel32.dll")]
    private static extern uint GetLastError();

    // Error code for lock violation (file is locked)
    private const int ERROR_LOCK_VIOLATION = 33;

   public  static unsafe bool IsFileLocked(string filePath)
    {
        fixed (char* pFileName = filePath)
        {
            // Open the file with read access and share it with other processes
            using SafeFileHandle handle = CreateFileW(
                pFileName,
                GENERIC_READ,
                FILE_SHARE_READ,
                IntPtr.Zero,
                OPEN_EXISTING,
                FILE_ATTRIBUTE_NORMAL,
                IntPtr.Zero);

            if (handle.IsInvalid)
            {
                Console.WriteLine($"Failed to open file. Error: {GetLastError()}");
                return false; // Failed to open file
            }

            // Try to lock the first byte of the file using LockFileEx
            NativeOverlapped overlapped = new NativeOverlapped();
            bool result = LockFileEx(handle, LOCKFILE_EXCLUSIVE_LOCK, 0, 1, 0, &overlapped);

            if (!result)
            {
                int error = (int)GetLastError();
                if (error == ERROR_LOCK_VIOLATION)
                {
                    // Lock failed, file is in use by another process
                    return true;
                }
                else
                {
                    Console.WriteLine($"LockFileEx failed. Error: {error}");
                }
            }
            else
            {
                // Successfully locked the file, release the lock immediately
                Console.WriteLine("Successfully locked the file.");
            }
            return false;
        }

    }
}