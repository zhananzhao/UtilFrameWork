namespace Util.Tests.Samples {
    public class Test3 {
        public string Name { get; set; }

        public static Test3 CreateA() {
            return new Test3 { Name = "A" };
        }

        public static Test3 CreateB() {
            return new Test3 { Name = "B" };
        }
    }
}
