namespace MealPlanner.API.Features.Recipes;

public class RecipeResponse
{
    public int from { get; set; }
    public int to { get; set; }
    //public Hit[] hits { get; set; }
    //public Ingredient[] ingredients { get; set; }
}

// public class Hit
// {
//     public Recipe recipe { get; set; }
// }

//public record Ingredient(string Text, string Food);

// public record Recipe
// {
//     public string label { get; set; }
//     public string image { get; set; }
//     public string source { get; set; }
//     public string shareAs { get; set; }
// }