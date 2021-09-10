# QR_Code_Generator

How to create QR code in dotnet core 

//    1. ZXing.Net
        //PM> Install-Package ZXing.Net
        //2. ZXing.Net.Bindings.CoreCompat.System.Drawing
        //PM> Install-Package ZXing.Net.Bindings.CoreCompat.System.Drawing -Version 0.16.5-beta
        //To work with images we will also need to install System.Drawing.Common package. It’s command is:
        //Install-Package System.Drawing.Common
    Create QR Codes
In your controller import the following namespaces:

1
2
3
4
5
6
7
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using ZXing;
using ZXing.QrCode;
Next add Index Action methods in your controller whose codes are given below:

1
2
3
4
5
6
7
8
9
10
11
12
13
14
15
16
17
18
19
20
21
22
23
24
25
26
27
28
29
30
31
32
33
34
35
36
37
38
39
40
41
42
43
44
45
46
47
public IActionResult Index()
{
    return View();
}
 
[HttpPost]
public IActionResult Index(string qrText)
{
    Byte[] byteArray;
    var width = 250; // width of the Qr Code   
    var height = 250; // height of the Qr Code   
    var margin = 0;
    var qrCodeWriter = new ZXing.BarcodeWriterPixelData
    {
        Format = ZXing.BarcodeFormat.QR_CODE,
        Options = new QrCodeEncodingOptions
        {
            Height = height,
            Width = width,
            Margin = margin
        }
    };
    var pixelData = qrCodeWriter.Write(qrText);
 
    // creating a bitmap from the raw pixel data; if only black and white colors are used it makes no difference   
    // that the pixel data ist BGRA oriented and the bitmap is initialized with RGB   
    using (var bitmap = new System.Drawing.Bitmap(pixelData.Width, pixelData.Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb))
    {
        using (var ms = new MemoryStream())
        {
            var bitmapData = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, pixelData.Width, pixelData.Height), System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            try
            {
                // we assume that the row stride of the bitmap is aligned to 4 byte multiplied by the width of the image   
                System.Runtime.InteropServices.Marshal.Copy(pixelData.Pixels, 0, bitmapData.Scan0, pixelData.Pixels.Length);
            }
            finally
            {
                bitmap.UnlockBits(bitmapData);
            }
            // save to stream as PNG   
            bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            byteArray = ms.ToArray();
        }
    }
    return View(byteArray);
}
Explanation: The [HttpPost] type of Index action gets the text (for which the QR Code has to be generated) in the ‘qrText’ string variable given in it’s parameter.

I first Initialize the BarcodeWriterPixelData class and then called it’s Write method to generate the ‘raw pixel data’ of the QR Code. Notice that I pass the text string to this method:
var pixelData = qrCodeWriter.Write(qrText);
Next, I create a bitmap from raw pixel data of the QR Code:

var bitmap = new System.Drawing.Bitmap(pixelData.Width, pixelData.Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
I then use the MemoryStream Class to change this Bitmap to a stream of PNG. Then finally get the byte[] array of this stream.

bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
byteArray = ms.ToArray();
I return this byte[] array value to the View where the bitmap code is displayed from this byte[] array value.

Create the “Index” view and add the following code to it:

1
2
3
4
5
6
7
8
9
10
11
12
13
14
15
16
17
18
19
20
21
22
23
24
25
26
27
28
@model Byte[]
@using (Html.BeginForm(null, null, FormMethod.Post))
{
    <table>
        <tbody>
            <tr>
                <td>
                    <label>Enter text for creating QR Code</label>
                </td>
                <td>
                    <input type="text" name="qrText" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <button>Submit</button>
                </td>
            </tr>
        </tbody>
    </table>
}
@{
    if (Model != null)
    {
        <h3>QR Code Successfully Generated</h3>
        <img src="@String.Format("data:image/png;base64,{0}", Convert.ToBase64String(Model))" />
    }
}
Explanation: The view has a form where the user enters the string in the text box. Once the QR Code is generated then the view gets it’s byte[] array value in it’s Model. This QR Code is displayed as an image by the img tag as shown below:
<img src="@String.Format("data:image/png;base64,{0}", Convert.ToBase64String(Model))" />
Testing
Run your application and open the URL of the Index action method in the browser. Enter any value in the text box and click the Submit button. You will see the QR Code is created and shown on the browser.

See the below video which explains it’s working:

ZXing.Net QR Code Generation
Create QR Code files
Here I will create QR Code files. These QR Code files will be stored inside the wwwroot/qrr folder of your application.

First create a new folder called “qrr” inside the ‘wwwroot’ folder of your app. Next, create GenerateFile() index methods inside the Controller, as shown below:

