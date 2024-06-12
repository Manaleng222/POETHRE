using Microsoft.VisualBasic;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static POETHRE.MainWindow;

namespace POETHRE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    

    // notifications for calories
    public delegate void CaloriesHandler(int totalCalories);

    public partial class MainWindow : Window
    {
        //call the recipedetails class
        private List<recipeDetails> recipeDetail;
        private List<string> currentSteps;
        public MainWindow()
        {
            InitializeComponent();
            recipeDetail = new List<recipeDetails>();
            currentSteps = new List<string>();
        }

        // when the user  input  a new  recipe
        private void saveRecipeButton_Click(object sender, RoutedEventArgs e)
        {

            string message = "Are you sure you want to save this recipe?";
            MessageBoxResult result = MessageBox.Show(message, "Confirm Save", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                recipeDetails details = new recipeDetails(ingredient.Text, measure.Text, double.Parse(qty.Text), rname.Text, instructionsTextBox.Text, foodGroupComboBox.SelectedItem.ToString(), double.Parse(carl.Text), new List<string>(currentSteps));
                recipeDetail.Add(details);
                currentSteps.Clear();
                //recipeDetail[currentSteps.Count - 1] = details;
                //recipeDetail.Clear();   
                //currentSteps.Add(details);
                list.ItemsSource = null;
                list.ItemsSource = recipeDetail;
                //CheckerCalories();
                CheckerCalories((int)double.Parse(carl.Text));



                //ingredient.Clear();
                //measure.Clear();
                //qty.Clear();
                // rname.Clear();
                // foodGroupComboBox.SelectedIndex = -1;
                //carl.Clear();
                //instructionsTextBox.Clear();
                //StepsCountTextBox.Clear();
            } 
        }

        // delete recipe 
        private void ClearInputFields()
        {
            // Clear all the input fields
            ingredient.Text = "";
            measure.Text = "";
            qty.Text = "";
            rname.Text = "";
            instructionsTextBox.Text = "";
            foodGroupComboBox.SelectedIndex = -1; // Reset the selected index
            carl.Text = "";
            StepsCountTextBox.Text = "";
            string messag = "Be Advised you are clearing recipe content but recipe name remains the same";
            MessageBox.Show(messag, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        // when user wants to more ingredients  add the same recipe
        private void AddIngredientButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(rname.Text))
            {
                // Clear the ingredient fields
                ingredient.Text = "";
                qty.Text = "";
                measure.Text = "";
                foodGroupComboBox.SelectedIndex = -1;
                carl.Text = "";
                StepsCountTextBox.Text = "";
                currentSteps.Clear();
                // Display a warning message to the user
                string message = "Be Advised you only are clearing  ingredient name,quantity , measurement , foodGroup, calories but recipe name remains the same if only want add more ingredints";
                MessageBox.Show(message, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                MessageBox.Show("Please enter a recipe name before adding ingredients.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        // add steps to  the recipe 
        private void AddSteps_Click(object sender, RoutedEventArgs e)
        {
            int numSteps = int.Parse(StepsCountTextBox.Text);

            List<string> steps = new List<string>();

            for (int i = 0; i < numSteps; i++)
            {
                string step = Interaction.InputBox("Enter step " + (i + 1) + ":");
                currentSteps.Add(step);
            }

            list.ItemsSource = null;
            list.ItemsSource = recipeDetail;
        }


        // Display the recipe details button
        private void displayButton_Click(object sender, RoutedEventArgs e)
        {
            var sortedRecipeDetails = recipeDetail.OrderBy(a => a.itemName).ToList();


            // Display the recipe details in a message box
            string message = "";
            foreach (recipeDetails recipe in recipeDetail)
            {
                message += recipe.ToString() + "\n";
                Console.WriteLine("**************************************");
                message += ("Steps:\n");

                for (int z = 0; z < recipe.Steps.Count; z++)
                {
                    message += ("step: " + (z + 1) + ": " + recipe.Steps[z] + "\n");
                    //message += ("step: " + (z + 1) + ":" +"\n");
                    //message += (string.Join("\n", "step: " + recipe.Steps[z]  + (z + 1)));
                    // message+=(string.Join("step: " + (z + 1) + ": " + recipe.Steps[z]));

                }
                MessageBox.Show(message);
                CheckerCalories((int)double.Parse(carl.Text));
                message += ("**************************************9\n");
            }

        }


        // scale the recipe by 0,5
        private void scaleButton1_Click(object sender, RoutedEventArgs e)
        {

            foreach (recipeDetails increase in recipeDetail)
            {
                increase.recipeScaling(0.5);
            }
            // Output the updated recipe quantities
            StringBuilder message = new StringBuilder();
            message.AppendLine("************************");
            message.AppendLine("Scaled recipe quantity by (0.5):");
            message.AppendLine("************************");

            foreach (recipeDetails recipe in recipeDetail)
            {
                message.AppendLine($"The Quantity: {recipe.itemQuantity}\nThe Measurement: {recipe.itemMeasurement}\nThe name of recipe: {recipe.recipeName}");
            }

            MessageBox.Show(message.ToString(), "Scaled Recipe Quantity");
            list.ItemsSource = null;
            list.ItemsSource = recipeDetail;
        }


        // scale button the recipe by 2
        private void scaleButton2_Click(object sender, RoutedEventArgs e)
        {


            foreach (recipeDetails increase in recipeDetail)
            {
                increase.recipeScaling(2);
            }
            // show the new recipe quantities
            StringBuilder message = new StringBuilder();
            message.AppendLine("************************");
            message.AppendLine("Scaled recipe quantity by (2):");
            message.AppendLine("************************");

            foreach (recipeDetails recipe in recipeDetail)
            {
                message.AppendLine($"The Quantity: {recipe.itemQuantity}\nThe Measurement: {recipe.itemMeasurement}\nThe name of recipe: {recipe.recipeName}");
            }

            MessageBox.Show(message.ToString(), "Scaled Recipe Quantity");
            list.ItemsSource = null;
            list.ItemsSource = recipeDetail;

        }

        // scale  button the recipe by 3
        private void scaleButton3_Click(object sender, RoutedEventArgs e)
        {

            foreach (recipeDetails increase in recipeDetail)
            {
                increase.recipeScaling(3);
            }
            // Output the updated recipe quantity
            StringBuilder message = new StringBuilder();
            message.AppendLine("************************");
            message.AppendLine("Scaled recipe quantity by(3):");
            message.AppendLine("************************");

            foreach (recipeDetails recipe in recipeDetail)
            {
                message.AppendLine($"The Quantity: {recipe.itemQuantity}\nThe Measurement: {recipe.itemMeasurement}\nThe name of recipe: {recipe.recipeName}");
            }

            MessageBox.Show(message.ToString(), "Scaled Recipe Quantity");
            list.ItemsSource = null;
            list.ItemsSource = recipeDetail;
        }
        private void resetButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Enter 'Yes' to reset quantities back to the original quantities.", "Reset Quantities", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                foreach (recipeDetails recipe in recipeDetail)
                {
                    recipe.resetRecipe();
                }

                // Output the updated recipe quantity
                StringBuilder message = new StringBuilder();
                message.AppendLine("************************");
                message.AppendLine("Your recipe is:");
                message.AppendLine("************************");

                foreach (recipeDetails recipe in recipeDetail)
                {
                    message.AppendLine($"- The Quantity: {recipe.itemQuantity}\nThe Measurement: {recipe.itemMeasurement}\nThe name of recipe: {recipe.recipeName}");
                }

                MessageBox.Show(message.ToString(), "Recipe Quantities");

                list.ItemsSource = null;
                list.ItemsSource = recipeDetail;

            }
            list.ItemsSource = recipeDetail;
        }

        // delete button for recipe
        private void deleteRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            if (list.SelectedItem != null)
            {
                recipeDetails selectedRecipe = (recipeDetails)list.SelectedItem;
                recipeDetail.Remove(selectedRecipe);
                list.ItemsSource = null;
                list.ItemsSource = recipeDetail;
            }
            else
            {
                MessageBox.Show("Please select a recipe to delete.", "Delete Recipe", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        // filter button from ingredient name , foodgroup , carlories
        private void check_Click(object sender, RoutedEventArgs e)
        {
            // Filter by Ingredient Name
            string ingredient = ingredientFilterTextBox.Text;

            var filteredRecipes = recipeDetail
                .Where(recipe => recipe.itemName.Contains(ingredient, StringComparison.OrdinalIgnoreCase))
                .ToList();

            // Filter by Food Group
            string foodGroup = (foodGroupFilterComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            if (!string.IsNullOrEmpty(foodGroup) && foodGroup != "All")
            {
                filteredRecipes = filteredRecipes
                    .Where(recipe => recipe.foodGroup == foodGroup)
                    .ToList();
            }

            // Filter by Maximum Number of Calories
            if (!string.IsNullOrEmpty(maxCaloriesFilterTextBox.Text) && double.TryParse(maxCaloriesFilterTextBox.Text, out double maxCalories))
            {
                filteredRecipes = filteredRecipes
                    .Where(recipe => recipe.Carlories <= maxCalories)
                    .ToList();
            }

            // Update the list to display filtered recipes
            list.ItemsSource = filteredRecipes;
            recipeDetail.Clear();
            //ClearInputFields();

        }

        private void foodGroupFilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            string selectedFoodGroup = comboBox.SelectedItem as string;

            // You can use the selectedFoodGroup variable to filter your recipes
            // For example:
            var filteredRecipes = recipeDetail
                .Where(recipe => recipe.foodGroup == selectedFoodGroup)
                .ToList();

            list.ItemsSource = filteredRecipes;
        }


        // Method to check calories and display a warning message
        public static void CheckerCalories(int totalCalories)
            {
                if (totalCalories >= 300)
                {
                    MessageBox.Show("Warning! Your recipe has high calorie levels.", "Calorie Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            public class recipeDetails
        {
            //Public class to store recipe details

            //Variables to store ingredients 
            public string itemName;
            public string itemMeasurement;
            public double itemQuantity;
            public string recipeName;
            public string recipeDescription;
            public string foodGroup;
            public double Carlories;
            public List<string> Steps;

            private readonly double originalQuantity;

            public recipeDetails(string itemName, string itemMeasurement, double itemQuantity, string recipeName, string recipeDescription, string foodGroup, double Carlories, List<string> steps)
            {
                //Constructor for ingredients
                this.itemName = itemName;
                this.itemMeasurement = itemMeasurement;
                this.itemQuantity = itemQuantity;
                this.recipeName = recipeName;
                this.recipeDescription = recipeDescription;
                originalQuantity = itemQuantity;
                this.foodGroup = foodGroup;
                this.Carlories = Carlories;
                Steps = steps; 
            }

            public void recipeScaling(double scaleBy)
            {
                //Method to scale recipe quantity
                itemQuantity = originalQuantity * scaleBy;
            }

            public void resetRecipe()
            {
                //Method to reset quantity
                itemQuantity = originalQuantity;
            }

            //Display recipe info
            public override string ToString()
            {
                return $"Recipe name: {recipeName}\n Ingredient name:{itemName}\n Measurement:{itemMeasurement}\n Quantity:{itemQuantity}\nCarlories:{Carlories}\nFoodGroup:{foodGroup}\nSteps: {string.Join("\n", Steps)}\n*************8**";

            }
        }

    }
}