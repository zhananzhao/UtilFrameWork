namespace Util.Webs.Tests.Samples {
    public class A {
        public string Name { get; set; }
        public B B { get; set; }
    }

    public class B {
        public string Name { get; set; }
        public C C { get; set; }
    }

    public class C {
        public string Name { get; set; }
        public A A { get; set; }
    }
}
