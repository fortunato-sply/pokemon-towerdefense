using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokemon_towerdefense.Models
{
    public class Type
    {
        public string Name { get; set; }
        public List<Type> Weaknesses { get; private set; }
        public List<Type> Resistances { get; private set; }

        private static Dictionary<string, Type> types = new Dictionary<string, Type>();

        private Type(string name)
        {
            Name = name;
            Weaknesses = new List<Type>();
            Resistances = new List<Type>();
        }

        public static Type GetInstance(string name)
        {
            if (!types.ContainsKey(name))
            {
                types[name] = new Type(name);
            }

            return types[name];
        }

        public void AddWeakness(Type type)
        {
            if (!Weaknesses.Contains(type))
            {
                Weaknesses.Add(type);
            }
        }

        public void AddResistance(Type type)
        {
            if (!Resistances.Contains(type))
            {
                Resistances.Add(type);
            }
        }
    }

    public static class TypeConfigurator
    { 
        public static void ConfigureTypes()
        {
            Type fireType = Type.GetInstance("Fire");
            Type waterType = Type.GetInstance("Water");
            Type grassType = Type.GetInstance("Grass");
            Type electricType = Type.GetInstance("Electric");
            Type normalType = Type.GetInstance("Normal");
            Type groundType = Type.GetInstance("Ground");
            Type rockType = Type.GetInstance("Rock");
            Type bugType = Type.GetInstance("Bug");
            Type ghostType = Type.GetInstance("Ghost");
            Type flyingType = Type.GetInstance("Flying");

            // colocar resistencias e weakness
            fireType.AddWeakness(waterType);
        }
    }
}
