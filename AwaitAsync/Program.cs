using System;
using System.Runtime.CompilerServices;

namespace AwaitAsync
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Test();
        }

        static async void Test()
        {
            await (await await false && await true);
        }
    }

    internal static class BoolExtensions
    {
        public static BoolAwaiter GetAwaiter(this bool value) => new BoolAwaiter(value);
    }


    internal class BoolAwaiter : INotifyCompletion
    {
        private readonly bool _value;
        public BoolAwaiter(bool value) => _value = value;

        public bool IsCompleted => true;
        public void OnCompleted(Action continuation) { }
        public bool GetResult() => _value;
    }
}