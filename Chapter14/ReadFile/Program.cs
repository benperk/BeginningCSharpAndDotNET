using System;
using System.Text;
using System.IO;

namespace ReadFile
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] byteData = new byte[200];
            char[] charData = new char[200];
            try
            {
                using (FileStream aFile = new FileStream(@"..\..\..\Program.cs", FileMode.Open))
                {
                    aFile.Seek(88, SeekOrigin.Begin);
                    aFile.Read(byteData, 0, 200);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An IO exception has been thrown!");
                Console.WriteLine(e.ToString());
                Console.ReadKey();
                return;
            }
            Decoder d = Encoding.UTF8.GetDecoder();
            d.GetChars(byteData, 0, byteData.Length, charData, 0);
            Console.WriteLine(charData);
            Console.ReadKey();
        }
    }
}
