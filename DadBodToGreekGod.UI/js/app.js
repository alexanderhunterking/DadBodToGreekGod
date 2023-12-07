let token = localStorage.authToken;

if (token) {
  checkMeals();
}

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

if(localStorage.authToken){
    loginMacroInitialCreate();
    calendarInitialCreate();
};

function checkMeals() {
  fetch("https://localhost:7265/api/meals/user", {
    method: "GET",
    headers: {
      "Authorization": `Bearer ${token}`,
    },
  })
  .then(function (response) {
    console.log(response)
    return response.status;
  })
  .then(function (status){
    console.log(status)
    if (status === 404){
      document.getElementById("noMeals").innerHTML = '<br/> <p>Create some meals to get started!</p><a class="btn btn-primary" href="./meals.html">Create Your Meal Plan</a>' 
    } if (status === 200) {
      displayTodaysMeal();
    }
  })
}

function displayTodaysMeal(){
  
}

function loginMacroInitialCreate() {
  fetch("https://localhost:7265/api/Macro", {
    method: "POST",
    headers: {
      "content-encoding": "gzip",
      "content-type": "application/json; charset=utf-8",
      "Authorization": `Bearer ${token}`,
    },
    body: JSON.stringify({
      calories: 1,
      protein: 1,
      carbs: 1,
      fats: 1
    }),
  })
    .then(function (response) {
    
      if (response.status == 200) {
        newUser();
      }
      if (response.status == 400) {
        returningUser();
      }
    })
  };
  

function calendarInitialCreate() {
  fetch("https://localhost:7265/api/calendarweek", {
    method: "POST",
    headers: {
      "content-encoding": "gzip",
      "content-type": "application/json; charset=utf-8",
      "Authorization": `Bearer ${token}`,
    },
    body: JSON.stringify({
      shoppingDay: 1,
      cookingDay: 2,
          }),
  })
    .then(function (response) {
    
      if (response.status == 200) {
        console.log("yayyy")
      }
      if (response.status == 400) {
        console.log("ahhhh shucks")
      }
    })
  };
  
  function newUser(){
    window.location.replace("../pages/settings.html")
  };
  
  function returningUser(){

  };
