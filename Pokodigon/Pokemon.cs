using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Pokodigon
{

    public class Pokemon 
    {
    	public string Type;
        public string Name;
        public string Attack1;
        public string Attack2;
        public int Damage1;
        public int Damage2;
        private int _health;
        public int Health{
        	get{
        		return _health;
        	}
        	set{
        		if(value <0) _health= 0;
        		else _health= value;
        	}
        }
        public Pokemon(){
        	
        }
        public Pokemon(string type, string name, string attack1, string attack2){
        	Type= type;
        	Name= name;
        	Attack1= attack1;
        	Attack2= attack2;
        	Damage1= RandomDamage();
        	Damage2= RandomDamage();
        	Health= 150;
        }
        private int RandomDamage(){
        	Random rdn= new  Random();
        	int damage= rdn.Next(15, 66);
        	return damage;
        }
        
        
        public override string ToString(){
        	return string.Format("{0} - {1}			Salud: {2}", Name, Type, Health);
        }
    }
}