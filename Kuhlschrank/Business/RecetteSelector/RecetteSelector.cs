using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContracts;

namespace Business.RecetteSelector
{
    public class RecetteSelector
    {
        private static readonly string[] uselessWords = 
        {
            #region Mots
                "de",
                "la",
                "cuillère",
                "soupe",
                "pincée",
                "zeste",
                "gr",
                "kg",
                "litre",
                "litres",
                "morceau",
                "morceaux",
            #endregion
        };

        public static List<Recette> SelectBestRecettes(List<Recette> recettes, List<Product> products, int limit = 3)
        {
            List<Tuple<int, List<string>>> lesMotsDesProduits = products.Select(o => new Tuple<int, List<string>>(o.ID, o.Libelle.Split(' ').ToList())).ToList();
            List<Tuple<int, List<List<string>>>> lesMotsDesRecettes = recettes.Select(o => new Tuple<int, List<List<string>>>(o.ID, o.Ingrédients.Select(i => i.Split(' ').ToList()).ToList())).ToList();

            lesMotsDesProduits.ForEach(o => o.Item2.RemoveAll(i => uselessWords.Contains(i)));
            lesMotsDesRecettes.ForEach(o => o.Item2.ForEach(l => l.RemoveAll(s => uselessWords.Contains(s))));

            Dictionary<int, int> classementRecette = new Dictionary<int, int>();

            foreach (Tuple<int, List<List<string>>> recette in lesMotsDesRecettes)
            {
                foreach (List<string> ingredient in recette.Item2)
                {
                    if (!classementRecette.ContainsKey(recette.Item1))
                    {
                        classementRecette[recette.Item1] = 0;
                    }
                    classementRecette[recette.Item1] += lesMotsDesProduits.Sum(o => o.Item2.Where(i => ingredient.Contains(i)).Count());
                }
            }
            classementRecette = classementRecette.OrderBy(o => o.Value).ToDictionary(o => o.Key, i => i.Value);

            return classementRecette.Values.All(o => o == 0) ? null : classementRecette.Take(limit).Select(r => recettes.Where(o => o.ID == r.Key && r.Value > 0).First()).ToList();
        }
    }
}
