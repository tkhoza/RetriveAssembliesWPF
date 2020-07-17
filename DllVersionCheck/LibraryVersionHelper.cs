using DllVersionCheck.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DllVersionCheck
{
    public static class LibraryVersionHelper
    {
        public static List<Library> GetAllPAckagesInstalled()
        {
            var _library = new List<Library>();
            string binPath = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, ""); 

            foreach (string dll in Directory.GetFiles(binPath, "*.dll", SearchOption.AllDirectories))
            {
                try
                {
                    Assembly _Assembly = Assembly.LoadFile(dll);
                    FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(_Assembly.Location);

                    var temoLib = new Library();
                    temoLib.Title = _Assembly.GetName().Name;
                    temoLib.Version = _Assembly.GetName().Version.ToString();
                    temoLib.ProdVersion = fileVersionInfo.ProductVersion;
                    temoLib.ProductName = fileVersionInfo.ProductName;

                    _library.Add(temoLib);
                }
                catch (Exception m)
                {
                    var mr = m.Message;
                }
            }

            return _library;
        }
    }
}
