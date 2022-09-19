using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace PubApp.Models
{
    public class FileHelper
    {
        public static void GeneratePDF(Beer beer)
        {
            Guid g = Guid.NewGuid();
            string filename =g.ToString();
            iTextSharp.text.Document doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4);
            string PDFpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/" + filename + ".pdf";
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(PDFpath, FileMode.Create));
            doc.Open();

            var currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo di = new DirectoryInfo(currentDirectory);
            di = di.Parent.Parent;
            currentDirectory = di.FullName;
            var logo = iTextSharp.text.Image.GetInstance(currentDirectory + "/"+beer.ImagePath);
            logo.ScaleAbsoluteHeight(500);
            logo.ScaleAbsoluteWidth(500);

            var content = $"Name : {beer.Name}\nVolume : {beer.Volume} litre\nPrice : {beer.Price} $\nCount : {beer.Count}\n\nThanks for shopping...";
            iTextSharp.text.Paragraph p = new iTextSharp.text.Paragraph();
            p.Add(content);
            doc.Add(logo);
            doc.Add(p);
            doc.Close();
        }
    }
}
