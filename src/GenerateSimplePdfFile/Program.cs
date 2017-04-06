using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;

namespace GenerateSimplePdfFile
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateSimplePdf();
            //DefinePageWidth();
            SetPageMargin();
            SetPadding();
            //AlignmentAlign();
            //SetMetaInformation();
            //CreateMultiPage();
            //CreateFromExistingPdf();
            //AddWatermark();
            //CreateMergedPDF("MergeFile.pdf");
        }

        private static void SetPadding()
        {
            float widthval = 25;
            var cellContent = "Check Cell Padding for iText PDF Table";
            try
            {
                var iTextCreateTable = new Document();
                PdfWriter.GetInstance(iTextCreateTable, new FileStream("iText_Cell_Padding_Example.pdf", FileMode.Create, FileAccess.Write, FileShare.None));
                iTextCreateTable.Open();
                var myFirstTable = new PdfPTable(3);
                var tableCell = new PdfPCell(new Phrase("Cell 1" + cellContent))
                {
                    Padding = widthval
                };
                /* Padding Set in All Sides */
                myFirstTable.AddCell(tableCell);
                tableCell = new PdfPCell(new Phrase("Cell 2" + cellContent))
                {
                    PaddingLeft = widthval
                };
                /* Left Padding Only */
                myFirstTable.AddCell(tableCell);
                tableCell = new PdfPCell(new Phrase("Cell 3" + cellContent))
                {
                    PaddingRight = widthval
                };
                /* Right Padding Only */
                myFirstTable.AddCell(tableCell);
                tableCell = new PdfPCell(new Phrase("Cell 4" + cellContent))
                {
                    PaddingTop = widthval
                };
                /* Top Padding Only */
                myFirstTable.AddCell(tableCell);
                tableCell = new PdfPCell(new Phrase("Cell 5" + cellContent))
                {
                    PaddingBottom = widthval
                };
                /* Bottom Padding Only */
                myFirstTable.AddCell(tableCell);
                tableCell = new PdfPCell(new Phrase("Cell 6" + cellContent));
                myFirstTable.AddCell(tableCell); /* No Padding Set */
                iTextCreateTable.Add(myFirstTable);
                iTextCreateTable.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        /// <summary>
        /// 6 steps to define a new simple pdf
        /// </summary>
        static void CreateSimplePdf()
        {
            var fs = new FileStream("Abc.pdf", FileMode.Create, FileAccess.Write, FileShare.None);
            var doc = new Document();
            var pdfWriter = PdfWriter.GetInstance(doc, fs);
            doc.Open();
            doc.Add(new Paragraph("Hello World"));
            doc.Close();
        }

        static void DefinePageWidth()
        {
            var fs = new FileStream("Abc.pdf", FileMode.Create, FileAccess.Write, FileShare.None);
            var rec = new Rectangle(PageSize.A4);
            var doc = new Document(rec);
            var pdfWriter = PdfWriter.GetInstance(doc, fs);
            doc.Open();
            doc.Add(new Paragraph("Hello World"));
            doc.Close();
        }
        /// <summary>
        /// 72 points = 1 inch
        /// </summary>
        static void SetPageMargin()
        {
            var fs = new FileStream("set-page-margin.pdf", FileMode.Create, FileAccess.Write, FileShare.None);
            var rec = new Rectangle(PageSize.A4);
            var doc = new Document(rec, 36, 72, 108, 180);
            var pdfWriter = PdfWriter.GetInstance(doc, fs);
            doc.Open();
            doc.Add(new Paragraph("Hello World"));
            doc.Close();
        }

        /// <summary>
        /// Alignment is one of the property of iTextSharp.text.Paragraph's object. iTextSharp Library provides various types of Alignments. These Alignments can be access through iTextSharp.text.Element class. The following are Alignment types provides iTextSharp
        /// </summary>
        static void AlignmentAlign()
        {
            var fs = new FileStream("Abc.pdf", FileMode.Create, FileAccess.Write, FileShare.None);
            var rec = new Rectangle(PageSize.A4);
            var doc = new Document(rec, 36, 72, 108, 180);
            var pdfWriter = PdfWriter.GetInstance(doc, fs);
            doc.Open();
            var paragraph = new Paragraph("Why do our headaches persist after we take a one-cent aspirin but disappear when we take a fifty-cent aspirin? Why do we splurge on a lavish meal but cut coupons to save twenty-five cents on a can of soup?");
            paragraph.Alignment = Element.ALIGN_JUSTIFIED;
            doc.Add(paragraph);
            paragraph = new Paragraph("When it comes to making decisions in our lives, we think we're making smart, rational choices. But are we?");
            doc.Add(paragraph);
            paragraph = new Paragraph("In this newly revised and expanded edition of the groundbreaking New York Times bestseller, Dan Ariely refutes the common assumption that we behave in fundamentally rational ways. From drinking coffee to losing weight, from buying a car to choosing a romantic partner, we consistently overpay, underestimate, and procrastinate. Yet these misguided behaviors are neither random nor senseless. They're systematic and predictable—making us predictably irrational.");
            //paragraph.Alignment = Element.ALIGN_JUSTIFIED;
            doc.Add(paragraph);
            doc.Add(paragraph);
            doc.Close();
        }
        /// <summary>
        /// Set info 
        /// </summary>
        static void SetMetaInformation()
        {
            var fs = new FileStream("Abc.pdf", FileMode.Create, FileAccess.Write, FileShare.None);
            var rec = new Rectangle(PageSize.A4);
            var doc = new Document(rec, 36, 72, 108, 180);
            

            var pdfWriter = PdfWriter.GetInstance(doc, fs);
            //add after creating pdfWriter
            doc.AddTitle("Hello World example");
            doc.AddSubject("This is an Example 4 of Chapter 1 of Book 'iText in Action'");
            doc.AddKeywords("Metadata, iTextSharp 5.4.4, Chapter 1, Tutorial");
            doc.AddCreator("iTextSharp 5.4.4");
            doc.AddAuthor("Debopam Pal");
            doc.AddHeader("Nothing", "No Header");
            doc.Open();
            doc.Add(new Paragraph("Hello World"));
            doc.Close();
        }

        static void CreateMultiPage()
        {
            var fs = new FileStream("Abc.pdf", FileMode.Create, FileAccess.Write, FileShare.None);
            var rec = new Rectangle(PageSize.A4);
            var doc = new Document(rec, 36, 72, 108, 180);
            var pdfWriter = PdfWriter.GetInstance(doc, fs);
            doc.Open();
            for (int i = 1; i <= 5; i++)
            {
                doc.NewPage();
                doc.Add(new Paragraph(string.Format("This is a page {0}", i)));
            }
            doc.Close();
        }

        static void CreateFromExistingPdf()
        {
            CreateSimplePdf();
            
            PdfReader reader = new PdfReader("Abc.pdf");
            var fs = new FileStream("Copy.pdf", FileMode.Create, FileAccess.Write, FileShare.None);
            using (PdfStamper stamper = new PdfStamper(reader, fs)) { }
        }

        static void AddWatermark()
        {
            CreateSimplePdf();

            var reader = new PdfReader("Abc.pdf");
            var watermarkText = "This is a test file";
            var fs = new FileStream("Copy.pdf", FileMode.Create, FileAccess.Write, FileShare.None);
            using (PdfStamper stamper = new PdfStamper(reader, fs))
            {
                // Getting total number of pages of the Existing Document
                int pageCount = reader.NumberOfPages;

                // Create New Layer for Watermark
                PdfLayer layer = new PdfLayer("WatermarkLayer", stamper.Writer);
                // Loop through each Page
                for (int i = 1; i <= pageCount; i++)
                {
                    // Getting the Page Size
                    Rectangle rect = reader.GetPageSize(i);

                    // Get the ContentByte object
                    PdfContentByte cb = stamper.GetUnderContent(i);

                    // Tell the cb that the next commands should be "bound" to this new layer
                    cb.BeginLayer(layer);
                    cb.SetFontAndSize(BaseFont.CreateFont(
                      BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED), 50);

                    PdfGState gState = new PdfGState();
                    gState.FillOpacity = 0.25f;
                    cb.SetGState(gState);

                    cb.SetColorFill(BaseColor.BLACK);
                    cb.BeginText();
                    cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, watermarkText, rect.Width / 2, rect.Height / 2, 45f);
                    cb.EndText();

                    // Close the layer
                    cb.EndLayer();
                }
            }
        }

        static void CreateMergedPDF(string targetPDF)
        {
            using (FileStream stream = new FileStream(targetPDF, FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A4);
                PdfCopy pdf = new PdfCopy(pdfDoc, stream);
                pdfDoc.Open();
                var files = new List<string>
                {
                    "Abc.pdf",
                    "Copy.pdf"
                };                
                int i = 1;
                foreach (string file in files)
                {
                    Console.WriteLine(i + ". Adding: " + file);
                    pdf.AddDocument(new PdfReader(file));
                    i++;
                }

                if (pdfDoc != null)
                    pdfDoc.Close();

                Console.WriteLine("SpeedPASS PDF merge complete.");
            }
        }
    }
}
