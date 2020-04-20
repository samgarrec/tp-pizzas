using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tpPizzas.Utils;

namespace BO
{
    public class PizzasCreateViewModel
    {




        public Pizza Pizza { get; set; }
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public List<int> IdIngredient { get; set; } = new List<int>();
        public List<Pate> Pates { get; set; } = new List<Pate>();


        public int IdPate { get; set; }

    }
}