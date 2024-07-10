using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace amendPdf
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length == 0)
                {
                    Console.WriteLine("Usage: amendpdf.exe -f filename -s w*h(如：408*697)");
                }
                var t = string.Join("", args);
                var t1 = t.Split('-');
                string filename = "";
                Size size = new Size();
                foreach (var t2 in t1)
                {
                    if (string.IsNullOrEmpty(t2))
                    {
                        continue;
                    }
                    switch (t2.Substring(0, 1))
                    {
                        case "f":
                            filename = t2.Substring(1);
                            break;
                        case "s":
                            string t3 = t2.Substring(1);
                            var t4 = t3.Split('*');
                            size.Width = int.Parse(t4[0]);
                            size.Height = int.Parse(t4[1]);
                            break;
                        default:
                            size = Size.Empty;
                            break;

                    }
                }
                

                Console.WriteLine(filename);
                Spirehelper.deleteImg(filename, size);
                Console.WriteLine(filename);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Usage: amendpdf.exe -f filename -s w*h(like this:408*697){ex.Message}");
            }
            Console.WriteLine("任何键退出");
            Console.ReadKey();
        }
    }
}
