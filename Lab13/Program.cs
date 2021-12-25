using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using System.IO;

//1. Какие классы содержаться с System.IO?
//- File,Fileinfo,StreamWrider,StreamRider,BinaryWriter,DirInfo,BinaryReader,FileStream

//2. Для чего используются классы Directory и DirectoryInfo? В чем отличие ?
// - Directory - создания, удаления, перемещения и переименования каталогов и подкаталогов.
// Ссылочный тип, наследуется от System.IO.FileSystemInfo, поэтому имеет массу перегруженных методов
// Позволяет получить информацию о каталогах

//3. Для чего используются классы File и FileInfo? Какие методы они содержат.
//Класс FileInfo позволяет получать подробности относительно существующих файлов на жестком диске
//Create, Append, Delete, Name
//Тип File предоставляет функциональность, почти идентичную типу FileInfo, с помощью нескольких статических методов.

//4. Для чего используются классы StreamReader и StreamWriter?
// Для записи в файл и для получения информации из файла

//5. Для чего используются классы BinaryWriter и BinaryReader
//Классы BinaryReader и BinaryWriter предназначены соответственно для чтения и записи данных в двоичном формате.

//6. Как можно сжимать и восстанавливать файлы?
// классы ZipFile и GZip позволяют сжимать и восстанавливать файлы

//8. Для чего служит класс Path?
//Он предоставляет статические методы, которые упрощают выполнение операций с путевыми именами.

//10.Что такое произвольный доступ к файлу? Приведите пример
// Произвольный доступ к файлу - это досту к любой части файла, то есть запись в файл можно произвести с любого места.

//11. Как применяется конструкция using (не директива) при работе с файловыми потоками? Для чего ее используют.
//Оператор using позволяет создавать объект в блоке кода, по завершению которого вызывается метод Dispose у этого объекта, и, таким образом, объект уничтожается.








namespace Lab13
{
    public static class LogInfo
    {
        public static void WriteLogInfo()
        {
            string logPath = Path.GetFullPath("C:/Study/forlab13/logfile.txt");
            try
            {
                using (StreamWriter sw = new StreamWriter(logPath, false, Encoding.Default))
                {
                    sw.WriteLine("<=========================================== LDILog ===================================================>");
                    sw.WriteLine($"Имя файла лога: {Path.GetFileName(logPath)}");
                    sw.WriteLine($"Полный путь лога: {logPath}");
                    sw.WriteLine($"Время записи лога: {DateTime.Now}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void WriteInLog(string message)
        {
            string logPath = Path.GetFullPath("C:/Study/forlab13/logfile.txt");
            try
            {
                using (StreamWriter sw = new StreamWriter(logPath, true, Encoding.Default))
                {
                    sw.WriteLine(message);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    
        public static string ReadLog()
        {
            string logPath = Path.GetFullPath("C:/Study/forlab13/logfile.txt");
            try
            {
                StreamReader sr = new StreamReader(logPath);
                return sr.ReadToEnd();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return String.Empty;
            }
        }

        
        
    }
    
    class LDILog
    {
         

        public  void createFile()
        {
            string DirPath = "C:/Study/forlab13";
            FileInfo file = new FileInfo(DirPath + "/ldilogfile.txt");
            StreamWriter sw = file.CreateText();
            sw.Close();
        }

        public  void WriteInfo(string info,string path)
        {
            StreamWriter sw = File.AppendText("C:/Study/forlab13/ldilogfile.txt");
            
            if (sw != null) sw.AutoFlush = true;
            sw.WriteLine(DateTime.Now);
            sw.WriteLine(info);
            sw.WriteLine(path);
            sw.WriteLine();
            sw.Close();
           

        }

        
    }


    class LDIDiskInfo
    {
        DriveInfo[] drivers = DriveInfo.GetDrives();
        

        public void DriversInfo()
        {
            foreach (DriveInfo drive in drivers)
            {
                Console.WriteLine(drive.Name);
                Console.WriteLine(drive.TotalSize/1024/1024/1024+"Гб");
                Console.WriteLine(drive.AvailableFreeSpace/1024/1024/1024+"Гб");
                Console.WriteLine(drive.DriveFormat);
                
            }
        }
    }

    class LDIFileInfo 
    {
        string dirname = "C:/Study/forlab13/Test.txt";
        
        public void FileInformation()
        {
            
                FileInfo file = new FileInfo(dirname);
                Console.WriteLine(file.FullName);
                Console.WriteLine(file.Name);
                Console.WriteLine(file.Length);
                Console.WriteLine(file.CreationTime);
        }
    }

    class LDIDirInfo
    {
        string dirname = "C:/Study/forlab13";

        public void DirInformation()
        {
            Console.WriteLine("Директории");
            string[] dirs = Directory.GetDirectories(dirname);
            foreach(string dir in dirs)
            {
                Console.WriteLine(dir);
            }

            Console.WriteLine("Файлы");
            string[] files = Directory.GetFiles(dirname);
            foreach(string file in files)
            {
                FileInfo CurrentFile = new FileInfo(file);
                Console.WriteLine(file);
                Console.WriteLine(CurrentFile.Name);
                Console.WriteLine(CurrentFile.Length);
                Console.WriteLine(CurrentFile.CreationTime);
                Console.WriteLine();
            }
        }
    }

    class LDIFileManager
    {
        string DiskPath = "C:/";
        string DirPath = "C:/Study/forlab13";
        
        public void SaveInfoInTxt()
        {
            string[] dirs = Directory.GetDirectories(DiskPath);
            DirectoryInfo dirInfo = new DirectoryInfo(DirPath);
            dirInfo.CreateSubdirectory("LDIInspect");

            LogInfo.WriteLogInfo();
            LogInfo.WriteInLog("Была создана директория" + DirPath);

            FileInfo file = new FileInfo(DirPath+"/LDIInspect/Information.txt");
            
            //StreamWriter sw = new StreamWriter("C:/Study/forlab13/LDIInspect/Information.txt");
            StreamWriter sw = file.CreateText();

            foreach (string dir in dirs)
            {
                Console.WriteLine(dir);
                sw.WriteLine(dir);

            }
            sw.Close();

            try
            {
                File.Copy(DirPath + "/LDIInspect/Information.txt", DirPath + "/LDIInspect/Information2.txt");
            }
            catch
            {
                
            }
            
            File.Delete(DirPath + "/LDIInspect/Information.txt");
        }

        public void MoveDir()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(DirPath);
            dirInfo.CreateSubdirectory("LDIFiles");

            string[] txtList = Directory.GetFiles(DirPath + "/LDIInspect", "*.txt");
            
            foreach(string file in txtList)
            {
                string fName = file.Substring((DirPath+"/LDIInspect").Length + 1);
                File.Copy(Path.Combine(DirPath + "/LDIInspect", fName), Path.Combine(DirPath + "/LDIFiles", fName), true);
            }

        }

        //7. Расскажите алгоритм сжатия GZip.
        //Метод Compress получает название исходного файла, который надо архивировать, и название будущего сжатого файла.
        //Сначала создается поток для чтения из исходного файла - FileStream sourceStream. Затем создается поток для записи в сжатый файл - FileStream targetStream. 
        //Поток архивации GZipStream compressionStream инициализируется потоком targetStream и с помощью метода CopyTo() получает данные от потока sourceStream.
        //Метод Decompress производит обратную операцию по восстановлению сжатого файла в исходное состояние. 
        //Он принимает в качестве параметров пути к сжатому файлу и будущему восстановленному файлу.

        public void Compress(string sourceFile, string compressedFile)
        {
            // поток для чтения исходного файла
            using (FileStream sourceStream = new FileStream(sourceFile, FileMode.OpenOrCreate))
            {
                // поток для записи сжатого файла
                using (FileStream targetStream = File.Create(compressedFile))
                {
                    // поток архивации
                    using (GZipStream compressionStream = new GZipStream(targetStream, CompressionMode.Compress))
                    {
                        sourceStream.CopyTo(compressionStream); // копируем байты из одного потока в другой
                        Console.WriteLine("Сжатие файла {0} завершено. Исходный размер: {1}  сжатый размер: {2}.",
                            sourceFile, sourceStream.Length.ToString(), targetStream.Length.ToString());
                    }
                }
            }
        }

        public void Decompress(string compressedFile, string targetFile)
        {
            using (FileStream sourceStream = new FileStream(compressedFile, FileMode.OpenOrCreate))
            {
                // поток для записи восстановленного файла
                using (FileStream targetStream = File.Create(targetFile))
                {
                    // поток разархивации
                    using (GZipStream decompressionStream = new GZipStream(sourceStream, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(targetStream);
                        Console.WriteLine("Восстановлен файл: {0}", targetFile);
                    }
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            LDIDiskInfo drivers = new LDIDiskInfo();
            drivers.DriversInfo();
            Console.ReadKey();

            LDIFileInfo file = new LDIFileInfo();
            file.FileInformation();
            Console.ReadKey();

            LDIDirInfo dirs = new LDIDirInfo();
            dirs.DirInformation();
            Console.ReadKey();

            LDIFileManager manager = new LDIFileManager();
            manager.SaveInfoInTxt();
            manager.MoveDir();

            string sourseFile = "C:/Study/forlab13/LDIFiles/Information2.txt";
            string compressedFile = "C:/Study/forlab13/Information2.gz";
            string targetFIle = "C:/Study/forlab13/LDIInspect/new_Information2.txt";

            manager.Compress(sourseFile, compressedFile);
            manager.Decompress(compressedFile, targetFIle);

            
           
        }
    }
}
