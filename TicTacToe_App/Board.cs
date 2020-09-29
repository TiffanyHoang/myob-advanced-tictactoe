using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe_App
{
    public class Board
    {
        public TokenType[][] Grid{ get; set; }

        public Board()
        {
            Grid = new TokenType[][] {
               new TokenType[] { TokenType.Empty, TokenType.Empty, TokenType.Empty },
               new TokenType[] { TokenType.Empty, TokenType.Empty, TokenType.Empty },
               new TokenType[] { TokenType.Empty, TokenType.Empty, TokenType.Empty }
            };
        }
    }
}
