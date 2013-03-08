// Sergey Kirichenkov [kirichenkov.sa@gmail.com]

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SBeep.Private.Useful.Cuckoo.Beeper.Imp.Stuff.Help
{
    public static class FileWizard
    {
        #region Pub
        //===============================================================================================[]
        public static T OpenXml< T >( string path ) where T : class
        {
            var builder = OpenFileOneLine( path );

            var serializer = new ConfigurationSerializer<T>();
            return serializer.Deserialize( builder );
        }

        //-------------------------------------------------------------------------------------[]
        public static void SaveXml< T >(
            T value,
            string path ) where T : class
        {
            var serializer = new ConfigurationSerializer<T>();
            var result = serializer.Serialize( value );

            //path = GetPathToFile(path);
            WriteText( result, path );
        }

        //-------------------------------------------------------------------------------------[]
        public static void WriteText(string input, string path)
        {
            using (TextWriter writer = new StreamWriter(File.Open(path, FileMode.Create)))
                writer.WriteLine(input);
        }

        //-------------------------------------------------------------------------------------[]
        public static IEnumerable<T> Parse< T >(
            string path,
            Func<string[], T> action ) where T : class
        {
            //open file
            var builder = OpenFileLine( path ).ToList();
            //parse
            return builder.Select( t => action( t.Split( ';' ) ) ).Where( t => t != null );
        }

        //-------------------------------------------------------------------------------------[]
        public static string OpenFileOneLine(string path)
        {
            var builder = OpenFileLine(path).Aggregate(
                new StringBuilder(),
                (current,
                  item) => current.Append(item));
            return builder.ToString();
        }

        //-------------------------------------------------------------------------------------[]
        public static IEnumerable<string> OpenFileLine(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException(string.Format("Configuration file '{0}; was not found", path));

            using (TextReader reader = new StreamReader(path, Encoding.UTF8))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    yield return line;
                    line = reader.ReadLine();
                }
            }
        }

        //===============================================================================================[]
        #endregion




        //-------------------------------------------------------------------------------------[]
        private static string GetPathToFile( string pathToFile )
        {
            var di = new DirectoryInfo( Path.GetDirectoryName( pathToFile ) );
            if( !di.Exists )
                di.Create();

            var finfo = new FileInfo( pathToFile );
            if( finfo.Exists )
                File.Delete( finfo.FullName );
            return finfo.FullName;
        }

    }
}