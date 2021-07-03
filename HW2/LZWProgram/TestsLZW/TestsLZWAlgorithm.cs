using LZWProgram;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace TestsLZW
{
    [TestClass]
    public class TestsLZWAlgorithm
    {
        private static bool IsSimilarFiles(string pathToCreateFile, string pathToRealFile)
        {
            using FileStream createFile = File.OpenRead(pathToCreateFile);
            using FileStream realFile = File.OpenRead(pathToRealFile);

            if (createFile.Length != realFile.Length)
            {
                return false;
            }

            for (int i = 0; i < createFile.Length; i++)
            {
                byte byteRealFile = (byte)realFile.ReadByte();
                byte byteCreateFile = (byte)createFile.ReadByte();

                if (byteRealFile != byteCreateFile)
                {
                    return false;
                }
            }

            return true;
        }

        [TestMethod]
        public void CompressDecompressTxtTest()
        {
            string pathToInitialFile = "../../../testTxt.txt";
            string pathToRealFile = "../../../testTxtReally.txt";
            string pathToCompressedFile = "../../../testTxt.txt.zipped";
            File.Delete(pathToInitialFile);
            LZWAlgorithm.Compress(pathToRealFile);
            File.Move(pathToRealFile + ".zipped", pathToCompressedFile);
            LZWAlgorithm.Decompress(pathToCompressedFile);
            File.Delete(pathToCompressedFile);

            Assert.IsTrue(IsSimilarFiles(pathToInitialFile, pathToRealFile));
            File.Delete(pathToInitialFile);
        }

        [TestMethod]
        public void CompressDecompressImageTest()
        {
            string pathToInitialFile = "../../../testImg.bmp";
            string pathToRealFile = "../../../testImgReally.bmp";
            string pathToCompressedFile = "../../../testImg.bmp.zipped";
            File.Delete(pathToInitialFile);
            LZWAlgorithm.Compress(pathToRealFile);
            File.Move(pathToRealFile + ".zipped", pathToCompressedFile);
            LZWAlgorithm.Decompress(pathToCompressedFile);
            File.Delete(pathToCompressedFile);

            Assert.IsTrue(IsSimilarFiles(pathToInitialFile, pathToRealFile));
            File.Delete(pathToInitialFile);
        }

        [TestMethod]
        public void CompressDecompressPdfTest()
        {
            string pathToInitialFile = "../../../testPdf.pdf";
            string pathToRealFile = "../../../testPdfReally.pdf";
            string pathToCompressedFile = "../../../testPdf.pdf.zipped";
            File.Delete(pathToInitialFile);
            LZWAlgorithm.Compress(pathToRealFile);
            File.Move(pathToRealFile + ".zipped", pathToCompressedFile);
            LZWAlgorithm.Decompress(pathToCompressedFile);
            File.Delete(pathToCompressedFile);

            Assert.IsTrue(IsSimilarFiles(pathToInitialFile, pathToRealFile));
            File.Delete(pathToInitialFile);
        }
    }
}