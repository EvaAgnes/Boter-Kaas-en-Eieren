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
            board.Board();
            }
        
        public void ShowExplanation(){
            string explanation = "Welkom bij het spel boter-kaas-en-eieren! Dit spel speel je met twee spelers.\n"+
            "Zoals je wellicht weet wordt het spel gespeeld op een speelveld van 3 bij 3 hokjes. In het begin\n" +
            "zijn alle velden leeg. De eerste speler zet een 'X' en de andere speler een 'O'. Degene die 3 van\n" +
            "zijn eigen tekens op een rij heeft (diagonaal, verticaal, of horizontaal), WINT!\n"+
            "Elke hokje heeft een nummer (zie het spelbord hieronder). Je plaatst een 'X' of een 'O' door het\n"+
            "nummer in te typen van het hokje waarin jij jouw symbool wilt plaatsen. Zie het speelveld hieronder:"; 
            Console.WriteLine(explanation);
            board.DrawNumberBoard();
        }

       

    //welke speler mag beginnen? (random)
        private void NamePlayers(){
            string introduction = "Om te bepalen wie er mag beginnen, hebben we jullie namen nodig!";
            Console.WriteLine(introduction);
            Console.WriteLine("Uitdager, wat is je naam?");
            namePlayerStart1 = Console.ReadLine();
            Console.WriteLine("En tegenstander, wat is jouw naam?");
            namePlayerStart2 = Console.ReadLine();
        }

        public void GetFirstPlayer(){
            NamePlayers();
            Random number = new Random();
            var randomNumber = number.Next(0, 2);
            if (randomNumber == 1){
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

        public void ChangeGameboard(){
            bool winner = false;
            bool draw = false;
            while(winner == false){
                bool check1A = true;
                bool check1B = true;
                bool check1C = true;
                while(check1A == true || check1B == true || check1C == true){
                    Console.WriteLine(namePlayer1+ ", wat is jouw set?");
                    inputPlayer1 = Console.ReadLine();
                    check1C = CheckLetter(inputPlayer1);
                    if (check1C == false){
                        var numberInputPlayer1 = int.Parse(inputPlayer1);
                        index1 = numberInputPlayer1 - 1;
                        check1A = CheckInput1(index1);
                        check1B = CheckInput2(numberInputPlayer1);
                    }
                }
                board.DrawOnBoard(index1, "X");
                winner = board.CheckWinner(index1, namePlayer1);
                draw = board.CheckDraw();
                if(winner == true || draw == true){
                    Console.Read();
                    break;
                }
                check1A = true;
                check1B = true;
                check1C = true;

                bool check2A = true;
                bool check2B = true;
                bool check2C = true;
                while(check2A == true || check2B == true || check2C == true){
                    Console.WriteLine(namePlayer2 + ", wat is jouw set?");
                    inputPlayer2 = Console.ReadLine();
                    check2C = CheckLetter(inputPlayer2);
                    if (check2C == false){
                        var numberInputPlayer2 = int.Parse(inputPlayer2);
                        index2 = numberInputPlayer2 - 1;
                        check2A = CheckInput1(index2);
                        check2B = CheckInput2(numberInputPlayer2);
                    }
                }
                board.DrawOnBoard(index2, "O");
                winner = board.CheckWinner(index2, namePlayer2);
                draw = board.CheckDraw();
                if(winner == true || draw == true){
                    Console.Read();
                    break;
                }
            }
        }

        private bool CheckInput1(int currentIndex){
            var input = currentIndex + 1;
            if(input >= 1 && input <= 9){
                if(board.CheckLocationFree(currentIndex) == true){
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
        private bool CheckInput2(int inputPlayer){
            if(inputPlayer > 9 || inputPlayer < 1){
                Console.WriteLine("Dit getal is ongeldig! Kies een getal tussen 1 en 9.");
                return true;
            }
            else{
            return false;
            }
        } 

        private bool CheckLetter(string input){ 
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