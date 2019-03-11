﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bkeproject
{
    
    class Program
    {
        static void DisplayArray(string[] array){
            Console.WriteLine(String.Join(" ", array));
        }

        string namePlayer1;
        string namePlayer2;
        string inputPlayer1;
        string inputPlayer2;
        string[] array;

        static void Main(string[] args){
            Program test = new Program();
            //test.explanation();
            //test.startPlayer();
            //test.drawEmptyBoard();
            test.board();
            test.printBoard(); 
            //test.setFirst();
            test.changeGameboard();
        }

        //uitleg spel + print number board
        public void explanation(){
            string explanation = "Welkom bij het spel boter-kaas-en-eieren! Dit spel speel je met twee spelers.\n"+
            "Zoals je wellicht weet wordt het spel gespeeld op een speelveld van 3 bij 3 hokjes. In het begin\n" +
            "zijn alle velden leeg. De eerste speler zet een 'X' en de andere speler een 'O'. Degene die 3 van\n" +
            "zijn eigen tekens op een rij heeft (diagonaal, verticaal, of horizontaal), WINT!\n"+
            "Elke hokje heeft een nummer (zie het spelbord hieronder). Je plaatst een 'X' of een 'O' door het\n"+
            "nummer in te typen van het hokje waarin jij jouw symbool wilt plaatsen. Zie het speelveld hieronder:"; 
            Console.WriteLine(explanation);
            drawNumberBoard();
        }
        
        //welke speler mag beginnen? (random)
        public string namePlayerOne(){
            string introduction = "Om te bepalen wie er mag beginnen, hebben we jullie namen nodig!";
            Console.WriteLine(introduction);
            Console.WriteLine("Uitdager, wat is je naam?");
            namePlayer1 = Console.ReadLine();
            return namePlayer1;
        }
        public string namePlayerTwo(){    
            Console.WriteLine("En tegenstander, wat is jouw naam?");
            namePlayer2 = Console.ReadLine();
            Console.WriteLine("Hi, " + namePlayer2);
            return namePlayer2;
        }

        public void startPlayer(){
            namePlayerOne();
            namePlayerTwo();
            Random number = new Random();
            var test = number.Next(0, 2);
            //Console.WriteLine(test);
            if (test == 1){
                Console.WriteLine(namePlayer1 + ", jij mag beginnen!");
            }
            else {
                Console.WriteLine(namePlayer2 + ", jij mag beginnen!");
            }
        }

        public void drawNumberBoard(){
            int[] arrayNumber = new int[]{1, 2, 3, 4, 5, 6, 7, 8, 9};
            int rowLength = arrayNumber.GetLength(0);
            Console.Write("------------------\n");
            for (int i = 0; i < rowLength; i++){
            Console.Write(string.Format("  {0}  ", arrayNumber[i]));  
            if (i % 3 == 2){
                Console.Write("\n");
                Console.Write("------------------\n");
            }
            else {
                Console.Write("|");
            }
            }   
        }

         public void board(){
            array = new string[]{" "," "," "," "," "," "," "," "," "};
        }
        
        //pint nice spelbord
        public void printBoard(){
            int rowLength = array.GetLength(0);
            Console.Write("------------------\n");
            for (int i = 0; i < rowLength; i++){
            Console.Write(string.Format("  {0}  ", array[i]));  
            if (i % 3 == 2){
                Console.Write("\n");
                Console.Write("------------------\n");
            }
            else {
                Console.Write("|");
            }
            }
        }

        public void changeGameboard(){
            bool winner = false;
            while(winner == false){
                var index1 = 0;
                bool check1a = true;
                bool check1b = true;
                bool check1c = true;
                while(check1a == true || check1b == true || check1c == true){
                    Console.WriteLine(namePlayer1+ ", wat is jouw set?");
                    inputPlayer1 = Console.ReadLine();
                    check1c = checkLetter(inputPlayer1);
                    if (check1c == false){
                        var numberInputPlayer1 = int.Parse(inputPlayer1);
                        index1 = numberInputPlayer1 - 1;
                        check1a = checkInput1(index1);
                        check1b = checkInput2(numberInputPlayer1);
                    }
                }
                array[index1] = "X"; 
                printBoard();
                winner = checkWinner();
                check1a = true;
                check1b = true;
                check1c = true;

                var index2 = 0;
                bool check2a = true;
                bool check2b = true;
                bool check2c = true;
                while(check2a == true || check2b == true || check2c == true){
                    Console.WriteLine(namePlayer2+ ", wat is jouw set?");
                    inputPlayer2 = Console.ReadLine();
                    check2c = checkLetter(inputPlayer2);
                    if (check2c == false){
                        var numberInputPlayer2 = int.Parse(inputPlayer2);
                        index2 = numberInputPlayer2 - 1;
                        check2a = checkInput1(index2);
                        check2b = checkInput2(numberInputPlayer2);
                    }
                    winner = checkWinner();
                }
                array[index2] = "O"; 
                printBoard();
                winner = checkWinner();
                }
        }

        public bool checkInput1(int currentIndex){
            var input = currentIndex + 1;
            if(input >= 1 && input <= 9){
                if(array[currentIndex] == "X" || array[currentIndex] == "O"){
                Console.WriteLine("Dit hokje is al bezet! Kies een ander hokje.");
                return true;
                }
                else{
                    return false;
                }
            }
            else{
            return false;
            }
        } 
        public bool checkInput2(int inputPlayer){
            if(inputPlayer > 9 || inputPlayer < 1){
                Console.WriteLine("Dit getal is ongeldig! Kies een getal tussen 1 en 9.");
                return true;
            }
            else{
            return false;
            }
        } 

        public bool checkLetter(string input){ 
            long number1 = 0;
            bool canConvert = long.TryParse(input, out number1);
            if(canConvert == false){
                Console.WriteLine("Dit is geen getal! Kies een getal tussen 1 en 9:");
                return true;
            }
            else {
                return false;
            }
        }

        public bool checkWinner(){
            if ((array[0] == array[1] && array[0] == array[2])){
                //||(array[3] == array[4] && array[3] == array[5])
                //||(array[6] == array[7] && array[6] == array[8])
                //||(array[0] == array[3] && array[0] == array[6])
                //||(array[1] == array[4] && array[1] == array[7])
                //||(array[2] == array[5] && array[2] == array[8])
                //||(array[0] == array[4] && array[0] == array[8])
                //||(array[2] == array[4] && array[2] == array[6])
                if(array[0] == "X"){
                    Console.WriteLine(namePlayer1 + " jij hebt gewonnen!");
                    return true;
                }
                if(array[0] == "O"){
                   Console.WriteLine(namePlayer2 + " jij hebt gewonnen!");
                   return true;
                }
                else{
                    return false;
                }
            }
            else {
                return false;
            }
        }
    }
}

//string[] result = Array.ConvertAll(array, x=>x.ToString());
//DisplayArray(result);

  //array[index1] = "X"; 
            //winner = checkWinner();
            //printBoard();

            /*var index2 = 0;
            bool check2a = true;
            bool check2b = true;
            bool check2c = true;
            while(check2a == true || check2b == true || check2c == true){
                Console.WriteLine(namePlayer2+ ", wat is jouw set?");
                inputPlayer2 = Console.ReadLine(); 
                check2c = checkLetter(inputPlayer2);
                if (check2c == false){  
                    var numberInputPlayer2 = int.Parse(inputPlayer2);
                    index2 = numberInputPlayer2 - 1;
                    check2a = checkInput1(index2);
                    check2b = checkInput2(numberInputPlayer2);
                }
            }
                array[index2] = "O";
                winner = checkWinner();
                printBoard();*/

