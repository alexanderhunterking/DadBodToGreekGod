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

document.addEventListener("DOMContentLoaded", function () {
    var deleteMealButton = document.getElementById("deleteMealButton");
  
    if (deleteMealButton) {
      deleteMealButton.addEventListener("click", function (event) {
       
      DeleteMeal();

      });
    }
  });

async function DeleteMeal() {
  
  const mealId = localStorage.getItem('selectedMealId');

  await fetch(`https://localhost:7265/api/meals/${mealId}`, {
    method: 'DELETE',
    headers: {
      'Content-Type': 'application/json',
      Authorization: `Bearer ${token}`,
    },
  });

  window.localStorage.removeItem("selectedMealId")

 window.location.replace("../pages/meals.html" );
  
}

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


        document.addEventListener('DOMContentLoaded', function () {
            const updateMealButton = document.getElementById('updateMealButton');

            updateMealButton.addEventListener('click', async function () {
                const mealId = localStorage.getItem('selectedMealId');

                // Fetch meal data from the form
                const mealName = document.getElementById('mealName').value;
                const description = document.getElementById('Description').value;

                // Make PUT request for the first two fields
                const updateMealUrl = `https://localhost:7265/api/meals/${mealId}`;
                const updateMealResponse = await fetch(updateMealUrl, {
                    method: 'PUT',
                    headers: {
                        'Content-Type': 'application/json',
                        'Authorization': `Bearer ${token}`
                    },
                    body: JSON.stringify({
                        mealName,
                        description
                    })
                });

                // Check if the update was successful
                if (!updateMealResponse.ok) {
                    console.error('Failed to update meal information.');
                    return;
                }

                // Fetch mealIngredientId data
                const getMealIngredientsUrl = `https://localhost:7265/api/mealingredients/meal/${mealId}`;
                const getMealIngredientsResponse = await fetch(getMealIngredientsUrl, {
                    method: 'GET',
                    headers: {
                        'Authorization': `Bearer ${token}`
                    }
                });

                // Check if the fetch was successful
                if (!getMealIngredientsResponse.ok) {
                    console.error('Failed to get meal ingredient information.');
                    return;
                }

                const mealIngredients = await getMealIngredientsResponse.json();

                // Update the last three fields
                for (const mealIngredient of mealIngredients) {
                    const ingredientId = mealIngredient.ingredientId;
                    const quantity = 0;
                    
                    const updateMealIngredientUrl = `https://localhost:7265/api/mealingredients/${mealIngredient.mealIngredientId}`;
                    const updateMealIngredientResponse = await fetch(updateMealIngredientUrl, {
                        method: 'PUT',
                        headers: {
                            'Content-Type': 'application/json',
                            'Authorization': `Bearer ${token}`
                        },
                        body: JSON.stringify({
                            ingredientId,
                            quantity
                        })
                    });

                    // Check if the update was successful
                    if (!updateMealIngredientResponse.ok) {
                        console.error(`Failed to update meal ingredient information for ingredientId ${ingredientId}.`);
                        return;
                    }
                }

                // Inform the user about the successful update
                alert('Meal information updated successfully!');
            });
        });
