using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Pokodigon
{

    public class ControlPoke 
    {
        public Pokemon pokemon= new Pokemon();
        public void GivePokemons(Pokemon[] pokes, Pokemon[] sixPokes, Pokemon[] userPoke){
        	Random rdn= new Random();
        	int random, yes= 1, count= 0;
        	int[] used= new int[50];//arreglo de numeros random usados
        	used[0]= 100;
        	for(int i= 0; i<7; i++){
        		//Comprobar que el numero random no sea el mismo
        		do{
        			random= rdn.Next(0, 16);
        			for(int j=0; j<=count; j++){
        				if(random == used[j]){
        					yes= 0;
        					break;
        				}else{
        					yes= 1;
        				}
        			}
        		}while(yes== 0);
        		count++;
        		used[count]= random;
        		sixPokes[i]= pokes[random];//agregar ak pokemon
        	}
        	userPoke[0] = sixPokes[6];
        	
        }   
        public int Catched(){
        	Random rdn= new Random();
        	int catched= rdn.Next(0, 2);
        	return catched;
        }

    }
}