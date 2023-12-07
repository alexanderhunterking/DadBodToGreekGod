let token = localStorage.authToken;

document.addEventListener("DOMContentLoaded", function () {
    var logoutLink = document.getElementById("logoutLink");
  
    if (logoutLink) {
      logoutLink.addEventListener("click", function (event) {
        event.preventDefault();
        logoutButton();
      });
    }
  });

  function logoutButton() {
    console.log("Logout function executed");
    window.localStorage.removeItem("authToken");
    window.location.replace("../index.html");
  }
  

// document.getElementById('makeNewMealButton').addEventListener('click', function () {
//     var mealName = document.getElementById('mealName').value;
//     var description = document.getElementById('Description').value;

//     var formData = {
//       mealName: mealName,
//       description: description
//     };

//     fetch('https://localhost:7265/api/meals', {
//       method: 'POST',
//       headers: {
//         'Content-Type': 'application/json',
//         'Authorization': `Bearer ${token}`,
//       },
//       body: JSON.stringify(formData)
//     })
//     .then(function (response) {
//         if (response.status == 200) {
//           return response.json(); // Parse JSON response
//         } else {
//           localStorage.removeItem("mealId");
//           alert("An error occurred. Please try again.");
//         }
//       })
//       .then(function (json) {
//         if (json) {
//           var mealId = json.mealId;
//           console.log(mealId);
//           localStorage.setItem("mealId", mealId);
//         window.location.replace("../pages/createNewMealIngredient.html")
//         }
//       });
//   });

  async function fetchDataAndCreateOptions() {
    try {
      const response = await fetch("https://localhost:7265/api/ingredients", {
        method: "GET",
        headers: {
          "Content-Type": "application/json",
          Authorization: `Bearer ${token}`,
        },
      });
      const data = await response.json();
  
      if (data && Array.isArray(data)) {
        const datalist = document.getElementById("datalistOptions");
  
        data.forEach((ingredient) => {
          const option = document.createElement("option");
          option.value = ingredient.name;
          option.setAttribute("id", ingredient.ingredientId);
          datalist.appendChild(option);
        });
      }
    } catch (error) {
      console.error("Error fetching data:", error);
    }
  }
  
  // Call the function to fetch data and populate options
  fetchDataAndCreateOptions();

  document.getElementById("makeNewMealButton").addEventListener("click", async function () {
    try {
      // Part 1: Create a new meal and get the mealId
      const mealName = document.getElementById("mealName").value;
      const description = document.getElementById("Description").value;
  
      const mealResponse = await fetch("https://localhost:7265/api/meals", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
          "Authorization": `Bearer ${token}`,
        },
        body: JSON.stringify({
          mealName: mealName,
          description: description,
        }),
      });
  
      if (!mealResponse.ok) {
        throw new Error(`Error creating meal. Status: ${mealResponse.status}`);
      }
  
      const mealData = await mealResponse.json();
      const mealId = mealData.mealId;
  
      console.log("Meal created successfully. MealId:", mealId);
  
      // Part 2: Select 3 Ingredients and make API requests
      const ingredientInputs = document.querySelectorAll("#ingredientContainer input");
  
      for (const input of ingredientInputs) {
        const ingredientName = input.value;
        const ingredientId = findIngredientIdByName(ingredientName);
  
        if (!ingredientId) {
          console.error(`Ingredient ID not found for ${ingredientName}`);
          continue; // Skip to the next iteration
        }
  
        const quantity = await calculateIngredientQuantity(ingredientId);
        
        // Make a POST request to api/mealingredients
        const mealIngredientResponse = await fetch("https://localhost:7265/api/mealingredients", {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
            "Authorization": `Bearer ${token}`,
          },
          body: JSON.stringify({
            mealId: mealId,
            ingredientId: ingredientId,
            quantity: quantity,
          }),
        });
  
        if (mealIngredientResponse.ok || mealIngredientResponse.status === 201) {
          console.log(`Ingredient ${ingredientId} added successfully to Meal ${mealId}`);
        } else {
          console.error(`Error adding ingredient ${ingredientId} to Meal ${mealId}. Status: ${mealIngredientResponse.status}`);
        }
      }
  
    } catch (error) {
      console.error("Error:", error);
    }

   await changeScreen();
  });

  function changeScreen() {
    window.location.replace("../pages/meals.html");
  }

  function findIngredientIdByName(ingredientName) {
    const datalistOptions = document.getElementById("datalistOptions").children;
  
    for (const option of datalistOptions) {
      if (option.value === ingredientName) {
        return parseInt(option.id, 10); // Parse as an integer with base 10
      }
    }
  
    return null; // Return null if not found
  }
  
  async function calculateIngredientQuantity(ingredientId) {
    try {
      // Fetch user's macro information
      const userMacroResponse = await fetch("https://localhost:7265/api/macro/user", {
        method: "GET",
        headers: {
          "Content-Type": "application/json",
          "Authorization": `Bearer ${token}`,
        },
      });
  
      if (!userMacroResponse.ok) {
        throw new Error(`Error fetching user macro information. Status: ${userMacroResponse.status}`);
      }
  
      const userMacroInfo = await userMacroResponse.json();
  
      // Divide user's macro information by 3
      const caloriesPerThird = userMacroInfo.calories / 3;
  
      // Fetch ingredient's nutritional information
      const ingredientResponse = await fetch(`https://localhost:7265/api/ingredients/${ingredientId}`, {
        method: "GET",
        headers: {
          "Content-Type": "application/json",
          "Authorization": `Bearer ${token}`,
        },
      });
  
      if (!ingredientResponse.ok) {
        throw new Error(`Error fetching ingredient information. Status: ${ingredientResponse.status}`);
      }
  
      const ingredientInfo = await ingredientResponse.json();
  
      // Parse out relevant nutritional information
      const {
        caloriesPer100g,
        proteinPer100g,
        carbsPer100g,
        fatPer100g
      } = ingredientInfo;
  
      // Check if all required values are present
      if (caloriesPer100g === undefined || caloriesPer100g === 0) {
        throw new Error("Error: Missing or invalid caloriesPer100g for ingredient.");
      }
  
      // Calculate quantity to achieve the desired macro distribution
      const quantity = (caloriesPerThird / (caloriesPer100g / 100)) || 0; // default to 0 if NaN
  
      console.log(`Quantity for Ingredient ${ingredientId}:`, quantity);
  
      return quantity;
  
    } catch (error) {
      console.error("Error calculating ingredient quantity:", error);
    }
  }