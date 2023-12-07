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
    // Headers to be added to each request
    const headers = {
      "Content-Type": "application/json",
      "Authorization": `Bearer ${token}`,
      // Add any other headers you need
    };

    // Make a GET request to get meal IDs
    fetch("https://localhost:7265/api/meals/user", { headers })
      .then(response => response.json())
      .then(meals => {
        meals.forEach(meal => {
          // For each meal ID, make another GET request to get detailed information
          fetch(`https://localhost:7265/api/meals/${meal.mealId}`, { headers })
            .then(response => response.json())
            .then(mealDetails => {
              // Create a new meal card
              createMealCard(mealDetails);
            })
            .catch(error => console.error("Error fetching meal details:", error));
        });
      })
      .catch(error => console.error("Error fetching meal IDs:", error));

function createMealCard(mealDetails) {
      // Create HTML elements for the meal card
      const mealCardContainer = document.createElement("div");
      mealCardContainer.classList.add("col-lg-4","col-md-6","col-sm-12", "mb-3"); // Adjust classes as needed

      mealCardContainer.innerHTML = `
        <button class="card w-100" data-meal-id="${mealDetails.mealId}">
          <div class="card-body">
            <h5 class="card-title">${mealDetails.mealName}</h5>
            <p class="card-text">${mealDetails.description}</p>
            <p>Ingredients:</p>
            <ul>
              ${mealDetails.mealIngredients.map(ingredient => `<li>${ingredient.ingredientName}</li>`).join('')}
            </ul>
          </div>
        </button>
      `;

      // Add event listener to the button
      const button = mealCardContainer.querySelector(".card");
      button.addEventListener("click", function () {
        // Get mealId from the button's data attribute
        const mealId = button.getAttribute("data-meal-id");

        // Store the mealId in localStorage
        localStorage.setItem("selectedMealId", mealId);

        // Navigate to updateMeal.html
        window.location.href = "./updateMeal.html";
      });

      // Append the new meal card to the row
      const rowContainer = document.querySelector(".row");

      if (!rowContainer) {
        console.error("Row container not found");
        return;
      }

      rowContainer.appendChild(mealCardContainer);
    }
  });
