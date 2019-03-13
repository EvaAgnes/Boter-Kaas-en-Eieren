using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bkeproject
{
    public class Game{
        string namePlayerStart1;
        string namePlayerStart2;
        string namePlayer1;
        string namePlayer2;
        string inputPlayer1;
        string inputPlayer2;
        int index1;
        int index2;
        GameBoard board;

        public Game(){
            board = new GameBoard();
            board.board();
            }
        
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

    //welke speler mag beginnen? (random)
        public void namePlayers(){
            string introduction = "Om te bepalen wie er mag beginnen, hebben we jullie namen nodig!";
            Console.WriteLine(introduction);
            Console.WriteLine("Uitdager, wat is je naam?");
            namePlayerStart1 = Console.ReadLine();
            Console.WriteLine("En tegenstander, wat is jouw naam?");
            namePlayerStart2 = Console.ReadLine();
        }

        public void startPlayer(){
            namePlayers();
            Random number = new Random();
            var test = number.Next(0, 2);
            if (test == 1){
                Console.WriteLine(namePlayerStart1 + ", jij mag beginnen!");
                namePlayer1 = namePlayerStart1;
                namePlayer2 = namePlayerStart2;
            }
            else {
                Console.WriteLine(namePlayer2 + ", jij mag beginnen!");
                namePlayer1 = namePlayerStart2;
                namePlayer2 = namePlayerStart1;
            }
        }

        public void changeGameboard(){
            bool winner = false;
            while(winner == false){
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
                board.drawOnBoard(index1, "X");
                winner = board.checkWinner1(index1, namePlayer1);
                if(winner == true){
                    break;
                }
                check1a = true;
                check1b = true;
                check1c = true;

                bool check2a = true;
                bool check2b = true;
                bool check2c = true;
                while(check2a == true || check2b == true || check2c == true){
                    Console.WriteLine(namePlayer2 + ", wat is jouw set?");
                    inputPlayer2 = Console.ReadLine();
                    check2c = checkLetter(inputPlayer2);
                    if (check2c == false){
                        var numberInputPlayer2 = int.Parse(inputPlayer2);
                        index2 = numberInputPlayer2 - 1;
                        check2a = checkInput1(index2);
                        check2b = checkInput2(numberInputPlayer2);
                    }
                }
                board.drawOnBoard(index2, "O");
                winner = board.checkWinner2(index2, namePlayer2);
                if(winner == true){
                    break;
                }
                }
        }

        public bool checkInput1(int currentIndex){
            var input = currentIndex + 1;
            if(input >= 1 && input <= 9){
                if(board.checkLocationFree(currentIndex) == true){
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
    }
}