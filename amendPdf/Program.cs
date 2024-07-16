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
using Newtonsoft.Json;

namespace amendPdf
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Size size = new Size();
                if (args.Length == 0)
                {
                    //amemdPdf.conf
                    string s1 = string.Empty ;
                    try
                    {
                        s1 = File.ReadAllText("amemdPdf.conf");
                        var s2 = JsonConvert.DeserializeObject<SizesConf>(s1);
                        var s3=s2.Sizes[0].Split('*');
                        size.Width = int.Parse(s3[0]);
                        size.Height = int.Parse(s3[1]);
                    }
                    catch
                    {

                    }

                    if (s1== string.Empty)
                    {
                        size.Width = int.Parse("408");
                        size.Height = int.Parse("697");
                    }
                    Spirehelper.deleteImgAll(size);
                }
                else
                {
                    var t = string.Join("", args);
                    var t1 = t.Split('-');
                    string filename = "";
                    foreach (var t2 in t1)
                    {
                        {
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
                                    size.Width = int.Parse("408");
                                    size.Height = int.Parse("697");
                                    break;
                            }
                        }
                        Console.WriteLine(filename);
                        Spirehelper.deleteImg(filename, size);
                        Console.WriteLine(filename);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Usage: amendpdf.exe -f filename -s w*h(default:408*697){ex.Message}");
            }
            Console.WriteLine("任何键退出");
            Console.ReadKey();
        }
    }
}
