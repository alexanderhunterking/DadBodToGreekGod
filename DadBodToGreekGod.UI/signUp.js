(function () {
  function toJSONString(form) {
    var obj = {};
    var elements = form.querySelectorAll("input");
    for (var i = 0; i < elements.length; ++i) {
      var element = elements[i];
      var name = element.name;
      var value = element.value;

      if (name) {
        obj[name] = value;
      }
    }

    return JSON.stringify(obj);
  }

  document.addEventListener("DOMContentLoaded", function () {
    var form = document.getElementById("signup");
    var output;
    form.addEventListener(
      "submit",
      async function (e) {
        e.preventDefault();
        var message = toJSONString(this);
        output = message;
        await fetch("https://localhost:7265/api/User/Register", {
          method: "POST",
          headers: {
            "content-encoding": "gzip",
            "content-type": "application/json; charset=utf-8",
          },
          body: output,
        })
          .then(function (response) {
            console.log(response);
            return response.status;
          })
          .then(function (status) {
            if (status == 200) {
              alert("User was registred!");
              document.getElementById("loginButton").click();
              newUserMacro();
            }
            if (status >= 400) {
              alert("An error occured. Please try again.");
            }
          });
      },
      false
    );
  });
})();

function newUserMacro(){
  
}