// -------------------------------------------------------------------	
// Department of Electrical and Computer Engineering
// University of Waterloo
//
// Student Name:     PRAGASH SIVASUNDARAM
// Userid:           psivasun
//
// Assignment:       WEEKLY ASSIGNMENT 6
// Submission Date:  NOVEMBER 3RD 2014
// 
// I declare that, other than the acknowledgements listed below, 
// this program is my original work.
//
// Acknowledgements:
// NONE
// -------------------------------------------------------------------


using System;
using System.IO; 

class Solution{
	static string inFileName = "StrategicPlan.txt";
	
	public static void Main(){
		StreamReader sr = new StreamReader( inFileName );
		string nLine;
		
		int innoCount = 0;
		int entreCount = 0;
		bool FoundInno = false;
		bool FoundEntre  = false;
		
		int noCount = 0;
		int oldNoCount = 0;
		int begLine = 1;
		int endLine = 1;
		
		string [] wordsInLine;

		
		while ( !sr.EndOfStream ){
			nLine = sr.ReadLine().ToLower();
			wordsInLine = nLine.Split( ); 
			
			foreach (string word in wordsInLine){
				if (word.StartsWith( "innova" ) && !FoundInno){
					innoCount++;
					FoundInno = true;
					
				
					if ( noCount > 0  ){
						if ( noCount > oldNoCount ){
							oldNoCount = noCount;
							begLine = ( endLine ) - oldNoCount;
						}
						noCount = 0;
					}
				}
				
				else if (word.StartsWith( "entrepre" ) && !FoundEntre){	
					entreCount++;
					FoundEntre = true;
					
					if ( noCount > 0  ){
						if ( noCount > oldNoCount ){
							oldNoCount = noCount;
							begLine = ( endLine ) - oldNoCount;
						}
						noCount = 0;
					}
				}
			}
		
			if (FoundInno == false && FoundEntre == false)
				noCount++;
				
			//Resetting and Updating variables
			endLine++;
			FoundInno = false;
			FoundEntre = false;
			
		}
		endLine = oldNoCount + begLine -1;
		Console.WriteLine( "Number of lines containing a word starting with \"innova\" is {0}",innoCount );
		Console.WriteLine( "Number of lines containing a word starting with\"entrepre\" is {0}", entreCount );
		Console.WriteLine( "The longest span without \"innova\" or \"entrepre\" begins at line {0} and ends at line {1}", begLine,endLine  );	
		sr.Dispose();
	}
}