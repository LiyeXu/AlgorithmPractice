using System;
using Algorithm.Graph;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Diagnostics;

namespace Algorithm.UnitTest
{
    [TestClass]
    public class GraphCloneTest
    {
        [TestMethod, TestCategory("Graph")]
        public void BfsCloneTest()
        {
            // a <-> b
            // a -> c
            // a -> d
            // a -> e <-> f            
            Trace.WriteLine("init graph");
            var a = new Graph<string>("a");
            var b = new Graph<string>("b");
            var c = new Graph<string>("c");
            var d = new Graph<string>("d");
            var e = new Graph<string>("e");
            var f = new Graph<string>("f");
            a.LinkTo(b);
            b.LinkTo(a);
            a.LinkTo(c);
            a.LinkTo(d);
            a.LinkTo(e);
            e.LinkTo(f);
            f.LinkTo(e);
            f.LinkTo(b);
            Trace.WriteLine("clone...");
            var a2 = a.BfsClone();
            Trace.WriteLine("done!");
            Assert.AreEqual(b.Payload, 
                a2.Neighbors.First(v=>v.Payload=="e")
                .Neighbors.First(v=>v.Payload=="f")
                .Neighbors.First(v => v.Payload == "b").Payload);
        }
    }
}
