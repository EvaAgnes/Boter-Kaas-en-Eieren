using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bkeproject
{

    public class GameBoard{

        string[] array;
         
        public void Board(){
            array = new string[]{" "," "," "," "," "," "," "," "," "};
        }
        
        //print nice spelbord
        public void PrintBoard(string[] boardArray){
            int rowLength = boardArray.GetLength(0);
            Console.Write("------------------\n");
            for (int i = 0; i < rowLength; i++){
            Console.Write(string.Format("  {0}  ", boardArray[i]));  
            if (i % 3 == 2){
                Console.Write("\n");
                Console.Write("------------------\n");
            }
            else {
                Console.Write("|");
            }
            }
        }

         public void DrawNumberBoard(){
            string[] arrayNumber = new string[]{"1", "2", "3", "4", "5", "6", "7", "8", "9"};
            PrintBoard(arrayNumber);
        }

        public void PrintEmptyBoard(){
            Console.WriteLine(PrintBoard(array));

        }

        public void DrawOnBoard(int index, string output){
            array[index] = output; 
            PrintBoard(array);
        }

        public bool CheckWinner(int index, string namePlayer){
            if (((array[0] == "X" || array[0] == "O") && array[0] == array[1] && array[0] == array[2]) 
                ||((array[3] == "X" || array[3] == "O") && array[3] == array[4] && array[3] == array[5])
                ||((array[6] == "X" || array[6] == "O") && array[6] == array[7] && array[6] == array[8])
                ||((array[0] == "X" || array[0] == "O") && array[0] == array[3] && array[0] == array[6])
                ||((array[1] == "X" || array[1] == "O") && array[1] == array[4] && array[1] == array[7])
                ||((array[2] == "X" || array[2] == "O") && array[2] == array[5] && array[2] == array[8])
                ||((array[0] == "X" || array[0] == "O") && array[0] == array[4] && array[0] == array[8])
                ||((array[2] == "X" || array[2] == "O") && array[2] == array[4] && array[2] == array[6])){
                Console.WriteLine(namePlayer + ", jij hebt gewonnen!");
                return true;
                }
            else {
                return false;
            }
        }

        public bool CheckLocationFree(int currentIndex){
            if (array[currentIndex] == "X" || array[currentIndex] == "O"){
                return true;
            }
            else {
                return false;
            }
        }

        public bool CheckDraw(){
            if ((array[0] == "X" || array[0] == "O") && (array[1] == "X" || array[1] == "O") && (array[2] == "X" || array[2] == "O") &&
            (array[3] == "X" || array[3] == "O") && (array[4] == "X" || array[4] == "O") && (array[5] == "X" || array[5] == "O") &&
            (array[6] == "X" || array[6] == "O") && (array[7] == "X" || array[7] == "O") && (array[8] == "X" || array[8] == "O")){
                Console.WriteLine("Het is gelijkspel!");
                return true;
            }
            else {
                return false;
            }
        }
    }
}
    