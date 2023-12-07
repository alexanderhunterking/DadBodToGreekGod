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

  document.addEventListener("DOMContentLoaded", function() {
    // Attach an event listener to the "Submit" button
    document.getElementById('submit').addEventListener('click', function() {
      submitForm();
    });
  });

  function submitForm() {
    // Get selected values from the dropdowns
    const shoppingDayValue = document.getElementById('shoppingDay').value;
    const cookingDayValue = document.getElementById('cookingDay').value;

    // Construct the request body
    const requestBody = {
      shoppingDay: parseInt(shoppingDayValue),
      cookingDay: parseInt(cookingDayValue)
    };


    // Make a PUT request to the API with Authorization header
    fetch('https://localhost:7265/api/calendarweek', {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${token}`
      },
      body: JSON.stringify(requestBody)
    })
    .then(response => {
      if (!response.ok) {
        throw new Error(`HTTP error! Status: ${response.status}`);
      }
      console.log('PUT request successful');
    })
    .catch(error => console.error('Error submitting form:', error));
  }
