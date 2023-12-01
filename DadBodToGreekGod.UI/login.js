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
      var form = document.getElementById("login");
      var output;
      form.addEventListener(
        "submit",
        async function (e) {
          e.preventDefault();
          var message = toJSONString(this);
          output = message;
          console.log(output);
          await fetch("https://localhost:7265/api/Token/", {
            method: "POST",
            headers: {
              "content-encoding": "gzip",
              "content-type": "application/json; charset=utf-8",
            },
            body: output,
          })
            .then(function (response) {
                if (response.status = 200) {
                return response.json();
                } else {
                    alert("An error occured. Please try again.");
                }
            })
            .then(function (json) {
              token = json.token;
              localStorage.setItem("authToken", token);
              
              return token;
            });
        },
        false
      );
    });
  })();