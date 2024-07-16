using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Spire.License;
using Spire.Pdf;
namespace amendPdf
{
    internal class Spirehelper
    {
        public static void deleteImgAll(Size? size)
        {
            int index = 1;
            try
            {
                
                PdfDocument pdf = new PdfDocument();
                var s = size ?? new Size(408, 697);
                var dir = Environment.CurrentDirectory;
                foreach (var filename in Directory.GetFiles(dir, "*.pdf"))
                {
                    pdf.LoadFromFile(filename);
                    foreach (PdfPageBase page in pdf.Pages)
                    {
                        //if (index >= 490) continue;
                        foreach (var item in page.ImagesInfo)
                        {
                            index++;
                            
                            if (item.Image.Size == s)
                            {
                                page.DeleteImage(item.Image);
                                Console.Write("-");
                            }
                            else
                            {
                                Console.Write(".");
                            }
                        }
                    }
                    var filenewname = filename.Replace(".pdf", "_new.pdf");
                    var path = Path.GetDirectoryName(filename) + @"\";
                    if (path == @"\")
                        path = Environment.CurrentDirectory + @"\";
                    pdf.SaveToFile(filenewname, FileFormat.PDF);
                    Console.WriteLine("");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message+ index);
            }
        }
        public static void deleteImg(string filename,Size? size)
        {
            try
            {
                PdfDocument pdf = new PdfDocument();
                var s = size ?? new Size(408, 697);
                pdf.LoadFromFile(filename);
                foreach (PdfPageBase page in pdf.Pages)
                {
                    foreach (var item in page.ImagesInfo)
                    {
                        if (item.Image.Size == s)
                        {
                            page.DeleteImage(item.Image);
                            Console.Write("-");
                        }
                        else
                        {
                            Console.Write(".");
                        }
                    }
                }
                var filenewname = DateTime.Now.Ticks.ToString() + ".pdf";
                var path = Path.GetDirectoryName(filename)+@"\";
                if(path==@"\")
                    path =Environment.CurrentDirectory+@"\";
                pdf.SaveToFile(path+filenewname, FileFormat.PDF);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message) ;
            }
        }
    }
}
