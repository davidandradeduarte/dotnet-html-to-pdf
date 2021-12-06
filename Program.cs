using DinkToPdf;

var converter = new BasicConverter(new PdfTools());

string template = System.IO.File.ReadAllText(@"template.html");

var doc = new HtmlToPdfDocument
{
    GlobalSettings = {
        ColorMode = ColorMode.Color,
        Orientation = Orientation.Portrait,
        PaperSize = PaperKind.A4Plus,
        Out = "test.pdf"
    },
    Objects = {
        new ObjectSettings
        {
            Page = "https://google.com/",
        },
        new ObjectSettings
        {
            PagesCount = true,
            HtmlContent = "template.html",
            WebSettings = { DefaultEncoding = "utf-8" },
            HeaderSettings = { FontSize = 9, Right = "Page [page] of [toPage]", Line = true, Spacing = 2.812 }
        },
        new ObjectSettings
        {
            PagesCount = true,
            HtmlContent = template,
            WebSettings = { DefaultEncoding = "utf-8" },
            HeaderSettings = { FontSize = 9, Right = "Page [page] of [toPage]", Line = true, Spacing = 2.812 }
        },
        new ObjectSettings
        {
            PagesCount = true,
            HtmlContent = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. In consectetur mauris eget ultrices  iaculis. Ut                               odio viverra, molestie lectus nec, venenatis turpis.",
            WebSettings = { DefaultEncoding = "utf-8" },
            HeaderSettings = { FontSize = 9, Right = "Page [page] of [toPage]", Line = true, Spacing = 2.812 }
        },
        new ObjectSettings
        {
            PagesCount = true,
            HtmlContent = @"<html><h1>Hello, world</h1></html>",
            WebSettings = { DefaultEncoding = "utf-8" },
            HeaderSettings = { FontSize = 9, Right = "Page [page] of [toPage]", Line = true, Spacing = 2.812 }
        }
    }
};

converter.Convert(doc);
