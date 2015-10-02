using UnityEngine;
using System.Collections;

public class Blackjack : MonoBehaviour {
//	private int[] points = {7,2,9,5,0};
//	private int[] points = {7,9,5,3,0,4,2,2};
//	private int[] points = {9, 9, 9, 9, 0, 9};
	private int[] points;
	private int first;
	private int second;
	private bool firstPass;
	private int breakPoint;


	// Use this for initialization
	void Start () {
		CreatePointsArray();
		blackjack();
	}

	void CreatePointsArray(){
		int ArrayLength = Random.Range(5,11);
		points = new int[ArrayLength];
		int zeroPos = Random.Range(2,ArrayLength);
		points[zeroPos] = 0;
		for(int i = 0 ; i < ArrayLength ; i++){
			if(i == zeroPos)
				continue;
			points[i] = Random.Range(1,10);
		}
	}

	void blackjack(){
		for(int i = 0 ; i < points.Length ; i++)
			print (points[i]);

		for(int i = 0 ; i < points.Length ; i++){
			if( i % 2 == 0){
				if(points[i] != 0)
					first += points[i];
				else{
					firstPass = true;
					breakPoint = i;
					break;
				}
			}

			if( i % 2 == 1){
				if(points[i] != 0)
					second += points[i];
				else{
					firstPass = false;
					breakPoint = i;
					break;
				}
			}
		}

		for(int i = breakPoint+1 ; i < points.Length ; i++){
			if( firstPass == false){
				first += points[i];
			}			
			else{
				second += points[i];
			}
		}

		print ("first player points: "+first+", second player points: "+second);


		if(first > 0 && second > 0){
			if(first > 21){
				print ("second player wins");
			}
			else if(second > 21){
				print ("first player wins");
			}
			else if(first <= 21 && second <= 21){
				if(first > second)
					print ("first player wins");
			    else
					print ("second player wins");
			}
		}


	}
}
