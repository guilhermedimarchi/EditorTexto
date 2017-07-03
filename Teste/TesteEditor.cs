using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Editor;

namespace Teste
{
    [TestClass]
    public class TesteEditor
    {
        [TestMethod]
        public void InserirSimples1()
        {
            Text t = new Text();
            t.InsertLine("Primeira Linha", -1);
            t.InsertLine("Segunda Linha", 0);
            Assert.AreEqual(2, t.NumLines);
            Assert.AreEqual("Primeira Linha", t.FirstLine.Info);
        }
        
        [TestMethod]
        public void InserirSimples2()
        {
            Text t = new Text();
            t.InsertLine("Primeira Linha", -1);
            t.InsertLine("Segunda Linha", 0);
            Assert.AreEqual(2, t.NumLines);
            Assert.AreEqual("Segunda Linha", t.FirstLine.Next.Info);
        }

        [TestMethod]
        public void TestePonteiros1()
        {
            Text t = new Text();
            t.InsertLine("A1", -1);
            t.InsertLine("B2", 0);
            t.InsertLine("C3", 1);
            Assert.AreEqual(3, t.NumLines);
            Assert.AreEqual("B2", t.FirstLine.Next.Next.Prior.Info);
        }

        [TestMethod]
        public void Alterar1()
        {
            Text t = new Text();
            t.InsertLine("A1", -1);
            t.InsertLine("B2", 0);
            t.InsertLine("C3", 1);
            t.ChangeLine("B22", 1);
            Assert.AreEqual(3, t.NumLines);
            Assert.AreEqual("B22", t.FirstLine.Next.Next.Prior.Info);
        }

        [TestMethod]
        public void Remover1()
        {
            Text t = new Text();
            t.InsertLine("A1", -1);
            t.InsertLine("B2", 0);
            t.InsertLine("C3", 1);
            t.InsertLine("D4", 2);
            t.RemoveLine(1);
            Assert.AreEqual(3, t.NumLines);
            Assert.AreEqual("C3", t.FirstLine.Next.Next.Prior.Info);
        }

    }
}
