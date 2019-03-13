using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bkeproject
{

public class GameBoard{

         string[] array;
         
        public void board(){
            array = new string[]{" "," "," "," "," "," "," "," "," "};
        }
        
        //print nice spelbord
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

        public void drawOnBoard(int index, string output){
            array[index] = output; 
            printBoard();
        }

        public bool checkWinner1(int index, string namePlayer){
            if (((array[0] == "X" || array[0] == "O") && array[0] == array[1] && array[0] == array[2]) 
                ||((array[3] == "X" || array[3] == "O") && array[3] == array[4] && array[3] == array[5])
                ||((array[6] == "X" || array[6] == "O") && array[6] == array[7] && array[6] == array[8])
                ||((array[0] == "X" || array[0] == "O") && array[0] == array[3] && array[0] == array[6])
                ||((array[1] == "X" || array[1] == "O") && array[1] == array[4] && array[1] == array[7])
                ||((array[2] == "X" || array[2] == "O") && array[2] == array[5] && array[2] == array[8])
                ||((array[0] == "X" || array[0] == "O") && array[0] == array[4] && array[0] == array[8])
                ||((array[2] == "X" || array[2] == "O") && array[2] == array[4] && array[2] == array[6])){
                if(array[index] == "X"){
                    Console.WriteLine(namePlayer + ", jij hebt gewonnen!");
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

        public bool checkWinner2(int index, string namePlayer){
            if (((array[0] == "X" || array[0] == "O") && array[0] == array[1] && array[0] == array[2]) 
                ||((array[3] == "X" || array[3] == "O") && array[3] == array[4] && array[3] == array[5])
                ||((array[6] == "X" || array[6] == "O") && array[6] == array[7] && array[6] == array[8])
                ||((array[0] == "X" || array[0] == "O") && array[0] == array[3] && array[0] == array[6])
                ||((array[1] == "X" || array[1] == "O") && array[1] == array[4] && array[1] == array[7])
                ||((array[2] == "X" || array[2] == "O") && array[2] == array[5] && array[2] == array[8])
                ||((array[0] == "X" || array[0] == "O") && array[0] == array[4] && array[0] == array[8])
                ||((array[2] == "X" || array[2] == "O") && array[2] == array[4] && array[2] == array[6])){
                if(array[index] == "O"){
                   Console.WriteLine(namePlayer + ", jij hebt gewonnen!");
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

        public bool checkLocationFree(int currentIndex){
            if (array[currentIndex] == "X" || array[currentIndex] == "O"){
                return true;
            }
            else {
                return false;
            }
        }

    }
}
    