﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bkeproject
{
    public class Program
    {
        static void Main(string[] args){
            var game = new Game();
            game.explanation();  
            game.startPlayer();
            game.changeGameboard();
        }
    }
}

