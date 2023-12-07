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

    fetch('https://localhost:7265/api/calendarweek', {
      headers: {
        'Authorization': `Bearer ${token}`
      }
    })
      .then(response => response.json())
      .then(data => {
        // Map day numbers to their corresponding IDs in the HTML
        const dayMappings = {
          1: '1',
          2: '2',
          3: '3',
          4: '4',
          5: '5',
          6: '6',
          7: '7'
        };

        // Iterate through the data and update the HTML
        data.forEach(entry => {
          const { shoppingDay, cookingDay } = entry;
          const dayIdShopping = dayMappings[shoppingDay];
          const dayIdCooking = dayMappings[cookingDay];

          // Update the specialDay paragraph element for Shopping Day
          const specialDayElementShopping = document.getElementById(dayIdShopping).querySelector('#specialDay');
          specialDayElementShopping.textContent = 'Shopping Day';

          // Update the specialDay paragraph element for Cooking Day
          const specialDayElementCooking = document.getElementById(dayIdCooking).querySelector('#specialDay');
          specialDayElementCooking.textContent = 'Cooking Day';
        });
      })
      .catch(error => console.error('Error fetching data:', error));
  });