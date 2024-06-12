# POETHRE
POE 

The Recipe Manager application is a WPF-based tool designed to help users create, manage, and scale recipes efficiently.
The application provides functionalities to input recipe details, add ingredients, specify steps, scale recipe quantities, filter recipes, and delete recipes.

Features

-Add Recipe: Users can input recipe names, ingredients, measurements, quantities, food groups, and calories.

-Add Ingredients: Additional ingredients can be added to an existing recipe.

-Add Steps: Users can specify the steps required to prepare the recipe.

-Scale Recipes: Recipes can be scaled by 0.5, 2, or 3 times their original quantities.

-Reset Quantities: Recipe quantities can be reset to their original values.

-Delete Recipes: Users can delete selected recipes.

-Display Recipes: Displays a list of current recipes and their details.

-Filter Recipes: Filter recipes by ingredient name, food group, and maximum calories.

-Calorie Warning: Displays a warning if the total calories exceed a specified threshold.


here is  how the code works

Main Window
-Recipe Name: Enter the name of the recipe.

-Enter Ingredient: Input the ingredient details including name, measurement, quantity, food group, and calories.

-Add More Ingredient: Clear ingredient fields to add another ingredient to the same recipe.

-Enter Steps: Input the number of steps and add them by clicking the Add Steps button.

-Save Recipe: Save the recipe with all the entered details.

-Display: Display the list of all recipes with their details.

-Scaling Buttons: Scale the recipe quantities by 0.5, 2, or 3.

-Reset: Reset the recipe quantities to their original values.

-Delete Recipe: Delete the selected recipe.

-Filters: Apply filters based on ingredient name, food group, and maximum calories.

Code Structure
XAML
The MainWindow.xaml file defines the user interface components including labels, text boxes, buttons, and combo boxes. 
It uses a Grid layout with several RowDefinition elements to organize the UI elements.

C#
The MainWindow.xaml.cs file contains the logic for handling user interactions, managing recipe details, scaling recipes, and applying filters.

Key Classes and Methods
-MainWindow: The main window class that initializes the application and handles various button click events.

-recipeDetails: A class to store and manage recipe details including ingredients, steps, and scaling functionality.

-saveRecipeButton_Click: Saves the current recipe.

-AddIngredientButton_Click: Adds more ingredients to an existing recipe.

-AddSteps_Click: Adds steps to the recipe.

-displayButton_Click: Displays the current list of recipes.

-scaleButton1_Click: Scales recipe quantities by 0.5.

-scaleButton2_Click: Scales recipe quantities by 2.

-scaleButton3_Click: Scales recipe quantities by 3.

-resetButton_Click: Resets recipe quantities to their original values.

-deleteRecipeButton_Click: Deletes the selected recipe.

-check_Click: Applies filters based on ingredient name, food group, and maximum calories.


