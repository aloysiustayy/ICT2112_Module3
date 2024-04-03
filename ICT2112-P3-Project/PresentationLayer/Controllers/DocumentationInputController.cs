using DomainLayer.Control;
using DomainLayer.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace PresentationLayer.Controllers
{
    public class DocumentationInputController : Controller
    {
        private readonly SafetyChecklistControl _safetyChecklistControl;

        public DocumentationInputController(SafetyChecklistControl safetyChecklistControl)
        {
            _safetyChecklistControl = safetyChecklistControl;
        }

        public IActionResult SafetyChecklist()
        {
            // Dummy data version or initial loading logic
            var dummySafetyChecklist = new SafetyChecklist
            {
                LocationCategory = "dummy",
                RiskTitle = "dummy",
                RiskComment = "dummy",
                RiskDescription = "dummy",
                PhotoId = 1 // Assuming a placeholder photo ID
            };
            return View(dummySafetyChecklist);
        }

        [HttpPost]
        public IActionResult UpdateSafetyChecklist(SafetyChecklist safetyChecklist)
        {
            // Update the safety checklist data
            _safetyChecklistControl.UpdateSafetyChecklist(safetyChecklist);
            return RedirectToAction("SafetyChecklist");
        }

        [HttpPost] // Handle POST requests for exporting to PDF
        public IActionResult ExportSafetyChecklistToPDF([FromBody] List<SafetyChecklist> safetyChecklists)
        {
            // Generate PDF content
            byte[] pdfBytes = GeneratePdf(safetyChecklists);

            // Return the PDF file as a file download
            return File(pdfBytes, "application/pdf", "SafetyChecklist.pdf");
        }

        public IActionResult Documentation()
        {
            // Return the Documentation view
            return View("~/Views/SafetyChecklist/Documentation.cshtml");
        }

        private byte[] GeneratePdf(IEnumerable<SafetyChecklist> safetyChecklists)
        {
            // Create a memory stream to store the PDF content
            using (MemoryStream stream = new MemoryStream())
            {
                // Create a PdfWriter to write to the memory stream
                using (PdfWriter writer = new PdfWriter(stream))
                {
                    // Create a PdfDocument
                    using (PdfDocument pdf = new PdfDocument(writer))
                    {
                        // Create a Document
                        Document document = new Document(pdf);

                        // Add content to the document
                        foreach (var checklist in safetyChecklists)
                        {
                            // Add checklist data to the document
                            document.Add(new Paragraph($"Location Category: {checklist.LocationCategory}"));
                            document.Add(new Paragraph($"Risk Title: {checklist.RiskTitle}"));
                            document.Add(new Paragraph($"Risk Comment: {checklist.RiskComment}"));
                            document.Add(new Paragraph($"Risk Description: {checklist.RiskDescription}"));
                            document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE)); // Add a page break
                        }
                    }
                }

                // Return the PDF content as bytes
                return stream.ToArray();
            }
        }
    }
}