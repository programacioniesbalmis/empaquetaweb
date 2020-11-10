using System;
using System.IO;
using System.Collections.Generic;

namespace DuplicarCarpetasConSeleccionFicheros
{
    class DuplicarCarpetasConSeleccionFicheros
    {
        const string RUTAORIGEN = @"c:\programacioniesbalmis";
        const string RUTADESTINO = @"c:\programacioniesbalmis.io";
        static string[] tiposEspecificados = new string[] { "png", "jpg", "pdf", "html" };

        static bool EsFicherosSegunTipoEspecificado(FileSystemInfo fichero)
        {
            foreach (string tipo in tiposEspecificados) if (fichero.Extension == "." + tipo) return true;
            return false;
        }
        static bool TieneFicherosSegunTipoEspecificado(DirectoryInfo directorio)
        {
            FileSystemInfo[] fileSystemInfos = directorio.GetFileSystemInfos();
            foreach (FileSystemInfo fsi in fileSystemInfos) if (EsFicherosSegunTipoEspecificado(fsi)) return true;
            return false;
        }
        static List<FileSystemInfo> ListaFicherosDeTipoEspecificado(DirectoryInfo directorio)
        {
            FileSystemInfo[] fileSystemInfos = directorio.GetFileSystemInfos();
            List<FileSystemInfo> ficherosSeleccionados = new List<FileSystemInfo>();
            foreach (FileSystemInfo fsi in fileSystemInfos) if (EsFicherosSegunTipoEspecificado(fsi)) ficherosSeleccionados.Add(fsi);
            return ficherosSeleccionados;
        }
        static bool TieneSubDirectorios(DirectoryInfo directorio)
        {
            return directorio.GetDirectories() != null ? true : false;
        }

        static void CreaFicherosSegunTipoEspecificados(DirectoryInfo directorioOrigen, string rutaDestino)
        {
            List<FileSystemInfo> ficherosSeleccionados = ListaFicherosDeTipoEspecificado(directorioOrigen);
            string rutaCompletaDirectorioDestino = rutaDestino + Path.DirectorySeparatorChar;
            string rutaCompletDirectorioOrigen = directorioOrigen.FullName + Path.DirectorySeparatorChar;
            foreach (FileSystemInfo fsi in ficherosSeleccionados) File.Copy(rutaCompletDirectorioOrigen + fsi.Name, rutaCompletaDirectorioDestino + fsi.Name, true);
        }

        static void DuplicaArbolConFicherosEspecificados(DirectoryInfo directorio)
        {

            if (TieneSubDirectorios(directorio))
            {
                DirectoryInfo[] subdirectorios = directorio.GetDirectories();
                foreach (DirectoryInfo d in subdirectorios)
                {
                    DuplicaArbolConFicherosEspecificados(d);
                }
            }
            if (TieneFicherosSegunTipoEspecificado(directorio))
            {
                DirectoryInfo directorioCreado = Directory.CreateDirectory(RUTADESTINO + Path.DirectorySeparatorChar + directorio.FullName.Substring(RUTAORIGEN.Length));
                CreaFicherosSegunTipoEspecificados(directorio, directorioCreado.FullName);
            }

        }

        static void Main()
        {
            try
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(RUTAORIGEN);
                DuplicaArbolConFicherosEspecificados(directoryInfo);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
