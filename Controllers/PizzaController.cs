
using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tpPizzas.Utils;

namespace tpPizzas.Controllers
{
    public class PizzaController : Controller
    {
        // GET: Pizza
        public ActionResult Index()
        {
            return View(FakeData.Instance.Pizzas);
        }

        // GET: Pizza/Details/5
        public ActionResult Details(int id)
        {
            Pizza pizza = FakeData.Instance.Pizzas.FirstOrDefault(x => x.Id == id);
            if (pizza != null)
            {
                return View(pizza);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Pizza/Create
        public ActionResult Create()
        {
            PizzasCreateViewModel vm = new PizzasCreateViewModel();
            vm.Pates = FakeData.Instance.Pates;
            vm.Ingredients = FakeData.Instance.Ingredients;

            return View(vm);
        }

        // POST: Pizza/Create
        [HttpPost]
        public ActionResult Create(PizzasCreateViewModel vm)
        {
            try
            {
                List<Ingredient> Ingredients = new List<Ingredient>();
                foreach (int id in vm.IdIngredient)
                {
                    Ingredient ingredient = FakeData.Instance.Ingredients.Find(i => i.Id == id);
                    Ingredients.Add(ingredient);
                }
                Pizza pizza = new Pizza
                {
                    Id = FakeData.Instance.Pizzas.Count == 0 ? 1 : FakeData.Instance.Pizzas.Max(x => x.Id) + 1,
                    Nom = vm.Pizza.Nom,
                    Pate = FakeData.Instance.Pates.FirstOrDefault(pate => pate.Id == vm.IdPate),
                    Ingredients = Ingredients
                };
                FakeData.Instance.Pizzas.Add(pizza);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(vm);
            }
        }

        // GET: Pizza/Edit/{id}
        public ActionResult Edit(int id)
        {
            Pizza pizza = FakeData.Instance.Pizzas.FirstOrDefault(x => x.Id == id);
            PizzasCreateViewModel vm = new PizzasCreateViewModel();
            vm.Pizza = pizza;
            vm.Pates = FakeData.Instance.Pates;
            vm.Ingredients = FakeData.Instance.Ingredients;

            if (pizza != null)
            {
                return View(vm);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Pizza/Edit/{id}
        [HttpPost]
        public ActionResult Edit(int id, PizzasCreateViewModel vm)
        {
            try
            {
                FakeData.Instance.Pizzas[vm.Pizza.Id] = savePizza(vm);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pizza/Delete/{id}
        public ActionResult Delete(int id)
        {
            Pizza pizza = FakeData.Instance.Pizzas.FirstOrDefault(x => x.Id == id);
            if (pizza != null)
            {
                return View(pizza);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Pizza/Delete/{id}
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Pizza pizza = FakeData.Instance.Pizzas.FirstOrDefault(x => x.Id == id);
                FakeData.Instance.Pizzas.Remove(pizza);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private Pizza savePizza(PizzasCreateViewModel vm)
        {
           

            

            return pizza;
        }
    }
}
