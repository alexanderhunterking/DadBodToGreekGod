import React from 'react';
import { BrowserRouter as Router, Route, Link } from 'react-router-dom';
import './App.css'; // You can keep this file or replace it with your custom styles

const Home = () => (
  <div class="position-absolute top-50 start-50 translate-middle">
  <div class="container text-center text-light">
    <div class="row justify-content-center">
      <div class="col-8">
        <h2>Go From Dad Bod to Greek God!</h2>
        <br />
        <p class="text-secondary">
          "Dad Bod to Greek God" is your go-to app for transforming your
          physique and improving your health through easy meal planning.
          This user-friendly app provides personalized meal suggestions,
          simple recipes, and nutritional guidance, making it easy for
          anyone to go from a relaxed dad bod to a sculpted Greek god.
        </p>
      </div>
    </div>
    <br />
    <div class="row justify-content-center">
      <div class="col-xl-2 col-lg-3 col-md-4">
        <a type="button" class="btn btn-primary" href="./pages/signUp.html"
          >Sign Up</a
        >
      </div>
      <div class="col-xl-2 col-lg-3 col-md-4">
        <a type="button" class="btn btn-secondary" href="./pages/login.html"
          >Login</a
        >
      </div>
    </div>
  </div>
</div>
);

const SignUp = () => (
  <div class="position-absolute top-50 start-50 translate-middle">
      <div class="container text-light">
        <div class="row">
          <div class="col">
            <h3 class="text-center">Sign Up</h3>
            <br />
          </div>
        </div>
        <form id="signup" method="post">
          <div class="mb-3">
            <label for="emailSignUp" class="form-label text-light"
              >Email address</label
            >
            <input
              type="email"
              class="form-control bg-dark text-light"
              id="email"
              name="email"
              aria-describedby="emailHelp"
            />
          </div>
          <div class="mb-3">
            <label for="userNameSignUp" class="form-label text-light"
              >Username</label
            >
            <input
              type="username"
              class="form-control bg-dark text-light"
              id="userName"
              name="userName"
              aria-describedby="emailHelp"
            />
          </div>
          <div class="mb-3">
            <label for="passwordSignUp" class="form-label text-light"
              >Password</label
            >
            <input
              type="password"
              class="form-control bg-dark text-light"
              id="password"
              name="password"
            />
          </div>
          <div class="mb-3">
            <label for="confirmPasswordSignUp" class="form-label text-light"
              >Confirm Password</label
            >
            <input
              type="password"
              class="form-control bg-dark text-light"
              id="confirmPassword"
              name="confirmPassword"
            />
            <div id="emailHelp" class="form-text">
              We'll never share your information with anyone else.
            </div>
          </div>
          <button
            type="submit"
            value="submit"
            class="btn btn-primary position-relative top-0 start-50 translate-middle"
          >
            Sign Up
          </button>
        </form>
      </div>
      <div class="row text-center">
        <div class="col">
          <a class="px-3" id="loginButton" href="login.html"
            >Already have an account?</a
          >
        </div>
      </div>
    </div>
);

const Login = () => (
  <div class="position-absolute top-50 start-50 translate-middle">
      <div class="container text-light">
        <div class="row">
          <div class="col">
            <h3 class="text-center">Login</h3>
            <br />
          </div>
        </div>
        <form id="login" method="post">
          <div class="mb-3">
            <label for="userNameSignUp" class="form-label text-light"
              >Username</label
            >
            <input
              type="username"
              class="form-control bg-dark text-light"
              id="username"
              name="username"
              aria-describedby="emailHelp"
            />
          </div>
          <div class="mb-3">
            <label for="passwordSignUp" class="form-label text-light"
              >Password</label
            >
            <input
              type="password"
              class="form-control bg-dark text-light"
              id="password"
              name="password"
            />
          </div>
          <br />
          <button
            type="submit"
            value="submit"
            class="btn btn-primary position-relative top-0 start-50 translate-middle"
          >
            Login
          </button>
        </form>
      </div>
      <br />
      <div class="row text-center">
        <div class="col">
          <a class="px-3" href="signUp.html">Don't have an account?</a>
        </div>
      </div>
    </div>
);

const CreateNewMacro = () => (
  <div className="d-flex justify-content-center">
    <div className="p-2">
      {/* Your existing HTML content for the CreateNewMacro page */}
    </div>
  </div>
);

const App = () => (
  <Router>
    <Route path="/" exact component={Home} />
    <Route path="/signUp" component={SignUp} />
    <Route path="/login" component={Login} />
    <Route path="/createNewMacro" component={CreateNewMacro} />
  </Router>
);

export default App;
