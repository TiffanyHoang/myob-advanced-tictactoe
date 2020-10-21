using System;
using Xunit;
using System.Collections.Generic;
using TicTacToe_App;

namespace TicTacToe_Tests
{
    public class TestRead
    {
        private readonly Queue<string> _value = new Queue<string>();

        public void SetToBeRead(string value) => _value.Enqueue(value);

        public string Read() => _value.Dequeue();
    }
}