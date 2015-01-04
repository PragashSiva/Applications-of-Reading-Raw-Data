// -------------------------------------------------------------------	
// Department of Electrical and Computer Engineering
// University of Waterloo
//
// Student Name:     PRAGASH SIVASUNDARAM
// Userid:           psivasun
//
// Assignment:       WEEKLY ASSIGNMENT 5
// Submission Date:  OCTOBER 27TH 2014
// 
// I declare that, other than the acknowledgements listed below, 
// this program is my original work.
//
// Acknowledgements:
// NONE
// -------------------------------------------------------------------

using System;
using System.IO;

static class Program
{
    const string intensityFile = "WorldCupIllumination.csv";      
    
    static void Main( )
    {
        int[ ][ ] intensities;
        
        // Read the array of intensities from the file.
        using( StreamReader sr = new StreamReader( intensityFile ) )
        {
            int rows = int.Parse( sr.ReadLine( ) );
            int cols = int.Parse( sr.ReadLine( ) );
            
            intensities = new int[ rows ][ ];
            for( int row = 0; row < rows; row ++ )
            {
                intensities[ row ] = new int[ cols ];
                string[ ] words = sr.ReadLine( ).Split( ",".ToCharArray( ) );
                for( int col = 0; col < cols; col ++ )
                {
                    intensities[ row ][ col ] = int.Parse( words[ col ] );
                }
            }
        }
            
        // Find minimal and maximal intensities.
        int minIntensity;
        int maxIntensity;
        
        FindMinMax( intensities, out minIntensity, out maxIntensity );
        
        Console.WriteLine( );
        Console.WriteLine( "minimal intensity = {0}", minIntensity );
        Console.WriteLine( "maximal intensity = {0}", maxIntensity );
    }
	
	// Find the minimum and maximum value.
	static void FindMinMax( int [][] values, out int min, out int max)
	{
		int smallest; 
		int biggest; 
		
	
		for ( int i = 0; i < values.GetLength( 0 ) ; i++ )
			Array.Sort( values[ i ] );
		
		smallest = values[ 0 ][ 0 ];
		biggest = values[ 0 ][ values.GetLength( 0 ) ];
		
		for ( int i = 0; i < values.GetLength( 0 ) ; i++ )
		{
			smallest = ( smallest < values[ i ][ 0 ] )? 
									 smallest:values[ i ][ 0 ];
			biggest = ( biggest > values[ i ][ values[ i ].Length- 1 ])? 
									 biggest:values[ i ][ values[ i ].Length- 1 ];
		}
		
		min = smallest; 
		max = biggest;
	}
}