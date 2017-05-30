using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Text.RegularExpressions;

/// <summary>
/// Summary description for ExportToWord
/// </summary>
public class ExportToWord
{
    public string GetPathFileName(string ServeMap, string Filename)
    {
        return ServeMap + @"Temp\" + Filename;
    }

    public string Export(string PathFile, List<string> lststr, List<string> lstReplace)
    {
        string PathNewFile = "";
        if (lststr.Count < lstReplace.Count)
            return "";
        byte[] byteArray = File.ReadAllBytes(PathFile);
        using (MemoryStream stream = new MemoryStream())
        {
            stream.Write(byteArray, 0, (int)byteArray.Length);
            using (WordprocessingDocument doc = WordprocessingDocument.Open(stream, true))
            {
                var body = doc.MainDocumentPart.Document.Body;

                foreach (var text in body.Descendants<Text>())
                {
                    // Duyet cac Tu can replace
                    for (int i = 0; i < lststr.Count; i++)
                    {
                        if (text.Text.Contains(lststr[i]))
                        {
                            text.Text = text.Text.Replace(lststr[i], lstReplace[i]);
                        }
                    }
                }
                #region block
                // code replace noi dung trong cac element
                //var paras = body.Elements<Paragraph>();
                //foreach (var para in paras)
                //{
                //    //for (int i = 0; i < lststr.Count; i++)
                //    //{
                //    //    if (para.InnerText.Contains(lststr[i]))
                //    //       {
                //    //           string modifiedString = Regex.Replace(para.InnerText, lststr[i], lstReplace[i]);
                //    //           //Style stl = para.FirstChild.Elements<Style>();/// .RemoveAllChildren<Run>();
                //    //           RunProperties t = (RunProperties)para.Elements<Run>().First().RunProperties.CloneNode(true);
                //    //           Run r = new Run(new Text(modifiedString));
                //    //           r.PrependChild<RunProperties>(t);
                //    //            para.RemoveAllChildren<Run>();
                //    //            para.AppendChild<Run>(r);
                //    //            //para.Append<par
                //    //           //para.InnerText = para.InnerText.Replace(lststr[i], lstReplace[i]);
                //    //       }
                //    //    //foreach (var text in para.Elements<Text>())
                //    //    //{
                //    //    //    if (text.Text.Contains(lststr[i]))
                //    //    //    {
                //    //    //        text.Text = text.Text.Replace(lststr[i], lstReplace[i]);
                //    //    //    }
                //    //    //}

                //    //}
                // Code goc
                //    foreach (var run in para.Elements<Run>())
                //    {
                //        // Duyet cac Tu can replace
                //        for (int i = 0; i < lststr.Count; i++)
                //        {
                //            foreach (var text in run.Elements<Text>())
                //            {
                //                if (text.Text.Contains(lststr[i]))
                //                {
                //                    text.Text = text.Text.Replace(lststr[i], lstReplace[i]);
                //                }
                //            }

                //        }

                //    }
                //}
                #endregion
            }
            DateTime MyDatetime = DateTime.Now;
            PathNewFile = (Path.GetFullPath(PathFile).Substring(0, PathFile.LastIndexOf("\\"))).Replace("Temp", "Temp2\\") + "/Temp/" + Path.GetFileName(PathFile).Split('.')[0] + MyDatetime.Day + MyDatetime.Month + MyDatetime.Year + MyDatetime.Hour + MyDatetime.Minute + MyDatetime.Second + ".docx";
            File.WriteAllBytes(PathNewFile, stream.ToArray());
        }
        return PathNewFile;
    }
}