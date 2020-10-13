using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Pokodigon
{

    public class Program 
    {
    	static int pokeCount= 5, userCount= 0;
    	
        public static void Main()
        {
        	
			Pokemon[] pokemons= new Pokemon[16];
        	pokemons[0] = new Pokemon("Fuego", "Charizard", "Colmillo igneo", "Sofoco");
        	pokemons[1] = new Pokemon("Agua", "Blastoise", "Hidrocañon", "Acua Jet");
        	pokemons[2] = new Pokemon("Electrico", "Pikachu", "Trueno", "Chispazo");
        	pokemons[3] = new Pokemon("Planta", "Venusaur", "Tormenta floral", "Latigazo");
        	pokemons[4] = new Pokemon("Hada", "Clefary", "Fuerza lunar", "Encanto");
        	pokemons[5] = new Pokemon("Hielo", "Vulpix", "Ventisca", "Rayo hielo");
        	pokemons[6] = new Pokemon("Tierra","Marowak", "Terremoto", "Taladrado");
        	pokemons[7] = new Pokemon("Dragon", "Dragonite", "Enfado", "Cola dragon");
        	pokemons[8] = new Pokemon("Fuego", "Blaziken", "Giro fuego", "Llamarada");
        	pokemons[9] = new Pokemon("Agua", "Samuratt", "Cascada", "Burbuja");
        	pokemons[10] = new Pokemon("Electrico", "Jolteon", "Rayo", "Impactrueno");
        	pokemons[11] = new Pokemon("Planta", "Chikorita", "Rayo solar", "Hojas navaja");
        	pokemons[12] = new Pokemon("Hada", "Gardevour", "Beso drenaje", "Brillo magico");
        	pokemons[13] = new Pokemon("Hielo", "Beartio", "Puño hielo", "Alud");
        	pokemons[14] = new Pokemon("Tierra", "Golem", "Disparo lodo", "Fisura");
        	pokemons[15] = new Pokemon("Dragon", "Garchomp", "Pulso dragon", "Ciclon");
        	
        	Pokemon[] sixPokemons= new Pokemon[14];//arreglo de los primeros 6 pokemones
        	Pokemon[] usersPokes= new Pokemon[14];//arreglo del primer pokemon del usuario y los que tendra
        	ControlPoke poke= new ControlPoke();
        	
        	int finished=0, attack, random;
        	int randAttack, catched;
        	int again, select;
        	Random rdn= new Random();
        	
        	poke.GivePokemons(pokemons, sixPokemons, usersPokes);
        	do{
        		Console.Clear();
        		random= rdn.Next(0, (pokeCount+1));//Da un nunero random ora seleccionar al pokemon que peleara
	        	Console.WriteLine("						Pokodigon\n");
	        	Console.WriteLine("Pokemones a atrapar: \n");
	        	for(int i= 0; i<(pokeCount+1); i++){
	        		//if(sixPokemons[i]== null) continue;
	        		Console.WriteLine(sixPokemons[i]);
	        	}
	        	
	        	Console.WriteLine("\nPokemon del usuario.\n\n" + usersPokes[0]);
	        	//Pelea de pokemones
	        	do{
	        		Console.WriteLine("{0}", userCount);
	        		Console.WriteLine("\n*****************LUCHA*****************");
	        		//Decirle al usuario sus pokemones
	        		Console.WriteLine("\nCon cual pokemon luchara(digite el numero) ?\n");
	        		
	        		for(int j=0; j<= userCount; j++){
	        			Console.Write("{0}. ", j+1);
	        			Console.WriteLine(usersPokes[j]);
	        		}
	        		select= int.Parse(Console.ReadLine());
	        		select= select-1;
	        		Console.WriteLine("\n***************************************");
		        	
	        		Console.WriteLine("\n" + usersPokes[select]);
		        	Console.WriteLine("\nElija un ataque(digite 1 o 2): ");
		        	Console.WriteLine("\n1.{0}\n2.{1}", usersPokes[select].Attack1, usersPokes[select].Attack2);
		        	attack= int.Parse(Console.ReadLine());
		        	if(attack== 1){
		        		Console.WriteLine("\n{0} uso {1}: {2}", usersPokes[select].Name, usersPokes[select].Attack1, usersPokes[select].Damage1);
		        		sixPokemons[random].Health -= usersPokes[select].Damage1;
		        	}else if(attack== 2){
		        		Console.WriteLine("\n{0} uso {1}: {2}", usersPokes[select].Name, usersPokes[select].Attack2, usersPokes[select].Damage2);
		        		sixPokemons[random].Health -= usersPokes[select].Damage2;
		        	}
		        	
		        	if(sixPokemons[random].Health<= 0){
		        	    RetireSixPoke(random, sixPokemons, usersPokes);
		        		break;
		        	}
		        		
		        	//Turno del oponente
		        	randAttack= rdn.Next(0, 2);
		        	Console.WriteLine("\n***************************************");
		        	Console.WriteLine("\n" + sixPokemons[random]);
		        	if(randAttack== 0){
		        		Console.WriteLine("\n{0} uso {1}: {2}", sixPokemons[random].Name, sixPokemons[random].Attack1, sixPokemons[random].Damage1);
		        		usersPokes[select].Health -= sixPokemons[random].Damage1;
		        	}else if(randAttack== 1){
		        		Console.WriteLine("\n{0} uso {1}: {2}", sixPokemons[random].Name, sixPokemons[random].Attack2, sixPokemons[random].Damage2);
		        		usersPokes[select].Health -= sixPokemons[random].Damage2;
		        	}
		        	
		        	if(usersPokes[select].Health<= 0){
		        		RetireUsersPoke(select, sixPokemons, usersPokes);
		        		break;
		        	}
		        	if(userCount< 0) break;
		        	
	        	}while(finished== 0);
	        	//Preguntar si desea pelear otra vez
		        Console.WriteLine("\nDesea pelear otra vez? (Digite 1 o 2)");
		       	Console.WriteLine("1.Si    2. No");
		       	again= int.Parse(Console.ReadLine());
        	
        	}while(again== 1);
        }
        public static void RetireSixPoke(int random, Pokemon[] sixPokemons, Pokemon[] usersPokes){
        	ControlPoke poke= new ControlPoke();
        	int catched= poke.Catched();
        	if(catched== 1){
        		Console.WriteLine("\nFelicidades ganaste al pokemon");
        		userCount++;
        		sixPokemons[random].Health= 150;
        		usersPokes[userCount]= sixPokemons[random];
        		//Quitar el elemento del arreglo
        		for(int i=0; i<= pokeCount; i++){
	        		if(sixPokemons[i].Name== sixPokemons[random].Name){
	        			sixPokemons[i]= null;
	        			break;
	        		}
        		}
        	}else{
        		Console.WriteLine("\nMala suerte, no pudiste atrapara al pokemon");
        		sixPokemons[random].Health= 150;
        	}
        }
        public static void RetireUsersPoke(int select, Pokemon[] sixPokemons, Pokemon[] usersPokes){
        	ControlPoke poke= new ControlPoke();
        	int catched= poke.Catched();
        	if(catched== 1){
        		Console.WriteLine("\nMala suerte, el oponente atrapo tu pokemon");
        		pokeCount++;
        		usersPokes[select].Health= 150;
        		sixPokemons[pokeCount]= usersPokes[select];
        		//Quitar el elemento del arreglo
        		for(int i=0; i<= userCount; i++){
	        		if(usersPokes[i].Name== usersPokes[select].Name){
	        			usersPokes[i]= null;
	        			break;
	        		}
        		}
        	}else{
        		Console.WriteLine("\nTienenes suerte, el oponente no te quito tu pokemon");
        		usersPokes[select].Health= 150;
        	}
        }
    }
    
}
