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

if(localStorage.authToken){
    loginMacroInitialCreate();
};



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
  
  function newUser(){
    alert("New user has succesfully logged in!")
    window.location.replace("../pages/createNewMacro.html")
  };
  
  function returningUser(){

  };