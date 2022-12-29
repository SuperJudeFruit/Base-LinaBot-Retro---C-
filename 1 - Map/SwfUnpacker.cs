using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using SwfDotNet.IO;
using SwfDotNet.IO.Tags;
using SwfDotNet.IO.ByteCode;
using SwfDotNet.IO.ByteCode.Actions;

class SwfUnpacker
{
    private string mapToDecompress = "";

    public void SwfUnpack(string FileName)
    {
        mapToDecompress = FileName;

        System.Threading.Thread Uncompresser = new System.Threading.Thread(UncompressSwf) { IsBackground = true };
        Uncompresser.Start();

        while (Uncompresser.IsAlive)
        {
            Application.DoEvents();
            System.Threading.Thread.Sleep(1);
        }
    }

    private void UncompressSwf()
    {
        try
        {
            if (!System.IO.Directory.Exists("temp"))
                System.IO.Directory.CreateDirectory("temp");

            My.Computer.Network.DownloadFile("http://dofusretro.cdn.ankama.com/maps/" + mapToDecompress, "temp/" + mapToDecompress);

            SwfReader swfReader = new SwfReader("temp/" + mapToDecompress);

            Swf swf = swfReader.ReadSwf();

            IEnumerator tagsEnu = swf.Tags.GetEnumerator();

            while (tagsEnu.MoveNext())
            {
                BaseTag tag = (BaseTag)tagsEnu.Current;

                if (tag.ActionRecCount != 0)
                {
                    string sb = "";
                    IEnumerator enum2 = tag.GetEnumerator();

                    while (enum2.MoveNext())
                    {
                        Decompiler dc = new Decompiler(swf.Version);
                        ArrayList actions = dc.Decompile((byte[])enum2.Current);

                        foreach (BaseAction obj in actions)
                            sb += obj.ToString() + Constants.vbCrLf;
                    }

                    string map_data = sb.ToString().Split(new string[] { "'" }, StringSplitOptions.None)(29);
                    string map_id = sb.ToString().Split(new string[] { "push" }, StringSplitOptions.None)(8).Split(new string[] { " " }, StringSplitOptions.None)(1);
                    string map_x = sb.ToString().Split(new string[] { "push" }, StringSplitOptions.None)(10).Split(new string[] { " " }, StringSplitOptions.None)(1);
                    string map_y = sb.ToString().Split(new string[] { "push" }, StringSplitOptions.None)(12).Split(new string[] { " " }, StringSplitOptions.None)(1);

                    string efileName = "Maps/" + mapToDecompress.Split(new string[] { "." }, StringSplitOptions.None)(0) + ".txt";
                    System.IO.StreamWriter writer = new System.IO.StreamWriter(efileName);
                    writer.Write(map_id + "|" + map_data + "|" + map_x + "|" + map_y);
                    writer.Close();
                }
            }

            My.Computer.FileSystem.DeleteFile("temp/" + mapToDecompress);
        }
        catch
        {
        }
    }
}
