using NUnit.Framework;
using Routers;
using System.IO;

namespace RoutersTests
{
    /// <summary>
    /// Class with tests of Kruskal's algorithm
    /// </summary>
    public class AlgorithmTests
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

        private void PrintBytes(string pathToCreateFile, string pathToRealFile)
        {
            using FileStream createFile = File.OpenRead(pathToCreateFile);
            using FileStream realFile = File.OpenRead(pathToRealFile);

            for (int i = 0; i < createFile.Length; i++)
            {
                System.Console.Write($"{createFile.ReadByte()} ");
            }

            System.Console.WriteLine();

            for (int i = 0; i < realFile.Length; i++)
            {
                System.Console.Write($"{realFile.ReadByte()} ");
            }
        }

        [Test]
        public void AlgorithmTaskTest()
        {
            var startMatrix = new int[3, 3] { { 0, 10, 5 }, { 10, 0, 1 }, { 5, 1, 0 } };

            var resultMatrix = new int[3, 3] { { 0, 10, 5 }, { 10, 0, 0 }, { 5, 0, 0 } };

            Assert.AreEqual(resultMatrix, Algorithm.KruskullsAlgorithm(startMatrix));
        }

        [Test]
        public void AlgorithmTaskWriteInFileTest()
        {
            var startPath = "../../../TaskTest.txt";
            var resultPath = "../../../TaskTestResult.txt";
            var corretFilePath = "../../../TaskTestR.txt";

            FileFunctions.WriteInFile(Algorithm.KruskullsAlgorithm(FileFunctions.CreateGraph(startPath)), resultPath);

            Assert.IsTrue(IsSimilarFiles(resultPath, corretFilePath));
            File.Delete(resultPath);
        }

        [Test]
        public void ExceptionAlgorithmTaskWriteInFileTest()
        {
            var startPath = "../../../ErrorTest.txt";
            var resultPath = "../../../ErrorTestResult.txt";

            Assert.Catch<DisconnectedNetworkException>(() => FileFunctions.WriteInFile(Algorithm.KruskullsAlgorithm(FileFunctions.CreateGraph(startPath)), resultPath));
            File.Delete(resultPath);
        }

        [Test]
        public void AlgorithmPersonalWriteInFileTest()
        {
            var startPath = "../../../PersonalTest.txt";
            var resultPath = "../../../PersonalTestResult.txt";
            var corretFilePath = "../../../PersonalTestR.txt";

            FileFunctions.WriteInFile(Algorithm.KruskullsAlgorithm(FileFunctions.CreateGraph(startPath)), resultPath);

            PrintBytes(resultPath, corretFilePath);

            Assert.IsTrue(IsSimilarFiles(resultPath, corretFilePath));
            File.Delete(resultPath);
        }
    }
}