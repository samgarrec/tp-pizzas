using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tpPizzas.Utils
{
    public class FakeData
    {
        private static FakeData _instance;
        static readonly object instanceLock = new object();

        private FakeData()
        {
            ingredients = this.InitialiserIngredients();
            pates = this.InitialiserPates();
            pizzas = new List<Pizza>();
        }

        public static FakeData Instance
        {
            get
            {
                if (_instance == null) 
                {
                    lock (instanceLock)
                    {
                        if (_instance == null) //on vérifie encore, au cas où l'instance aurait été créée entretemps.
                            _instance = new FakeData();
                    }
                }
                return _instance;
            }
        }

        private List<Pizza> pizzas;

        public List<Pizza> Pizzas
        {
            get { return pizzas; }
        }

        private List<Ingredient> ingredients;

        public List<Ingredient> Ingredients
        {
            get { return ingredients; }
        }

        private List<Ingredient> InitialiserIngredients()
        {
            return new List<Ingredient>
            {
                new Ingredient{Id=1,Nom="Mozzarella"},
                new Ingredient{Id=2,Nom="Jambon"},
                new Ingredient{Id=3,Nom="Tomate"},
                new Ingredient{Id=4,Nom="Oignon"},
                new Ingredient{Id=5,Nom="Cheddar"},
                new Ingredient{Id=6,Nom="Saumon"},
                new Ingredient{Id=7,Nom="Champignon"},
                new Ingredient{Id=8,Nom="Poulet"}
            };
        }

        private List<Pate> pates;

        public List<Pate> Pates
        {
            get { return pates; }
        }

        private List<Pate> InitialiserPates()
        {
            return new List<Pate>
            {
                new Pate{ Id=1,Nom="Pate fine, base crême"},
                new Pate{ Id=2,Nom="Pate fine, base tomate"},
                new Pate{ Id=3,Nom="Pate épaisse, base crême"},
                new Pate{ Id=4,Nom="Pate épaisse, base tomate"}
            };
        }
    }
}