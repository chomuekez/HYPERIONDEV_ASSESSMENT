
        /*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package recursion;

/**
 *
 * @author user
 */
import java.util.Scanner;
import static javafx.scene.input.KeyCode.T;

public class Recursion {
public static void main(String[] args) {
// Saves the string that would be reversed
Scanner sc = new Scanner(System.in);
System.out.println("ENTER YOUR STRING : ");
 if(sc.hasNext("[A-Za-z]*")) {


String myString = sc.nextLine();
//String myStr = "emosewA si avaJ";
//create Method and pass and input parameter string

String reversed = reverse_string(myString);

 
 

System.out.println("The reversed string is: " + reversed);
 }
 else{
 System.out.println("Please Enter a Valid string");
 
 }
 
System.out.println("ENTER THE MAXIMUM NUMBER");
if(sc.hasNext("[0-9]*")) {
int maxNumber=0;
function(maxNumber);
}
else{
 System.out.println("Please Enter a Valid Number");
 
 }

}

//Method take string parameter and check string is empty or not
public static String reverse_string(String myStr)
{
if (myStr.isEmpty()){
System.out.println("String in now Empty");
return myStr;
}
//Calling Function Recursively
System.out.println("String to be passed in Recursive Function:"+myStr.substring(1));
return reverse_string(myStr.substring(1)) + myStr.charAt(0);}
public static <T> void function(T maxNumber) {
// Set it to the number of elements you want in the Fibonacci Series
Scanner sc = new Scanner(System.in);
int maxNum = sc.nextInt();
int previousNumber = 0;
int nextNumber = 1;
System.out.print("Fibonacci Series of "+maxNum+" numberssss:");
for (int i = 1; i <= maxNum; ++i){
System.out.print(previousNumber+" ");
// On each iteration, we are assigning second number
// to the first number and assigning the sum of last two
// numbers to the second number
int sum = previousNumber + nextNumber;
previousNumber = nextNumber;
nextNumber = sum;
}
}
}
