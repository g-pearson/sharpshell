﻿using System;
using System.Runtime.InteropServices;
using System.Text;

namespace SharpShell.Interop
{
    /// <summary>
    /// Methods imported from Shell32.dll.
    /// </summary>
    public static class Shell32
    {
        /// <summary>
        /// Retrieves the names of dropped files that result from a successful drag-and-drop operation.
        /// </summary>
        /// <param name="hDrop">Identifier of the structure that contains the file names of the dropped files.</param>
        /// <param name="iFile">Index of the file to query. If the value of this parameter is 0xFFFFFFFF, DragQueryFile returns a count of the files dropped. If the value of this parameter is between zero and the total number of files dropped, DragQueryFile copies the file name with the corresponding value to the buffer pointed to by the lpszFile parameter.</param>
        /// <param name="lpszFile">The address of a buffer that receives the file name of a dropped file when the function returns. This file name is a null-terminated string. If this parameter is NULL, DragQueryFile returns the required size, in characters, of this buffer.</param>
        /// <param name="cch">The size, in characters, of the lpszFile buffer.</param>
        /// <returns>A nonzero value indicates a successful call.</returns>
        [DllImport("shell32.dll", SetLastError = true)]
        public static extern uint DragQueryFile(IntPtr hDrop, uint iFile, [Out] StringBuilder lpszFile, uint cch);

        /// <summary>
        /// Performs an operation on a specified file.
        /// </summary>
        /// <param name="pExecInfo">A pointer to a SHELLEXECUTEINFO structure that contains and receives information about the application being executed.</param>
        /// <returns>Returns TRUE if successful; otherwise, FALSE. Call GetLastError for extended error information.</returns>
        [DllImport("shell32.dll", EntryPoint = "ShellExecuteEx", SetLastError = true)]
        public static extern int ShellExecuteEx(ref SHELLEXECUTEINFO pExecInfo);

        /// <summary>
        /// Retrieves the path of a known folder as an ITEMIDLIST structure.
        /// </summary>
        /// <param name="rfid">A reference to the KNOWNFOLDERID that identifies the folder. The folders associated with the known folder IDs might not exist on a particular system.</param>
        /// <param name="dwFlags">Flags that specify special retrieval options. This value can be 0; otherwise, it is one or more of the KNOWN_FOLDER_FLAG values.</param>
        /// <param name="hToken">An access token used to represent a particular user. This parameter is usually set to NULL, in which case the function tries to access the current user's instance of the folder.</param>
        /// <param name="ppidl">When this method returns, contains a pointer to the PIDL of the folder. This parameter is passed uninitialized. The caller is responsible for freeing the returned PIDL when it is no longer needed by calling ILFree.</param>
        /// <returns>Returns S_OK if successful, or an error value otherwise, including the following:</returns>
        [DllImport("shell32.dll", SetLastError = true)]
        public static extern int SHGetKnownFolderIDList([MarshalAs(UnmanagedType.LPStruct)] Guid rfid, KNOWN_FOLDER_FLAG dwFlags, IntPtr hToken, out IntPtr ppidl);

        /// <summary>
        /// Retrieves the full path of a known folder identified by the folder's KNOWNFOLDERID.
        /// </summary>
        /// <param name="rfid">A reference to the KNOWNFOLDERID that identifies the folder. The folders associated with the known folder IDs might not exist on a particular system.</param>
        /// <param name="dwFlags">Flags that specify special retrieval options. This value can be 0; otherwise, it is one or more of the KNOWN_FOLDER_FLAG values.</param>
        /// <param name="hToken">An access token used to represent a particular user. This parameter is usually set to NULL, in which case the function tries to access the current user's instance of the folder.</param>
        /// <param name="pszPath">When this method returns, contains the address of a pointer to a null-terminated Unicode string that specifies the path of the known folder. The calling process is responsible for freeing this resource once it is no longer needed by calling CoTaskMemFree. The returned path does not include a trailing backslash. For example, "C:\Users" is returned rather than "C:\Users\".</param>
        /// <returns>Returns S_OK if successful, or an error value otherwise, including the following:</returns>
        [DllImport("shell32.dll")]
        public static extern int SHGetKnownFolderPath([MarshalAs(UnmanagedType.LPStruct)] Guid rfid, KNOWN_FOLDER_FLAG dwFlags, IntPtr hToken, out string pszPath);

        /// <summary>
        /// Frees an ITEMIDLIST structure allocated by the Shell.
        /// </summary>
        /// <param name="pidl">A pointer to the ITEMIDLIST structure to be freed. This parameter can be NULL.</param>
        [DllImport("shell32.dll")]
        public static extern void ILFree(IntPtr pidl);
    }
}
