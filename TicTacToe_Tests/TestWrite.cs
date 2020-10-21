using System;
using Xunit;
using System.Collections.Generic;
using TicTacToe_App;

namespace TicTacToe_Tests
{
    public class TestWrite
    {
        private readonly Queue<string> _value = new Queue<string>();

        public void Write(string text) => _value.Enqueue(text);

        public string GetText() => _value.Dequeue();

        public bool HasText(string text)
        {
            var hasText = 0;
            foreach (var value in _value)
            {
                if (value.Contains(text))
                {
                    hasText += 1; 
                }
            }
            return hasText != 0;
        }
    }
}