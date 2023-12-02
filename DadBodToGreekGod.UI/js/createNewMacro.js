let token = localStorage.authToken;

document.addEventListener("DOMContentLoaded", function () {
  var logoutLink = document.getElementById("calculateButton");

  if (logoutLink) {
    logoutLink.addEventListener("click", function (event) {
      event.preventDefault();
      calculateCalories();
    });
  }
});

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

function calculateCalories() {
    const feet = parseFloat(document.getElementById('feet').value);
    const inches = parseFloat(document.getElementById('inches').value);
    const height = feet * 12 + inches; // Convert feet and inches to inches
    const weight = parseFloat(document.getElementById('weight').value);
    const age = parseFloat(document.getElementById('age').value);
    const gender = document.getElementById('gender').value;
    const activityLevel = document.getElementById('activityLevel').value;
    const goal = document.getElementById('goal').value;

    // Convert height to centimeters
    const heightInCm = height * 2.54;

    // Convert weight to kilograms
    const weightInKg = weight * 0.453592;

    // Calculate BMR based on Mifflin-St Jeor equations
    let bmr;
    if (gender === 'male') {
      bmr = 10 * weightInKg + 6.25 * heightInCm - 5 * age + 5;
    } else {
      bmr = 10 * weightInKg + 6.25 * heightInCm - 5 * age - 161;
    }

    // Adjust BMR based on activity level
    let calories;
    switch (activityLevel) {
      case 'sedentary':
        calories = bmr * 1.2;
        break;
      case 'lightlyActive':
        calories = bmr * 1.375;
        break;
      case 'moderatelyActive':
        calories = bmr * 1.55;
        break;
      case 'veryActive':
        calories = bmr * 1.725;
        break;
      case 'extraActive':
        calories = bmr * 1.9;
        break;
      default:
        calories = bmr;
    }

    // Calculate protein intake based on goal
    let protein;
    switch (goal) {
      case 'loseWeight':
        protein = weightInKg * 1.5;
        calories -= 300; // Reduce calories by 300 for lose weight goal
        break;
      case 'maintainWeight':
        protein = weightInKg * 1.75;
        break;
      case 'gainWeight':
        protein = weightInKg * 2;
        calories += 300; // Increase calories by 300 for gain weight goal
        break;
      default:
        protein = weightInKg * 1.5; // Default to loseWeight goal
    }

    // Round results to the nearest whole number
    calories = Math.round(calories);
    protein = Math.round(protein);

    // Display results
    const results = {
      calories: calories,
      protein: protein,
      carbs: Math.round((calories - (protein * 4)) * 0.5 / 4), // Adjust for protein calories
      fat: Math.round((calories - (protein * 4)) * 0.3 / 9) // Adjust for protein calories
    };

    
    
    fetch("https://localhost:7265/api/Macro", {
        method: "PUT",
        headers: {
          "content-encoding": "gzip",
          "content-type": "application/json; charset=utf-8",
          Authorization: `Bearer ${token}`,
        },
        body: JSON.stringify(results, null, 2),
      }).then(function (response) {
        if (response.status == 200) {
          alert("macros successfully updated")
          window.location.replace("../pages/app.html")
        }
        if (response.status > 400) {
          alert("Something went wrong, please try again.")
        }
      });
  }
